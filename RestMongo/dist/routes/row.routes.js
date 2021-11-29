"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const express_1 = __importDefault(require("express"));
const row_controller_1 = __importDefault(require("../app/row/row.controller"));
const router = express_1.default.Router();
router.post("/:dbName/:tableName/", row_controller_1.default.createRow);
router.post("/add-value/:dbName/:tableName/:columnIndex/:rowIndex", row_controller_1.default.addValue);
router.delete("/:dbName/:tableName/:rowIndex", row_controller_1.default.deleteRow);
exports.default = router;
