"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const TableType_1 = __importDefault(require("./TableType"));
class TableTypeColor extends TableType_1.default {
    validate(value) {
        const nums = value.split(',');
        for (let num of nums) {
            if (!Number.isInteger(Number(num)))
                return false;
        }
        try {
            if (nums.length != 3 ||
                Number(nums[0]) > 255 || Number(nums[0]) < 0 ||
                Number(nums[1]) > 255 || Number(nums[1]) < 0 ||
                Number(nums[2]) > 255 || Number(nums[2]) < 0)
                return false;
            else
                return true;
        }
        catch (_a) {
            return false;
        }
    }
}
exports.default = TableTypeColor;
