package com.example.androidproject.implementation;

import com.example.androidproject.DbManagerIF;
import com.example.androidproject.types.Row;
import com.example.androidproject.types.Table;
import com.example.androidproject.types.Type;
import com.example.androidproject.types.Value;

import org.apache.commons.io.FileUtils;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.FilenameFilter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Collection;
import java.util.List;
import java.util.Map;

public class DbManager implements DbManagerIF {
    
    private static final String METADATA_FILE_NAME = "metadata";
    private static final String TABLE_FILE_NAME = "table";
    private static final String TABLE_FILE_NAME_TEMP = "table_temp";
    
    private File home;     
    private File databaseFolder;
    
    @Override
    public void setDatabaseHome(File file){
        home = file;
    }
    
    @Override
    public void forDatabaseFolder(String databaseFolderName) {
        this.databaseFolder = new File(home, databaseFolderName);
        initDatabaseFolder(this.databaseFolder);
    }

    private final static void initDatabaseFolder(File databaseFolder) {
        databaseFolder.mkdirs();
    }
    
    @Override
    public String getDatabaseName(){
        return databaseFolder.getName();
    }
    
    @Override
    public void dropDatabase() throws IOException {
        FileUtils.deleteDirectory(databaseFolder);
    }
    
    @Override
    public Table createTable(String tableName, List<String> columnTypeNames) throws IOException {
        File tableDirectory = new File(databaseFolder, tableName);
        tableDirectory.mkdir();
        
        List<Type> columnTypes = new ArrayList<Type>();
        for (String columnTypeName : columnTypeNames) {
            columnTypes.add(Type.createType(columnTypeName));
        }
        
        StringBuilder metadata = new StringBuilder();
        for (Type columnType : columnTypes) {
            if (metadata.length() > 0) {
                metadata.append("|");
            }
            metadata.append(columnType.getName());
        }
        
        File metadataFile = new File(tableDirectory, METADATA_FILE_NAME);
        FileUtils.writeStringToFile(metadataFile, metadata.toString());
        
        return new Table(tableName, columnTypes);
    }
    
    @Override
    public Row addRow(String tableName, List<String> columnData) throws Exception {
        Table table = loadTable(tableName);
        if(table.getColumnTypes().size() != columnData.size()){
            throw new Exception("Type of row is not valid");
        }
        List<Type> types = table.getColumnTypes();
        for(int i=0;i<columnData.size();i++){
            if(!types.get(i).isValid(columnData.get(i))){
                throw new Exception("Type of row is not valid");
            }
        }
        
        List<Value> values = new ArrayList<Value>();
        for(int i=0; i<columnData.size(); i++)
            values.add(new Value(columnData.get(i),types.get(i)));
        
        Row row = new Row(values);
        
        return addRow(tableName, row);
    }
    
    @Override
    public List<Row> removeRow(String tableName, Map<Integer,String> columnData) throws Exception {
        
        Table table = loadTable(tableName);
        List<Type> types = table.getColumnTypes();
        for(int curKey : columnData.keySet()){
            Type curType = types.get(curKey-1);
            if(!curType.isValid(columnData.get(curKey))){
                throw new Exception("Type of row is not valid");
            }
        }
        
        
        File tableFile = new File(new File(databaseFolder,tableName), TABLE_FILE_NAME);
        File tableFileTemp = new File(new File(databaseFolder,tableName), TABLE_FILE_NAME_TEMP);
        
        BufferedReader reader = new BufferedReader(new FileReader(tableFile));
        BufferedWriter writer = new BufferedWriter(new FileWriter(tableFileTemp));
        
        String currentLine;
        List<Row> res = new ArrayList<Row>();;
        boolean toRemove = true;
        while((currentLine = reader.readLine()) != null){
            toRemove = true;
            String[] curLineData = currentLine.split(" ");
            for(int curKey : columnData.keySet()){
                if(!curLineData[curKey-1].equals(columnData.get(curKey))){
                    toRemove = false;
                    break;
                }
            }
            if(toRemove == false) writer.write(currentLine+"\n");
            else{
                List<Value> valueList = new ArrayList<Value>();
                for(int i=0; i<curLineData.length;i++){
                    valueList.add(new Value(curLineData[i],types.get(i)));
                }
                res.add(new Row(valueList));
            }
        }
        tableFileTemp.renameTo(tableFile);
        reader.close();
        writer.close();
        return res;
    }
    
    @Override
    public Collection<Table> listTables() throws IOException {
        String[] dirList = databaseFolder.list(new FilenameFilter() {
            
            @Override
            public boolean accept(File dir, String name) {
                return dir.equals(databaseFolder) && new File(dir,name).isDirectory();
            }
        });
        
        Collection<Table> result = new ArrayList<Table>();
        for(String dir : dirList){
            result.add(loadTable(dir));
        }
        
        return result;
    }
    
    @Override
    public Table loadTable(String tableName) throws IOException {
        File tableDirectory = new File(databaseFolder, tableName);
        
        List<Type> columnTypes = new ArrayList<Type>();
        
        String metadata = FileUtils.readFileToString(new File(tableDirectory, METADATA_FILE_NAME));
        String[] columnTypeNames = metadata.split("\\|");
        for (String columnTypeName : columnTypeNames) {
            columnTypes.add(Type.createType(columnTypeName));
        }
        
        Table result = new Table(tableName, columnTypes);
        return result;
    }
    
    @Override
    public List<Row> loadTableData(String tableName) throws IOException {
        List<Row> result = new ArrayList<Row>();
        
        Table table = loadTable(tableName);
        List<Type> types = table.getColumnTypes();
        File tableFile = new File(new File(databaseFolder,tableName), TABLE_FILE_NAME);
        BufferedReader reader = new BufferedReader(new FileReader(tableFile));
        
        String currentLine;
        while((currentLine = reader.readLine()) != null){
            String[] curLineData = currentLine.split(" ");
            List<Value> valueList = new ArrayList<Value>();
            for(int i=0;i<types.size();i++){
                String val = curLineData[i];
                valueList.add(new Value(val,types.get(i)));
            }
            result.add(new Row(valueList));
            
        }
        reader.close();
        return result;
    }
    
    @Override
    public void removeTable(String tableName) throws IOException {
        FileUtils.deleteDirectory(new File(databaseFolder, tableName));
    }

    @Override
    public Table cartesianProduct(String tableName1, String tableName2, String newTableName) throws Exception {
    	Table table1 = loadTable(tableName1);
        Table table2 = loadTable(tableName2);
    
        List<Type> types1 = table1.getColumnTypes();
        List<Type> types2 = table2.getColumnTypes();
        List<String> typeNames = new ArrayList<String>();
        for(int i=0;i<types1.size();i++) typeNames.add(types1.get(i).getName());
        for(int i=0;i<types2.size();i++) typeNames.add(types2.get(i).getName());
        
        Table newTable = createTable(newTableName, typeNames);
        
        List<Row> tableData1 = loadTableData(tableName1);
        List<Row> tableData2 = loadTableData(tableName2);

        List<Row> resRows = new ArrayList<>();
        for(Row firstRow : tableData1) {
            for(Row secondRow : tableData2) {
                Row newRow = new Row();
                newRow.setRow(new ArrayList<Value>(firstRow.getRow()));
                newRow.joinRow(secondRow);
                resRows.add(newRow);
            }
        }

        for(Row curRow : resRows){
            addRow(newTableName, curRow);
        }
        
        return newTable;
    }

    @Override
    public Table newTable(String newTableName, String types) throws Exception {
        String[] types_ = types.split("\\s+");
        List<String> outputTypes = new ArrayList<String>();
        for (String str : types_) {
        	outputTypes.add(str);
        }
        
        createTable(newTableName, outputTypes);
        
        return loadTable(newTableName);
    }
    
    private Row addRow(String tableName, Row row) throws IOException {
        StringBuilder stringRow = new StringBuilder();
        for(int i=0;i<row.length();i++){
            if(stringRow.length() > 0)
                stringRow.append(' ');
            stringRow.append(row.getElement(i).getData());
        }
        if(stringRow.length() > 0) stringRow.append('\n');
        File tableFile = new File(new File(databaseFolder, tableName), TABLE_FILE_NAME);
        FileUtils.writeStringToFile(tableFile, stringRow.toString(), true);
        
        return row;
    }
}
