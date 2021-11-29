"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const CustomType_1 = __importDefault(require("./CustomType"));
class TimeInvl extends CustomType_1.default {
    validate(value) {
        const times = value.split("-");
        const regex = /^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$/;
        return times.length == 2 && regex.test(times[0]) && regex.test(times[1]);
    }
}
exports.default = TimeInvl;
