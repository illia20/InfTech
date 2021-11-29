"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const mongoose_1 = require("mongoose");
const DBSchema = new mongoose_1.Schema({
    name: { type: String, required: true, unique: true },
    tables: [{ type: Object, required: true }],
});
exports.default = (0, mongoose_1.model)("Db", DBSchema);
