<!DOCTYPE html>
<html>
<body>
    <%

    On Error Resume Next
    response.write("My first ASP script!")    

    Dim Inst = Server.CreateObject("ClassicASPCOM.ClassCOM")

    response.write(Inst.GetMessage())
   
    %>
</body>
</html>
