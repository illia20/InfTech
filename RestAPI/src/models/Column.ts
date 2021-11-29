import CustomInteger from "./CustomInteger";
import CustomString from "./CustomString";
import CustomType from "./CustomType";
import CustomTime from "./CustomTime";
import CustomReal from "./CustomReal";
import CustomTimeInvl from "./CustomTimeInvl";
import CustomChar from "./CustomChar";

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
