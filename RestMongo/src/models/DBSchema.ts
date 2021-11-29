import { Table } from "./Table";

import { Schema, model } from "mongoose";

const DBSchema = new Schema({
  name: { type: String, required: true, unique: true },
  tables: [{ type: Object, required: true }],
});

export default model("Db", DBSchema);