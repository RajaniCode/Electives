INSERT INTO OPENROWSET
(
'Microsoft.ACE.OLEDB.12.0', 
'Excel 8.0;Database=E:\Excel.xls;', 
'SELECT * FROM [Sheet1$]'
) 
SELECT * FROM Customers


