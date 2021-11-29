import { DB } from "../../models/DB";
import DBSchema from "../../models/DBSchema";
import { Row } from "../../models/Row";
import { Table } from "../../models/Table";
import { readFile, writeFile } from "../../utils/FileManager";
import dbService from "../db/db.service";

class TableService {
  public async getTable(
    dbName: string,
    tableName: string
  ): Promise<Table | undefined> {
    let db = (await DBSchema.find({ name: dbName }))[0] as DB;
    if (!db) return undefined;
    const table = db.tables.find((table) => table.name === tableName);
    return table;
  }

  public async createTable(
    dbName: string,
    tableName: string
  ): Promise<Table | null> {
    const table = new Table(tableName);
    await DBSchema.findOneAndUpdate(
      { name: dbName },
      {
        $push: {
          tables: table,
        },
      }
    );
    return table;
  }

  public async validateTable(
    dbName: string,
    tableName: string
  ): Promise<string> {
    if (!dbName) return "Db name not provided";
    if (!tableName) return "Table name can't be empty";
    const table = await this.getTable(dbName, tableName);
    if (table) return "Table with name already exists";

    return "";
  }

  public async deleteTable(dbName: string, tableName: string): Promise<boolean> {
    await DBSchema.findOneAndUpdate(
      { name: dbName },
      {
        $pull: {
          tables: { name: tableName },
        },
      }
    );
    return true;
  }

  public async cartesian(
    dbName: string,
    tableName1: string,
    tableName2: string
  ): Promise<Table | null> {
    const table1 = await this.getTable(dbName, tableName1);
    const table2 = await this.getTable(dbName, tableName2);
    if (!table1 || !table2) return null;
    const resTable = new Table("Result");

    resTable.columnsList = [...table1.columnsList, ...table2.columnsList];
    for (let i = 0; i < table1.rowsList.length; ++i) {
      for (let j = 0; j < table2.rowsList.length; ++j) {
          let addedRow = new Row();
          addedRow.values = [
            ...table1.rowsList[i].values,
            ...table2.rowsList[j].values,
          ];
          resTable.rowsList.push(addedRow);
      }
    }
    return resTable;
  }
}

export default new TableService();
