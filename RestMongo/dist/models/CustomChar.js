"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const CustomType_1 = __importDefault(require("./CustomType"));
class CustomChar extends CustomType_1.default {
    validate(value) {
        return value.length === 1;
    }
}
exports.default = CustomChar;
