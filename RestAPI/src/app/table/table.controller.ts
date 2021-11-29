import { Request, Response } from "express";
import tableService from "./table.service";

class TableController {
  public getTable(req: Request, res: Response) {
    const { dbName, tableName } = req.params;

    const table = tableService.getTable(dbName, tableName);

    return table
      ? res.status(200).json(table)
      : res.status(404).send({ message: "Can't find table" });
  }

  public createTable(req: Request, res: Response) {
    const { dbName } = req.params;
    const { name } = req.body;

    const error = tableService.validateTable(dbName, name);
    if (error) return res.status(400).send(error);

    const table = tableService.createTable(dbName, name);
    if (!table) return res.status(400).send("Can't create table");

    res.status(201).json({ message: "Table created successfully", table });
  }

  public deleteTable(req: Request, res: Response) {
    const { dbName, tableName } = req.params;
    tableService.deleteTable(dbName, tableName)
      ? res.status(200).json({ message: "Table deleted successfully" })
      : res.status(400).json({ message: "Can't delete table" });
  }
}

export default new TableController();
