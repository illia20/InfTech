package com.example.androidproject.types;

import java.io.Serializable;

public class TypeTime extends Type implements Serializable {
    
    private static final long serialVersionUID = 1L;
    
    public TypeTime(String name){
        super(name);
    }
    
    public boolean isValid(String val){
        if(val.length() > 5 || val.length() < 4) return false;
        if(val.charAt(val.length() - 3) != ':') return false;
        String hh = val.length() == 4 ? val.substring(0, 1) : val.substring(0, 2);
        String mm = val.substring(val.indexOf(':') + 1);
        int h, m;
        try{
            h = Integer.parseInt(hh);
            m = Integer.parseInt(mm);
            if(h > 23 || m > 59 || h < 0 || m < 0) return false;
            return true;
        }
        catch (Exception e){
            return false;
        }
    }

    @Override
    public String getValue(String val) {
            return val;
    }
    
}
