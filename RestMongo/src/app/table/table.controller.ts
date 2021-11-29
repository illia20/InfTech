import { Request, Response } from "express";
import tableService from "./table.service";

class TableController {
  public async getTable(req: Request, res: Response) {
    const { dbName, tableName } = req.params;

    const table = await tableService.getTable(dbName, tableName);

    return table
      ? res.status(200).json(table)
      : res.status(404).send({ message: "Can't find table" });
  }

  public async createTable(req: Request, res: Response) {
    const { dbName } = req.params;
    const { name } = req.body;

    const error = await tableService.validateTable(dbName, name);
    if (error) return res.status(400).send(error);

    const table = await tableService.createTable(dbName, name);
    if (!table) return res.status(400).send("Can't create table");

    res.status(201).json({ message: "Table created successfully", table });
  }

  public async deleteTable(req: Request, res: Response) {
    const { dbName, tableName } = req.params;
    (await tableService.deleteTable(dbName, tableName))
      ? res.status(200).json({ message: "Table deleted successfully" })
      : res.status(400).json({ message: "Can't delete table" });
  }

  public async cartesian(req: Request, res: Response) {
    const { dbName, tableName1, tableName2 } =
      req.params;
    const table = await tableService.cartesian(
      dbName,
      tableName1,
      tableName2
    );

    table
      ? res.status(200).json(table)
      : res.status(400).json({ message: "Something went wrong" });
  }
}

export default new TableController();
