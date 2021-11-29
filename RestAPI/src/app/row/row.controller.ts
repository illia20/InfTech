import { Request, Response } from "express";
import rowService from "./row.service";

class RowController {
  public createRow(req: Request, res: Response) {
    const { dbName, tableName } = req.params;

    const row = rowService.createRow(dbName, tableName);
    if (!row) return res.status(400).send("Can't create row");

    res.status(201).json({ message: "Row created successfully" });
  }

  public deleteRow(req: Request, res: Response) {
    const { dbName, tableName, rowIndex } = req.params;
    rowService.deleteRow(dbName, tableName, Number(rowIndex))
      ? res.status(200).json({ message: "Row deleted successfully" })
      : res.status(400).json({ message: "Can't delete row" });
  }

  public addValue(req: Request, res: Response) {
    const { dbName, tableName, columnIndex, rowIndex } = req.params;
    const { value } = req.body;

    rowService.addValue(
      dbName,
      tableName,
      Number(columnIndex),
      Number(rowIndex),
      value
    )
      ? res.status(200).json({ message: "Value added" })
      : res.status(400).json({ message: "Validation Error" });
  }
}

export default new RowController();
