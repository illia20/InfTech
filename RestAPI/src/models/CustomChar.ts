import CustomType from "./CustomType";

class CustomChar extends CustomType {
  validate(value: string): boolean {
    return value.length === 1;
  }
}

export default CustomChar;
