import { Column } from "../../models/Column";
import { Row } from "../../models/Row";
import { readFile, writeFile } from "../../utils/FileManager";
import dbService from "../db/db.service";

class ColumService {
  public createColumn(
    dbName: string,
    tableName: string,
    column: { name: string; typename: string }
  ): Column | null {
    const newColumn = new Column(column.name, column.typename);

    const db = dbService.getDBAndTable(dbName, tableName);
    if (!db) return null;
    const { databases, index, tableIndex } = db;

    databases[index].tables[tableIndex].columnsList.push(newColumn);
    writeFile(databases);

    return newColumn;
  }

  public deleteColumn(
    dbName: string,
    tableName: string,
    columnName: string
  ): boolean {
    const db = dbService.getDBAndTable(dbName, tableName);
    if (!db) return false;
    const { databases, index, tableIndex } = db;

    const columnIndex = databases[index].tables[
      tableIndex
    ].columnsList.findIndex((column) => column.name === columnName);

    if (columnIndex < 0) return false;

    databases[index].tables[tableIndex].columnsList.splice(columnIndex, 1);

    writeFile(databases);

    return true;
  }
}

export default new ColumService();
