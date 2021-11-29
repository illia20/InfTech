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
const table_service_1 = __importDefault(require("./table.service"));
class TableController {
    getTable(req, res) {
        return __awaiter(this, void 0, void 0, function* () {
            const { dbName, tableName } = req.params;
            const table = yield table_service_1.default.getTable(dbName, tableName);
            return table
                ? res.status(200).json(table)
                : res.status(404).send({ message: "Can't find table" });
        });
    }
    createTable(req, res) {
        return __awaiter(this, void 0, void 0, function* () {
            const { dbName } = req.params;
            const { name } = req.body;
            const error = yield table_service_1.default.validateTable(dbName, name);
            if (error)
                return res.status(400).send(error);
            const table = yield table_service_1.default.createTable(dbName, name);
            if (!table)
                return res.status(400).send("Can't create table");
            res.status(201).json({ message: "Table created successfully", table });
        });
    }
    deleteTable(req, res) {
        return __awaiter(this, void 0, void 0, function* () {
            const { dbName, tableName } = req.params;
            (yield table_service_1.default.deleteTable(dbName, tableName))
                ? res.status(200).json({ message: "Table deleted successfully" })
                : res.status(400).json({ message: "Can't delete table" });
        });
    }
    innerJoin(req, res) {
        return __awaiter(this, void 0, void 0, function* () {
            const { dbName, tableName1, columnName1, tableName2, columnName2 } = req.params;
            const table = yield table_service_1.default.innerJoin(dbName, tableName1, columnName1, tableName2, columnName2);
            table
                ? res.status(200).json(table)
                : res.status(400).json({ message: "Something went wrong" });
        });
    }
}
exports.default = new TableController();
