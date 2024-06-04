--/ Copyright (c) Microsoft Corporation.  All rights reserved. 
--/  
--/ THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
--/ WHETHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
--/ WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
--/ THE ENTIRE RISK OF USE OR RESULTS IN CONNECTION WITH THE USE OF THIS CODE 
--/ AND INFORMATION REMAINS WITH THE USER. 
--/ 

-- Upgrade script for 'bts-WindowsSharePointServices-properties' property schema in Microsoft.BizTalk.GlobalPropertySchemas.dll assembly.
-- This script removes the Windows SharePoint Service Adapter schema and schema properties from BizTalk Management database

DECLARE @gpsassemblyid AS int, @gpsitemid AS int, @documentSpecId AS uniqueidentifier

SELECT @gpsassemblyid = ( SELECT nID FROM bts_assembly WHERE nvcName = N'Microsoft.BizTalk.GlobalPropertySchemas' )

INSERT INTO bts_item (AssemblyId, Namespace, [Name], Type, IsPipeline, Guid, SchemaType)
	VALUES( @gpsassemblyid, N'WSS', N'bts_WindowsSharePointServices_properties', N'', 0, newid(), 1)

SELECT @gpsitemid = ( SELECT [id] FROM bts_item WHERE FullName = N'WSS.bts_WindowsSharePointServices_properties' )

INSERT INTO bt_XMLShare (active, target_namespace, date_modified, content)
	VALUES (1, N'http://schemas.microsoft.com/BizTalk/2006/WindowsSharePointServices-properties', GETDATE(), 
N'<?xml version="1.0" encoding="utf-16"?>
<xs:schema xmlns:b="http://schemas.microsoft.com/BizTalk/2003" xmlns="http://schemas.microsoft.com/BizTalk/2006/WindowsSharePointServices-properties" targetNamespace="http://schemas.microsoft.com/BizTalk/2006/WindowsSharePointServices-properties" xmlns:xs="http://www.w3.org/2001/XMLSchema">
  <xs:annotation>
    <xs:appinfo>
      <b:schemaInfo schema_type="property" xmlns:b="http://schemas.microsoft.com/BizTalk/2003" />
    </xs:appinfo>
  </xs:annotation>
  <xs:element name="Filename" type="xs:string">
    <xs:annotation>
      <xs:appinfo>
        <b:fieldInfo propertyGuid="b1a1f574-5a7c-41ad-90c5-99d32ed83b9d" propSchFieldBase="MessageContextPropertyBase" />
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
  <xs:element name="Url" type="xs:string">
    <xs:annotation>
      <xs:appinfo>
        <b:fieldInfo propertyGuid="7fb27202-9a05-4ae9-b287-589661064dc1" propSchFieldBase="MessageContextPropertyBase" />
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
  <xs:element name="InArchivedMsgUrl" type="xs:string">
    <xs:annotation>
      <xs:appinfo>
        <b:fieldInfo propertyGuid="5117B6E2-17D8-47c0-B2C2-34C576E1885F" propSchFieldBase="MessageContextPropertyBase" />
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
  <xs:element name="InIconUrl" type="xs:string">
    <xs:annotation>
      <xs:appinfo>
        <b:fieldInfo propertyGuid="be473dcc-1f09-43d3-8bf8-075d3508b082" propSchFieldBase="MessageContextPropertyBase" />
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
  <xs:element name="InTitle" type="xs:string">
    <xs:annotation>
      <xs:appinfo>
        <b:fieldInfo propertyGuid="d94730a6-8dda-4405-b526-ff14b0daa324" propSchFieldBase="MessageContextPropertyBase" />
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
  <xs:element name="InLastModified" type="xs:dateTime">
    <xs:annotation>
      <xs:appinfo>
        <b:fieldInfo propertyGuid="5126a8fb-16c2-44a5-a5b6-53f76e689162" propSchFieldBase="MessageContextPropertyBase" />
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
  <xs:element name="InLastModifiedBy" type="xs:string">
    <xs:annotation>
      <xs:appinfo>
        <b:fieldInfo propertyGuid="a467f7ec-297a-44b9-bb3f-ee81e12b8990" propSchFieldBase="MessageContextPropertyBase" />
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
  <xs:element name="InItemId" type="xs:int">
    <xs:annotation>
      <xs:appinfo>
        <b:fieldInfo propertyGuid="e09b1f57-f8a3-459e-9900-d8fc0bc0958c" propSchFieldBase="MessageContextPropertyBase" />
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
  <xs:element name="InEditUrl" type="xs:string">
    <xs:annotation>
      <xs:appinfo>
        <b:fieldInfo propertyGuid="8f19936a-edd3-46ce-a3d5-b9cfd4fa9ae7" propSchFieldBase="MessageContextPropertyBase" />
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
  <xs:element name="InCreated" type="xs:dateTime">
    <xs:annotation>
      <xs:appinfo>
        <b:fieldInfo propertyGuid="6747403c-d444-470d-a65e-fd5732e7beda" propSchFieldBase="MessageContextPropertyBase" />
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
  <xs:element name="InCreatedBy" type="xs:string">
    <xs:annotation>
      <xs:appinfo>
        <b:fieldInfo propertyGuid="5cdf8927-9529-45ce-8837-caf9184ea33a" propSchFieldBase="MessageContextPropertyBase" />
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
  <xs:element name="InFileSize" type="xs:int">
    <xs:annotation>
      <xs:appinfo>
        <b:fieldInfo propertyGuid="a6c005e9-eb59-486f-9b6b-f2801de5e95a" propSchFieldBase="MessageContextPropertyBase" />
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
  <xs:element name="InListName" type="xs:string">
    <xs:annotation>
      <xs:appinfo>
        <b:fieldInfo propertyGuid="4b30ca21-6b7b-4d73-a8fa-8af4b8cee2a4" propSchFieldBase="MessageContextPropertyBase" />
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
  <xs:element name="InListUrl" type="xs:string">
    <xs:annotation>
      <xs:appinfo>
        <b:fieldInfo propertyGuid="97ad9913-5f5a-4b44-8696-9be6c4d2c45c" propSchFieldBase="MessageContextPropertyBase" />
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
  <xs:element name="InPropertiesXml" type="xs:string">
    <xs:annotation>
      <xs:appinfo>
        <b:fieldInfo propertyGuid="ca388c8e-e066-4447-90e8-1294e6de6866" propSchFieldBase="MessageContextPropertyBase" />
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
  <xs:element name="InOfficeIntegration" type="xs:string">
    <xs:annotation>
      <xs:appinfo>
        <b:fieldInfo propertyGuid="b5703630-b96b-47a7-b3d8-4167d8085be6" propSchFieldBase="MessageContextPropertyBase" />
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
  <xs:element name="ConfigOverwrite" type="xs:string">
    <xs:annotation>
      <xs:appinfo>
        <b:fieldInfo propertyGuid="09fa4d07-bc64-44c9-883d-8f7314593894" propSchFieldBase="MessageContextPropertyBase" />
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
  <xs:element name="ConfigNamespaceAliases" type="xs:string">
    <xs:annotation>
      <xs:appinfo>
        <b:fieldInfo propertyGuid="0d7286c4-d6be-46a4-98ee-4c8efce054fa" propSchFieldBase="MessageContextPropertyBase" />
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
  <xs:element name="ConfigOfficeIntegration" type="xs:string">
    <xs:annotation>
      <xs:appinfo>
        <b:fieldInfo propertyGuid="693171f5-c9e5-4aac-bf15-bb020c93b4e1" propSchFieldBase="MessageContextPropertyBase" />
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
  <xs:element name="ConfigTemplatesDocLib" type="xs:string">
    <xs:annotation>
      <xs:appinfo>
        <b:fieldInfo propertyGuid="da0199e3-91ea-4783-b367-85498d57a6d7" propSchFieldBase="MessageContextPropertyBase" />
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
  <xs:element name="ConfigTemplatesNamespaceCol" type="xs:string">
    <xs:annotation>
      <xs:appinfo>
        <b:fieldInfo propertyGuid="11dda6a5-3ad9-465d-9150-c827e7f4752e" propSchFieldBase="MessageContextPropertyBase" />
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
  <xs:element name="ConfigCustomTemplatesDocLib" type="xs:string">
    <xs:annotation>
      <xs:appinfo>
        <b:fieldInfo propertyGuid="8dc216ec-d94d-4794-8de8-4fbb92bc5628" propSchFieldBase="MessageContextPropertyBase" />
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
  <xs:element name="ConfigCustomTemplatesNamespaceCol" type="xs:string">
    <xs:annotation>
      <xs:appinfo>
        <b:fieldInfo propertyGuid="a790c580-6d5b-4ff0-9ea9-fe66d62b43c8" propSchFieldBase="MessageContextPropertyBase" />
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
  <xs:element name="ConfigPropertiesXml" type="xs:string">
    <xs:annotation>
      <xs:appinfo>
        <b:fieldInfo propertyGuid="89b6eae9-dfc7-4ffd-b5c2-27032aec5c20" propSchFieldBase="MessageContextPropertyBase" />
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
  <xs:element name="ConfigTimeout" type="xs:int">
    <xs:annotation>
      <xs:appinfo>
        <b:fieldInfo propertyGuid="0e30b953-1de3-4624-b23a-61779bfa6443" propSchFieldBase="MessageContextPropertyBase" />
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
  <xs:element name="ConfigAdapterWSPort" type="xs:int">
    <xs:annotation>
      <xs:appinfo>
        <b:fieldInfo propertyGuid="e8385e95-43c1-4c72-9c96-7e00347b8662" propSchFieldBase="MessageContextPropertyBase" />
      </xs:appinfo>
    </xs:annotation>
  </xs:element>
</xs:schema>')

SELECT @documentSpecId = (SELECT [id] FROM bt_XMLShare WHERE target_namespace = N'http://schemas.microsoft.com/BizTalk/2006/WindowsSharePointServices-properties')

INSERT INTO bt_DocumentSpec ([id], itemid, assemblyid, shareid, msgtype, date_modified, body_xpath, is_property_schema, is_multiroot, clr_namespace, clr_typename, clr_assemblyname, schema_root_name, xsd_type, is_tracked, is_flat, property_clr_class)
	VALUES (N'{5117B6E2-17D8-47c0-B2C2-34C576E1885F}', @gpsitemid, @gpsassemblyid, @documentSpecId, N'http://schemas.microsoft.com/BizTalk/2006/WindowsSharePointServices-properties#InArchivedMsgUrl', GETDATE(), N'', 1, 0, N'WSS', N'bts_WindowsSharePointServices_properties', N'Microsoft.BizTalk.GlobalPropertySchemas,  Version=3.0.1.0,  Culture=neutral,  PublicKeyToken=31bf3856ad364e35', N'InArchivedMsgUrl', N'string', 0, 0, N'InArchivedMsgUrl')

INSERT INTO bt_DocumentSpec ([id], itemid, assemblyid, shareid, msgtype, date_modified, body_xpath, is_property_schema, is_multiroot, clr_namespace, clr_typename, clr_assemblyname, schema_root_name, xsd_type, is_tracked, is_flat, property_clr_class)
	VALUES (N'{BE473DCC-1F09-43D3-8BF8-075D3508B082}', @gpsitemid, @gpsassemblyid, @documentSpecId, N'http://schemas.microsoft.com/BizTalk/2006/WindowsSharePointServices-properties#InIconUrl', GETDATE(), N'', 1, 0, N'WSS', N'bts_WindowsSharePointServices_properties', N'Microsoft.BizTalk.GlobalPropertySchemas,  Version=3.0.1.0,  Culture=neutral,  PublicKeyToken=31bf3856ad364e35', N'InIconUrl', N'string', 0, 0, N'InIconUrl')

INSERT INTO bt_DocumentSpec ([id], itemid, assemblyid, shareid, msgtype, date_modified, body_xpath, is_property_schema, is_multiroot, clr_namespace, clr_typename, clr_assemblyname, schema_root_name, xsd_type, is_tracked, is_flat, property_clr_class)
	VALUES (N'{CA388C8E-E066-4447-90E8-1294E6DE6866}', @gpsitemid, @gpsassemblyid, @documentSpecId, N'http://schemas.microsoft.com/BizTalk/2006/WindowsSharePointServices-properties#InPropertiesXml', GETDATE(), N'', 1, 0, N'WSS', N'bts_WindowsSharePointServices_properties', N'Microsoft.BizTalk.GlobalPropertySchemas,  Version=3.0.1.0,  Culture=neutral,  PublicKeyToken=31bf3856ad364e35', N'InPropertiesXml', N'string', 0, 0, N'InPropertiesXml')

INSERT INTO bt_DocumentSpec ([id], itemid, assemblyid, shareid, msgtype, date_modified, body_xpath, is_property_schema, is_multiroot, clr_namespace, clr_typename, clr_assemblyname, schema_root_name, xsd_type, is_tracked, is_flat, property_clr_class)
	VALUES (N'{89B6EAE9-DFC7-4FFD-B5C2-27032AEC5C20}', @gpsitemid, @gpsassemblyid, @documentSpecId, N'http://schemas.microsoft.com/BizTalk/2006/WindowsSharePointServices-properties#ConfigPropertiesXml', GETDATE(), N'', 1, 0, N'WSS', N'bts_WindowsSharePointServices_properties', N'Microsoft.BizTalk.GlobalPropertySchemas,  Version=3.0.1.0,  Culture=neutral,  PublicKeyToken=31bf3856ad364e35', N'ConfigPropertiesXml', N'string', 0, 0, N'ConfigPropertiesXml')

INSERT INTO bt_DocumentSpec ([id], itemid, assemblyid, shareid, msgtype, date_modified, body_xpath, is_property_schema, is_multiroot, clr_namespace, clr_typename, clr_assemblyname, schema_root_name, xsd_type, is_tracked, is_flat, property_clr_class)
	VALUES (N'{B5703630-B96B-47A7-B3D8-4167D8085BE6}', @gpsitemid, @gpsassemblyid, @documentSpecId, N'http://schemas.microsoft.com/BizTalk/2006/WindowsSharePointServices-properties#InOfficeIntegration', GETDATE(), N'', 1, 0, N'WSS', N'bts_WindowsSharePointServices_properties', N'Microsoft.BizTalk.GlobalPropertySchemas,  Version=3.0.1.0,  Culture=neutral,  PublicKeyToken=31bf3856ad364e35', N'InOfficeIntegration', N'string', 0, 0, N'InOfficeIntegration')

INSERT INTO bt_DocumentSpec ([id], itemid, assemblyid, shareid, msgtype, date_modified, body_xpath, is_property_schema, is_multiroot, clr_namespace, clr_typename, clr_assemblyname, schema_root_name, xsd_type, is_tracked, is_flat, property_clr_class)
	VALUES (N'{0D7286C4-D6BE-46A4-98EE-4C8EFCE054FA}', @gpsitemid, @gpsassemblyid, @documentSpecId, N'http://schemas.microsoft.com/BizTalk/2006/WindowsSharePointServices-properties#ConfigNamespaceAliases', GETDATE(), N'', 1, 0, N'WSS', N'bts_WindowsSharePointServices_properties', N'Microsoft.BizTalk.GlobalPropertySchemas,  Version=3.0.1.0,  Culture=neutral,  PublicKeyToken=31bf3856ad364e35', N'ConfigNamespaceAliases', N'string', 0, 0, N'ConfigNamespaceAliases')

INSERT INTO bt_DocumentSpec ([id], itemid, assemblyid, shareid, msgtype, date_modified, body_xpath, is_property_schema, is_multiroot, clr_namespace, clr_typename, clr_assemblyname, schema_root_name, xsd_type, is_tracked, is_flat, property_clr_class)
	VALUES (N'{8DC216EC-D94D-4794-8DE8-4FBB92BC5628}', @gpsitemid, @gpsassemblyid, @documentSpecId, N'http://schemas.microsoft.com/BizTalk/2006/WindowsSharePointServices-properties#ConfigCustomTemplatesDocLib', GETDATE(), N'', 1, 0, N'WSS', N'bts_WindowsSharePointServices_properties', N'Microsoft.BizTalk.GlobalPropertySchemas,  Version=3.0.1.0,  Culture=neutral,  PublicKeyToken=31bf3856ad364e35', N'ConfigCustomTemplatesDocLib', N'string', 0, 0, N'ConfigCustomTemplatesDocLib')

INSERT INTO bt_DocumentSpec ([id], itemid, assemblyid, shareid, msgtype, date_modified, body_xpath, is_property_schema, is_multiroot, clr_namespace, clr_typename, clr_assemblyname, schema_root_name, xsd_type, is_tracked, is_flat, property_clr_class)
	VALUES (N'{5126A8FB-16C2-44A5-A5B6-53F76E689162}', @gpsitemid, @gpsassemblyid, @documentSpecId, N'http://schemas.microsoft.com/BizTalk/2006/WindowsSharePointServices-properties#InLastModified', GETDATE(), N'', 1, 0, N'WSS', N'bts_WindowsSharePointServices_properties', N'Microsoft.BizTalk.GlobalPropertySchemas,  Version=3.0.1.0,  Culture=neutral,  PublicKeyToken=31bf3856ad364e35', N'InLastModified', N'dateTime', 0, 0, N'InLastModified')

INSERT INTO bt_DocumentSpec ([id], itemid, assemblyid, shareid, msgtype, date_modified, body_xpath, is_property_schema, is_multiroot, clr_namespace, clr_typename, clr_assemblyname, schema_root_name, xsd_type, is_tracked, is_flat, property_clr_class)
	VALUES (N'{7FB27202-9A05-4AE9-B287-589661064DC1}', @gpsitemid, @gpsassemblyid, @documentSpecId, N'http://schemas.microsoft.com/BizTalk/2006/WindowsSharePointServices-properties#Url', GETDATE(), N'', 1, 0, N'WSS', N'bts_WindowsSharePointServices_properties', N'Microsoft.BizTalk.GlobalPropertySchemas,  Version=3.0.1.0,  Culture=neutral,  PublicKeyToken=31bf3856ad364e35', N'Url', N'string', 0, 0, N'Url')

INSERT INTO bt_DocumentSpec ([id], itemid, assemblyid, shareid, msgtype, date_modified, body_xpath, is_property_schema, is_multiroot, clr_namespace, clr_typename, clr_assemblyname, schema_root_name, xsd_type, is_tracked, is_flat, property_clr_class)
	VALUES (N'{0E30B953-1DE3-4624-B23A-61779BFA6443}', @gpsitemid, @gpsassemblyid, @documentSpecId, N'http://schemas.microsoft.com/BizTalk/2006/WindowsSharePointServices-properties#ConfigTimeout', GETDATE(), N'', 1, 0, N'WSS', N'bts_WindowsSharePointServices_properties', N'Microsoft.BizTalk.GlobalPropertySchemas,  Version=3.0.1.0,  Culture=neutral,  PublicKeyToken=31bf3856ad364e35', N'ConfigTimeout', N'int', 0, 0, N'ConfigTimeout')

INSERT INTO bt_DocumentSpec ([id], itemid, assemblyid, shareid, msgtype, date_modified, body_xpath, is_property_schema, is_multiroot, clr_namespace, clr_typename, clr_assemblyname, schema_root_name, xsd_type, is_tracked, is_flat, property_clr_class)
	VALUES (N'{E8385E95-43C1-4C72-9C96-7E00347B8662}', @gpsitemid, @gpsassemblyid, @documentSpecId, N'http://schemas.microsoft.com/BizTalk/2006/WindowsSharePointServices-properties#ConfigAdapterWSPort', GETDATE(), N'', 1, 0, N'WSS', N'bts_WindowsSharePointServices_properties', N'Microsoft.BizTalk.GlobalPropertySchemas,  Version=3.0.1.0,  Culture=neutral,  PublicKeyToken=31bf3856ad364e35', N'ConfigAdapterWSPort', N'int', 0, 0, N'ConfigAdapterWSPort')

INSERT INTO bt_DocumentSpec ([id], itemid, assemblyid, shareid, msgtype, date_modified, body_xpath, is_property_schema, is_multiroot, clr_namespace, clr_typename, clr_assemblyname, schema_root_name, xsd_type, is_tracked, is_flat, property_clr_class)
	VALUES (N'{DA0199E3-91EA-4783-B367-85498D57A6D7}', @gpsitemid, @gpsassemblyid, @documentSpecId, N'http://schemas.microsoft.com/BizTalk/2006/WindowsSharePointServices-properties#ConfigTemplatesDocLib', GETDATE(), N'', 1, 0, N'WSS', N'bts_WindowsSharePointServices_properties', N'Microsoft.BizTalk.GlobalPropertySchemas,  Version=3.0.1.0,  Culture=neutral,  PublicKeyToken=31bf3856ad364e35', N'ConfigTemplatesDocLib', N'string', 0, 0, N'ConfigTemplatesDocLib')

INSERT INTO bt_DocumentSpec ([id], itemid, assemblyid, shareid, msgtype, date_modified, body_xpath, is_property_schema, is_multiroot, clr_namespace, clr_typename, clr_assemblyname, schema_root_name, xsd_type, is_tracked, is_flat, property_clr_class)
	VALUES (N'{4B30CA21-6B7B-4D73-A8FA-8AF4B8CEE2A4}', @gpsitemid, @gpsassemblyid, @documentSpecId, N'http://schemas.microsoft.com/BizTalk/2006/WindowsSharePointServices-properties#InListName', GETDATE(), N'', 1, 0, N'WSS', N'bts_WindowsSharePointServices_properties', N'Microsoft.BizTalk.GlobalPropertySchemas,  Version=3.0.1.0,  Culture=neutral,  PublicKeyToken=31bf3856ad364e35', N'InListName', N'string', 0, 0, N'InListName')

INSERT INTO bt_DocumentSpec ([id], itemid, assemblyid, shareid, msgtype, date_modified, body_xpath, is_property_schema, is_multiroot, clr_namespace, clr_typename, clr_assemblyname, schema_root_name, xsd_type, is_tracked, is_flat, property_clr_class)
	VALUES (N'{09FA4D07-BC64-44C9-883D-8F7314593894}', @gpsitemid, @gpsassemblyid, @documentSpecId, N'http://schemas.microsoft.com/BizTalk/2006/WindowsSharePointServices-properties#ConfigOverwrite', GETDATE(), N'', 1, 0, N'WSS', N'bts_WindowsSharePointServices_properties', N'Microsoft.BizTalk.GlobalPropertySchemas,  Version=3.0.1.0,  Culture=neutral,  PublicKeyToken=31bf3856ad364e35', N'ConfigOverwrite', N'string', 0, 0, N'ConfigOverwrite')

INSERT INTO bt_DocumentSpec ([id], itemid, assemblyid, shareid, msgtype, date_modified, body_xpath, is_property_schema, is_multiroot, clr_namespace, clr_typename, clr_assemblyname, schema_root_name, xsd_type, is_tracked, is_flat, property_clr_class)
	VALUES (N'{B1A1F574-5A7C-41AD-90C5-99D32ED83B9D}', @gpsitemid, @gpsassemblyid, @documentSpecId, N'http://schemas.microsoft.com/BizTalk/2006/WindowsSharePointServices-properties#Filename', GETDATE(), N'', 1, 0, N'WSS', N'bts_WindowsSharePointServices_properties', N'Microsoft.BizTalk.GlobalPropertySchemas,  Version=3.0.1.0,  Culture=neutral,  PublicKeyToken=31bf3856ad364e35', N'Filename', N'string', 0, 0, N'Filename')

INSERT INTO bt_DocumentSpec ([id], itemid, assemblyid, shareid, msgtype, date_modified, body_xpath, is_property_schema, is_multiroot, clr_namespace, clr_typename, clr_assemblyname, schema_root_name, xsd_type, is_tracked, is_flat, property_clr_class)
	VALUES (N'{97AD9913-5F5A-4B44-8696-9BE6C4D2C45C}', @gpsitemid, @gpsassemblyid, @documentSpecId, N'http://schemas.microsoft.com/BizTalk/2006/WindowsSharePointServices-properties#InListUrl', GETDATE(), N'', 1, 0, N'WSS', N'bts_WindowsSharePointServices_properties', N'Microsoft.BizTalk.GlobalPropertySchemas,  Version=3.0.1.0,  Culture=neutral,  PublicKeyToken=31bf3856ad364e35', N'InListUrl', N'string', 0, 0, N'InListUrl')

INSERT INTO bt_DocumentSpec ([id], itemid, assemblyid, shareid, msgtype, date_modified, body_xpath, is_property_schema, is_multiroot, clr_namespace, clr_typename, clr_assemblyname, schema_root_name, xsd_type, is_tracked, is_flat, property_clr_class)
	VALUES (N'{8F19936A-EDD3-46CE-A3D5-B9CFD4FA9AE7}', @gpsitemid, @gpsassemblyid, @documentSpecId, N'http://schemas.microsoft.com/BizTalk/2006/WindowsSharePointServices-properties#InEditUrl', GETDATE(), N'', 1, 0, N'WSS', N'bts_WindowsSharePointServices_properties', N'Microsoft.BizTalk.GlobalPropertySchemas,  Version=3.0.1.0,  Culture=neutral,  PublicKeyToken=31bf3856ad364e35', N'InEditUrl', N'string', 0, 0, N'InEditUrl')

INSERT INTO bt_DocumentSpec ([id], itemid, assemblyid, shareid, msgtype, date_modified, body_xpath, is_property_schema, is_multiroot, clr_namespace, clr_typename, clr_assemblyname, schema_root_name, xsd_type, is_tracked, is_flat, property_clr_class)
	VALUES (N'{693171F5-C9E5-4AAC-BF15-BB020C93B4E1}', @gpsitemid, @gpsassemblyid, @documentSpecId, N'http://schemas.microsoft.com/BizTalk/2006/WindowsSharePointServices-properties#ConfigOfficeIntegration', GETDATE(), N'', 1, 0, N'WSS', N'bts_WindowsSharePointServices_properties', N'Microsoft.BizTalk.GlobalPropertySchemas,  Version=3.0.1.0,  Culture=neutral,  PublicKeyToken=31bf3856ad364e35', N'ConfigOfficeIntegration', N'string', 0, 0, N'ConfigOfficeIntegration')

INSERT INTO bt_DocumentSpec ([id], itemid, assemblyid, shareid, msgtype, date_modified, body_xpath, is_property_schema, is_multiroot, clr_namespace, clr_typename, clr_assemblyname, schema_root_name, xsd_type, is_tracked, is_flat, property_clr_class)
	VALUES (N'{11DDA6A5-3AD9-465D-9150-C827E7F4752E}', @gpsitemid, @gpsassemblyid, @documentSpecId, N'http://schemas.microsoft.com/BizTalk/2006/WindowsSharePointServices-properties#ConfigTemplatesNamespaceCol', GETDATE(), N'', 1, 0, N'WSS', N'bts_WindowsSharePointServices_properties', N'Microsoft.BizTalk.GlobalPropertySchemas,  Version=3.0.1.0,  Culture=neutral,  PublicKeyToken=31bf3856ad364e35', N'ConfigTemplatesNamespaceCol', N'string', 0, 0, N'ConfigTemplatesNamespaceCol')

INSERT INTO bt_DocumentSpec ([id], itemid, assemblyid, shareid, msgtype, date_modified, body_xpath, is_property_schema, is_multiroot, clr_namespace, clr_typename, clr_assemblyname, schema_root_name, xsd_type, is_tracked, is_flat, property_clr_class)
	VALUES (N'{5CDF8927-9529-45CE-8837-CAF9184EA33A}', @gpsitemid, @gpsassemblyid, @documentSpecId, N'http://schemas.microsoft.com/BizTalk/2006/WindowsSharePointServices-properties#InCreatedBy', GETDATE(), N'', 1, 0, N'WSS', N'bts_WindowsSharePointServices_properties', N'Microsoft.BizTalk.GlobalPropertySchemas,  Version=3.0.1.0,  Culture=neutral,  PublicKeyToken=31bf3856ad364e35', N'InCreatedBy', N'string', 0, 0, N'InCreatedBy')

INSERT INTO bt_DocumentSpec ([id], itemid, assemblyid, shareid, msgtype, date_modified, body_xpath, is_property_schema, is_multiroot, clr_namespace, clr_typename, clr_assemblyname, schema_root_name, xsd_type, is_tracked, is_flat, property_clr_class)
	VALUES (N'{E09B1F57-F8A3-459E-9900-D8FC0BC0958C}', @gpsitemid, @gpsassemblyid, @documentSpecId, N'http://schemas.microsoft.com/BizTalk/2006/WindowsSharePointServices-properties#InItemId', GETDATE(), N'', 1, 0, N'WSS', N'bts_WindowsSharePointServices_properties', N'Microsoft.BizTalk.GlobalPropertySchemas,  Version=3.0.1.0,  Culture=neutral,  PublicKeyToken=31bf3856ad364e35', N'InItemId', N'int', 0, 0, N'InItemId')

INSERT INTO bt_DocumentSpec ([id], itemid, assemblyid, shareid, msgtype, date_modified, body_xpath, is_property_schema, is_multiroot, clr_namespace, clr_typename, clr_assemblyname, schema_root_name, xsd_type, is_tracked, is_flat, property_clr_class)
	VALUES (N'{A467F7EC-297A-44B9-BB3F-EE81E12B8990}', @gpsitemid, @gpsassemblyid, @documentSpecId, N'http://schemas.microsoft.com/BizTalk/2006/WindowsSharePointServices-properties#InLastModifiedBy', GETDATE(), N'', 1, 0, N'WSS', N'bts_WindowsSharePointServices_properties', N'Microsoft.BizTalk.GlobalPropertySchemas,  Version=3.0.1.0,  Culture=neutral,  PublicKeyToken=31bf3856ad364e35', N'InLastModifiedBy', N'string', 0, 0, N'InLastModifiedBy')

INSERT INTO bt_DocumentSpec ([id], itemid, assemblyid, shareid, msgtype, date_modified, body_xpath, is_property_schema, is_multiroot, clr_namespace, clr_typename, clr_assemblyname, schema_root_name, xsd_type, is_tracked, is_flat, property_clr_class)
	VALUES (N'{A6C005E9-EB59-486F-9B6B-F2801DE5E95A}', @gpsitemid, @gpsassemblyid, @documentSpecId, N'http://schemas.microsoft.com/BizTalk/2006/WindowsSharePointServices-properties#InFileSize', GETDATE(), N'', 1, 0, N'WSS', N'bts_WindowsSharePointServices_properties', N'Microsoft.BizTalk.GlobalPropertySchemas,  Version=3.0.1.0,  Culture=neutral,  PublicKeyToken=31bf3856ad364e35', N'InFileSize', N'int', 0, 0, N'InFileSize')

INSERT INTO bt_DocumentSpec ([id], itemid, assemblyid, shareid, msgtype, date_modified, body_xpath, is_property_schema, is_multiroot, clr_namespace, clr_typename, clr_assemblyname, schema_root_name, xsd_type, is_tracked, is_flat, property_clr_class)
	VALUES (N'{6747403C-D444-470D-A65E-FD5732E7BEDA}', @gpsitemid, @gpsassemblyid, @documentSpecId, N'http://schemas.microsoft.com/BizTalk/2006/WindowsSharePointServices-properties#InCreated', GETDATE(), N'', 1, 0, N'WSS', N'bts_WindowsSharePointServices_properties', N'Microsoft.BizTalk.GlobalPropertySchemas,  Version=3.0.1.0,  Culture=neutral,  PublicKeyToken=31bf3856ad364e35', N'InCreated', N'dateTime', 0, 0, N'InCreated')

INSERT INTO bt_DocumentSpec ([id], itemid, assemblyid, shareid, msgtype, date_modified, body_xpath, is_property_schema, is_multiroot, clr_namespace, clr_typename, clr_assemblyname, schema_root_name, xsd_type, is_tracked, is_flat, property_clr_class)
	VALUES (N'{A790C580-6D5B-4FF0-9EA9-FE66D62B43C8}', @gpsitemid, @gpsassemblyid, @documentSpecId, N'http://schemas.microsoft.com/BizTalk/2006/WindowsSharePointServices-properties#ConfigCustomTemplatesNamespaceCol', GETDATE(), N'', 1, 0, N'WSS', N'bts_WindowsSharePointServices_properties', N'Microsoft.BizTalk.GlobalPropertySchemas,  Version=3.0.1.0,  Culture=neutral,  PublicKeyToken=31bf3856ad364e35', N'ConfigCustomTemplatesNamespaceCol', N'string', 0, 0, N'ConfigCustomTemplatesNamespaceCol')

INSERT INTO bt_DocumentSpec ([id], itemid, assemblyid, shareid, msgtype, date_modified, body_xpath, is_property_schema, is_multiroot, clr_namespace, clr_typename, clr_assemblyname, schema_root_name, xsd_type, is_tracked, is_flat, property_clr_class)
	VALUES (N'{D94730A6-8DDA-4405-B526-FF14B0DAA324}', @gpsitemid, @gpsassemblyid, @documentSpecId, N'http://schemas.microsoft.com/BizTalk/2006/WindowsSharePointServices-properties#InTitle', GETDATE(), N'', 1, 0, N'WSS', N'bts_WindowsSharePointServices_properties', N'Microsoft.BizTalk.GlobalPropertySchemas,  Version=3.0.1.0,  Culture=neutral,  PublicKeyToken=31bf3856ad364e35', N'InTitle', N'string', 0, 0, N'InTitle')



