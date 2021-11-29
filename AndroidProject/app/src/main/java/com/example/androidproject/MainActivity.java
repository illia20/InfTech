package com.example.androidproject;

import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.graphics.Color;
import android.os.Bundle;
import android.util.TypedValue;
import android.view.Gravity;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TableLayout;
import android.widget.TableRow;
import android.widget.TextView;

import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

import com.example.androidproject.implementation.DbManager;
import com.example.androidproject.types.Row;
import com.example.androidproject.types.Table;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class MainActivity extends AppCompatActivity {
    public final static String TABLE1 = "TABLE1";
    public final static String TABLE2 = "TABLE2";
    public final static String OPERATION = "OPERATION";
    public final static String RESULT_TABLE = "RESULT_TABLE";
    private final static int CREATE_TABLE_CODE = 0;

    private AlertDialog.Builder builder;
    private Context context;
    private DbManagerIF dbManagerIF;
    private String currentTableName = "";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        context = MainActivity.this;
        dbManagerIF = new DbManager();
        dbManagerIF.setDatabaseHome(getFilesDir());
        dbManagerIF.forDatabaseFolder("db");

        try {
            createSimpleDatabase();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data){
        super.onActivityResult(requestCode, resultCode, data);
        if(requestCode == CREATE_TABLE_CODE && resultCode == RESULT_OK){
            String Table1 = data.getStringExtra(TABLE1);
            String Table2 = data.getStringExtra(TABLE2);
            String ResultTable = data.getStringExtra(RESULT_TABLE);
            String Operation = data.getStringExtra(OPERATION);
            String types = Table2;
            try {
                if(Operation.equals("new table")){
                    dbManagerIF.newTable(Table1, types);
                    dbManagerIF.addRow(Table1, new ArrayList<String>());
                    ResultTable = Table1;
                }
                else if(Operation.equals("descart")){
                    dbManagerIF.cartesianProduct(Table1, Table2, ResultTable);
                }
                Button addButton = (Button) findViewById(R.id.add_row_button);
                addButton.setEnabled(true);
                showTable(ResultTable);
            } catch (Exception e) {
                return;
            }
        }
    }

    private void createSimpleDatabase() throws Exception{
        dbManagerIF.dropDatabase();

        List<String> types = new ArrayList<String>();
        types.add("int"); types.add("char");
        dbManagerIF.createTable("table1",types);
        List<String> row = new ArrayList<String>();
        row.add("1"); row.add("a");
        dbManagerIF.addRow("table1",row);
        row = new ArrayList<String>();
        row.add("2"); row.add("b");
        dbManagerIF.addRow("table1", row);

        List<String> types2 = new ArrayList<String>();
        types2.add("timeinvl");
        dbManagerIF.createTable("table2", types2);
        row.clear();
        row.add("10:10-14:00");
        dbManagerIF.addRow("table2", row);
        row.clear();
        row.add("17:10-18:00");
        dbManagerIF.addRow("table2", row);
        row.clear();
        row.add("21:10-22:00");
        dbManagerIF.addRow("table2", row);
    }

    public void addRow(View view){
        builder = new AlertDialog.Builder(this);
        builder.setTitle("Add new row to table");

        final EditText input = new EditText(this);
        builder.setView(input);

        builder.setPositiveButton("OK", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                if(currentTableName == "") return;
                String[] data = input.getText().toString().split("\\s+");;
                List<String> columnData = new ArrayList<String>(Arrays.asList(data));
                try {
                    dbManagerIF.addRow(currentTableName, columnData);
                    addRow(data);
                } catch (Exception e) {
                    return;
                }
            }
        });
        builder.setNegativeButton("Cancel", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                dialog.cancel();
            }
        });

        builder.show();
    }

    public void addRow(String[] data){
        TableLayout table = (TableLayout) findViewById(R.id.spreadsheet);

        TableRow row = new TableRow(this);
        row.setGravity(Gravity.CENTER);

        for(int i=0;i<data.length;i++){
            TextView text = new TextView(this);
            text.setText(data[i]);
            text.setTextSize(TypedValue.COMPLEX_UNIT_DIP, 36);
            text.setGravity(Gravity.CENTER);
            text.setTextColor(Color.BLUE);
            row.addView(text);
        }

        table.addView(row);
    }

    public void listTables(View v) throws IOException {
        final ArrayList<Table> tables = (ArrayList<Table>) dbManagerIF.listTables();
        builder = new AlertDialog.Builder(context);
        String[] tableNames = new String[tables.size()];
        int i=0;
        for(Table table : tables){
            tableNames[i] = table.getName();
            i++;
        }
        builder.setTitle("Choose table");
        builder.setItems(tableNames, new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                String name = tables.get(which).getName();
                currentTableName = name;
                Button addButton = (Button) findViewById(R.id.add_row_button);
                addButton.setEnabled(true);
                showTable(name);
            }
        });
        builder.show();
    }

    public void showTable(String tableName){
        try {
            TableLayout table = (TableLayout)findViewById(R.id.spreadsheet);
            table.removeAllViews();
            List<Row> rows = dbManagerIF.loadTableData(tableName);
            for(Row row : rows){
                String[] data = new String[row.length()];
                for(int i=0;i<row.length();i++){
                    data[i] = row.getElement(i).getData();
                }
                addRow(data);
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public void createTable(View v){
        Intent intent = new Intent(this, CreateTableActivity.class);
        startActivityForResult(intent, CREATE_TABLE_CODE);
    }

    public void showAlert(View v){
        File[] files = getFilesDir().listFiles();
        builder = new AlertDialog.Builder(context);
        if(files.length <= 0){
            builder.setMessage("Zero files");
        }
        else{
            builder.setMessage(files[0].getAbsolutePath());
        }
        builder.show();
    }
}