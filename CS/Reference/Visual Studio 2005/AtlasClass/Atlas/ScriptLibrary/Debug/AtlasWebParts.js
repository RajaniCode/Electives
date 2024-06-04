//-----------------------------------------------------------------------
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------
// AtlasWebParts.js
// Atlas WebParts Framework.

Type.registerNamespace('Sys.UI.Controls.WebParts');

function __wpTranslateOffset(x, y, offsetElement, relativeToElement, includeScroll) {
    while ((typeof(offsetElement) != "undefined") && (offsetElement != null) && (offsetElement != relativeToElement)) {
        x += offsetElement.offsetLeft;
        y += offsetElement.offsetTop;

                                                                        var tagName = offsetElement.tagName;
        if ((tagName != "TABLE") && (tagName != "BODY")) {
                        if (offsetElement.clientLeft) {
                x += offsetElement.clientLeft;
            }
                        if (offsetElement.clientTop) {
                y += offsetElement.clientTop;
            }
        }

                                if (includeScroll && (tagName != "BODY")) {
            x -= offsetElement.scrollLeft;
            y -= offsetElement.scrollTop;
        }

        offsetElement = offsetElement.offsetParent;
    }
    return new Point(x, y);
}

function Zone_ToggleDropCues(show, index, ignoreOutline) {
    if (ignoreOutline == false) {
        this.webPartTable.style.borderColor = (show ? this.highlightColor : this.savedBorderColor);
    }

    if (index == -1) {
        return;
    }
    var dropCue = this.dropCueElements[index];
    if (dropCue && dropCue.style) {
        if (dropCue.style.height == "100%" && !dropCue.webPartZoneHorizontalCueResized) {
                                                                        
                                    var oldParentHeight = dropCue.parentNode.clientHeight;
            
            var realHeight = oldParentHeight - 10;
            dropCue.style.height = realHeight + "px";
            var dropCueVerticalBar = dropCue.getElementsByTagName("DIV")[0];
            if (dropCueVerticalBar && dropCueVerticalBar.style) {
                dropCueVerticalBar.style.height = dropCue.style.height;

                                                var heightDiff = (dropCue.parentNode.clientHeight - oldParentHeight);

                if (heightDiff) {
                    dropCue.style.height = (realHeight - heightDiff) + "px";
                    dropCueVerticalBar.style.height = dropCue.style.height;
                }
            }
            dropCue.webPartZoneHorizontalCueResized = true;
        }
        dropCue.style.visibility = (show ? "visible" : "hidden");
    }
}

for (var i=0; i < __wpm.zones.length; i++) {
    var whidbeyZone = __wpm.zones[i];
    whidbeyZone.ToggleDropCues = Zone_ToggleDropCues;
}
Sys.UI.Controls.WebParts.WebPart = function(associatedElement) {
    Sys.UI.Controls.WebParts.WebPart.initializeBase(this, [associatedElement]);

    var _titleElement;
    var _zone;
    var _zoneIndex;
    var _allowZoneChange = true;

    this.get_allowZoneChange = function() {
        return _allowZoneChange;
    }

    this.set_allowZoneChange = function(value) {
        _allowZoneChange = value;
    }

    this.get_titleElement = function() {
        return _titleElement;
    }

    this.set_titleElement = function(value) {
        _titleElement = value;
    }

    this.get_zone = function() {
        return _zone;
    }

    this.set_zone = function(value) {
        _zone = value;
    }

    this.get_zoneIndex = function() {
        return _zoneIndex;
    }

    this.set_zoneIndex = function(value) {
        _zoneIndex = value;
    }

    this.getDescriptor = function() {
        var td = Sys.UI.Controls.WebParts.WebPart.callBaseMethod(this, "getDescriptor");
        td.addProperty("titleElement", Object, false, Sys.Attributes.Element, true);
        td.addProperty("zone", Object);
        td.addProperty("zoneIndex", Number);
        td.addProperty("allowZoneChange", Boolean);
        return td;
    }

    this.initialize = function() {
        Sys.UI.Controls.WebParts.WebPart.callBaseMethod(this, "initialize");

                if (_titleElement && _zone.get_webPartManager().get_allowPageDesign() && _zone.get_allowLayoutChange()) {
                        _titleElement.detachEvent("onmousedown", WebPart_OnMouseDown);
            this.element.detachEvent("ondragstart", WebPart_OnDragStart);
            this.element.detachEvent("ondrag", WebPart_OnDrag);
            this.element.detachEvent("ondragend", WebPart_OnDragEnd);

                        _titleElement.attachEvent("onmousedown", Function.createDelegate(this, mouseDownHandler));

                                                _titleElement.style.cursor = "move";
        }
    }

    function mouseDownHandler() {
        _zone.startDragDrop(this);

                window.event.returnValue = false;
    }
}
Sys.UI.Controls.WebParts.WebPart.registerClass("Sys.UI.Controls.WebParts.WebPart", Sys.UI.Control);
Sys.TypeDescriptor.addType("script", "webPart", Sys.UI.Controls.WebParts.WebPart);
Sys.UI.Controls.WebParts.WebPartManager = function(associatedElement) {
    Sys.UI.Controls.WebParts.WebPartManager.initializeBase(this, [associatedElement]);

    var _allowPageDesign;

    this.get_allowPageDesign = function() {
        return _allowPageDesign;
    }

    this.set_allowPageDesign = function(value) {
        _allowPageDesign = value;
    }

    this.getDescriptor = function() {
        var td = Sys.UI.Controls.WebParts.WebPartManager.callBaseMethod(this, "getDescriptor");
        td.addProperty("allowPageDesign", Boolean);
        return td;
    }

    this.initialize = function() {
        Sys.UI.Controls.WebParts.WebPartManager.callBaseMethod(this, "initialize");

        var baseShowHelp = Function.createDelegate(__wpm, __wpm.ShowHelp);
        __wpm.ShowHelp = function(helpUrl, helpMode) {
            var supportedHelpMode;
                        if (helpMode == 0 && !window.showModalDialog) {
                supportedHelpMode = 1;
            }
            else {
                supportedHelpMode = helpMode;
            }

            baseShowHelp(helpUrl, supportedHelpMode);
        }
    }
}
Sys.UI.Controls.WebParts.WebPartManager.registerClass("Sys.UI.Controls.WebParts.WebPartManager", Sys.UI.Control);
Sys.TypeDescriptor.addType("script", "webPartManager", Sys.UI.Controls.WebParts.WebPartManager);
Sys.UI.Controls.WebParts.WebPartZone = function(associatedElement) {
    Sys.UI.Controls.WebParts.WebPartZone.initializeBase(this, [associatedElement]);

        var _dataType = "WebPart";

    var _allowLayoutChange = true;
    var _uniqueId;
    var _webPartManager;

    var _dropIndex = -1;
    var _floatContainer;
    var _whidbeyZone;

    this.get_allowLayoutChange = function() {
        return _allowLayoutChange;
    }

    this.set_allowLayoutChange = function(value) {
        _allowLayoutChange = value;
    }

    this.get_uniqueId = function() {
        return _uniqueId;
    }

    this.set_uniqueId = function(value) {
        _uniqueId = value;
    }

    this.get_webPartManager = function() {
        return _webPartManager;
    }

    this.set_webPartManager = function(value) {
        _webPartManager = value;
    }

    function createFloatContainer(webPart) {
                var floatContainer = document.createElement("div");

                                floatContainer.style.filter = "progid:DXImageTransform.Microsoft.BasicImage(opacity=0.75);";
                floatContainer.style.opacity = "0.75";

        floatContainer.style.position = "absolute";
        floatContainer.style.zIndex = 32000;

        var currentLocation = Sys.UI.Control.getLocation(webPart.element);
        Sys.UI.Control.setLocation(floatContainer, currentLocation);
        floatContainer.style.display = "block";

                floatContainer.style.width = webPart.element.offsetWidth + "px";
        floatContainer.style.height = webPart.element.offsetHeight + "px";

        floatContainer.appendChild(webPart.element.cloneNode(true));

        return floatContainer;
    }

    this.getDescriptor = function() {
        var td = Sys.UI.Controls.WebParts.WebPartZone.callBaseMethod(this, "getDescriptor");
        td.addProperty("uniqueId", String);
        td.addProperty("webPartManager", Object);
        td.addProperty("allowLayoutChange", Boolean);
        return td;
    }

    this.initialize = function() {
        Sys.UI.Controls.WebParts.WebPartZone.callBaseMethod(this, "initialize");

        for (var i=0; i < __wpm.zones.length; i++) {
            if (__wpm.zones[i].zoneElement == this.element) {
                _whidbeyZone = __wpm.zones[i];
                break;
            }
        }

                _whidbeyZone.webPartTable.detachEvent("ondragenter", Zone_OnDragEnter);
        _whidbeyZone.webPartTable.detachEvent("ondrop", Zone_OnDrop);

        if (_webPartManager.get_allowPageDesign() && _allowLayoutChange) {
            Sys.UI.DragDropManager.registerDropTarget(this);
        }
    }

    this.startDragDrop = function(webPart) {
                __wpm.UpdatePositions();

        _floatContainer = createFloatContainer(webPart);
        document.body.appendChild(_floatContainer);
        Sys.UI.DragDropManager.startDragDrop(this, _floatContainer, webPart);
    }

            this.get_dataType = function() {
        return _dataType;
    }

        this.get_data = function(context) {
        return context;
    }

        this.get_dragMode = function() {
        return Sys.UI.DragMode.Copy;
    }

        this.onDragStart = function() {
    }

        this.onDrag = function() {
    }

        this.onDragEnd = function(cancelled) {
                                debug.assert(_floatContainer != null, "_floatContainer is null");
        debug.assert(_floatContainer.parentNode == document.body,
            "_floatContainer is not parented to document.body");

        document.body.removeChild(_floatContainer);
    }

        this.get_dropTargetElement = function() {
        return _whidbeyZone.webPartTable;
    }

        this.canDrop = function(dragMode, dataType, data) {
        var webPart = data;
                        
        return ((dragMode == Sys.UI.DragMode.Copy) &&
                (dataType == _dataType) &&
                (Sys.UI.Controls.WebParts.WebPart.isInstanceOfType(webPart)) &&
                (webPart.get_allowZoneChange() || (webPart.get_zone() == this)) &&
                (getDropIndex() != -1));
    }

        this.drop = function(dragMode, dataType, data) {
                        debug.assert(_dropIndex != -1);

                        _whidbeyZone.ToggleDropCues(false, _dropIndex, false);

        var webPart = data;
        if (webPartMoved(webPart, this, _dropIndex)) {
            var eventTarget = _uniqueId;
            var eventArgument = "Drag:" + webPart.get_id() + ":" + _dropIndex;
            __doPostBack(eventTarget, eventArgument);
        }
    }

    function webPartMoved(webPart, dropZone, dropIndex) {
        if (dropZone != webPart.get_zone()) {
            return true;
        }

                        if (dropIndex == webPart.get_zoneIndex() || dropIndex == (webPart.get_zoneIndex() + 1)) {
            return false;
        }

        return true;
    }

        this.onDragEnterTarget = function(dragMode, dataType, data) {
        var dropIndex = getDropIndex();
        _whidbeyZone.ToggleDropCues(true, dropIndex, false);
        _dropIndex = dropIndex;
    }

        this.onDragLeaveTarget = function(dragMode, dataType, data) {
        _whidbeyZone.ToggleDropCues(false, _dropIndex, false);
    }

        this.onDragInTarget = function() {
        var dropIndex = getDropIndex();
        if (dropIndex != _dropIndex) {
            _whidbeyZone.ToggleDropCues(false, _dropIndex, true);
            _whidbeyZone.ToggleDropCues(true, dropIndex, true);
            _dropIndex = dropIndex;
        }
    }

    function getDropIndex() {
        var pageLocation = __wpGetPageEventLocation(window.event, false);
        return _whidbeyZone.GetWebPartIndex(pageLocation);
    }

}
Sys.UI.Controls.WebParts.WebPartZone.registerClass("Sys.UI.Controls.WebParts.WebPartZone",
    Sys.UI.Control, Sys.UI.IDragSource, Sys.UI.IDropTarget);
Sys.TypeDescriptor.addType("script", "webPartZone", Sys.UI.Controls.WebParts.WebPartZone);
