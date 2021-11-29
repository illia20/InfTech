import fs from "fs";
import { DB } from "../models/DB";

const PATH_NAME: string = "./static/db.json";

export const readFile = (): DB[] => {
  const data = fs.readFileSync(PATH_NAME);
  const parsedData: DB[] = JSON.parse(data.toString());
  return parsedData || [];
};

export const writeDB = (body: DB) => {
  const data = readFile();
  fs.writeFileSync(PATH_NAME, JSON.stringify([...data, body]));
};

export const writeFile = (data: DB[]) => {
  fs.writeFileSync(PATH_NAME, JSON.stringify(data));
};
