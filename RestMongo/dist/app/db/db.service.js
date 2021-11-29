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
class DBService {
    getDB(name) {
        return __awaiter(this, void 0, void 0, function* () {
            return DBSchema_1.default.findOne({ name });
        });
    }
    postDB(name) {
        return __awaiter(this, void 0, void 0, function* () {
            const db = new DBSchema_1.default({ name, tables: [] });
            yield db.save();
            return db;
        });
    }
    validateDB(name) {
        return __awaiter(this, void 0, void 0, function* () {
            if (!name)
                return "Name can't be empty";
            const dataBase = yield this.getDB(name);
            if (dataBase)
                return "Db with name already exists";
            return "";
        });
    }
    deleteDB(name) {
        return __awaiter(this, void 0, void 0, function* () {
            const db = yield DBSchema_1.default.find({ name });
            if (!db)
                return false;
            yield DBSchema_1.default.deleteOne({ name });
            return true;
        });
    }
    getDBAndTable(dbName, tableName) {
        return __awaiter(this, void 0, void 0, function* () {
            const databases = yield DBSchema_1.default.find({ notInSchema: 1 });
            const index = databases.findIndex((db) => db.name === dbName);
            if (index < 0)
                return null;
            const tableIndex = databases[index].tables.findIndex((table) => table.name === tableName);
            if (tableIndex < 0)
                return null;
            return { databases, index, tableIndex };
        });
    }
}
exports.default = new DBService();
