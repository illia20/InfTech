import CustomType from "./CustomType";

class CustomReal extends CustomType {
  validate(value: string): boolean {
    return !Number.isNaN(Number(value));
  }
}

export default CustomReal;
