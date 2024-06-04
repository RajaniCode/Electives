<%
'----------------------------------------------------------------------------------
' PayPal Constants File
' ====================================
' Authentication Credentials for making the call to the server
'----------------------------------------------------------------------------------

' Sandbox credentials
	Const API_ENDPOINT	= "https://api-3t.sandbox.paypal.com/nvp"
	Const API_USERNAME	= ""
	Const API_PASSWORD	= ""
      Const API_SIGNATURE	= ""
      Const PAYPAL_EC_URL	= "https://www.sandbox.paypal.com/webscr"
	Const ECURLLOGIN        = "https://developer.paypal.com"


      'SUBJECT To be used in unipay other credentials like username,password, signature can be commented
      'Const SUBJECT          = ""


'beta-sandbox credentials

	'Const API_ENDPOINT	= "https://api-3t.beta-sandbox.paypal.com/nvp"
	'Const API_USERNAME	= ""
	'Const API_PASSWORD	= ""
	'Const API_SIGNATURE	= ""
	'Const PAYPAL_EC_URL	= "https://www.beta-sandbox.paypal.com/webscr"
	'Const ECURLLOGIN       = "https://beta-developer.paypal.com"
'

	Const API_VERSION	= "92.0"
      Const HTTPREQUEST_PROXYSETTING_SERVER = ""
	Const HTTPREQUEST_PROXYSETTING_PORT = ""
	Const USE_PROXY = False

%>
