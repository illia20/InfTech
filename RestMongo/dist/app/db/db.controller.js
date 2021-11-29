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
const db_service_1 = __importDefault(require("./db.service"));
class DBController {
    getDB(req, res) {
        return __awaiter(this, void 0, void 0, function* () {
            const { name } = req.params;
            const db = yield db_service_1.default.getDB(name);
            if (db)
                return res.status(200).json(db);
            else
                return res.status(404).send("DB not found");
        });
    }
    postDB(req, res) {
        return __awaiter(this, void 0, void 0, function* () {
            const { name } = req.body;
            const error = yield db_service_1.default.validateDB(name);
            if (error)
                return res.status(400).send(error);
            const db = yield db_service_1.default.postDB(name);
            res.status(201).json({ message: "Db created successfully", db });
        });
    }
    deleteDB(req, res) {
        return __awaiter(this, void 0, void 0, function* () {
            const { name } = req.params;
            (yield db_service_1.default.deleteDB(name))
                ? res.status(200).json({ message: "DB deleted successfully" })
                : res.status(400).json({ message: "Can't delete DB" });
        });
    }
}
exports.default = new DBController();
