//-----------------------------------------------------------------------
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------
// AtlasCompat2.js
// Atlas Compat Framework (Part 2).
function _loadSafariCompat2Layer(w){Sys.TypeDescriptor.prototype._addEvent =Sys.TypeDescriptor.prototype.addEvent;Sys.TypeDescriptor.prototype._addProperty =Sys.TypeDescriptor.prototype.addProperty;Sys.TypeDescriptor.prototype._addMethod =Sys.TypeDescriptor.prototype.addMethod;Sys.TypeDescriptor._createParameter =Sys.TypeDescriptor.createParameter;Sys.TypeDescriptor._addType =Sys.TypeDescriptor.addType;Sys.TypeDescriptor.prototype.addEvent =function(eventName,supportsActions){this._addEvent(eventName,supportsActions);var lcEventName =eventName.toLowerCase();if (eventName !=lcEventName){this._addEvent(lcEventName,supportsActions);this._getEvents()[lcEventName].name =eventName;}
}
Sys.TypeDescriptor.prototype.addProperty =function(propertyName,propertyType,readOnly){this._addProperty.apply(this,arguments);var lcPropertyName =propertyName.toLowerCase();if (propertyName !=lcPropertyName){var baseArguments =[];baseArguments.add(lcPropertyName);for (var a =1;a <arguments.length;a++){baseArguments.add(arguments[a]);}
this._addProperty.apply(this,baseArguments);this._getProperties()[lcPropertyName].name =propertyName;}
}
Sys.TypeDescriptor.prototype.addMethod =function(methodName,associatedParameters){if (associatedParameters){for (var i =associatedParameters.length -1;i >=0;i--){associatedParameters[i].name =associatedParameters[i].name.toLowerCase();}
}
this._addMethod(methodName,associatedParameters);}
Sys.TypeDescriptor.createParameter =function(parameterName,parameterType){return Sys.TypeDescriptor._createParameter(parameterName.toLowerCase(),parameterType);}
Sys.TypeDescriptor.addType =function(tagPrefix,tagName,type,lowerCaseOnly){if (!lowerCaseOnly){Sys.TypeDescriptor._addType(tagPrefix,tagName,type);}
var lcTagName =tagName.toLowerCase();if (tagName !=lcTagName){Sys.TypeDescriptor._addType(tagPrefix,lcTagName,type);}
if (lcTagName =="image"){Sys.TypeDescriptor._addType(tagPrefix,"image_",type);}
}
if (Sys.TypeDescriptor._registeredTags !=null){var tagTable;for (var tagPrefix in Sys.TypeDescriptor._registeredTags){tagTable =Sys.TypeDescriptor._registeredTags[tagPrefix];for (var tagName in tagTable){if (typeof(tagTable[tagName])=="function"){Sys.TypeDescriptor.addType(tagPrefix,tagName,tagTable[tagName],true);}
}
}
}
}
if (window.__safari){_loadSafariCompat2Layer(window);}
