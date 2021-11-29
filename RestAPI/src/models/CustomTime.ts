import CustomType from "./CustomType";

class CustomTime extends CustomType {
  validate(value: string): boolean {
    var ind = value.indexOf(":");
    var hh = Number(value.substr(0, ind));
    var mm = Number(value.substr(ind + 1));
    if(Number.isInteger(hh) && Number.isInteger(mm)){
      if(hh >= 0 && hh <= 23 && mm >= 0 && mm <= 59){
        return true;
      }
    }
    return false;
  }
}

export default CustomTime;
