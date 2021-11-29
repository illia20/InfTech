"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const TableType_1 = __importDefault(require("./TableType"));
class TableTypeColorInvl extends TableType_1.default {
    validate(value) {
        const parts = value.split('-');
        return ((parts.length == 2) && this.check(parts[0]) && this.check(parts[1]));
    }
    check(value) {
        const nums = value.split(',');
        for (let num of nums) {
            if (!Number.isInteger(Number(value)))
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
exports.default = TableTypeColorInvl;
