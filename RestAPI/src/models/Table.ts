import { Column } from "./Column";
import { Row } from "./Row";

export class Table {
  name: string;
  columnsList: Column[];
  rowsList: Row[];

  constructor(name: string) {
    this.name = name;
    this.columnsList = [];
    this.rowsList = [];
  }
}
