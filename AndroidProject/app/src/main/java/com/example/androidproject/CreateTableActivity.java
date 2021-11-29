package com.example.androidproject;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.RadioButton;
import android.widget.TextView;

import androidx.appcompat.app.AppCompatActivity;

import com.example.androidproject.types.Type;

import java.util.Arrays;
import java.util.List;

public class CreateTableActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_create_table);
    }

    public void onRadioClick(View v){

        switch (v.getId()) {
            case R.id.radioNewTable:
                ((TextView)findViewById(R.id.firstTableLabel)).setText("New table name:");
                ((TextView)findViewById(R.id.secondTableLabel)).setText("Types:");
                ((EditText)findViewById(R.id.result_table)).setVisibility(View.INVISIBLE);
                ((TextView)findViewById(R.id.resultTableLabel)).setVisibility(View.INVISIBLE);
                break;
            case R.id.radioDescart:
                ((TextView)findViewById(R.id.firstTableLabel)).setText("First table name:");
                ((TextView)findViewById(R.id.secondTableLabel)).setText("Second table name:");
                ((EditText)findViewById(R.id.result_table)).setVisibility(View.VISIBLE);
                ((TextView)findViewById(R.id.resultTableLabel)).setVisibility(View.VISIBLE);
                break;
            default:
                break;
        }
    }

    public void onOkClick(View v){
        Intent answerIntent = new Intent();

        String table1 = ((EditText)findViewById(R.id.table1)).getText().toString();
        String resultTable = ((EditText)findViewById(R.id.result_table)).getText().toString();
        answerIntent.putExtra(MainActivity.TABLE1, table1);
        answerIntent.putExtra(MainActivity.RESULT_TABLE, resultTable);

        RadioButton rNewTable;
        rNewTable = (RadioButton) findViewById(R.id.radioNewTable);
        RadioButton rDescart;
        rDescart = (RadioButton) findViewById(R.id.radioDescart);
        if(rNewTable.isChecked()){
            answerIntent.putExtra(MainActivity.OPERATION, "new table");
            String table2 = ((EditText)findViewById(R.id.table2)).getText().toString();
            List<String> types = Arrays.asList(table2.split(" "));
            boolean f = true;
            for(String type : types){
                if(!Type.TYPES.contains(type)){
                    setResult(RESULT_CANCELED, answerIntent);
                    finish();
                }
            }
            answerIntent.putExtra(MainActivity.TABLE2, table2);
        }
        else if(rDescart.isChecked()){
            answerIntent.putExtra(MainActivity.OPERATION, "descart");
            String table2 = ((EditText)findViewById(R.id.table2)).getText().toString();
            answerIntent.putExtra(MainActivity.TABLE2, table2);
        }

        setResult(RESULT_OK, answerIntent);
        finish();
    }
}