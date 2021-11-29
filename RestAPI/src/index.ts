import express from "express";
import cors from "cors";

import DBRouter from "./routes/db.routes";
import TableRouter from "./routes/table.routes";
import ColumnRouter from "./routes/column.routes";
import RowRouter from "./routes/row.routes";

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

app.listen(PORT, () => {
  console.log(`listening on port ${PORT}`);
});
