package com.example.androidproject.types;

import java.io.Serializable;

public class TypeTimeInvl extends Type implements Serializable {
    
    private static final long serialVersionUID = 1L;
    
    public TypeTimeInvl(String name){
        super(name);
    }
    
    public boolean isValid(String val){
        try{
            int i = val.indexOf("-");
            if(i == -1) return false;
            TypeTime t1 = new TypeTime(val.substring(0,i));
            TypeTime t2 = new TypeTime(val.substring(i+1));
            if(!t1.isValid(val.substring(0,i)) || !t2.isValid(val.substring(i+1))) return false;
            String start = val.substring(0, i).trim();
            String end = val.substring(i+1).trim();

            return compare(start, end);
        }catch (Exception e) {
            return false;
        }
    }

    private boolean compare(String start, String end)
    {
        String h1, m1, h2, m2;
        h1 = start.length() == 4 ? start.substring(0, 1) : start.substring(0, 2);
        m1 = start.substring(start.indexOf(':') + 1);
        h2 = end.length() == 4 ? end.substring(0, 1) : end.substring(0, 2);
        m2 = end.substring(end.indexOf(':') + 1);

        int hh1, mm1, hh2, mm2;

        try {
            hh1 = Integer.parseInt(h1);
            hh2 = Integer.parseInt(h2);
            mm1 = Integer.parseInt(m1);
            mm2 = Integer.parseInt(m2);
        }
        catch (Exception e){return false;}
        if (hh1 > hh2) return false;
        else if (hh1 == hh2)
        {
            if(mm1 > mm2) return false;
        }

        return true;
    }

    @Override
    public String getValue(String val) {
        return val;
    }
}
