xSupermarket
============

Homework of Domain-Specific Language Course

## How to run
1. Install Microsoft dotNet Framework 4.0
2. Install SQLite3, actually you only need sqlite3.dll
3. Install System.Data.SQLite for dotNet 4.0 64/32bit
4. Create a SQLite database with SQL scripts in data folder, or you can just use the xsm.db file in the folder
5. Edit the configuration file xSupermarket.App.exe, make sure your database file path is correct in the connection string
```  
<?xml version="1.0" encoding="utf-8" ?>  
<configuration>  
  <connectionStrings>  
    <add name="SQLiteConnectionString" providerName="System.Data.SQLite.SQLiteConnection" connectionString="Data Source={YOUR_DB_FILE};Version=3;"/>  
  </connectionStrings>  
</configuration>  
```  
6. Double click exe and test it  


## Some External DSL Example
- select * from Product where Section = 'A' group by ProductArea;  
```  
SELECT Product(Section=A) GROUP(ProductArea);
```  
- select * from Product where Section = 'A' order by Name desc;  
```  
SELECT Product(Section=A) DESC(Name);
```  
- insert into Section(Name, Id) values('X', 'X');  
```  
INSERT Section(Name=X Id=X);  
```  
- update Section set Name = 'X' where Id = 'X';  
```  
UPDATE Section(Name=X Id=X);  
```  
- delete from Product where Cost > 1 and Cost < 10;  
```  
DELETE Product(Cost>1 Cost<10);  
```  
- find products which are most often bought together, and at least for 60 times.  
```  
TOP Marketbasket 60;  
```  
- support = P(egg U bread)  
```  
SUPP Marketbasket (White Bread) (Eggs); 
```  
- confidence = P(egg | bread)  
```  
SUPP Marketbasket (White Bread) (Eggs); 
```