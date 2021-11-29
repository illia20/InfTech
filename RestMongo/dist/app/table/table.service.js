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
const DBSchema_1 = __importDefault(require("../../models/DBSchema"));
const Row_1 = require("../../models/Row");
const Table_1 = require("../../models/Table");
class TableService {
    getTable(dbName, tableName) {
        return __awaiter(this, void 0, void 0, function* () {
            let db = (yield DBSchema_1.default.find({ name: dbName }))[0];
            if (!db)
                return undefined;
            const table = db.tables.find((table) => table.name === tableName);
            return table;
        });
    }
    createTable(dbName, tableName) {
        return __awaiter(this, void 0, void 0, function* () {
            const table = new Table_1.Table(tableName);
            yield DBSchema_1.default.findOneAndUpdate({ name: dbName }, {
                $push: {
                    tables: table,
                },
            });
            return table;
        });
    }
    validateTable(dbName, tableName) {
        return __awaiter(this, void 0, void 0, function* () {
            if (!dbName)
                return "Db name not provided";
            if (!tableName)
                return "Table name can't be empty";
            const table = yield this.getTable(dbName, tableName);
            if (table)
                return "Table with name already exists";
            return "";
        });
    }
    deleteTable(dbName, tableName) {
        return __awaiter(this, void 0, void 0, function* () {
            yield DBSchema_1.default.findOneAndUpdate({ name: dbName }, {
                $pull: {
                    tables: { name: tableName },
                },
            });
            return true;
        });
    }
    innerJoin(dbName, tableName1, columnName1, tableName2, columnName2) {
        return __awaiter(this, void 0, void 0, function* () {
            const table1 = yield this.getTable(dbName, tableName1);
            const table2 = yield this.getTable(dbName, tableName2);
            if (!table1 || !table2)
                return null;
            const colIndex1 = table1.columnsList.findIndex((column) => column.name === columnName1);
            const colIndex2 = table2.columnsList.findIndex((column) => column.name === columnName2);
            if (colIndex1 < 0 || colIndex2 < 0)
                return null;
            const resTable = new Table_1.Table("Result");
            resTable.columnsList = [...table1.columnsList, ...table2.columnsList];
            for (let i = 0; i < table1.rowsList.length; ++i) {
                for (let j = 0; j < table2.rowsList.length; ++j) {
                    if (table1.rowsList[i].values[colIndex1] ==
                        table2.rowsList[j].values[colIndex2]) {
                        let addedRow = new Row_1.Row();
                        addedRow.values = [
                            ...table1.rowsList[i].values,
                            ...table2.rowsList[j].values,
                        ];
                        resTable.rowsList.push(addedRow);
                    }
                }
            }
            return resTable;
        });
    }
}
exports.default = new TableService();
