import { Row } from "../../models/Row";
import { readFile, writeFile } from "../../utils/FileManager";
import dbService from "../db/db.service";
import { Column } from "../../models/Column";

class RowService {
  public createRow(dbName: string, tableName: string) {
    const db = dbService.getDBAndTable(dbName, tableName);
    if (!db) return false;
    const { databases, index, tableIndex } = db;

    const columnCount = databases[index].tables[tableIndex].columnsList.length;
    const row = new Row();
    row.values = new Array(columnCount);
    row.values.fill("");
    databases[index].tables[tableIndex].rowsList.push(row);

    writeFile(databases);

    return true;
  }

  public deleteRow(
    dbName: string,
    tableName: string,
    rowIndex: number
  ): boolean {
    const db = dbService.getDBAndTable(dbName, tableName);
    if (!db) return false;
    const { databases, index, tableIndex } = db;

    databases[index].tables[tableIndex].rowsList.splice(rowIndex, 1);

    writeFile(databases);

    return true;
  }

  public addValue(
    dbName: string,
    tableName: string,
    columnIndex: number,
    rowIndex: number,
    value: string
  ) {
    const db = dbService.getDBAndTable(dbName, tableName);
    if (!db) return false;
    const { databases, index, tableIndex } = db;

    const column = databases[index].tables[tableIndex].columnsList[columnIndex];
    const customColumn = new Column(column.name, column.typename);

    const isValueRight = customColumn.type.validate(value);
    if (!isValueRight) return false;
    databases[index].tables[tableIndex].rowsList[rowIndex].values[columnIndex] =
      value;

    writeFile(databases);

    return true;
  }
}

export default new RowService();
