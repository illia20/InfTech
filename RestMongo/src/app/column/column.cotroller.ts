import { Request, Response } from "express";
import columnService from "./column.service";

class ColumnController {
  public async createColumn(req: Request, res: Response) {
    const { dbName, tableName } = req.params;
    const columnBody = req.body;

    const column = await columnService.createColumn(dbName, tableName, columnBody);
    if (!column) return res.status(400).send("Can't create column");

    res.status(201).json({ message: "Column created successfully", column });
  }

  public async deleteColumn(req: Request, res: Response) {
    const { dbName, tableName, columnName } = req.params;
    (await columnService.deleteColumn(dbName, tableName, columnName))
      ? res.status(200).json({ message: "Column deleted successfully" })
      : res.status(400).json({ message: "Can't delete column" });
  }
}

export default new ColumnController();
