//-----------------------------------------------------------------------
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------
// AtlasRuntime.js
// Atlas Runtime Framework.


//-----------------------------------------------------------------------
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------
// AtlasRuntime.js
// Atlas Runtime Framework.


var RuntimeVersion = "2.021006.A";



Function.abstractMethod = function() {
    throw 'Abstract method should be implemented';
}

Function.createCallback = function(method, context) {
    return function() {
        return method(context);
    }
}

Function.createDelegate = function(instance, method) {
    return function() {
        return method.apply(instance, arguments);
    }
}

Function.emptyFunction = Function.emptyMethod = function() {
}

Function.prototype.getBaseMethod = function(instance, methodName, baseTypeName) {
    var baseType = baseTypeName ? Function.parse(baseTypeName) : this.getBaseType();
    var baseMethod = null;

    if (baseType) {
        var directBaseType = baseType;
        
        if (instance._baseMethods) {
                        
            while (baseType) {
                var methodKey = baseType.getName() + '.' + methodName;
                var method = instance._baseMethods[methodKey];
                if (method) {
                    return method;
                }

                baseType = baseType._baseType;
            }
        }

        if (!baseMethod) {
            return directBaseType.prototype[methodName];
        }
    }
    
    return null;
}

Function.prototype.getBaseType = function() {
    return this._baseType;
}

Function.prototype.getName = function() {
    return this._typeName;
}

Function.parse = function(functionName) {
    if (!Function._htClasses) {
        Function._htClasses = {};
    }
    var fn = Function._htClasses[functionName];
    if (!fn) {
        try {
            eval('fn = ' + functionName);
            if (typeof(fn) != 'function') {
                fn = null;
            }
            else {
                Function._htClasses[functionName] = fn;
            }
        }
        catch (ex) {
        }
    }
    return fn;
}

Function.prototype._copyProps = function(p_objFnc) {
    for (var strName in p_objFnc.prototype) {
        var vValue = p_objFnc.prototype[strName];
        if (!this.prototype[strName]) {
            this.prototype[strName] = vValue;
        }
    }
}

Function.prototype._setBases = function(p_objRoot) {
    if (p_objRoot._basePrototypePending) {
                var astrPending = this.prototype._astrPendingInherits || [];    
        for (var i=0; i < astrPending.length; i++) {

            var fncType = astrPending[i] instanceof Function ? astrPending[i] : Function.parse(astrPending[i]);

                        if (!fncType._parentBase) {
                fncType._parentBase= [];
            }
            fncType._parentBase.push(p_objRoot._typeName);
            if (!p_objRoot._childBase) {
                p_objRoot._childBase= [];
            }
            p_objRoot._childBase.push(fncType._typeName);

                        
            if (fncType && (this != fncType) && (!this.inheritsFrom(fncType)) && (!fncType.inheritsFrom(this)) && !fncType._sealed) {
                if (!fncType._typeName) {
                    fncType._typeName = typeof(astrPending[i])=="function" ? astrPending[i]._typeName : astrPending[i];
                }
                if (!this.bases) {
                    this.bases = [];
                }
                this.bases.push(fncType);
                fncType._setBases(p_objRoot);
                this._copyProps(fncType);
            }
        }
    }
    this._basePrototypePending = false;
}

Function.prototype._callBaseConstructors = function(p_objInstance, p_objArgs) {
    if (this.bases) {
        for (var i=0; i < this.bases.length; i++) {                    
            if (p_objArgs) {
                this.bases[i].apply(p_objInstance, p_objArgs);
            }
            else {
                this.bases[i].apply(p_objInstance);
            }
        }
    }
}

Function.prototype.callBaseMethod = function(instance, methodName, baseArguments) {
    var baseMethod = this.getBaseMethod(instance, methodName);
    if (baseMethod) {
        if (!baseArguments) {
            return baseMethod.apply(instance);
        }
        else {
            return baseMethod.apply(instance, baseArguments);
        }
    }
    
    return null;
}

Function.prototype.implementsInterface = function(interfaceType) {
    this._setBases(this);
    var interfaces = this._interfaces;
    if (interfaces) {
        if (interfaces.contains(interfaceType)) {
            return true;
        }
    }
    if (this.bases)
    {
        for (var i=0; i < this.bases.length; i++)
        {
            if (this.bases[i].implementsInterface(interfaceType))
            {
                return true;
            }
        }
    }
    
    return false;
}

Function.prototype.inheritsFrom = function(parentType) {
    if (parentType == this) {
        return true;
    }
    if (!this._basesPending) {
        this._basesPending = true;
        this._setBases(this);
        delete this._basesPending;
    }
    if (this.bases) {
        for (var i = 0; i < this.bases.length; i++) {
            if (this.bases[i].inheritsFrom(parentType)) {
                return true;
            }
        }
    }
    
    return false;
}

Function.prototype.initializeBase = function(instance, baseArguments) {
                    
    if (this._interfaces) {
        for (var i = 0; i < this._interfaces.length; i++) {
            this._interfaces[i].call(instance);
        }
    }

    if (!this._parentBase)        {
        this._parentBase = [];
        this._parentBase.push(this._typeName);
        this._childBase = [];
        this._childBase.push(this._typeName);
    } 
    
    this._setBases(this);
    this._callBaseConstructors(instance, baseArguments);
    
    return instance;
}

Function.prototype.isImplementedBy = function(instance) {
    if (!instance) return false;
    var instanceType = Object.getType(instance);
    if (!instanceType.implementsInterface) {
        return false;
    }
    return instanceType.implementsInterface(this);
}

Function.prototype.isInstanceOfType = function(instance) {
    if (typeof(instance) == 'undefined' || instance == null) {
        return false;
    }

    if (instance instanceof this) {
        return true;
    }
    
    var instanceType = Object.getType(instance);
    if (instanceType == this) {
        return true;
    }
    if (!instanceType.inheritsFrom) {
        return false;
    }
    return instanceType.inheritsFrom(this);
}

Function.prototype.registerBaseMethod = function(instance, methodName) {
            
    if (!instance._baseMethods) {
        instance._baseMethods = { };
    }
    var methodKey = this.getName() + '.' + methodName;
    instance._baseMethods[methodKey] = instance[methodName];
}

Function.createInstance = function(type) {
    if (typeof(type) != 'function') {
        type = Function.parse(type);
    }
    
    return new type();
}

Function.prototype.registerClass = function(typeName, baseType, interfaceType) {
        
    if (window.__safari) {
        this.prototype.constructor = this;
    }
    this._typeName = typeName;
    if (baseType) {
        this._baseType = baseType;
        if (!(baseType instanceof Array)) {
            baseType = [baseType];
        }
        if (!this.prototype._astrPendingInherits) {
            this.prototype._astrPendingInherits = [];
        }
        for (var i=0; i < baseType.length; i++) {
            this.prototype._astrPendingInherits.push(baseType[i]);
        }
        this._basePrototypePending = true;
    }
    
    if (interfaceType) {
        this._interfaces = [];
        for (var i = 2; i < arguments.length; i++) {
            interfaceType = arguments[i];
            this._interfaces.push(interfaceType);
        }
    }

    return this;
}

Function.prototype.registerAbstractClass = function(typeName, baseType) {
    this.registerClass.apply(this, arguments);
    this._abstract = true;
    
    return this;
}

Function.prototype.registerSealedClass = function(typeName, baseType) {
    this.registerClass.apply(this, arguments);
    this._sealed = true;
    
    return this;
}

Function.prototype.registerInterface = function(typeName) {
    this._typeName = typeName;
    this._interface = true;
    this._abstract = true;
    this._sealed = true;
    
    return this;
}

var registerNamespace = Function.registerNamespace = function(namespacePath) {
    var rootObject = window;
    var namespaceParts = namespacePath.split('.');
    
    for (var i = 0; i < namespaceParts.length; i++) {
        var currentPart = namespaceParts[i];
        if (!rootObject[currentPart]) {
            rootObject[currentPart] = new Object();
        }
        rootObject = rootObject[currentPart];
    }
}

Function._typeName = 'Function';

window.Type = Function;



Object.getType = function(instance) {
    var ctor = instance.constructor;
    if (!ctor || (typeof(ctor) != "function") || !ctor._typeName) {
        return Object;
    }
    return instance.constructor;
}

Object.getTypeName = function(instance) {
    return Object.getType(instance).getName();
}

Object._typeName = 'Object';

Boolean.parse = function(value) {
    if (typeof(value) == 'string') {
        return (value.trim().toLowerCase() == 'true');
    }
    return value ? true : false;
}

Boolean._typeName = 'Boolean';

Number.parse = function(value) {
    if (!value || (value.length == 0)) {
        return 0;
    }
    return parseFloat(value);
}

Number._typeName = 'Number';

String.prototype.endsWith = function(suffix) {
    return (this.substr(this.length - suffix.length) == suffix);
}
String.prototype.startsWith = function(prefix) {
    return (this.substr(0, prefix.length) == prefix);
}
String.prototype.lTrim = String.prototype.trimLeft = function() {
    return this.replace(/^\s*/, "");
}
String.prototype.rTrim = String.prototype.trimRight = function() {
    return this.replace(/\s*$/, "");
}
String.prototype.trim = function() {
    return this.trimRight().trimLeft();
}

String.format = function(format) {
    var result = "";
    
    for (var i=0;;) {
                var next = format.indexOf("{", i);
        if (next < 0) {
                        result += format.slice(i);
            break;
        }
        
                result += format.slice(i, next);
        i = next+1;
        
                if (format.charAt(i) == '{') {
            result += '{';
            i++;
            continue;
        }
        
                var next = format.indexOf("}", i);
        
                var brace = format.slice(i, next).split(':');
        
        var argNumber = Number.parse(brace[0])+1;
        var arg = arguments[argNumber];
        if (arg == null) {
            arg = '';
        }

                if (arg.toFormattedString)
            result += arg.toFormattedString(brace[1] ? brace[1] : '');
        else
            result += arg.toString();
        
        i = next+1;
    }
    
    return result;
}

String.localeFormat = function(format) {
    for (var i = 1; i < arguments.length; i++) {
        var arg = arguments[i];
        if (arg == null) {
            arg = '';
        }
        format = format.replace("{" + (i - 1) + "}", arg.toLocaleString());
    }
    return format;
}

String._typeName = 'String';

Array.prototype.add = Array.prototype.queue = function(item) {
    this.push(item);
}
Array.prototype.addRange = function(items) {
    var length = items.length;
    
    if (length != 0) {
        for (var index = 0; index < length; index++) {
            this.push(items[index]);
        }
    }
}
Array.prototype.clear = function() {
    if (this.length > 0) {
        this.splice(0, this.length);
    }
}
Array.prototype.clone = function() {
    var clonedArray = [];
    
    var length = this.length;
    for (var index = 0; index < length; index++) {
        clonedArray[index] = this[index];
    }
    return clonedArray;
}
Array.prototype.contains = Array.prototype.exists = function(item) {
    var index = this.indexOf(item);
    return (index >= 0);
}
Array.prototype.dequeue = function() {
    return this.shift();
}
if (!Array.prototype.indexOf) {
    Array.prototype.indexOf = function(item, startIndex) {
        var length = this.length;
        if (length != 0) {
                        startIndex = startIndex || 0;
                        if (startIndex < 0) {
                startIndex = Math.max(0, length + startIndex);
            }
            for (var i = startIndex; i < length; i++) {
                if (this[i] == item) {
                    return i;
                }
            }
        }
        return -1;
    }
}
if (!Array.prototype.forEach) {
    Array.prototype.forEach = function(fnCb, context) {
        var length = this.length;
        for (var i = 0; i < length; i++) {
            fnCb.call(context, this[i], i, this);
        }
    }
}
Array.prototype.insert = function(index, item) {
    this.splice(index, 0, item);
}
Array.prototype.remove = function(item) {
    var index = this.indexOf(item);
    if (index >= 0) {
        this.splice(index, 1);
    }
    return (index >= 0);
}
Array.prototype.removeAt = function(index) {
    this.splice(index, 1);
}

Array._typeName = 'Array';

Array.parse = function(value) {
    return eval('(' + value + ')');
}

RegExp.parse = function(value) {
    if (value.startsWith('/')) {
        var endSlashIndex = value.lastIndexOf('/');
        if (endSlashIndex > 1) {
            var expression = value.substring(1, endSlashIndex);
            var flags = value.substr(endSlashIndex + 1);
            return new RegExp(expression, flags);
        }
    }

    return null;    
}

RegExp._typeName = 'RegExp';

Date._typeName = 'Date';

Error.createError = function(message, details, innerError) {
    var e = new Error(message);

    if (details && details.length) {
        e.details = details;
    }
    if (innerError) {
        e.innerError = innerError;
    }

    return e;
}

Error._typeName = 'Error';



Type.registerNamespace('Sys');


Type.createEnum = function(name) {

    function getValues() {
        if (!enumeration._values) {
            var values = { };
            
            for (var f in enumeration) {
                if (typeof(enumeration[f]) != 'function') {
                    values[f] = enumeration[f];
                }
            }
            enumeration._values = values;
        }
        return enumeration._values;
    }

    function valueFromString(s) {
        if (s) {
            for (var f in enumeration) {
                if (f.toLowerCase() === s.toLowerCase()) {
                    return enumeration[f];
                }
            }
        }
        return null;
    }

    function valueToString(value) {
        for (var i in enumeration) {
            if (enumeration[i] === value) {
                return i;
            }
        }
        throw Error.createError('Invalid Enumeration Value');
    }
    
    var enumeration = {};
        if (name) {
        eval('enumeration=' + name + '={};');
    }
    enumeration.getValues = getValues;
    enumeration.parse = valueFromString;
    enumeration.toString = valueToString;
    enumeration.getName = function() {return name;}
    enumeration.isEnum = function() {return true;}
    
    for (var i = 1; i < arguments.length; i += 2) {
        enumeration[arguments[i]] = arguments[i + 1];
    }
    
    return enumeration;
}

Type.createFlags = function(name) {

    function valueFromString(s) {
        var parts = s.split('|');
        var value = 0;
        
        for (var i = parts.length - 1; i >= 0; i--) {
            var part = parts[i].trim();
            var found = false;
            
            for (var f in flags) {
                if (f == part) {
                    value |= flags[f];
                    found = true;
                    break;
                }
            }
            if (found == false) {
                throw 'Invalid Enumeration Value';
            }
        }
        
        return value;
    }

    function valueToString(value) {
        var sb = new Sys.StringBuilder();
        for (var i in flags) {
            if ((flags[i] & value) != 0) {
                if (sb.isEmpty() == false) {
                    sb.append(' | ');
                }
                sb.append(i);
            }
        }
        return sb.toString();
    }

    var flags = {};
    if (name) {
        eval('flags=' + name + '={};');
    }
    flags.parse = valueFromString;
    flags.toString = valueToString;
    flags.getName = function() {return name;}
    flags.isFlags = function() {return true;}
    
    for (var i = 1; i < arguments.length; i += 2) {
        flags[arguments[i]] = arguments[i + 1];
    }
    
    return flags;
}

Sys.IArray = function() {
    this.get_length = Function.abstractMethod;
    this.getItem = Function.abstractMethod;
}
Sys.IArray.registerInterface("Sys.IArray");

Array.prototype.get_length = function() {
    return this.length;
}

Array.prototype.getItem = function(index) {
    return this[index];
}

Array._interfaces = [];
Array._interfaces.push(Sys.IArray);


Sys.IDisposable = function() {
    this.dispose = Function.abstractMethod;
}
Sys.IDisposable.registerInterface('Sys.IDisposable');

Sys.CultureInfo = {"Name":"en-US","NumberFormat":{"CurrencyDecimalDigits":2,"CurrencyDecimalSeparator":".","IsReadOnly":false,"CurrencyGroupSizes":[3],"NumberGroupSizes":[3],"PercentGroupSizes":[3],"CurrencyGroupSeparator":",","CurrencySymbol":"$","NaNSymbol":"NaN","CurrencyNegativePattern":0,"NumberNegativePattern":1,"PercentPositivePattern":0,"PercentNegativePattern":0,"NegativeInfinitySymbol":"-Infinity","NegativeSign":"-","NumberDecimalDigits":2,"NumberDecimalSeparator":".","NumberGroupSeparator":",","CurrencyPositivePattern":0,"PositiveInfinitySymbol":"Infinity","PositiveSign":"+","PercentDecimalDigits":2,"PercentDecimalSeparator":".","PercentGroupSeparator":",","PercentSymbol":"%","PerMilleSymbol":"","NativeDigits":["0","1","2","3","4","5","6","7","8","9"],"DigitSubstitution":1},"DateTimeFormat":{"AMDesignator":"AM","Calendar":{"MinSupportedDateTime":new Date(-59011459200000),"MaxSupportedDateTime":new Date(253402300799999),"AlgorithmType":1,"CalendarType":1,"Eras":[1],"TwoDigitYearMax":2029,"IsReadOnly":false},"DateSeparator":"/","FirstDayOfWeek":0,"CalendarWeekRule":0,"FullDateTimePattern":"dddd, MMMM dd, yyyy h:mm:ss tt","LongDatePattern":"dddd, MMMM dd, yyyy","LongTimePattern":"h:mm:ss tt","MonthDayPattern":"MMMM dd","PMDesignator":"PM","RFC1123Pattern":"ddd, dd MMM yyyy HH\':\'mm\':\'ss \'GMT\'","ShortDatePattern":"M/d/yyyy","ShortTimePattern":"h:mm tt","SortableDateTimePattern":"yyyy\'-\'MM\'-\'dd\'T\'HH\':\'mm\':\'ss","TimeSeparator":":","UniversalSortableDateTimePattern":"yyyy\'-\'MM\'-\'dd HH\':\'mm\':\'ss\'Z\'","YearMonthPattern":"MMMM, yyyy","AbbreviatedDayNames":["Sun","Mon","Tue","Wed","Thu","Fri","Sat"],"ShortestDayNames":["Su","Mo","Tu","We","Th","Fr","Sa"],"DayNames":["Sunday","Monday","Tuesday","Wednesday","Thursday","Friday","Saturday"],"AbbreviatedMonthNames":["Jan","Feb","Mar","Apr","May","Jun","Jul","Aug","Sep","Oct","Nov","Dec",""],"MonthNames":["January","February","March","April","May","June","July","August","September","October","November","December",""],"IsReadOnly":false,"NativeCalendarName":"Gregorian Calendar","AbbreviatedMonthGenitiveNames":["Jan","Feb","Mar","Apr","May","Jun","Jul","Aug","Sep","Oct","Nov","Dec",""],"MonthGenitiveNames":["January","February","March","April","May","June","July","August","September","October","November","December",""]}};

Sys.StringBuilder = function(initialText) {
    var _parts = new Array();
    
    if ((typeof(initialText) == 'string') &&
        (initialText.length != 0)) {
        _parts.push(initialText);
    }

    this.append = function(text) {
        if ((text == null) || (typeof(text) == 'undefined')) {
            return;
        }
        if ((typeof(text) == 'string') && (text.length == 0)) {
            return;
        }
        
        _parts.push(text);
    }

    this.appendLine = function(text) {
        this.append(text);
        _parts.push('\r\n');
    }

    this.clear = function() {
        _parts.clear();
    }

    this.isEmpty = function() {
        return (_parts.length == 0);
    }

    this.toString = function(delimiter) {
        return _parts.join(delimiter || '');
    }
}
Sys.StringBuilder.registerSealedClass('Sys.StringBuilder');
if (!window.XMLHttpRequest) {
    window.XMLHttpRequest = function() {
        var progIDs = [ 'Msxml2.XMLHTTP', 'Microsoft.XMLHTTP' ];
	    
        for (var i = 0; i < progIDs.length; i++) {
            try {
                var xmlHttp = new ActiveXObject(progIDs[i]);
                return xmlHttp;
            }
            catch (ex) {
            }
        }
	    
        return null;
    }
}

Date.prototype.toFormattedString = function(format) {

    var dtf = Sys.CultureInfo.DateTimeFormat;

        if (!format)
        format = "F";

    if (format.length == 1) {
        switch (format) {
        case "d":
            format = dtf.ShortDatePattern;
            break;
        case "D":
            format = dtf.LongDatePattern;
            break;
        case "t":
            format = dtf.ShortTimePattern;
            break;
        case "T":
            format = dtf.LongTimePattern;
            break;
        case "F":
            format = dtf.FullDateTimePattern;
            break;
        case "M": case "m":
            format = dtf.MonthDayPattern;
            break;
        case "s":
            format = dtf.SortableDateTimePattern;
            break;
        case "Y": case "y":
            format = dtf.YearMonthPattern;
            break;
        default:
            throw Error.createError("'" + format + "' is not a valid date format");
        }
    }

    var regex = /dddd|ddd|dd|d|MMMM|MMM|MM|M|yyyy|yy|y|hh|h|HH|H|mm|m|ss|s|tt|t|fff|ff|f|zzz|zz|z/g;

        var ret = "";
    var hour;

    function addLeadingZero(num) {
        if (num < 10) {
            return '0' + num;
        }
        return num.toString();
    }

    function addLeadingZeros(num) {
        if (num < 10) {
            return '00' + num;
        }
        if (num < 100) {
            return '0' + num;
        }
        return num.toString();
    }

    for (;;) {

                var index = regex.lastIndex;

                var ar = regex.exec(format);

                ret += format.slice(index, ar ? ar.index : format.length);

        if (!ar) break;

        switch (ar[0]) {
        case "dddd":
                        ret += dtf.DayNames[this.getDay()];
            break;
        case "ddd":
                        ret += dtf.AbbreviatedDayNames[this.getDay()];
            break;
        case "dd":
                        ret += addLeadingZero(this.getDate());
            break;
        case "d":
                        ret += this.getDate();
            break;
        case "MMMM":
                        ret += dtf.MonthNames[this.getMonth()];
            break;
        case "MMM":
                        ret += dtf.AbbreviatedMonthNames[this.getMonth()];
            break;
        case "MM":
                        ret += addLeadingZero(this.getMonth() + 1);
            break;
        case "M":
                        ret += this.getMonth() + 1;
            break;
        case "yyyy":
                        ret += this.getFullYear();
            break;
        case "yy":
                        ret += addLeadingZero(this.getFullYear() % 100);
            break;
        case "y":
                        ret += this.getFullYear() % 100;
            break;
        case "hh":
                        hour = this.getHours() % 12;
            if (hour == 0) hour = 12;
            ret += addLeadingZero(hour);
            break;
        case "h":
                        hour = this.getHours() % 12;
            if (hour == 0) hour = 12;
            ret += hour;
            break;
        case "HH":
                        ret += addLeadingZero(this.getHours());
            break;
        case "H":
                        ret += this.getHours();
            break;
        case "mm":
                        ret += addLeadingZero(this.getMinutes());
            break;
        case "m":
                        ret += this.getMinutes();
            break;
        case "ss":
                        ret += addLeadingZero(this.getSeconds());
            break;
        case "s":
                        ret += this.getSeconds();
            break;
        case "tt":
                        ret += (this.getHours() < 12) ? dtf.AMDesignator : dtf.PMDesignator;
            break;
        case "t":
                        ret += ((this.getHours() < 12) ? dtf.AMDesignator : dtf.PMDesignator).charAt(0);
            break;
        case "f":
                        ret += addLeadingZeros(this.getMilliseconds()).charAt(0);
            break;
        case "ff":
                        ret += addLeadingZeros(this.getMilliseconds()).substr(0, 2);
            break;
        case "fff":
                        ret += addLeadingZeros(this.getMilliseconds());
            break;
        case "z":
                        hour = this.getTimezoneOffset() / 60;
            ret += ((hour >= 0) ? '+' : '-') + Math.floor(Math.abs(hour));
            break;
        case "zz":
                        hour = this.getTimezoneOffset() / 60;
            ret += ((hour >= 0) ? '+' : '-') + addLeadingZero(Math.floor(Math.abs(hour)));
            break;
        case "zzz":
                        hour = this.getTimezoneOffset() / 60;
            ret += ((hour >= 0) ? '+' : '-') + addLeadingZero(Math.floor(Math.abs(hour))) +
                dtf.TimeSeparator + addLeadingZero(Math.abs(this.getTimezoneOffset() % 60));
            break;
        default:
            debug.assert(false);
        }
    }
    return ret;
}

Type.createEnum('Sys.ActionSequence', 'BeforeEventHandler', 0, 'AfterEventHandler', 1);
Sys.IAction = function() {
    this.get_sequence = Function.abstractMethod;
    this.execute = Function.abstractMethod;
    this.setOwner = Function.abstractMethod;
}
Sys.IAction.registerInterface('Sys.IAction');

Type.Event = function(owner, autoInvoke) {
    var _owner = owner;
    var _handlers = null;
    var _actions = null;
    var _autoInvoke = autoInvoke;
    var _invoked = false;
    
    this.get_autoInvoke = function() {
        return _autoInvoke;
    }
    
    this._getActions = function() {
if (_actions && _actions.length && !_owner) throw "Actions are only supported on events that have an owner.";
        if (_actions == null) {
            _actions = [];
        }
        return _actions;
    }
    this._getHandlers = function() {
        if (_handlers == null) {
            _handlers = [];
        }
        return _handlers;
    }
    this._getOwner = function() {
        return _owner;
    }
    
    this.isActive = function() {
        return ((_handlers != null) && (_handlers.length != 0)) ||
               ((_actions != null) && (_actions.length != 0));
    }
    
    this.get_isInvoked = function() {
        return _invoked;
    }
    
    this.dispose = function() {
        if (_handlers) {
            for (var h = _handlers.length - 1; h >= 0; h--) {
                _handlers[h] = null;
            }
            _handlers = null;
        }
        if (_actions) {
            for (var i = _actions.length - 1; i >= 0; i--) {
                _actions[i].dispose();
            }
            _actions = null;
        }
        
        _owner = null;
    }
    
    this._setInvoked = function(value) {
        _invoked = true;
    }
}
Type.Event.registerSealedClass('Type.Event', null, Sys.IDisposable);

Type.Event.prototype.add = function(handler) {
    this._getHandlers().add(handler);
    if (this.get_autoInvoke() && this.get_isInvoked()) {
        handler(this._getOwner(), null);
    }
}
Type.Event.prototype.addAction = function(action) {
    action.setOwner(this._getOwner());
    this._getActions().add(action);
}
Type.Event.prototype.remove = function(handler) {
    this._getHandlers().remove(handler);
}
Type.Event.prototype.removeAction = function(action) {
    action.dispose();
    this._getActions().remove(action);
}
Type.Event.prototype.invoke = function(sender, eventArgs) {
    if (this.isActive()) {
        var actions = this._getActions();
        var handlers = this._getHandlers();
        var hasPostActions = false;
        var i;
        
        for (i = 0; i < actions.length; i++) {
            if (actions[i].get_sequence() == Sys.ActionSequence.BeforeEventHandler) {
                actions[i].execute(sender, eventArgs);
            }
            else {
                hasPostActions = true;
            }
        }

        for (i = 0; i < handlers.length; i++) {
            handlers[i](sender, eventArgs);
        }
        
        if (hasPostActions) {
            for (i = 0; i < actions.length; i++) {
                if (actions[i].get_sequence() == Sys.ActionSequence.AfterEventHandler) {
                    actions[i].execute(sender, eventArgs);
                }
            }
        }
        
        this._setInvoked();
    }
}

Type.createEnum('Sys.HostType', 'Other', 0, 'InternetExplorer', 1, 'Firefox', 2);

Sys.Runtime = new function() {

    var _isBrowser = false;
    var _hostType = Sys.HostType.Other;
    
    var _initialized = false;
    var _disposed = false;
    var _unloading = false;

    var _disposableObjects = [];

    try {
        _isBrowser = (window != null);
    }
    catch (e) {
    }

    if (_isBrowser) {
        if (navigator.userAgent.indexOf('MSIE') != -1) {
            _hostType = Sys.HostType.InternetExplorer;
        }
        else if (navigator.userAgent.indexOf('Firefox') != -1) {
            _hostType = Sys.HostType.Firefox;
        }
        
        window.attachEvent('onload', onWindowLoad);
        window.attachEvent('onunload', onWindowUnload);
    }

    
    this.get_hostName = function() {
        if (_isBrowser) {
            return navigator.userAgent;
        }
        return '';
    }

    this.get_hostType = function() {
        return _hostType;
    }
    
    this.load = new Type.Event( null,  true);
    this.unload = new Type.Event( null,  true);

    this.dispose = function() {
        if (_isBrowser) {
            window.detachEvent('onunload', onWindowUnload);
        }
        if (_disposed == false) {
            _disposed = true;
            Sys.Runtime.unload.invoke(Sys.Runtime, null);

            if (_disposableObjects.length) {
                _unloading = true;
                var count = _disposableObjects.length;
                for (var i = 0; i < count; i++) {
                    _disposableObjects[i].dispose();
                }
                _disposableObjects.clear();
            }
        }
    }
    
    this.initialize = function() {
        if (_isBrowser) {
            window.detachEvent('onload', onWindowLoad);
        }
        if (_initialized == false) {
            _initialized = true;
            Sys.Runtime.load.invoke(Sys.Runtime, null);
        }
    }
    
    this.registerDisposableObject = function(object) {
        _disposableObjects.add(object);
    }
    
    this.unregisterDisposableObject = function(object) {
        if (!_unloading && _disposableObjects.length) {
            _disposableObjects.remove(object);
        }
    }

    function onWindowLoad() {
        Sys.Runtime.initialize();
    }

    function onWindowUnload() {
        Sys.Runtime.dispose();
    }
}
window.XMLDOM = function(markup) {
    if (!window.XMLDOMParser) {
        var progIDs = [ 'Msxml2.DOMDocument.3.0', 'Msxml2.DOMDocument' ];
        
        for (var i = 0; i < progIDs.length; i++) {
            try {
                var xmlDOM = new ActiveXObject(progIDs[i]);
                xmlDOM.async = false;
                xmlDOM.loadXML(markup);
                xmlDOM.setProperty('SelectionLanguage', 'XPath');
                
                return xmlDOM;
            }
            catch (ex) {
            }
        }
        
        return null;
    }
    else {
        var domParser = new window.XMLDOMParser();
        return domParser.parseFromString(markup, 'text/xml');
    }
}



if (!Debug.breakIntoDebugger) {
    Debug.breakIntoDebugger = function(message) {
        Debug.writeln(message);
        eval('debugger;');
    }
}

Sys._Debug = function() {

    this.assert = function(condition, message, displayCaller) {
        if (!condition) {
            message = 'Assertion Failed: ' + message + (displayCaller ? '\r\nat ' + this.assert.caller : '');
            if (confirm(message + '\r\n\r\nBreak into debugger?')) {
                this.fail(message);
            }
        }
    }

    this.clearTrace = function() {
        var traceElement = document.getElementById('__atlas_trace');
        if (traceElement) {
            var children = traceElement.childNodes;
            for(var i = children.length - 2; i > 0; i--) {
                traceElement.removeChild(children[i]);
            }
            document.getElementById('__atlas_trace').style.display = 'none';
        }
    }

    this.dump = function(object, name, recursive, indentationPadding, loopArray) {
        name = name ? name : '';
        indentationPadding = indentationPadding ? indentationPadding : '';
        if (object == null) {
            this.trace(indentationPadding + name + ': null');
            return;
        }
        switch(typeof(object)) {
            case 'undefined':
                this.trace(indentationPadding + name + ': Undefined');
                break;
            case 'number': case 'string': case 'boolean':
                this.trace(indentationPadding + name + ': ' + object);
                break;
            default:
                if (Date.isInstanceOfType(object) || RegExp.isInstanceOfType(object)) {
                    this.trace(indentationPadding + name + ': ' + object.toString());
                    break;
                }
                if (!loopArray) {
                    loopArray = [];
                }
                else if (loopArray.contains(object)) {
                    this.trace(indentationPadding + name + ': ...');
                    return;
                }
                loopArray.add(object);
                var type = Object.getType(object);
                var tagName = object.tagName;
                var attributes = object.attributes;
                if ((type == Object) && tagName && attributes) {
                    this.trace(indentationPadding + name + ' {' + tagName + '}');
                    indentationPadding += '+';
                    length = attributes.length;
                    for (var i = 0; i < length; i++) {
                        var val = attributes[i].nodeValue;
                        if (val) {
                            this.dump(val, attributes[i].nodeName, recursive, indentationPadding, loopArray);
                        }
                    }
                }
                else {
                    var typeName = type.getName();
                    this.trace(indentationPadding + name + (typeof(typeName) == 'string' ? ' {' + typeName + '}' : ''));
                    if ((indentationPadding == '') || recursive) {
                        indentationPadding += '+';
                        var i, length, properties, p, v;
                        if (Sys.IArray.isImplementedBy(object)) {
                            length = object.get_length();
                            for (i = 0; i < length; i++) {
                                this.dump(object.getItem(i), '[' + i + ']', recursive, indentationPadding, loopArray);
                            }
                        }
                        if (Sys.ITypeDescriptorProvider.isImplementedBy(object)) {
                            var td = Sys.TypeDescriptor.getTypeDescriptor(object);
                            properties = td._getProperties();
                            for (p in properties) {
                                var propertyInfo = properties[p];
                                if (propertyInfo.name) {
                                    v = Sys.TypeDescriptor.getProperty(object, propertyInfo.name);
                                    this.dump(v, p, recursive, indentationPadding, loopArray);
                                }
                            }
                        }
                        else {
                            for (p in object) {
                                v = object[p];
                                if (!Function.isInstanceOfType(v) && !Type.Event.isInstanceOfType(v)) {
                                    this.dump(v, p, recursive, indentationPadding, loopArray);
                                }
                            }
                        }
                    }
                }
                loopArray.remove(object);
        }
    }

    this.fail = function(message) {
        Debug.breakIntoDebugger(message);
    }

    this.trace = function(text) {
        Debug.writeln(text);

        var traceElement = document.getElementById('__atlas_trace');
        if (!traceElement) {
            traceElement = document.createElement('FIELDSET');
            traceElement.id = '__atlas_trace';
            traceElement.style.backgroundColor = 'white';
            traceElement.style.color = 'black';
            traceElement.style.textAlign = 'left';
            traceElement.style.font = 'normal normal normal 1em/1.1em verdana,sans-serif';
            var legend = document.createElement('LEGEND');
            var legendText = document.createTextNode('Debugging Trace');
            legend.appendChild(legendText);
            traceElement.appendChild(legend);
            var clearButton = document.createElement('INPUT');
            clearButton.type = 'button';
            clearButton.value = 'Clear Trace';
            clearButton.onclick = debug.clearTrace;
            traceElement.appendChild(clearButton);
            document.body.appendChild(traceElement);
        }
        var traceLine = document.createElement('DIV');
        traceLine.innerHTML = text;
        traceElement.insertBefore(traceLine, traceElement.childNodes[traceElement.childNodes.length - 1]);
        traceElement.style.display = 'block';
    }

        this.checkType = function(debugTag, name, value, type) {
        if (!type.isInstanceOfType(value)) {
            this.assert(false, String.format("{0}: parameter '{1}' was set to a '{2}' while it should be of type '{3}'. Its value is '{4}'",
                debugTag, name, Object.getTypeName(value), type.getName(), value));
        }
    }

        this.validateParameters = function(debugTag, argumentArray, validationData) {
                for (var i=0; i<validationData.length; i++) {
                        if (!validationData[i])
                continue;

            var paramName = validationData[i][0];
            var checksToMake = validationData[i][1];
            var paramOptional = validationData[i][2];

                        if (!argumentArray[i]) {
                                if (paramOptional)
                    continue;

                this.assert(false, String.format("{0}: The required parameter '{1}' of type '{2}' is missing",
                    debugTag, paramName, checksToMake.getName()));
            }
            else {
                this.checkType(debugTag, paramName, argumentArray[i], checksToMake);
            }
        }
    }
}
Sys._Debug.registerSealedClass('Sys._Debug');

window.debug = new Sys._Debug();

Type.registerNamespace('Sys.Serialization');


Sys.Serialization.JSON = new function() {

    function serializeWithBuilder(object, stringBuilder) {
        var i;
        
        switch (typeof object) {
        case 'object':
            if (object) {
                                if (Array.isInstanceOfType(object)) {
                    stringBuilder.append('[');
                    for (i = 0; i < object.length; ++i) {
                        if (i > 0) {
                            stringBuilder.append(',');
                        }
                        stringBuilder.append(serializeWithBuilder(object[i], stringBuilder));
                    }
                    stringBuilder.append(']');
                } 
                                else {
                                        if (typeof object.serialize == 'function') {
                        stringBuilder.append(object.serialize());
                        break;
                    }
                
                    stringBuilder.append('{');
                    var needComma = false;
                    for (var name in object) {

                                                if (name.startsWith('$')) {
                            continue;
                        }

                        var value = object[name];
                        if (typeof value != 'undefined' && typeof value != 'function') {
                            if (needComma) {
                                stringBuilder.append(',');
                            }
                            else {
                                needComma = true;
                            }
             
                                                        stringBuilder.append(serializeWithBuilder(name, stringBuilder));
                            stringBuilder.append(':');
                            stringBuilder.append(serializeWithBuilder(value, stringBuilder));
                        }
                    }
                    stringBuilder.append('}');
                }
            }
            else {
                stringBuilder.append('null');
            }
            break;
            
        case 'number':
            if (isFinite(object)) {
                stringBuilder.append(String(object));
            }
                        else {
                stringBuilder.append('null');
            }
            break;
            
        case 'string':
            stringBuilder.append('"');
            var length = object.length;
            for (i = 0; i < length; ++i) {
                var curChar = object.charAt(i);
                                                if (curChar >= ' ') {
                                        if (curChar == '\\' || curChar == '"') {
                        stringBuilder.append('\\');
                    }
                    stringBuilder.append(curChar);
                }
                else {
                                        switch (curChar) {
                        case '\b':
                            stringBuilder.append('\\b');
                            break;
                        case '\f':
                            stringBuilder.append('\\f');
                            break;
                        case '\n':
                            stringBuilder.append('\\n');
                            break;
                        case '\r':
                            stringBuilder.append('\\r');
                            break;
                        case '\t':
                            stringBuilder.append('\\t');
                            break;
                        default:
                                                        stringBuilder.append('\\u00');
                            stringBuilder.append(curChar.charCodeAt().toString(16));
                    }
                }
            }
            stringBuilder.append('"');
            break;
 
        case 'boolean':
            stringBuilder.append(object.toString());
            break;
 
        default:
            stringBuilder.append('null');
            break;
        }
    }

    this.serialize = function(object) { 
        var stringBuilder = new Sys.StringBuilder();
        serializeWithBuilder(object, stringBuilder);
        return stringBuilder.toString();
    }

    this.deserialize = function(data) {
        return eval('(' + data + ')');
    }
}

Date.prototype.serialize = function() {
    var stringBuilder = new Sys.StringBuilder();

    stringBuilder.append('new Date(');
    stringBuilder.append(Date.UTC(this.getUTCFullYear(), this.getUTCMonth(), this.getUTCDate(), this.getUTCHours(), this.getUTCMinutes(), this.getUTCSeconds(), this.getUTCMilliseconds()));
    stringBuilder.append(')');

    return stringBuilder.toString();
}

Type.registerNamespace('Sys.Net');

Sys.Net.WebRequestExecutor = function() {
    var _webRequest = null;
    var _resultObject = null;
    var _resultXml = null;
    
    this.get_webRequest = function() {
        return _webRequest;
    }
    this.set_webRequest = function(value) {
        _webRequest = value;
    }

    this.get_userContext = function() {
        return _webRequest.get_userContext();
    }
    
    this.executeRequest = Function.abstractMethod;
    this.abort = Function.abstractMethod;

    this.get_isActive = Function.abstractMethod;
    this.get_isComplete = Function.abstractMethod;
    this.get_timedOut = Function.abstractMethod;
    this.get_data = Function.abstractMethod;
    this.get_statusCode = Function.abstractMethod;
    this.get_statusText = Function.abstractMethod;

    this.get_object = function() {
        if (!_resultObject) {
            _resultObject = Sys.Serialization.JSON.deserialize(this.get_data());
        }
        return _resultObject;
    }

    this.get_xml = function() {
        if (!_resultXml) {
            _resultXml = new XMLDOM(this.get_data());

                        if (!_resultXml || !_resultXml.documentElement)
                return null;
        }
        
        return _resultXml;
    }
    Sys.Net.WebRequestExecutor.registerBaseMethod(this, 'get_xml');
}
Sys.Net.WebRequestExecutor.registerAbstractClass('Sys.Net.WebRequestExecutor');

Type.createEnum('Sys.Net.WebRequestExecutorType', 'XmlHttp', 0, 'IFrame', 1);
Sys.Net.XMLHttpExecutor = function() {
    Sys.Net.XMLHttpExecutor.initializeBase(this);
    
    var _this = this;
    var _xmlHttpRequest = null;
    var _webRequest = null;
    var _isComplete = false;
    var _timedOut = false;
    var _timer = null;
    
    this.get_timedOut = function() {
        return _timedOut;    
    }
    
    this.get_isActive = function() {
        return _xmlHttpRequest != null;
    }

    this.get_isComplete = function() {
        return _isComplete;
    }

    this.executeRequest = function() {
        
        _webRequest = this.get_webRequest();
        var body = _webRequest.get_body();
        var headers = _webRequest.get_headers();
        
        _xmlHttpRequest = new XMLHttpRequest();
        _xmlHttpRequest.onreadystatechange = onReadyStateChange;
        
        if (body != null) {
            _xmlHttpRequest.open('POST', _webRequest.get_resolvedUrl(), true );
            
                        if ((headers == null) || !headers['Content-Type']) {
                _xmlHttpRequest.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
            }
        }
        else {
            _xmlHttpRequest.open('GET', _webRequest.get_resolvedUrl(), true  );
        }
        
        if (headers != null) {
            for (var header in headers) {
                var val = headers[header];
                if (typeof(val) != "function")
                    _xmlHttpRequest.setRequestHeader(header, val);
            }
        }

        var timeoutInterval = _webRequest.get_timeoutInterval();
        if (timeoutInterval > 0) {
            _timer = window.setTimeout(Function.createDelegate(this, onTimeout), timeoutInterval);
        }

        _xmlHttpRequest.send(body);
    }

    this.get_data = function() {
        return _xmlHttpRequest.responseText;
    }
    
    this.get_statusCode = function() {
        return _xmlHttpRequest.status;
    }
    
    this.get_statusText = function() {
        return _xmlHttpRequest.statusText;
    }
    
    this.get_xml = function() {
        var xml = _xmlHttpRequest.responseXML;
        if (!xml || !xml.documentElement) {
                        xml = new XMLDOM(_xmlHttpRequest.responseText);
            
                        if (!xml || !xml.documentElement)
                return null;
        }
        else if (Sys.Runtime.get_hostType() == Sys.HostType.InternetExplorer) {
            xml.setProperty('SelectionLanguage', 'XPath');
        }
        return xml;
    }
    
    function onReadyStateChange() {
        
        if (_xmlHttpRequest.readyState == 4 ) {

            ClearTimer();
                        
            _isComplete = true;
            
            if (_webRequest.completed != null)
                _webRequest.completed.invoke(_this, null);
            
            cleanupXmlHttpRequest();
        }
    }
    
    function ClearTimer() {
        if (_timer != null) {
            window.clearTimeout(_timer);
            _timer = null;
        }    
    }
    
    function onTimeout() {
        if (!_isComplete) {
            ClearTimer();

            _timedOut = true;
            _isComplete = true;
        
            _xmlHttpRequest.onreadystatechange = Function.emptyMethod;
            _xmlHttpRequest.abort();
        
            _webRequest.timeout.invoke(_webRequest, null);
            
            _xmlHttpRequest = null;
        }
    }
        
    this.abort = function() {
        ClearTimer();

        if (_xmlHttpRequest != null && !_isComplete) {
        
                        _xmlHttpRequest.onreadystatechange = Function.emptyMethod;            
            _xmlHttpRequest.abort();

            _xmlHttpRequest = null;
            _webRequest.aborted.invoke(_webRequest, null);
        }
    }
    
    function cleanupXmlHttpRequest() {
        if (_xmlHttpRequest != null) {
            _xmlHttpRequest.onreadystatechange = Function.emptyMethod;
            _xmlHttpRequest = null;
        }
    }
}
Sys.Net.XMLHttpExecutor.registerClass('Sys.Net.XMLHttpExecutor', Sys.Net.WebRequestExecutor);
Sys.Net.IFrameExecutor = function() {
    Sys.Net.IFrameExecutor.initializeBase(this);

        if (!Sys.Net.IFrameManager) {
        Sys.Net.IFrameManager = new Sys.Net._IFrameManager();
    }

    var _this = this;
    var _webRequest = null;
    var _isComplete = false;
    var _responseData;
    var _iframe;
    var _loaded = false;
    var _timer = null;
    
        var _base64Table = ['A','B','C','D','E','F','G','H','I','J','K','L','M','N','O',
                        'P','Q','R','S','T','U','V','W','X','Y','Z','a','b','c','d',
                        'e','f','g','h','i','j','k','l','m','n','o','p','q','r','s',
                        't','u','v','w','x','y','z','0','1','2','3','4','5','6','7',
                        '8','9','-','_','=' ];

    this.get_isActive = function() {
        return _iframe != null;
    }

    this.get_isComplete = function() {
        return _isComplete;
    }

    this.executeRequest = function() {
                Sys.Net.IFrameManager.getAvailableIFrame(Function.createDelegate(this, executeRequestInternal));
    }
    
    function URLTokenEncode(input) {
        var bytes = new Array();
        var result = "";        
        
                for (var index = 0; index < input.length; index++) {
            var charCode = input.charCodeAt(index);
            
            if (charCode < 0x000080) {
                bytes.push(charCode);
            }
            else if (charCode < 0x000800) {
                bytes.push(0xc0 | charCode >> 6);
                bytes.push(0x80 | charCode & 0x3f);
            }
            else if (charCode < 0x010000) {
                bytes.push(0xe0 | charCode >> 12);
                bytes.push(0x80 | ((charCode & 0xfff) >> 6));
                bytes.push(0x80 | charCode & 0x3f);
            }
            else {
                bytes.push(0xf0 | charCode >> 18);
                bytes.push(0x80 | ((charCode & 0x3ffff) >> 12));
                bytes.push(0x80 | ((charCode & 0xfff) >> 6));
                bytes.push(0x80 | charCode & 0x3f);
            }
        }

                var i = 0;
        
                while (i < bytes.length - 2) {
            var i1 = bytes[i++];
            var i2 = bytes[i++];
            var i3 = bytes[i++];

            result += _base64Table[i1 >> 2];
            result += _base64Table[(i1 & 0x03) << 4 | i2 >> 4];
            result += _base64Table[(i2 & 0x0f) << 2 | i3 >> 6];
            result += _base64Table[i3 & 0x3f];
        }
        
                switch (bytes.length - i) {
            case 2 :
                var i1 = bytes[i++];
                var i2 = bytes[i++];
            
                result += _base64Table[i1 >> 2];
                result += _base64Table[(i1 & 0x03) << 4 | i2 >> 4];
                result += _base64Table[(i2 & 0x0f) << 2];
                result += '1';
                break;

            case 1:
                var i1 = bytes[i++];
            
                result += _base64Table[i1 >> 2];
                result += _base64Table[(i1 & 0x03) << 4];
                result += '2';
                break;
                
            case 0:
                result += '0';
        }        
        
        return result;
    }

    function executeRequestInternal(iframe) {
        _webRequest = this.get_webRequest();
        _iframe = iframe;

        var requestData = {
            headers: _webRequest.get_headers(),
            uri: _webRequest.get_resolvedUrl(),
            body: _webRequest.get_body()
        };

                var appUrl = Sys.Net.WebRequest.resolveUrl(_webRequest.get_appUrl());
        var queryString = {data:Sys.Serialization.JSON.serialize(requestData)};
        var url = appUrl + "iframecall.axd" + '?' + Sys.Net.WebRequest.createQueryString(queryString, URLTokenEncode);
            
        var frameDoc = _iframe.document;

                frameDoc.open("about:blank", "_self", "", true );

                        frameDoc.write();
        _iframe.__exec = this;
        
        frameDoc.write('<SCRIPT id="script" src="' + url + '"></SCRIPT>');
        
        var scriptElement = frameDoc.getElementById("script");

        var timeoutInterval = _webRequest.get_timeoutInterval();
        if (timeoutInterval > 0) {
            _timer = window.setTimeout(Function.createDelegate(this, onTimeout), timeoutInterval);
        }
        
        function onScriptLoaded() {
            if (scriptElement.readyState == 'complete' || scriptElement.readyState == 'loaded') {
                _loaded = true;
                
                                                                if (!_isComplete) {
                    _this.onMethodComplete({
                        content: "A web request made using the iframe executor failed. Make sure that the app's web.config registers iframecall.axd in its <httpHandlers>.",
                        status: 500});
                }
            }
        }

        if (Sys.Runtime.get_hostType() != Sys.HostType.InternetExplorer) {
            scriptElement.readyState = 'loaded';
            scriptElement.onload = onScriptLoaded;
        }
        else {
            scriptElement.onreadystatechange = onScriptLoaded;
        }
        
        frameDoc.close();
    }

    this.get_data = function() {
        if (_responseData) {
            return _responseData.content;
        }

debug.assert(_isComplete, "Request is not completed yet.");

        return null;
    }
    
    this.get_statusCode = function() {
        if (_responseData) {
            return _responseData.status;
        }

debug.assert(_isComplete, "Request is not completed yet.");

        if (_timedOut) {
                        if (_loaded) {
                                return 500;
            }

                        return 408;
        }
    }
    
    this.get_statusText = function() {
                return "Status text not available";
    }
    
    this.abort = function() {
        ClearTimer();

        if (_iframe != null && !_isComplete) {
        
            releaseIFrame();
            
            _webRequest.aborted.invoke(_webRequest, null);
        }
    }

    this.onMethodComplete = function(responseData) {

                        if (!_iframe) {
            return;
        }
        
        releaseIFrame();

        _responseData = responseData;

        _isComplete = true;
        
        if (_webRequest.completed != null) {
            _webRequest.completed.invoke(_this, null);
        }

        ClearTimer();
    }

    function ClearTimer() {
        if (_timer != null) {
            window.clearTimeout(_timer);
            _timer = null;
        }    
    }

    function onTimeout() {
        releaseIFrame();
            
        if (!_isComplete) {
            ClearTimer();

            _timedOut = true;
            _isComplete = true;

            _webRequest.timeout.invoke(_webRequest, null);
        }
    }
    
        function releaseIFrame() {
        if (_iframe != null) {
            Sys.Net.IFrameManager.releaseIFrame(_iframe);
            _iframe = null;
        }
    }
}
Sys.Net.IFrameExecutor.registerClass('Sys.Net.IFrameExecutor', Sys.Net.WebRequestExecutor);

Sys.Net._IFrameManager = function() {

    var _iframes;
    var _waitingQueue = new Array();
    var _frames = 2;
    
    this.get_frames = function() {
        return _frames;
    }
    
    this.set_frames = function(value) {
        _frames = value;
    }
    
    
    this.getAvailableIFrame = function(callback) {
    
                var iframe = findAvailableIFrame();
        
                if (iframe != null) {
            callback(iframe);
            return true;
        }
        
                _waitingQueue.add(callback);
        return false;
    }

    this.releaseIFrame = function(iframe) {

                iframe._available = true;
        
                        if (_waitingQueue.length > 0) {
            window.setTimeout(Function.createDelegate(this, processNextItemInQueue), 0);
        }
    }
    
    function processNextItemInQueue() {
        if (_waitingQueue.length == 0)
            return;
        
        var iframe = findAvailableIFrame();
        if (iframe != null) {
                        callback = _waitingQueue.dequeue();
            callback(iframe);
        }
    }

    function findAvailableIFrame() {
    
                ensureIFramesCreated();

                for (var i=0; i<_iframes.length; i++) {
            if (_iframes[i]._available) {
                                _iframes[i]._available = false;
                return _iframes[i];
            }
        }

                return null;
    }

    function ensureIFramesCreated() { 
    
                if (_iframes)
            return;
            
                _iframes = new Array();
        for (var i=0; i<_frames; i++) {
            _iframes[i] = createIFrame();
            _iframes[i]._available = true;
        }
    }
    
    function createIFrame() { 
        var iframe = document.createElement("iframe"); 
        iframe.setAttribute("width", 0); 
        iframe.setAttribute("height", 0); 
        iframe.style.visibility = "hidden";
        
                var frameCount = window.frames.length;
        document.body.appendChild(iframe);

        return window.frames[frameCount];
    } 
}

Sys.Net._WebRequestManager = function() {

    var _requestQueue = new Object();
    var _batchDelay = 500;
    var _timeoutInterval = 0;
    var _executorType = Sys.Net.XMLHttpExecutor;
    var _enableBatching = false;
    var _batchSize = 5;
    var _defaultAppUrl = document.URL.substr(0, document.URL.lastIndexOf('/') + 1);
    var _defaultDomain = getDomainFromUrl(document.URL);

    this.get_batchDelay = function() {
        return _batchDelay;
    }
    
    this.set_batchDelay = function(value) {
        _batchDelay = value;
    }
    
    this.get_timeoutInterval = function() {
        return _timeoutInterval;
    }

    this.set_timeoutInterval = function(value) {
        _timeoutInterval = value;
    }

    this.get_enableBatching = function() {
        return _enableBatching;
    }
    
    this.set_enableBatching = function(value) {
        _enableBatching = value;
    }
    
    this.get_batchSize = function() {
        return _batchSize;
    }

    this.set_batchSize = function(value) {
        _batchSize = value;
    }
    
    this.get_executorType = function() {
        return _executorType;
    }
    this.set_executorType = function(value) {
        switch (value) {
        case Sys.Net.WebRequestExecutorType.XmlHttp:
            _executorType = Sys.Net.XMLHttpExecutor;
            break;
            
        case Sys.Net.WebRequestExecutorType.IFrame:
            _executorType = Sys.Net.IFrameExecutor;
            break;

        default:
debug.assert(false, "set_executorType");
        }
    }
    
    
    this.enqueue = function(webRequest) {
                if (webRequest.get_aborted() == true) {
            return;
        }
        
        if (!_enableBatching || webRequest.get_priority() == Sys.Net.WebRequestPriority.High) {
                        executeRequest(webRequest);
        }
        else {
            var appUrl = Sys.Net.WebRequest.resolveUrl(webRequest.get_appUrl());

                        appUrl = appUrl.toLowerCase();

            var queueInfo = _requestQueue[appUrl];
                        if (!queueInfo) {
                queueInfo = new Object();
                queueInfo.queue = new Array();
                queueInfo.appUrl = appUrl;
                _requestQueue[appUrl] = queueInfo;
            }

            var queue = queueInfo.queue;
            
                        queue.add(webRequest);

            if (queue.length >= _batchSize) {
                                sendBatchedRequests(queueInfo);
            }
            else if (queue.length == 1) {
            
                function onTimer() {
                    queueInfo.timer = null;
                    
                                        if (queue.length > 0) {
                        sendBatchedRequests(queueInfo);
                    }
                }
            
                                queueInfo.timer = window.setTimeout(onTimer, _batchDelay);
            }
        }
    }
    
    this.flush = function() {
        for (var appUrl in _requestQueue) {
            var queueInfo = _requestQueue[appUrl];

            sendBatchedRequests(queueInfo);
        }
    }
    
    function containsHost(url) {
        if (url.indexOf(':') != -1) {
            return true;
        }
        return false;
    }
    
    function isAbsoluteUrl(url) {
        if (containsHost(url)) {
            return true;
        }

        var firstChar = url.charAt(0);
        if (firstChar == '/' || firstChar == '\\') {
            return true;
        }
        
        return false;
    }

    function sendBatchedRequests(queueInfo) {
        var queue = queueInfo.queue;
        if (queue.length == 0)
            return;
            
        var appUrl = queueInfo.appUrl;
        
                queue.sort(compareRequestPriority);

        var request;

        if (queue.length == 1 || _batchSize == 1) {
                        request = queue[0];
        }
        else {
                        request = createBatchRequest(appUrl, queue);
        }

        executeRequest(request);

                queueInfo.queue = new Array();

                if (queueInfo.timer) {
            window.clearTimeout(queueInfo.timer);
            queueInfo.timer = null;
        }        
    }
    
    function getDomainFromUrl(url) {
                                        var i = url.indexOf('://');
        if (i == -1 || i > 10) {
            return null;
        }

                var j = url.indexOf('/', i + 3);
        var host;
        if (j > -1) {
            host = url.substring(i + 3, j);
        }
        else {
            host = url.substring(i + 3);
        }

        var parts = host.split('.');
        var length = parts.length;
        var domain = host;
        
                if (length > 2) {
            domain = parts[length - 2] + '.' + parts[length - 1];
        }

        return domain.toLowerCase();
    }

    function isCrossDomainRequest(webRequest) {
        var domain;
        var url = webRequest.get_resolvedUrl();
        domain = getDomainFromUrl(url);
        
                if (!domain) {
debug.assert(false, "expect url to always contain domain: "+url);
            return false;
        }
        
        return domain != _defaultDomain;
    }

    function executeRequest(webRequest) {
                if (webRequest.get_aborted() == true) {
            return;
        }

        var executor = null;
                                        if (_executorType != Sys.Net.IFrameExecutor &&
            !webRequest.get_forceXmlHttp() && 
            isCrossDomainRequest(webRequest)) {
            executor = new Sys.Net.IFrameExecutor();
        }
        else {
            executor = new _executorType();
        }
        
        executor.set_webRequest(webRequest);

                        if (Sys.Runtime.get_hostType() != Sys.HostType.InternetExplorer) {        
            webRequest.get_headers().referer = document.URL;
        }
        
        webRequest.set_executor(executor);

        if (_timeoutInterval != 0 && webRequest.get_timeoutInterval() == 0) {
            webRequest.set_timeoutInterval(_timeoutInterval);
        }
        
        executor.executeRequest();
    }

    function createBatchRequest(appUrl, requests) {

        var batchRequestData = new Array();
        
                var batchRequest = new Sys.Net.WebRequest();        
        
        var forceXmlHttp = false;
        for (var i=0; i<requests.length; i++) {
            var request = requests[i];

                        if (request.get_aborted() == true) {
                continue;
            }
            
            if (request.get_forceXmlHttp()) {
                forceXmlHttp = true;
            }

            request.set_delegateRequest(batchRequest);            
            
            batchRequestData[i] = {
                headers: request.get_headers(),
                uri: request.get_resolvedUrl(),
                body: request.get_body()
            };
        }
        
                batchRequest.set_forceXmlHttp(forceXmlHttp);
       
                batchRequest.completed.add(onComplete);
        batchRequest.timeout.add(onTimeout);
        batchRequest.aborted.add(onAborted);
        
        batchRequest.set_url(appUrl + "atlasbatchcall.axd");
        batchRequest.set_appUrl(appUrl);
        batchRequest.set_body(Sys.Serialization.JSON.serialize(batchRequestData));
        batchRequest.get_headers()['Content-Type'] = 'application/json';
        
        function onComplete(response) {

            var statusCode = response.get_statusCode();
            var result = null;

            try {
                result = response.get_object();
            }
            catch (ex) {
            }

            if (statusCode < 200 || statusCode >= 300) {
                                                for (var i=0; i<requests.length; i++)
                    requests[0].completed.invoke(response, null);
            }
            else {
                for (var i=0; i<requests.length; i++) {
                    var request = requests[i];

                    var subResponse = new Sys.Net.BatchResponse(
                        request, result[i].content, result[i].status);
                        
                    request.completed.invoke(subResponse, null);
                }
            }
        }
        
        function onTimeout() {
            for (var i=0; i<requests.length; i++) {
                var request = requests[i];
                    
                request.timeout.invoke(request, null);
            }
        }
        
        function onAborted() {
            for (var i=0; i<requests.length; i++) {
                var request = requests[i];

                request.aborted.invoke(request, null);
            }        
        }

        return batchRequest;
    }
    
    function compareRequestPriority(requestOne, requestTwo) {
        return requestOne.get_priority() - requestTwo.get_priority();
    }
}


Sys.Net.WebRequestManager = new Sys.Net._WebRequestManager();
Sys.Net.WebRequest = function() {
    Sys.Net.WebRequest.initializeBase(this, [true]);

        var _url = null;
    var _headers = null;
    var _body = null;
    var _userContext = null;
    var _appUrl = null;

    var _executor;
    var _invokeCalled = false;
    var _abortCalled = false;

    var _timeoutInterval = 0;
    var _priority = Sys.Net.WebRequestPriority.Normal;
    
    var _delegateRequest = null;
    
    var _forceXmlHttp = false;

    
    this.get_appUrl = function() {
        return _appUrl;
    }
    
    this.set_appUrl = function(value) {
        _appUrl = value;
        if (_appUrl && _appUrl.charAt(_appUrl.length - 1) != '/') {
            _appUrl += '/';
        }
    }

    this.get_url = function() {
        return _url;
    }
    
        this.get_resolvedUrl = function() {
                if (_appUrl) {
            var resolvedAppUrl = Sys.Net.WebRequest.resolveUrl(_appUrl);
            return Sys.Net.WebRequest.resolveUrl(_url, resolvedAppUrl);
        }
        else {
            return Sys.Net.WebRequest.resolveUrl(_url);
        }
    }
    
    this.set_url = function(value) {
        _url = value;
    }
    
    this.get_headers = function() {
        if (_headers == null) {
            _headers = { };
        }
        return _headers;
    }

    this.get_forceXmlHttp = function() {
        return _forceXmlHttp;
    }
    this.set_forceXmlHttp = function(value) {
        _forceXmlHttp = value;
    }
    
    this.get_body = function() {
        return _body;
    }
    this.set_body = function(value) {
        _body = value;
    }
    
    this.get_userContext = function() {
        return _userContext;
    }
    
    this.get_executor = function() {
        if (_executor) {
            return _executor;
        }

        return _delegateRequest;
    }
    
    this.set_executor = function(value) {
        _executor = value;
    }

    this.get_timeoutInterval = function() {
        return _timeoutInterval;
    }
    
    this.set_timeoutInterval = function(value) {
        _timeoutInterval = value;
    }
    
    this.get_priority = function() {
        return _priority;
    }

    this.set_priority = function(value) {
        _priority = value;
    }
    
        this.get_aborted = function() {
        return _abortCalled;
    }
    
    this.get_isActive = function() {
        var executor = this.get_executor();
        return executor && executor.get_isActive();
    }
    
    this.get_timedOut = function() {
        return _timedOut;
    }
    
    this.set_delegateRequest = function(request) {
        _delegateRequest = request;
    }

        
    this.aborted = new Type.Event(this);

    this.completed = new Type.Event(this);
    
    this.timeout = new Type.Event(this);


    
    this.invoke = function(userContext) {
    
                if (_executor || _invokeCalled) {
debug.assert(false, "executor and invokeCalled should not be set");
            return;
        }
        
        _userContext = userContext;
        
        Sys.Net.WebRequestManager.enqueue(this);
        _invokeCalled = true;
    }

    this.abort = function() {

                if (!_invokeCalled) {
debug.assert(false, "abort called but invoke wasn't");
            return;
        }

        _abortCalled = true;

        var executor = this.get_executor();
        if (executor) {
            executor.abort();
        }
    }
}
Sys.Net.WebRequest.registerClass('Sys.Net.WebRequest');

Sys.Net.WebRequest.resolveUrl = function(url, baseUrl) {
        if (url && url.startsWith('http') && url.indexOf('://') != -1) {
        return url;
    }
    
        if (!baseUrl) {
        var baseElement = document.getElementsByTagName('base')[0];
        if (baseElement) {
            baseUrl = baseElement.href;
        }
        else {
            baseUrl = document.URL;
        }
    }
    baseUrl = baseUrl.substr(0, baseUrl.lastIndexOf('/') + 1);

        if (!url) {
        return baseUrl;
    }

        if (url.charAt(0) == '/') {
        var slashslash = baseUrl.indexOf('://');
        if (slashslash == -1) {
debug.assert(false, "base url doesn't contain ://");
            return url;
        }
            
        var nextSlash = baseUrl.indexOf('/', slashslash + 3);
        if (nextSlash == -1) {
debug.assert(false, "base url doesn't contain another /");
            return url;
        }
        
        return baseUrl.substr(0, nextSlash) + url;
    }
            else {
        var lastSlash = baseUrl.lastIndexOf('/');
        if (lastSlash == -1) {
debug.assert(false, "can't find last / in base url");
            return url;
        }
            
        return baseUrl.substr(0, lastSlash+1) + url;
    }
}

Sys.Net.WebRequest.createQueryString = function(queryString, encodeMethod) {

        if (encodeMethod == null)
        encodeMethod = encodeURIComponent;
        
    var sb = new Sys.StringBuilder();

    var i = 0;    
    for (var arg in queryString) {
        var val = queryString[arg];
        if (typeof(val) == "function") continue;
        if (i != 0) {
            sb.append('&');
        }
        
        sb.append(arg);
        sb.append('=');
        debug.assert(!Object.isInstanceOfType(val), "The parameter '" + arg + "' is set to a complex object (" +
            Sys.Serialization.JSON.serialize(val) + "), but it must be a simple object to be passed on the query string");
        sb.append(encodeMethod(val));
        
        i++;
    }
    
    return sb.toString();
}

Sys.Net.WebRequest.createUrl = function(url, queryString) {
    if (!queryString) {
        return url;
    }
    
    var sep = '?';
    if (url && url.indexOf('?') != -1) 
        sep = '&';
    return url + sep + Sys.Net.WebRequest.createQueryString(queryString);
}

Sys.Net.WebMethod = function() {
    this.addHeaders = Function.abstractMethod;
    this.get_appUrl = Function.abstractMethod;
    this.get_url = Function.abstractMethod;
    this.get_body = Function.abstractMethod;

        this.invoke = function(params) {

                                        var numOfParams = arguments.length;
        if (numOfParams == 2 && arguments[1] && typeof(arguments[1]) != 'function') {
        
                        var expectedParamNames = ["onMethodComplete", "onMethodTimeout", "onMethodError",
                "onMethodAborted", "userContext", "timeoutInterval", "priority", "useGetMethod"];

                        var paramContainer = arguments[1];
            
                        var newParams = new Array(expectedParamNames.length + 1);
            newParams[0] = params;
            
            for (var paramName in paramContainer) {
            
                                var index = expectedParamNames.indexOf(paramName);
                
                                if (index < 0) {
                    throw Error.createError(String.format("'{0}' is not a valid argument. It should be one of {1}", paramName, expectedParamNames));
                }

                newParams[index+1] = paramContainer[paramName];
            }
            
            return this._invoke.apply(this, newParams);
        }
        
        return this._invoke.apply(this, arguments);
    }
    
    this._invoke = function(params, onMethodComplete, onMethodTimeout, 
        onMethodError, onMethodAborted, userContext, timeoutInterval, priority, useGetMethod) {

        window.debug.validateParameters("WebMethod.Invoke", arguments,
            [   
                ['params', Object, true],
                ['onMethodComplete', Function, true],
                ['onMethodTimeout', Function, true],
                ['onMethodError', Function, true],
                ['onMethodAborted', Function, true],
                ,                   ['timeoutInterval', Number, true],
                ['priority', Number, true],
                ['useGetMethod', Boolean, true]
            ]);

                var request = new Sys.Net.WebRequest();

                this.addHeaders(request.get_headers());

        request.set_url(this.get_url(params, useGetMethod));
        request.set_appUrl(this.get_appUrl());
        
        if (params == null) {
            params = {};
        }
            
                request.set_body(this.get_body(params, useGetMethod));

        request.completed.add(onComplete);
        request.timeout.add(onTimeout);
        request.aborted.add(onAborted);
        
        if (timeoutInterval) {
            request.set_timeoutInterval(timeoutInterval);
        }
        
        if (priority >= 0) {
            request.set_priority(priority);
        }
        
var methodName = this.get_methodName();

        request.invoke();

        function onComplete(response, eventArgs) {
            var statusCode = response.get_statusCode();
            var result = null;

                                    try {
                result = response.get_object();
            }
            catch (ex) {
                try {
                    result = response.get_xml();
                }
                catch (ex) {
                }
            }

            if (((statusCode < 200) || (statusCode >= 300)) ||
                Sys.Net.MethodRequestError.isInstanceOfType(result)) {

                if (onMethodError) {
                    onMethodError(result, response, userContext);
                }
                else {
                                        debug.trace("The server method '" + methodName + "' failed with the following error:");
                    if (result != null) {
                                                debug.trace(result.get_exceptionType() + ": " + result.get_message());
                    }
                    else {
                                                                        debug.trace(response.get_data());
                    }
                }
            }
            else if (onMethodComplete) {
                onMethodComplete(result, response, userContext);
            }
        }

        function onTimeout(request, eventArgs) {
            if (onMethodTimeout) {
                onMethodTimeout(request, userContext);
            }
        }
        
        function onAborted(request, eventArgs) {
            if (onMethodAborted) {
                onMethodAborted(request, userContext);
            }
        }
        
        return request;
    }
}
Sys.Net.WebMethod.registerAbstractClass('Sys.Net.WebMethod');

Sys.Net.WebMethod.generateTypedConstructor = function(serverType) {
    return function(properties) {
        this.__serverType = serverType;
        
                if (properties != null) {
            for (var name in properties) {
                this[name] = properties[name];
            }
        }
    }
}

Sys.Net.ServiceMethod = function(url, methodName, appUrl) {
    Sys.Net.ServiceMethod.initializeBase(this);

this.get_methodName = function() { return methodName; }

    this.addHeaders = function(headers) {
                headers['Content-Type'] = 'application/json';
    }

    this.get_url = function(params, useGetMethod) {
                if (!useGetMethod || !params)
            params = {};
        
                params.mn = methodName;
        var fullUrl = Sys.Net.WebRequest.createUrl(url, params );
        delete params.mn;           
        return fullUrl;
    }

    this.get_body = function(params, useGetMethod) {
                if (useGetMethod) return null;
        
        var body = Sys.Serialization.JSON.serialize(params);
        
                if (body == "{}")
            return "";
            
        return body;
    }
    
    this.get_appUrl = function() {
        return appUrl;
    }
}
Sys.Net.ServiceMethod.registerClass('Sys.Net.ServiceMethod', Sys.Net.WebMethod);

Sys.Net.ServiceMethod.invoke = function(methodURL, methodName, appUrl) {
    
    var method = new Sys.Net.ServiceMethod(methodURL, methodName, appUrl);

        var callMethodArgs = new Array();
    for (var i=3; i<arguments.length; i++)
        callMethodArgs[i-3] = arguments[i];

        return method.invoke.apply(method, callMethodArgs);
}

Sys.Net.ServiceMethod.createProxyMethod = function(proxy, methodName) {

        var numOfParams = arguments.length-2;
    
        var createWebMethodArguments = arguments;

        proxy[methodName] = function() {
    
                                var args = {};
        for (var i=0; i<numOfParams; i++) {
                        if (typeof(arguments[i]) == 'function') {
                throw Error.createError(String.format("Parameter #{0} passed to method '{1}' should not be a function", i+1, methodName));
            }
            
            args[createWebMethodArguments[i+2]] = arguments[i];
        }
        
                        var callMethodArgs = [ proxy.path, methodName, proxy.appPath, args ];
        
                for (var i=0; i+numOfParams<arguments.length; i++)
            callMethodArgs[i+4] = arguments[numOfParams+i];
        
                return Sys.Net.ServiceMethod.invoke.apply(null, callMethodArgs);
    }
}
Sys.Net.PageMethod = function(methodName) {
    Sys.Net.PageMethod.initializeBase(this);

this.get_methodName = function() { return methodName; }

    this.addHeaders = function(headers) {
                headers['Content-Type'] = 'application/x-www-form-urlencoded';
    }

    this.get_url = function() {
        var form = document.forms[0];
        return form.action;
    }
    
    this.get_appUrl = function() {
        return null;
    }
    
    this.get_body = function(params) {
        var form = document.forms[0];

        
                var bodyDictionary = {};
        bodyDictionary["__serviceMethodName"] = methodName;
        bodyDictionary["__serviceMethodParams"] = Sys.Serialization.JSON.serialize(params);

                var count = form.elements.length;
        var element;
        for (var i = 0; i < count; i++) {
            element = form.elements[i];
            var tagName = element.tagName.toLowerCase();
            if (tagName == "input") {
                var type = element.type;
                if ((type == "text" || type == "hidden" || type == "password" ||
                    ((type == "checkbox" || type == "radio") && element.checked))) {
                    bodyDictionary[element.name] = element.value;
                }
            }
            else if (tagName == "select") {
                var selectCount = element.options.length;
                for (var j = 0; j < selectCount; j++) {
                    var selectChild = element.options[j];
                    if (selectChild.selected == true) {
                        bodyDictionary[element.name] = element.value;
                    }
                }
            }
            else if (tagName == "textarea") {
                bodyDictionary[element.name] = element.value;
            }
        }

                return Sys.Net.WebRequest.createQueryString(bodyDictionary, encodeFormPostField);
    }

                function encodeFormPostField(param) {
                        param = param.replace(/%/gi, "%25");
        param = param.replace(/&/gi, "%26");
        param = param.replace(/=/gi, "%3d");
        param = param.replace(/\+/gi, "%2b");
        return param;
    }
}
Sys.Net.PageMethod.registerClass('Sys.Net.PageMethod', Sys.Net.WebMethod);

Sys.Net.PageMethod.invoke = function(methodName) {
    
    var method = new Sys.Net.PageMethod(methodName);

        var callMethodArgs = new Array();
    for (var i=1; i<arguments.length; i++)
        callMethodArgs[i-1] = arguments[i];

        return method.invoke.apply(method, callMethodArgs);
}

Sys.Net.PageMethod.createProxyMethod = function(proxy, methodName) {

        var numOfParams = arguments.length-2;
    
        var createWebMethodArguments = arguments;

        proxy[methodName] = function() {
    
                                var args = {};
        for (var i=0; i<numOfParams; i++) {
                        if (typeof(arguments[i]) == 'function') {
                throw Error.createError(String.format("Parameter #{0} passed to method '{1}' should not be a function", i+1, methodName));
            }

            args[createWebMethodArguments[i+2]] = arguments[i];
        }

                        var callMethodArgs = [ methodName, args ];
        
                for (var i=0; i+numOfParams<arguments.length; i++)
            callMethodArgs[i+2] = arguments[numOfParams+i];
        
                return Sys.Net.PageMethod.invoke.apply(null, callMethodArgs);
    }
}
Sys.Net.MethodRequestError = function(message, stackTrace, exceptionType) {
    var _message = message;
    var _stackTrace = stackTrace;
    var _exceptionType = exceptionType;
    
    this.get_message = function() {
        return _message;
    }
    
    this.get_stackTrace = function() {
        return _stackTrace;
    }
    
    this.get_exceptionType = function() {
        return _exceptionType;
    }
}
Sys.Net.MethodRequestError.registerClass('Sys.Net.MethodRequestError');
Sys.Net.BatchResponse = function(request, data, status) {
    Sys.Net.BatchResponse.initializeBase(this);
    
    this.set_webRequest(request);
    
    this.get_data = function() {
        return data;
    }
    
    this.get_statusCode = function() {
        return status;
    }
}
Sys.Net.BatchResponse.registerClass('Sys.Net.BatchResponse', Sys.Net.WebRequestExecutor);
Type.createEnum('Sys.Net.WebRequestPriority', 'High', 0, 'Normal', 1, 'Low', 2);

Type.registerNamespace('Sys.Services');

Sys.Services._AuthenticationService = function() {
    this.path = "ScriptServices/Microsoft/Web/Services/Standard/AuthenticationWebService.asmx";
    
    var cm=Sys.Net.ServiceMethod.createProxyMethod;
    cm(this, "login", "userName", "password", "createPersistentCookie");
    cm(this, "logout");
    cm(this, "validateUser", "userName", "password");
    }
Sys.Services._AuthenticationService.registerSealedClass('Sys.Services._AuthenticationService');

Sys.Services.AuthenticationService = new Sys.Services._AuthenticationService();

Sys._Profile = function() {
    Sys._Profile.initializeBase(this);

    var _properties = { };
    var _propertyNames;
    var _isDirty;
    var _autoSave;
    
    Sys.Runtime.registerDisposableObject(this);
    
    this.get_autoSave = function() {
        return _autoSave;
    }
    this.set_autoSave = function(value) {
        _autoSave = value;
    }

    this.get_initialData = function() {
        return null;
    }
    this.set_initialData = function(value) {
        if (value && value.length) {
            this._updateProperties(Sys.Serialization.JSON.deserialize(value));
        }
    }
    
    this.get_isDirty = function() {
        return _isDirty;
    }
    
    this.get_propertyNames = function() {
        return _propertyNames;
    }
    this.set_propertyNames = function(value) {
        _propertyNames = value;
    }
    
    this.loaded = new Type.Event(null);

    
    this.saved = new Type.Event(null);
    
    this.dispose = function() {
        this.loaded.dispose();
        this.saved.dispose();

        Sys.Runtime.unregisterDisposableObject(this);
    }

    
    this.load = function() {
        Sys.Net.ServiceMethod.invoke(Sys._Profile.WebServicePath, "GetProfile", null,
                                                { properties: _propertyNames },
                                                Function.createDelegate(this, this._onRequestComplete), null, null, null,
                                                 true);
    }
    
    this.save = function() {
        Sys.Net.ServiceMethod.invoke(Sys._Profile.WebServicePath, "SetProfile", null,
                                                { values: _properties },
                                                Function.createDelegate(this, this._onRequestComplete), null, null, null,
                                                 false);
    }
    
    this._saveIfDirty = function() {
        if (_isDirty) {
            this.save();
        }
    }
    

    this._onRequestComplete = function(result, response, userContext) {
        if (userContext) {
            this._updateProperties(result);
            _isDirty = false;

            this.loaded.invoke(this, null);
        }
        else {
            _isDirty = false;

            this.saved.invoke(this, null);
        }
    }
    
    this._updateProperties = function(properties) {
        _properties = properties;
        this.properties = properties;
    }
}
Sys._Profile.WebServicePath = 'ScriptServices/Microsoft/Web/Services/Standard/ProfileWebService.asmx';

Sys._Profile.registerSealedClass('Sys._Profile', null, Sys.IDisposable);

Sys.Profile = new Sys._Profile();
