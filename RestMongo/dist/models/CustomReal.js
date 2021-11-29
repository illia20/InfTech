"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const TableType_1 = __importDefault(require("./TableType"));
class CustomReal extends TableType_1.default {
    validate(value) {
        return !Number.isNaN(Number(value));
    }
}
exports.default = CustomReal;
