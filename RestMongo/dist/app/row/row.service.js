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
const Row_1 = require("../../models/Row");
const db_service_1 = __importDefault(require("../db/db.service"));
const Column_1 = require("../../models/Column");
const DBSchema_1 = __importDefault(require("../../models/DBSchema"));
class RowService {
    createRow(dbName, tableName) {
        return __awaiter(this, void 0, void 0, function* () {
            const db = yield db_service_1.default.getDBAndTable(dbName, tableName);
            if (!db)
                return false;
            const { tableIndex } = db;
            const dataBase = yield DBSchema_1.default.findOne({ name: dbName });
            const columnCount = dataBase.tables[tableIndex].columnsList.length;
            const row = new Row_1.Row();
            row.values = new Array(columnCount);
            row.values.fill("");
            yield DBSchema_1.default.updateOne({ "tables.name": tableName }, { $push: { [`tables.${tableIndex}.rowsList`]: row } });
            return true;
        });
    }
    deleteRow(dbName, tableName, rowIndex) {
        return __awaiter(this, void 0, void 0, function* () {
            const db = yield db_service_1.default.getDBAndTable(dbName, tableName);
            if (!db)
                return false;
            const { databases, index, tableIndex } = db;
            yield DBSchema_1.default.updateOne({ "tables.name": tableName }, {
                $pull: {
                    [`tables.${tableIndex}.rowsList.${rowIndex}`]: {},
                },
            });
            return true;
        });
    }
    addValue(dbName, tableName, columnIndex, rowIndex, value) {
        return __awaiter(this, void 0, void 0, function* () {
            const db = yield db_service_1.default.getDBAndTable(dbName, tableName);
            if (!db)
                return false;
            const { databases, index, tableIndex } = db;
            const dataBase = yield DBSchema_1.default.findOne({ name: dbName });
            const column = dataBase.tables[tableIndex].columnsList[columnIndex];
            const customColumn = new Column_1.Column(column.name, column.typename);
            const isValueRight = customColumn.type.validate(value);
            if (!isValueRight)
                return false;
            yield DBSchema_1.default.updateOne({ "tables.name": tableName }, {
                $set: {
                    [`tables.${tableIndex}.rowsList.${rowIndex}.values.${columnIndex}`]: value,
                },
            });
            return true;
        });
    }
}
exports.default = new RowService();
