/*  JavaScript implementation of WebFu HtmlTag.cs
No dependance on jQuery or other WebFu scripts :)
msnead 5/10/2012

Usage:
Functions, constructor, methods are almost identical to WebFormsUtilities.HtmlTag C# class
ie:
var tag = webfu.HtmlTag(); //creates an HTML tag
var tag = webfu.HtmlTag("input"); //creates <input></input>
var tag = webfu.HtmlTag("br", true); //creates <br />
var tag = webfu.HtmlTag("div", { style: "color:red;" }) //creates <div style="color:red;"></div>
    
You can also use "initialization" arguments:
var tag = webfu.HtmlTag("div", { class: "someclass" })({ InnerText: "sometext" }) //creates <div class="someclass">sometext</div> 
    
"initialization" arguments include
- Children [] of HtmlTag
- InnerText string
- SelfClosing bool
        

Constructor (don't use the "new" keyword)
var htmlTag = webfu.HtmlTag(arg1,arg2,arg3)
arg1: optional, string, HTMLTagName
arg2: optional
boolean - whether or not the tag is self closing
object - properties of arg2 are applied to HTMLProperties
arg3: optional, boolean, whether or not the tag is self closing

See http://webfu.codeplex.com/wikipage?title=HtmlTag.js&referringTitle=Documentation for complete documentation.
*/

(function(context) {

    //Utility method to determine how many properties an object has
    //https://developer.mozilla.org/en/JavaScript/Reference/Global_Objects/Object/keys
    if (!Object.keys) {
        Object.keys = (function() {
            var hasOwnProperty = Object.prototype.hasOwnProperty,
				hasDontEnumBug = !({ toString: null }).propertyIsEnumerable('toString'),
				dontEnums = [
				  'toString',
				  'toLocaleString',
				  'valueOf',
				  'hasOwnProperty',
				  'isPrototypeOf',
				  'propertyIsEnumerable',
				  'constructor'
				],
				dontEnumsLength = dontEnums.length

            return function(obj) {
                if (typeof obj !== 'object' && typeof obj !== 'function' || obj === null) throw new TypeError('Object.keys called on non-object')

                var result = []

                for (var prop in obj) {
                    if (hasOwnProperty.call(obj, prop)) result.push(prop)
                }

                if (hasDontEnumBug) {
                    for (var i = 0; i < dontEnumsLength; i++) {
                        if (hasOwnProperty.call(obj, dontEnums[i])) result.push(dontEnums[i])
                    }
                }
                return result
            }
        })()
    };

    //Utility method to determine what type a variable may be
    //http://stackoverflow.com/questions/332422/how-do-i-get-the-name-of-an-objects-type-in-javascript
    function type(obj) {
        return Object.prototype.toString.call(obj).match(/^\[object (.*)\]$/)[1];
    }

    //Utility method to HTML encode
    //http://stackoverflow.com/questions/1219860/javascript-jquery-html-encoding
    function htmlEscape(str) {
        return String(str)
					.replace(/&/g, '&amp;')
					.replace(/"/g, '&quot;')
					.replace(/'/g, '&#39;')
					.replace(/</g, '&lt;')
					.replace(/>/g, '&gt;');
    }

    //arg1: May be a string to specify the HTML tag name
    //arg2: 
    //		-- May be an object, will derive HTML properties from this object
    //		-- May be a boolean whether or not the HTML tag is self-closing
    //arg3: May be a boolean whether or not the HTML tag is self-closing
    var HtmlTag = function(arg1, arg2, arg3) {

        var _HTMLProperties = {};
        var _InnerText;
        var _Children = [];

        var htmlTag = function(props) {
            for (var attr in props) {
                if (props.hasOwnProperty(attr)) {
                    if (attr.toLowerCase() === "innertext") {
                        _InnerText = props[attr];
                    } else if (attr.toLowerCase() === "children") {
                        _Children = props[attr];
                    } else if (attr.toLowerCase() === "selfclosing") {
                        htmlTag.SelfClosing = props[attr];
                    } else if (attr.toLowerCase() === "htmlproperties") {
                        _HTMLProperties = props[attr]
                    }
                }
            }
            return htmlTag;
        };

        if (arg1 !== undefined) {
            if (type(arg1) === 'String') {
                htmlTag.HTMLTagName = arg1;
            }
        }
        if (arg2 !== undefined) {
            if (type(arg2) === 'Boolean') { htmlTag.SelfClosing = arg2; }
            else {
                for (var attr in arg2) {
                    if (arg2.hasOwnProperty(attr)) {
                        _HTMLProperties[attr] = arg2[attr];
                    }
                }
            }
        }
        if (arg3 !== undefined) {
            if (type(arg3) === 'Boolean') { htmlTag.SelfClosing = arg2; }
        }

        htmlTag.MergeObjectProperties = function(props) {
            for (var attr in arg2) {
                if (arg2.hasOwnProperty(attr)) {
                    _HTMLProperties[attr] = arg2[attr];
                }
            }
        };

        htmlTag.getHTMLProperties = function() {
            return _HTMLProperties;
        };
        htmlTag.setHTMLProperties = function(val) {
            _HTMLProperties = val;
        };

        htmlTag.getInnerText = function() {
            return _InnerText;
        };
        htmlTag.setInnerText = function(val) {
            _InnerText = val;
        };
        htmlTag.getChildren = function() {
            return _Children;
        };
        htmlTag.setChildren = function(val) {
            _Children = val;
        };
        htmlTag.Children = {};
        htmlTag.Children.Add = function(tag) {
            _Children.push(tag);
        };
        htmlTag.Children.Remove = function(tag) {
            for (var i = 0; i < _Children.length; i++) {
                if (tag === _Children[i]) {
                    _Children.splice(i, 1);
                }
            }
        };
        htmlTag.Children.RemoveAt = function(index) {
            _Children.splice(index, 1);
        };
        htmlTag.Attr = function(attName, attValue) {
            if (attValue === undefined) {
                if (_HTMLProperties[attName] !== undefined) {
                    return _HTMLProperties[attName];
                } else {
                    return "";
                }
            } else {
                _HTMLProperties[attName] = attValue;
            }
            return _HTMLProperties[attName];
        };
        htmlTag.RenderBeginningOnly = function() {
            var retTxt = "";
            retTxt += "<" + htmlTag.HTMLTagName;
            if (_HTMLProperties !== undefined) {
                for (var attr in _HTMLProperties) {
                    if (_HTMLProperties.hasOwnProperty(attr)) {
                        retTxt += " " + attr + " = \"" + _HTMLProperties[attr] + "\"";
                    }
                }
            }
            retTxt += ">";
            return retTxt;
        };
        htmlTag.RenderEndingOnly = function() {
            var retTxt = "";
            retTxt += "</" + htmlTag.HTMLTagName + ">";
            return retTxt;
        };
        htmlTag.Render = function() {
            var retTxt = "";
            if (!htmlTag.SelfClosing) {
                retTxt += "<" + htmlTag.HTMLTagName;
                if (_HTMLProperties !== undefined) {
                    for (var attr in _HTMLProperties) {
                        if (_HTMLProperties.hasOwnProperty(attr)) {
                            retTxt += " " + attr + " = \"" + _HTMLProperties[attr] + "\"";
                        }
                    }
                }
                retTxt += ">";
                if (_Children !== undefined && _Children.length > 0) {
                    for (var i = 0; i < _Children.length; i++) {
                        if (_Children[i].Render !== undefined) {
                            retTxt += _Children[i].Render();
                        }
                    }
                } else {
                    if (_InnerText) {
                        retTxt += _InnerText;
                    }
                }
                retTxt += "</" + htmlTag.HTMLTagName + ">";
            } else {
                retTxt += "<" + htmlTag.HTMLTagName;
                if (_HTMLProperties !== undefined) {
                    for (var attr in _HTMLProperties) {
                        if (_HTMLProperties.hasOwnProperty(attr)) {
                            retTxt += " " + attr + " = \"" + _HTMLProperties[attr] + "\"";
                        }
                    }
                }
                retTxt += " />";
            }
            return retTxt;

        };
        var _ToString = htmlTag.ToString;
        htmlTag.ToString = function() { return htmlTag.Render(); }

        htmlTag.AddClass = function(clsName) {
            if (_HTMLProperties["class"]) {
                if (_HTMLProperties["class"] !== "") {
                    var classes = _HTMLProperties["class"].split(' ');
                    for (var i = 0; i < classes.length; i++) {
                        if (classes[i].toLowerCase() === clsName) {
                            return;
                        }
                    }
                    _HTMLProperties["class"] = _HTMLProperties["class"] + " " + clsName;
                }
            } else {
                _HTMLProperties["class"] = clsName;
            }
        };
        htmlTag.RemoveClass = function(clsName) {
            if (_HTMLProperties["class"]) {
                if (_HTMLProperties["class"] !== "") {
                    var newClasses = "";
                    var classes = _HTMLProperties["class"].split(' ');
                    for (var i = 0; i < classes.length; i++) {
                        if (classes[i].toLowerCase() !== clsName.toLowerCase()) {
                            newClasses += (newClasses === "") ? classes[i] : " " + classes[i];
                        }
                    }
                    htmlTag.Attr("class", newClasses);
                }
            }
        };
        htmlTag.IsClass = function(clsName) {
            if (_HTMLProperties["class"] &&
					_HTMLProperties["class"] !== "") {
                var classes = _HTMLProperties["class"].split(' ');
                for (var i = 0; i < classes.length; i++) {
                    if (classes[i].toLowerCase() === clsName) {
                        return true;
                    }
                }
            }
            return false;
        }

        htmlTag.SanitizeForMarkup = function(input) {
            return htmlEscape(input);
        };
        return htmlTag;
    };

    var HtmlTagLiteral = function(innerText) {
        var literal = {};
        var _InnerText = innerText;
        literal.Render = function() {
            return _InnerText;
        };
        return literal;
    };

    context.webfu = context.webfu || {};
    context.webfu.HtmlTag = context.webfu.HtmlTag || HtmlTag;
    context.webfu.HtmlTagLiteral = context.webfu.HtmlTagLiteral || HtmlTagLiteral;
})(this);