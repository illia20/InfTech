import express from "express";
import rowController from "../app/row/row.controller";

const router = express.Router();

router.post("/:dbName/:tableName/", rowController.createRow);
router.post(
  "/add-value/:dbName/:tableName/:columnIndex/:rowIndex",
  rowController.addValue
);
router.delete("/:dbName/:tableName/:rowIndex", rowController.deleteRow);

export default router;
