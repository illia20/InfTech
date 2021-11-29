import CustomType from "./CustomType";

class CustomInteger extends CustomType {
  validate(value: string): boolean {
    return Number.isInteger(Number(value));
  }
}

export default CustomInteger;
