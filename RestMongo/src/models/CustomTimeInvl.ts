import CustomType from "./CustomType";

class CustomTimeInvl extends CustomType {
  validate(value: string): boolean {
      var ind = value.indexOf("-");
      var t1 = value.substr(0, ind);
      var t2 = value.substr(ind+1);
      if(this.validateTime(t1) && this.validateTime(t2)){
        if(this.compareTime(t1, t2)){
          return true;
        }
      }
      return false;
    }


    validateTime(value: string): boolean {
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

    compareTime(t1: string, t2: string){
      var ind1 = t1.indexOf(":");
      var hh1 = Number(t1.substr(0, ind1));
      var mm1 = Number(t1.substr(ind1 + 1));

      var ind2 = t2.indexOf(":");
      var hh2 = Number(t2.substr(0, ind2));
      var mm2 = Number(t2.substr(ind2 + 1));

      if(hh1 < hh2){
        return true;
      }
      else if(hh1 == hh2 && mm1 < mm2){
        return true;
      }
      else {
        return false;
      }
    }
}

export default CustomTimeInvl;
