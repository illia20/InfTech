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
const column_service_1 = __importDefault(require("./column.service"));
class ColumnController {
    createColumn(req, res) {
        return __awaiter(this, void 0, void 0, function* () {
            const { dbName, tableName } = req.params;
            const columnBody = req.body;
            const column = yield column_service_1.default.createColumn(dbName, tableName, columnBody);
            if (!column)
                return res.status(400).send("Can't create column");
            res.status(201).json({ message: "Column created successfully", column });
        });
    }
    deleteColumn(req, res) {
        return __awaiter(this, void 0, void 0, function* () {
            const { dbName, tableName, columnName } = req.params;
            (yield column_service_1.default.deleteColumn(dbName, tableName, columnName))
                ? res.status(200).json({ message: "Column deleted successfully" })
                : res.status(400).json({ message: "Can't delete column" });
        });
    }
}
exports.default = new ColumnController();
