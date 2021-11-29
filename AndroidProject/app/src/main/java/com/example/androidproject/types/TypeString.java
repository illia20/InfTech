package com.example.androidproject.types;

import java.io.Serializable;

public class TypeString extends Type implements Serializable {
    private static final long serialVersionUID = 1L;

    public TypeString(String name){
        super(name);
    }

    public boolean isValid(String val){
        return true;
    }

    @Override
    public String getValue(String val) {
        return val;
    }
}
