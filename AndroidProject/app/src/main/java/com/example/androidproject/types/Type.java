package com.example.androidproject.types;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public abstract class Type implements Serializable {
    
    private static final long serialVersionUID = 1L;

    public static final List<String> TYPES = new ArrayList<String>(Arrays.asList("char", "int", "real", "time", "string", "timeinvl"));
    
    private final String name;

    public Type(String name) {
        this.name = name;
    }
    
    public static Type createType(String name){
        if("char".equals(name)) return new TypeChar(name);
        else if("int".equals(name)) return new TypeInt(name);
        else if("real".equals(name)) return new TypeReal(name);
        else if("time".equals(name)) return new TypeTime(name);
        else if("string".equals(name)) return new TypeString(name);
        else if("timeinvl".equals(name)) return new TypeTimeInvl(name);
        else return null;
    }

    public String getName() {
        return name;
    }
    
    public abstract boolean isValid(String val);
    public abstract String getValue(String val);
}
