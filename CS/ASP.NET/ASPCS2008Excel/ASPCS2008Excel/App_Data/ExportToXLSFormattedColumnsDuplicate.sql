INSERT INTO OPENROWSET
(
'Microsoft.ACE.OLEDB.12.0', 
'Excel 8.0;Database=E:\ExcelDuplicate.xls;', 
'SELECT * FROM [Sheet1$]'
) 
SELECT * FROM Customers
UNION ALL
SELECT * FROM Customers

