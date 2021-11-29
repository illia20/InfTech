"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.writeFile = exports.writeDB = exports.readFile = void 0;
const fs_1 = __importDefault(require("fs"));
const PATH_NAME = "./static/db.json";
const readFile = () => {
    const data = fs_1.default.readFileSync(PATH_NAME);
    const parsedData = JSON.parse(data.toString());
    return parsedData || [];
};
exports.readFile = readFile;
const writeDB = (body) => {
    const data = (0, exports.readFile)();
    fs_1.default.writeFileSync(PATH_NAME, JSON.stringify([...data, body]));
};
exports.writeDB = writeDB;
const writeFile = (data) => {
    fs_1.default.writeFileSync(PATH_NAME, JSON.stringify(data));
};
exports.writeFile = writeFile;
