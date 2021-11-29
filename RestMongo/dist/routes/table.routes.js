"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const express_1 = __importDefault(require("express"));
const table_controller_1 = __importDefault(require("../app/table/table.controller"));
const router = express_1.default.Router();
router.get("/:dbName/:tableName", table_controller_1.default.getTable);
router.get("/inner-join/:dbName/:tableName1/:columnName1/:tableName2/:columnName2", table_controller_1.default.innerJoin);
router.post("/:dbName", table_controller_1.default.createTable);
router.delete("/:dbName/:tableName", table_controller_1.default.deleteTable);
exports.default = router;
