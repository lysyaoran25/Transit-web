//WFUtilitiesJquery.js
(function(context) {
    var $wf = function() {
        /// <summary>
        /// WebFu JavaScript object. Can be accessed via $wf or webfu.
        ///&#10; Functions include:
        ///&#10; webfu.submitForm()
        ///&#10; webfu.enableUpload()
        ///&#10; webfu.callPage()
        ///&#10; webfu.serializePage()
        return new $wf.fn.init(context);
    };
    //Would like to imitate jQuery here somewhat
    //$wf.fn = { "webfu": '0.2012.03.28' };
    //$wf.fn = $wf.prototype;
    //$wf.fn.init.prototype = $wf.fn;
    //$wf.prototype.init = function

    // WFUtilities
    function WFSubmitForm(methodName) {
        /// <summary>Invoke a full postback, passing an extra JSMethod form variable to indicate which method the server should invoke.
        /// &#10;You can use WFPageUtilities.CallJSMethod() on the server side during a postback to call this method automatically.
        /// &#10;The target method should have two arguments: object sender and EventArgs e, which will both be null.</summary>
        /// <param name="methodName" type="String">The name of the method on the page class to invoke.</param>
        /// <returns>Returns false.</returns>
        var elem = $('#JSMethod');
        var elemStr = '<input type="hidden" name="JSMethod" id="JSMethod" value="' + methodName + '" />';
        if (elem[0] === undefined) {
            elem = $("form").append(elemStr);
        } else {
            elem = $('#JSMethod').replaceWith(elemStr);
        }
        (document.forms[0]).submit();
        return false;
    }

    function WFEnableUpload() {
        ///<summary>Add enctype and encoding attributes to the &lt;form&gt; tag so that WebForms will see the files uploaded by &lt;input type=file&gt;</summary>
        $('form').attr("enctype", "multipart/form-data");
        $('form').attr("encoding", "multipart/form-data");
    }


    //Syntax is like this:
    //  PageName.aspx/MethodName
    //This works against AJAX in 3.5 but not 2.0 (2.0 has no .d property)
    function WFCallPage(pageMethodURL, args) {
        ///<summary>Shortcut to invoke a [WebMethod] using jQuery's $.ajax()
        ///&#10;[WebMethod]'s from any WebForms page can be called.
        ///&#10;If you wish to send JavaScript objects in args.data, be sure to include JSON2.js for older browsers.</summary>
        ///<param name="pageMethodURL" type="String">Syntax: PageName.aspx/WebMethodName</param>
        ///<param name="args" type="Object">Magic arguments object that will be passed to jQuery's ajax.
        /// &#10;   data: String or Object. String must be in the form of a JSON object which must match the signature of the webmethod.
        /// &#10;         If using an Object, JSON2.js must be used for older browsers for JSON.stringify().
        /// &#10;   success: function(a, b, c),
        /// &#10;   error: function(a, b, c)
        /// &#10; For additional arguments, see jQuery's .ajax documentation.</param>
        if (args.data === undefined || args.data === null || args.data === "") { args.data = "{}"; }
        //If the object is not a string
        if (Object.prototype.toString.call(args.data) !== '[object String]') {
            if (!JSON) {
                alert('Error: Please include JSON2.js as JSON.stringify() is needed for sending objects through AJAX.');
            } else {
                args.data = JSON.stringify(args.data);
            }
        }
        $.ajax({ type: "POST", url: pageMethodURL, data: args.data, contentType: "application/json; charset=utf-8",
            async: args.async,
            dataType: "json",
            success: function(a, b, c) {
                if (args.success != undefined && args.success != null) {
                    args.success(a, b, c);
                }
            },
            error: function(a, b, c) {
                if (args.error != undefined && args.error != null) {
                    args.error(a, b, c);
                }
            }
        });
    }

    function WFSerializePage(includeViewState) {
        ///<summary>Serialize the page into a post 'body' string. (ie: name=value&amp;name2=value2...) Will escape double-quotes.
        ///&#10;Sample usage with jQuery.ajax might be: '{"formValues":"' + webfu.serializePage() + '"}'</summary>
        ///<param name="includeViewState" type="bool">Optional: Whether to include WebForms __VIEWSTATE, __EVENTVALIDATION, etc.</param>
        ///<returns>Returns a string in the form of (ie: name=value&amp;name2=value2...)</returns>
        var retStr = "";
        var selector = $(':input');
        if (includeViewState === undefined || includeViewState !== true) {
            selector = selector.not('#__VIEWSTATE,#__EVENTVALIDATION,#__EVENTTARGET,#__EVENTARGUMENT');
        }
        selector.each(function() {
            var name = this.name;
            var value;
            if (this.type && this.type.toLowerCase() === "checkbox") {
                if (this.checked) {
                    value = $(this).val();
                } else {
                    //Bail out! This checkbox should not be included.
                    return;
                }
            } else {
                value = $(this).val();
            }
            if (name === "" || name === undefined) {
                name = this.id;
            }
            if (name === "") { return; } //if we can't find a name for this control, don't send it
            name = encodeURIComponent(name);
            value = encodeURIComponent(value);
            retStr += (retStr == '') ? name + '=' + value : '&' + name + '=' + value;
        });
        return retStr;
    }
    context.$wf = context.$wf || $wf;
    context.webfu = context.webfu || $wf;

    $wf.submitForm = WFSubmitForm;
    $wf.enableUpload = WFEnableUpload;
    $wf.callPage = WFCallPage;
    $wf.serializePage = WFSerializePage;


})(this);