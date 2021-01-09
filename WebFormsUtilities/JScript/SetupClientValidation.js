this.webfu = this.webfu || {};
webfu.validation = webfu.validation || {};
webfu.validation.validationSummaryValidClass = webfu.validationSummaryValidClass || "validation-summary-valid";
webfu.validation.validationSummaryErrorsClass = webfu.validationSummaryErrorsClass || "validation-summary-error";
webfu.validation.inputValidationErrorClass = webfu.inputValidationErrorClass || "input-validation-error";
webfu.validation.inputValidationValidClass = webfu.inputValidationValidClass || "input-validation-valid";
webfu.validation.fieldValidationErrorClass = webfu.fieldValidationErrorClass || "field-validation-error";
webfu.validation.fieldValidationValidClass = webfu.fieldValidationValidClass || "field-validation-valid";
webfu.validation.errorElement = webfu.validation.errorElement || "span";
webfu.validation.errorPlacement = webfu.validation.errorPlacement || function(error, element) {
    var messageSpan = webfu.fieldToMessageMappings[element.attr("name")];
    $(messageSpan).empty();
    $(messageSpan).removeClass(webfu.validation.fieldValidationValidClass);
    $(messageSpan).addClass(webfu.validation.fieldValidationErrorClass);
    error.removeClass(webfu.validation.inputValidationErrorClass);
    error.attr("_for_validation_message", messageSpan);
    error.appendTo(messageSpan);
};
webfu.validation.success = webfu.validation.success || function(label) {
    var messageSpan = $(label.attr("_for_validation_message"));
    $(messageSpan).empty();
    $(messageSpan).addClass(webfu.validation.fieldValidationValidClass);
    $(messageSpan).removeClass(webfu.validation.fieldValidationErrorClass);
};


// register custom jQuery methods
if (jQuery.validator) { //Only if validator plugin is loaded
    jQuery.validator.addMethod("regex", function(value, element, params) {
        if (this.optional(element)) {
            return true;
        }

        var match = new RegExp(params).exec(value);
        return (match && (match.index == 0) && (match[0].length == value.length));
    });
}

//Most of these methods are "ripped-off" from Microsoft's MVC validation JavaScript and changed slightly.
function __WFU_ApplyValidator_Range(object, min, max) {
    object["range"] = [min, max];
}
function __WFU_ApplyValidator_RegularExpression(object, pattern) {
    object["regex"] = pattern;
}
function __WFU_ApplyValidator_Required(object) {
    object["required"] = true;
}
function __WFU_ApplyValidator_StringLength(object, maxLength) {
    object["maxlength"] = maxLength;
}
function __WFU_ApplyValidator_Unknown(object, validationType, validationParameters) {
    object[validationType] = validationParameters;
}
function __WFU_CreateFieldToValidationMessageMapping(validationFields) {
    var mapping = {};

    for (var i = 0; i < validationFields.length; i++) {
        var thisField = validationFields[i];
        mapping[thisField.FieldName] = "#" + thisField.ValidationMessageId;
    }

    return mapping;
}
function __WFU_CreateErrorMessagesObject(validationFields) {
    var messagesObj = {};

    for (var i = 0; i < validationFields.length; i++) {
        var thisField = validationFields[i];
        var thisFieldMessages = {};
        messagesObj[thisField.FieldName] = thisFieldMessages;
        var validationRules = thisField.ValidationRules;

        for (var j = 0; j < validationRules.length; j++) {
            var thisRule = validationRules[j];
            if (thisRule.ErrorMessage) {
                var jQueryValidationType = thisRule.ValidationType;
                switch (thisRule.ValidationType) {
                    case "regularExpression":
                        jQueryValidationType = "regex";
                        break;

                    case "stringLength":
                        jQueryValidationType = "maxlength";
                        break;
                }

                thisFieldMessages[jQueryValidationType] = thisRule.ErrorMessage;
            }
        }
    }

    return messagesObj;
}
function __WFU_CreateRulesForField(validationField) {
    var validationRules = validationField.ValidationRules;

    // hook each rule into jquery
    var rulesObj = {};
    for (var i = 0; i < validationRules.length; i++) {
        var thisRule = validationRules[i];
        switch (thisRule.ValidationType) {
            case "range":
                __WFU_ApplyValidator_Range(rulesObj,
                    thisRule.ValidationParameters["minimum"], thisRule.ValidationParameters["maximum"]);
                break;

            case "regularExpression":
                __WFU_ApplyValidator_RegularExpression(rulesObj,
                    thisRule.ValidationParameters["pattern"]);
                break;

            case "required":
                __WFU_ApplyValidator_Required(rulesObj);
                break;

            case "stringLength":
                __WFU_ApplyValidator_StringLength(rulesObj,
                    thisRule.ValidationParameters["maximumLength"]);
                break;

            default:
                __WFU_ApplyValidator_Unknown(rulesObj,
                    thisRule.ValidationType, thisRule.ValidationParameters);
                break;
        }
    }

    return rulesObj;
}
function __WFU_CreateValidationOptions(validationFields) {
    var rulesObj = {};
    for (var i = 0; i < validationFields.length; i++) {
        var validationField = validationFields[i];
        var fieldName = validationField.FieldName;
        rulesObj[fieldName] = __WFU_CreateRulesForField(validationField);
    }

    return rulesObj;
}

function __WFU_EnableClientValidation(validationContext) {
    // this represents the form containing elements to be validated
    webfu.validationContext = validationContext;
    if (webfu.validationContext.FormId === "") {
        webfu.theForm = $('form').first();
    } else {
        webfu.theForm = $("#" + validationContext.FormId);
    }

    webfu.fields = webfu.validationContext.Fields;
    webfu.rulesObj = __WFU_CreateValidationOptions(webfu.fields);
    webfu.fieldToMessageMappings = __WFU_CreateFieldToValidationMessageMapping(webfu.fields);
    webfu.errorMessagesObj = __WFU_CreateErrorMessagesObject(webfu.fields);

    webfu.options = {
        errorClass: webfu.inputValidationErrorClass,
        errorElement: webfu.validation.errorElement,
        errorPlacement: webfu.validation.errorPlacement,
        messages: webfu.errorMessagesObj,
        rules: webfu.rulesObj,
        success: webfu.validation.success
    };

    // register callbacks with our AJAX system
    if (webfu.validationContext.FormId === "") {
        webfu.formElement = document.forms[0];
    } else {
        webfu.formElement = document.getElementById(webfu.validationContext.FormId);
    }
    webfu.registeredValidatorCallbacks = webfu.formElement.validationCallbacks;
    if (!webfu.registeredValidatorCallbacks) {
        webfu.registeredValidatorCallbacks = [];
        webfu.formElement.validationCallbacks = webfu.registeredValidatorCallbacks;
    }
    webfu.registeredValidatorCallbacks.push(function() {
        webfu.theForm.validate();
        return webfu.theForm.valid();
    });

    webfu.theForm.validate(webfu.options);
}
// need to wait for the document to signal that it is ready
$(document).ready(function() {
    if (jQuery.validator) { //Only if validator plugin is loaded
        var allFormOptions = window.wfuClientValidationMetadata;
        if (allFormOptions) {
            while (allFormOptions.length > 0) {
                var thisFormOptions = allFormOptions.pop();
                __WFU_EnableClientValidation(thisFormOptions);
            }
        }
    }
});