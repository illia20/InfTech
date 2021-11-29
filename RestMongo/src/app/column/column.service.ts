import { Column } from "../../models/Column";
import { DB } from "../../models/DB";
import DBSchema from "../../models/DBSchema";
import { writeFile } from "../../utils/FileManager";
import dbService from "../db/db.service";

class ColumService {
  public async createColumn(
    dbName: string,
    tableName: string,
    column: { name: string; typename: string }
  ): Promise<Column | null | undefined> {
    const db = await dbService.getDBAndTable(dbName, tableName);
    if (!db) return null;
    const { tableIndex } = db;

    const newColumn = new Column(column.name, column.typename);

    await DBSchema.updateOne(
      { "tables.name": tableName },
      { $push: { [`tables.${tableIndex}.columnsList`]: newColumn } }
    );
    return newColumn;
  }

  public async deleteColumn(
    dbName: string,
    tableName: string,
    columnName: string
  ): Promise<boolean> {
    const db = await dbService.getDBAndTable(dbName, tableName);
    if (!db) return false;
    const { tableIndex } = db;
    const dataBase: any = await DBSchema.findOne({ name: dbName });
    const columnIndex = (dataBase as DB).tables[
      tableIndex
    ].columnsList.findIndex((column) => column.name === columnName);

    if (columnIndex < 0) return false;

    dataBase.tables[tableIndex].columnsList.splice(columnIndex, 1);
    await DBSchema.updateOne(
      { "tables.name": tableName },
      {
        $pull: {
          [`tables.${tableIndex}.columnsList.${columnIndex}`]: columnName,
        },
      }
    );

    return true;
  }
}

export default new ColumService();
