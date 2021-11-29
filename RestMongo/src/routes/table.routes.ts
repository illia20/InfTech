import express from "express";
import tableController from "../app/table/table.controller";

const router = express.Router();

router.get("/:dbName/:tableName", tableController.getTable);
router.get(
  "/car/:dbName/:tableName1/:tableName2",
  tableController.cartesian
);
router.post("/:dbName", tableController.createTable);
router.delete("/:dbName/:tableName", tableController.deleteTable);

export default router;
