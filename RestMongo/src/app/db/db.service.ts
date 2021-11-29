import { DB } from "../../models/DB";
import { readFile, writeDB, writeFile } from "../../utils/FileManager";
import DBSchema from "../../models/DBSchema";

class DBService {
  public async getDB(name: string): Promise<DB | undefined> {
    return DBSchema.findOne({ name });
  }

  public async postDB(name: string): Promise<DB> {
    const db = new DBSchema({ name, tables: [] });
    await db.save();
    return db;
  }

  public async validateDB(name: string): Promise<string> {
    if (!name) return "Name can't be empty";

    const dataBase = await this.getDB(name);
    if (dataBase) return "Db with name already exists";

    return "";
  }

  public async deleteDB(name: string): Promise<boolean> {
    const db = await DBSchema.find({ name });
    if (!db) return false;
    await DBSchema.deleteOne({ name });
    return true;
  }

  public async getDBAndTable(dbName: string, tableName: string) {
    const databases: DB[] = await DBSchema.find({ notInSchema: 1 });
    const index = databases.findIndex((db) => db.name === dbName);
    if (index < 0) return null;
    const tableIndex = databases[index].tables.findIndex(
      (table) => table.name === tableName
    );
    if (tableIndex < 0) return null;

    return { databases, index, tableIndex };
  }
}

export default new DBService();
