"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const row_service_1 = __importDefault(require("./row.service"));
class RowController {
    createRow(req, res) {
        return __awaiter(this, void 0, void 0, function* () {
            const { dbName, tableName } = req.params;
            const row = yield row_service_1.default.createRow(dbName, tableName);
            if (!row)
                return res.status(400).send("Can't create row");
            res.status(201).json({ message: "Row created successfully" });
        });
    }
    deleteRow(req, res) {
        return __awaiter(this, void 0, void 0, function* () {
            const { dbName, tableName, rowIndex } = req.params;
            (yield row_service_1.default.deleteRow(dbName, tableName, Number(rowIndex)))
                ? res.status(200).json({ message: "Row deleted successfully" })
                : res.status(400).json({ message: "Can't delete row" });
        });
    }
    addValue(req, res) {
        return __awaiter(this, void 0, void 0, function* () {
            const { dbName, tableName, columnIndex, rowIndex } = req.params;
            const { value } = req.body;
            (yield row_service_1.default.addValue(dbName, tableName, Number(columnIndex), Number(rowIndex), value))
                ? res.status(200).json({ message: "Value added" })
                : res.status(400).json({ message: "Validation Error" });
        });
    }
}
exports.default = new RowController();
