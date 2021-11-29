import express from "express";
import cors from "cors";
import mongoose from "mongoose";

import DBRouter from "./routes/db.routes";
import TableRouter from "./routes/table.routes";
import ColumnRouter from "./routes/column.routes";
import RowRouter from "./routes/row.routes";
import MONGO_URL from "./config";

const PORT = process.env.PORT || 5000;

const app = express();

app.use(express.json());
app.use(cors());

app.get("/", (req, res) => {
  res.status(200).send("Hello world");
});

app.use("/db", DBRouter);
app.use("/table", TableRouter);
app.use("/column", ColumnRouter);
app.use("/row", RowRouter);

async function start() {
  try {
    await mongoose.connect(MONGO_URL, {
      useNewUrlParser: true,
      useUnifiedTopology: true,
    } as mongoose.ConnectOptions);
    app.listen(PORT, () => console.log(`Listening on port ${PORT}`));
  } catch (error:any) {
    console.log(`Error: ${error.message}`);
  }
}

start();
