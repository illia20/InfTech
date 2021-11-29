import { DB } from "../../models/DB";
import { Table } from "../../models/Table";
import { Row } from "../../models/Row";
import { Column } from "../../models/Column";
import { readFile, writeDB, writeFile } from "../../utils/FileManager";

class DBService {
  public getDB(name: string): DB | undefined {
    const dataBases = readFile();
    return dataBases.find((db) => db.name === name);
  }

  public postDB(name: string): DB {
    const db = new DB(name, []);
    writeDB(db);
    return db;
  }

  public validateDB(name: string): string {
    if (!name) return "Name can't be empty";

    const dataBase = this.getDB(name);
    if (dataBase) return "Db with name already exists";

    return "";
  }

  public deleteDB(name: string): boolean {
    const data = readFile();
    const index = data.findIndex((el) => el.name === name);
    if (index < 0) return false;
    data.splice(index, 1);
    writeFile(data);

    return true;
  }

  public getDBAndTable(dbName: string, tableName: string) {
    const databases = readFile();

    const index = databases.findIndex((db) => db.name === dbName);
    if (index < 0) return null;

    const tableIndex = databases[index].tables.findIndex(
      (table) => table.name === tableName
    );

    if (tableIndex < 0) return null;

    return { databases, index, tableIndex };
  }

  public cartesianDB(dbName: string, t1: string, t2: string){
    const db = this.getDB(dbName);
    if (!db) return undefined;
    const table1 = db.tables.find((table) => table.name === t1);
    const table2 = db.tables.find((table) => table.name === t2);
    if (!table1 || !table2) return undefined;
    const restable = new Table("Cartesian");
    const cols = table1.columnsList.concat(table2.columnsList);
    restable.columnsList = cols;
    for(var i = 0; i < table1.rowsList.length; i++){
      for(var j = 0; j < table2.rowsList.length; j++){
        var row = new Row();
        row.values = table1.rowsList[i].values.concat(table2.rowsList[j].values);
        restable.rowsList.push(row);
      }
    }

    return restable;
  }
}

export default new DBService();
