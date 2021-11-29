import { Row } from "../../models/Row";
import { readFile, writeFile } from "../../utils/FileManager";
import dbService from "../db/db.service";
import { Column } from "../../models/Column";
import DBSchema from "../../models/DBSchema";

class RowService {
  public async createRow(dbName: string, tableName: string) {
    const db = await dbService.getDBAndTable(dbName, tableName);
    if (!db) return false;
    const { tableIndex } = db;
    const dataBase: any = await DBSchema.findOne({ name: dbName });
    const columnCount = dataBase.tables[tableIndex].columnsList.length;
    const row = new Row();
    row.values = new Array(columnCount);
    row.values.fill("");

    await DBSchema.updateOne(
      { "tables.name": tableName },
      { $push: { [`tables.${tableIndex}.rowsList`]: row } }
    );

    return true;
  }

  public async deleteRow(
    dbName: string,
    tableName: string,
    rowIndex: number
  ): Promise<boolean> {
    const db = await dbService.getDBAndTable(dbName, tableName);
    if (!db) return false;
    const { databases, index, tableIndex } = db;

    await DBSchema.updateOne(
      { "tables.name": tableName },
      {
        $pull: {
          [`tables.${tableIndex}.rowsList.${rowIndex}`]: {},
        },
      }
    );
    return true;
  }

  public async addValue(
    dbName: string,
    tableName: string,
    columnIndex: number,
    rowIndex: number,
    value: string
  ) {
    const db = await dbService.getDBAndTable(dbName, tableName);
    if (!db) return false;
    const { databases, index, tableIndex } = db;

    const dataBase: any = await DBSchema.findOne({ name: dbName });
    const column = dataBase.tables[tableIndex].columnsList[columnIndex];
    const customColumn = new Column(column.name, column.typename);

    const isValueRight = customColumn.type.validate(value);
    if (!isValueRight) return false;

    await DBSchema.updateOne(
      { "tables.name": tableName },
      {
        $set: {
          [`tables.${tableIndex}.rowsList.${rowIndex}.values.${columnIndex}`]: value,
        },
      }
    );

    return true;
  }
}

export default new RowService();
