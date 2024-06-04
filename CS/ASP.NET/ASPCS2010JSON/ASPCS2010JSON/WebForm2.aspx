<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="ASPCS2010JSON.WebForm2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function ChangeDateFormat(jsonDate) 
        {
            
            jsonDate = jsonDate.replace("/Date(", "").replace(")/", "");
            if (jsonDate.indexOf("+") > 0) 
            {
                jsonDate = jsonDate.substring(0, jsonDate.indexOf("+"));
            }
            else if (jsonDate.indexOf("-") > 0) 
            {
                jsonDate = jsonDate.substring(0, jsonDate.indexOf("-"));
            }

            var json_text = JSON.stringify(your_object, null, 2); 

            var dt = new Date(parseInt(jsonDate, 10));
            var mm = dt.getMonth() + 1 < 10 ? "0" + (dt.getMonth() + 1) : dt.getMonth() + 1;
            var dd = dt.getDate() < 10 ? "0" + dt.getDate() : dt.getDate();
            return dt.getFullYear() + "-" + mm + "-" + dd;
        }

        function Load() 
        {
            alert("Change JSON Date format using JavaScript: \n" + parseJsonDate("\/Date(1234567890123+0800)\/"));
        }

        window.onload = Load;

        function parseJsonDate(jsonDate) 
        {
            var offset = new Date().getTimezoneOffset() * 60000;
            var parts = /\/Date\((-?\d+)([+-]\d{2})?(\d{2})?.*/.exec(jsonDate);

            if (parts[2] == undefined)
                parts[2] = 0;

            if (parts[3] == undefined)
                parts[3] = 0;

            return new Date(+parts[1] + offset + parts[2] * 3600000 + parts[3] * 60000);
        };

//        function parseJsonDate(jsonDate) 
//        {
//            // Get the date time part
//            var dateTimePart = jsonDate.replace(/\/+Date\(([\d+-]+)\)\/+/, '$1');

//            // Check for + or - sign
//            var minusSignIndex = dateTimePart.indexOf('-');
//            var plusSignIndex = dateTimePart.indexOf('+');

//            // Get the sign index
//            var signIndex = minusSignIndex > 0 ? minusSignIndex : plusSignIndex;

//            // If sign index is not 0 then we are extracting offset part and 
//            if (signIndex > 0) {
//                var datePart = dateTimePart.substring(0, signIndex);
//                var offsetPart = dateTimePart.substring(signIndex);

//                var offset = offsetPart.substring(0, 3) + '.' + ((parseFloat(offsetPart.substring(3)) / 60) * 100).toString();

//                return getJSDate(parseFloat(datePart), parseFloat(offset));
//            }
//            else {
//                return getJSDate(dateTimePart, 0);
//            }
//        }

//        function getJSDate(ms, offset) {
//            // create Date object for current location
//            var date = new Date(ms);

//            // convert to msec
//            // add local time zone offset 
//            // get UTC time in msec
//            var utcTime = date.getTime() + (date.getTimezoneOffset() * 60000);

//            // create new Date object for different city
//            // using supplied offset
//            var jsDate = new Date(utcTime + (3600000 * offset));

//            return jsDate;
//        }

        function ShowDate() {
            alert(ChangeDateFormat("\/Date(1234567890123+0800)\/"));
        }
    </script>
</head>
<body>
    <form id="form1" runat="server" >
    <div>
    <input type="button" value="Click" onclick="ShowDate();" />
    </div>
    </form>
</body>
</html>
