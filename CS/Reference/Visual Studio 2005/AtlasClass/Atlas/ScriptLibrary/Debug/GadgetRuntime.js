//-----------------------------------------------------------------------
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------
// GadgetRuntime.js
// Atlas Runtime for Gadgets.

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




Number.prototype.toFormattedString = function(format) {
        var _percentPositivePattern = ["n %", "n%", "%n" ];
    var _percentNegativePattern = ["-n %", "-n%", "-%n"];
    var _numberNegativePattern = ["(n)","-n","- n","n-","n -"];
    var _currencyPositivePattern = ["$n","n$","$ n","n $"];
    var _currencyNegativePattern = ["($n)","-$n","$-n","$n-","(n$)","-n$","n-$","n$-","-n $","-$ n","n $-","$ n-","$ -n","n- $","($ n)","(n $)"];

        function expandNumber(number, precision, groupSizes, sep, decimalChar) {
debug.assert(groupSizes.length > 0, "groupSizes must be an array of at least 1");
        var curSize = groupSizes[0];
        var curGroupIndex = 1;

                var numberString = ""+number;
        var decimalIndex = numberString.indexOf('.');
        var right = "";
        if (decimalIndex > 0) {
            right = numberString.slice(decimalIndex+1);
            numberString = numberString.slice(0, decimalIndex);
        }

                if (precision > 0) {
                        var rightDifference = right.length - precision;
            if (rightDifference > 0) {
                right = right.slice(0, precision);
            } else if (rightDifference < 0) {
                for (var i=0; i<Math.abs(rightDifference); i++) {
                    right += '0';
                }
            }

                        right = decimalChar + right;
        }
        else {             right = "";
        }

        var stringIndex = numberString.length-1;
        var ret = "";
        while (stringIndex >= 0) {

                        if (curSize == 0 || curSize > stringIndex) {
                if (ret.length > 0)
                    return numberString.slice(0, stringIndex + 1) + sep + ret + right;
                else
                    return numberString.slice(0, stringIndex + 1) + right;
            }

            if (ret.length > 0)
                ret = numberString.slice(stringIndex - curSize + 1, stringIndex+1) + sep + ret;
            else
                ret = numberString.slice(stringIndex - curSize + 1, stringIndex+1);

            stringIndex -= curSize;

            if (curGroupIndex < groupSizes.length) {
                curSize = groupSizes[curGroupIndex];
                curGroupIndex++;
            }
        }
        return numberString.slice(0, stringIndex + 1) + sep + ret + right;
    }
    var nf = Sys.CultureInfo.NumberFormat;

        var number = Math.abs(this);

        if (!format)
        format = "D";

    var precision = -1;
    if (format.length > 1) precision = parseInt(format.slice(1));

    var pattern;
    switch (format.charAt(0)) {
    case "d":
    case "D":
        pattern = 'n';

                if (precision != -1) {
            var numberStr = ""+number;
            var zerosToAdd = precision - numberStr.length;
            if (zerosToAdd > 0) {
                for (var i=0; i<zerosToAdd; i++) {
                    numberStr = '0'+numberStr;
                }
            }
            number = numberStr;
        }

                if (this < 0) number = -number;
        break;
    case "c":
    case "C":
        if (this < 0) pattern = _currencyNegativePattern[nf.CurrencyNegativePattern];
        else pattern = _currencyPositivePattern[nf.CurrencyPositivePattern];
        if (precision == -1) precision = nf.CurrencyDecimalDigits;
        number = expandNumber(Math.abs(this), precision, nf.CurrencyGroupSizes, nf.CurrencyGroupSeparator, nf.CurrencyDecimalSeparator);
        break;
    case "n":
    case "N":
        if (this < 0) pattern = _numberNegativePattern[nf.NumberNegativePattern];
        else pattern = 'n';
        if (precision == -1) precision = nf.NumberDecimalDigits;
        number = expandNumber(Math.abs(this), precision, nf.NumberGroupSizes, nf.NumberGroupSeparator, nf.NumberDecimalSeparator);
        break;
    case "p":
    case "P":
        if (this < 0) pattern = _percentNegativePattern[nf.PercentNegativePattern];
        else pattern = _percentPositivePattern[nf.PercentPositivePattern];
        if (precision == -1) precision = nf.PercentDecimalDigits;
        number = expandNumber(Math.abs(this), precision, nf.PercentGroupSizes, nf.PercentGroupSeparator, nf.PercentDecimalSeparator);
        break;
    default:
        debug.assert(false, "'" + format + "' is not a valid number format");
    }

    var regex = /n|\$|-|%/g;

        var ret = "";

    for (;;) {

                var index = regex.lastIndex;

                var ar = regex.exec(pattern);

                ret += pattern.slice(index, ar ? ar.index : pattern.length);

        if (!ar)
            break;

        switch (ar[0]) {
        case "n":
            ret += number;
            break;
        case "$":
            ret += nf.CurrencySymbol;
            break;
        case "-":
            ret += nf.NegativeSign;
            break;
        case "%":
            ret += nf.PercentSymbol;
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
Sys._Runtime = function(p_elSource, p_args, p_namespace) {
    Sys._Runtime.initializeBase(this, arguments);

    Sys.Runtime = this;

    var _hostType = Sys.HostType.Other;

    var _disposed = false;
    var _unloading = false;

    var _disposableObjects = [];

    if (navigator.userAgent.indexOf('MSIE') != -1) {
        _hostType = Sys.HostType.InternetExplorer;
    }
    else if (navigator.userAgent.indexOf('Firefox') != -1) {
        _hostType = Sys.HostType.Firefox;
    }

    this.get_hostName = function() {
        return navigator.userAgent;
    }

    this.get_hostType = function() {
        return _hostType;
    }

    this.load = new Type.Event( null,  true);
    this.unload = new Type.Event( null,  true);

    this.dispose = function() {
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

            Sys._Runtime.getBaseMethod(this, "dispose", "Web.Bindings.Base").call(this);
        }
    }

    this.initialize = function(p_objScope) {
        Sys._Runtime.getBaseMethod(this, "initialize", "Web.Bindings.Base").call(this, p_objScope);

        var base = document.getElementsByTagName('base')[0];
        if (!base) {
            base = document.createElement("base");
            var headElement = document.getElementsByTagName('head')[0];
            headElement.appendChild(base);
        }
        base.href = p_args.uri;

        var renderingElement = document.createElement("div");

                var escapedRendering = p_args.xmlSources["rendering"].responseXML.documentElement.childNodes[0].data;
        var unescapedRendering = Sys.UI._unescapeCData(escapedRendering);

        renderingElement.innerHTML = unescapedRendering;
        p_elSource.appendChild(renderingElement);

                        var atlasFXPathNode = p_args.xml.responseXML.documentElement.selectSingleNode("//atlasfxpath");
        var atlasFXPath = atlasFXPathNode.text;
        var scriptLoader = new Sys.ScriptLoader();
        scriptLoader.load([{url: atlasFXPath}], onAtlasFXLoaded);
    }

    function onAtlasFXLoaded() {
        Sys.Runtime.load.invoke(Sys.Runtime, null);
    }

    this.resize = function() {
        p_args.module.Resize();
    }

    this.getPreference = function(name) {
                        if (p_args.onDashboard) {
            var params = p_args.module.GetBindingParams();
            return params[name];
        }
        else {
            return null;
        }
    }

    this.setPreference = function(name, value) {
                        if (p_args.onDashboard) {
            var params = p_args.module.GetBindingParams();
            params[name] = value;
        }
    }

    this.savePreferences = function() {
                        if (p_args.onDashboard) {
            p_args.module.Serialize();
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
}
Sys._Runtime.registerClass("Sys._Runtime", "Web.Bindings.Base");
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



Sys.ScriptLoader = function() {

    var _references;
    var _completionCallback;
    var _callbackContext;

    var _currentLoadingReference;
    var _currentOnScriptLoad;
    
    this.load = function(references, completionCallback, callbackContext) {
        _references = references;
        _completionCallback = completionCallback;
        _callbackContext = callbackContext;
        
        loadReferences();
    }

    function loadReferences() {
        if (_currentLoadingReference) {
            if ((_currentLoadingReference.readyState != 'loaded') &&
                (_currentLoadingReference.readyState != 'complete')) {
                return;
            }
            else {
                                if (_currentOnScriptLoad) {
                    eval(_currentOnScriptLoad);
                    _currentOnScriptLoad = null;
                }
                
                if (Sys.Runtime.get_hostType() != Sys.HostType.InternetExplorer) {
                    _currentLoadingReference.onload = null;
                }
                else {
                    _currentLoadingReference.onreadystatechange = null;
                }
                _currentLoadingReference = null;
            }
        }

        if (_references.length) {
            var reference = _references.dequeue();
            var scriptElement = document.createElement('script');
            _currentLoadingReference = scriptElement;
            _currentOnScriptLoad = reference.onscriptload;
            
            if (Sys.Runtime.get_hostType() != Sys.HostType.InternetExplorer) {
                scriptElement.readyState = 'loaded';
                scriptElement.onload = loadReferences;
            }
            else {
                scriptElement.onreadystatechange = loadReferences;
            }
            scriptElement.type = 'text/javascript';
            scriptElement.src = reference.url;

            var headElement = document.getElementsByTagName('head')[0];
            headElement.appendChild(scriptElement);

            return;
        }
        
        if (_completionCallback) {
            var completionCallback = _completionCallback;
            var callbackContext = _callbackContext;
            
            _completionCallback = null;
            _callbackContext = null;
            
            completionCallback(callbackContext);
        }
        
        _references = null;
    }
}
Sys.ScriptLoader.registerClass('Sys.ScriptLoader');

Type.registerNamespace('Sys.UI');

function $(elementID) {
    return document.getElementById(elementID);
}

Sys.UI._escapeCData = function(value) {
    return value.replace(/\\/g, '\\\\').replace(/]/g, '\\]');
}

Sys.UI._unescapeCData = function(cDataValue) {
    return cDataValue.replace(/\\\\/g, '\\').replace(/\\]/g, ']');
}


