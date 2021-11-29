import express from "express";
import dbController from "../app/db/db.controller";

const router = express.Router();

router.get("/:name", dbController.getDB);
router.post("/", dbController.postDB);
router.delete("/:name", dbController.deleteDB);

export default router;
