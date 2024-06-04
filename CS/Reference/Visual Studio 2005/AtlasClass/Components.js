// JScript File
registerNamespace("NameSpaceCustomer");
NameSpaceCustomer.clsCustomer =function()
{
var m_CustomerCode='';
var m_CustomerName='';

this.get_CustomerCode = function(){return m_CustomerCode;}
this.set_CustomerCode = function(value){m_CustomerCode=value;}

this.get_CustomerName = function(){return m_CustomerName;}
this.set_CustomerName = function(value){m_CustomerName=value;}

this.getCodeAndName = function(){alert(m_CustomerCode + ' : ' + m_CustomerName);}
this.dispose = function(){alert('This will be your clean up code');}

}
NameSpaceCustomer.clsCustomer.registerClass('NameSpaceCustomer.clsCustomer',
                                            null,
                                            Sys.IDisposable);



