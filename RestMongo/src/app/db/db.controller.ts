import { Request, Response } from "express";
import dbService from "./db.service";

class DBController {
  public async getDB(req: Request, res: Response) {
    const { name } = req.params;
    const db = await dbService.getDB(name);
    if (db) return res.status(200).json(db);
    else return res.status(404).send("DB not found");
  }

  public async postDB(req: Request, res: Response) {
    const { name } = req.body;

    const error = await dbService.validateDB(name);
    if (error) return res.status(400).send(error);

    const db = await dbService.postDB(name);

    res.status(201).json({ message: "Db created successfully", db });
  }

  public async deleteDB(req: Request, res: Response) {
    const { name } = req.params;
    (await dbService.deleteDB(name))
      ? res.status(200).json({ message: "DB deleted successfully" })
      : res.status(400).json({ message: "Can't delete DB" });
  }
}
export default new DBController();
