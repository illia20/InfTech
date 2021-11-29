import express from "express";
import tableController from "../app/table/table.controller";

const router = express.Router();

router.get("/:dbName/:tableName", tableController.getTable);
router.post("/:dbName", tableController.createTable);
router.delete("/delete/:dbName/:tableName", tableController.deleteTable);

export default router;
