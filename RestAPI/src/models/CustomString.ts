import CustomType from "./CustomType";

class CustomString extends CustomType {
  validate(value: string): boolean {
    return true;
  }
}

export default CustomString;
