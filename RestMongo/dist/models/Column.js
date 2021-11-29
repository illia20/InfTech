"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.Column = void 0;
const TableChar_1 = __importDefault(require("./TableChar"));
const CustomInteger_1 = __importDefault(require("./CustomInteger"));
const CustomReal_1 = __importDefault(require("./CustomReal"));
const CustomString_1 = __importDefault(require("./CustomString"));
const TableTypeColor_1 = __importDefault(require("./TableTypeColor"));
const TableTypeColorInvl_1 = __importDefault(require("./TableTypeColorInvl"));
class Column {
    constructor(name, typename) {
        this.name = name;
        this.typename = typename;
        switch (typename) {
            case "Integer":
                this.type = new CustomInteger_1.default();
                break;
            case "Real":
                this.type = new CustomReal_1.default();
                break;
            case "Char":
                this.type = new TableChar_1.default();
                break;
            case "String":
                this.type = new CustomString_1.default();
                break;
            case "Color":
                this.type = new TableTypeColor_1.default();
                break;
            case "ColorInvl":
                this.type = new TableTypeColorInvl_1.default();
                break;
            default:
                this.type = new CustomString_1.default();
                break;
        }
    }
}
exports.Column = Column;
