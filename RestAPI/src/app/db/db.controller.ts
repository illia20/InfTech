import { Request, Response } from "express";
import dbService from "./db.service";

class DBController {
  public getDB(req: Request, res: Response) {
    const { name } = req.params;
    const db = dbService.getDB(name);
    if (db) return res.status(200).json(db);
    else return res.status(404).send("DB not found");
  }

  public postDB(req: Request, res: Response) {
    const { name } = req.body;

    const error = dbService.validateDB(name);
    if (error) return res.status(400).send(error);

    const db = dbService.postDB(name);

    res.status(201).json({ message: "Db created successfully", db });
  }

  public deleteDB(req: Request, res: Response) {
    const { name } = req.params;
    dbService.deleteDB(name)
      ? res.status(200).json({ message: "DB deleted successfully" })
      : res.status(400).json({ message: "Can't delete DB" });
  }

  public cartesian(req: Request, res: Response){
    const {name, t1, t2} = req.params;
    const t = dbService.cartesianDB(name, t1, t2);
    return res.status(200).json(t);
  }
}
export default new DBController();
