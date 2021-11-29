import { Table } from "../../models/Table";
import { readFile, writeFile } from "../../utils/FileManager";
import dbService from "../db/db.service";

class TableService {
  public getTable(dbName: string, tableName: string): Table | undefined {
    const db = dbService.getDB(dbName);
    if (!db) return undefined;

    const table = db.tables.find((table) => table.name === tableName);
    return table;
  }

  public createTable(dbName: string, tableName: string): Table | null {
    const table = new Table(tableName);
    const databases = readFile();

    const index = databases.findIndex((db) => db.name === dbName);
    if (index < 0) return null;

    databases[index].tables.push(table);

    writeFile(databases);

    return table;
  }

  public validateTable(dbName: string, tableName: string): string {
    if (!dbName) return "Db name not provided";
    if (!tableName) return "Table name can't be empty";
    const table = this.getTable(dbName, tableName);
    if (table) return "Table with name already exists";

    return "";
  }

  public deleteTable(dbName: string, tableName: string): boolean {
    const databases = readFile();

    const index = databases.findIndex((db) => db.name === dbName);
    if (index < 0) return false;

    const tableIndex = databases[index].tables.findIndex(
      (table) => table.name === tableName
    );
    
    if (tableIndex < 0) return false;

    databases[index].tables.splice(tableIndex, 1);

    writeFile(databases);

    return true;
  }
}

export default new TableService();
