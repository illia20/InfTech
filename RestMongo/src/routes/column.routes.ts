import express from "express";
import columnController from "../app/column/column.cotroller";

const router = express.Router();

router.post("/:dbName/:tableName/", columnController.createColumn);
router.delete(
  "/:dbName/:tableName/:columnName",
  columnController.deleteColumn
);

export default router;
