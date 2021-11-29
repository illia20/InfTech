"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const express_1 = __importDefault(require("express"));
const column_cotroller_1 = __importDefault(require("../app/column/column.cotroller"));
const router = express_1.default.Router();
router.post("/:dbName/:tableName/", column_cotroller_1.default.createColumn);
router.delete("/:dbName/:tableName/:columnName", column_cotroller_1.default.deleteColumn);
exports.default = router;
