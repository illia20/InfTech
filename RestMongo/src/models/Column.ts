import CustomChar from "./CustomChar";
import CustomInteger from "./CustomInteger";
import CustomReal from "./CustomReal";
import CustomString from "./CustomString";
import CustomType from "./CustomType";
import CustomTime from "./CustomTime";
import CustomTimeInvl from "./CustomTimeInvl";

export class Column {
  name: string;
  type: CustomType;
  typename: string;

  constructor(name: string, typename: string) {
    this.name = name;
    this.typename = typename;
    switch (typename) {
      case "Integer":
        this.type = new CustomInteger();
        break;
      case "Real":
        this.type = new CustomReal();
        break;
      case "Char":
        this.type = new CustomChar();
        break;
      case "String":
        this.type = new CustomString();
        break;
       case "Time":
         this.type = new CustomTime();
         break;
       case "TimeInvl":
         this.type = new CustomTimeInvl();
         break;
      default:
        this.type = new CustomString();
        break;
    }
  }
}
