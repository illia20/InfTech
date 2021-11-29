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
const Column_1 = require("../../models/Column");
const DBSchema_1 = __importDefault(require("../../models/DBSchema"));
const db_service_1 = __importDefault(require("../db/db.service"));
class ColumService {
    createColumn(dbName, tableName, column) {
        return __awaiter(this, void 0, void 0, function* () {
            const db = yield db_service_1.default.getDBAndTable(dbName, tableName);
            if (!db)
                return null;
            const { tableIndex } = db;
            const newColumn = new Column_1.Column(column.name, column.typename);
            yield DBSchema_1.default.updateOne({ "tables.name": tableName }, { $push: { [`tables.${tableIndex}.columnsList`]: newColumn } });
            return newColumn;
        });
    }
    deleteColumn(dbName, tableName, columnName) {
        return __awaiter(this, void 0, void 0, function* () {
            const db = yield db_service_1.default.getDBAndTable(dbName, tableName);
            if (!db)
                return false;
            const { tableIndex } = db;
            const dataBase = yield DBSchema_1.default.findOne({ name: dbName });
            const columnIndex = dataBase.tables[tableIndex].columnsList.findIndex((column) => column.name === columnName);
            if (columnIndex < 0)
                return false;
            dataBase.tables[tableIndex].columnsList.splice(columnIndex, 1);
            yield DBSchema_1.default.updateOne({ "tables.name": tableName }, {
                $pull: {
                    [`tables.${tableIndex}.columnsList.${columnIndex}`]: columnName,
                },
            });
            return true;
        });
    }
}
exports.default = new ColumService();
