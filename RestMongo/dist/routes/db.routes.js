"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const express_1 = __importDefault(require("express"));
const db_controller_1 = __importDefault(require("../app/db/db.controller"));
const router = express_1.default.Router();
router.get("/:name", db_controller_1.default.getDB);
router.post("/", db_controller_1.default.postDB);
router.delete("/:name", db_controller_1.default.deleteDB);
exports.default = router;
