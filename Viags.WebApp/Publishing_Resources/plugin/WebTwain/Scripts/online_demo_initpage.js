var _dwtParam = {
    'productKey': 'D829518254915FD980BE1787DF5F616C216ACAB49EC30528F1BF76DEFB204E46216ACAB49EC305280526295C0E6EF647216ACAB49EC305281BBFB22F671BD8E130000000',
    'containerID': 'dwtcontrolContainer',   //The ID of Dynamic Web TWAIN control div in HTML.This value is required.

    'width': _iWidth,        //The width of Dynamic Web TWAIN control. This value is optional. The default value is '580'.
    'height': _iHeight,       //The height of  Dynamic Web TWAIN control.This value is optional. The default value is '600'.

    /*
    'isTrial': 'true',  
    isTrial is used to judge whether Dynamic Web TWAIN control is trial or full. This value is optional.
    The default value is 'TRUE', which means the control is a trial one. The value of isTrial is 'TRUE' or 'FALSE'.
    */

    /*
    'version': '9,2',   
    The version of Dynamic Web TWAIN control, which is used to judge the version when downloading CAB.
    This value is optional. The default value is '9,2'.
    */

    /*
    'resourcesPath': 'Resources',   
    The relative path of MSI, CAB and PKG.
    This value is optional. The default value is 'Resources'.
    */

    /*  These are events. The name of 'OnPostAllTransfer' shouldn't be changed, but the name of 'Dynamsoft_OnPostAllTransfers' can be modified. 
    Please pay attention, the name of 'Dynamsoft_OnPostAllTransfers' and 'function Dynamsoft_OnPostAllTransfers()' event must be coincident.
        
    Events are as follows. You can choose one or many according to you needs.
    Once an event is added, you must make sure the corresponding function is defined in your code.
        
    'onPostTransfer':Dynamsoft_OnPostTransfer,
    'onPostAllTransfers':Dynamsoft_OnPostAllTransfers,  
    'onMouseClick':Dynamsoft_OnMouseClick,   
    'onPostLoad':Dynamsoft_OnPostLoadfunction,    
    'onImageAreaSelected':Dynamsoft_OnImageAreaSelected,   
    'onMouseDoubleClick':Dynamsoft_OnMouseDoubleClick,   
    'onMouseRightClick':Dynamsoft_OnMouseRightClick,   
    'onTopImageInTheViewChanged':Dynamsoft_OnTopImageInTheViewChanged,   
    'onImageAreaDeSelected':Dynamsoft_OnImageAreaDeselected,    
    'onGetFilePath':Dynamsoft_OnGetFilePath  
    */                              
    'isTrial': 'false', //
    'onPostTransfer': Dynamsoft_OnPostTransfer,
    'onPostAllTransfers':Dynamsoft_OnPostAllTransfers,
    'onMouseClick':Dynamsoft_OnMouseClick,   
    'onPostLoad':Dynamsoft_OnPostLoadfunction,    
    'onImageAreaSelected':Dynamsoft_OnImageAreaSelected,   
    'onMouseDoubleClick':Dynamsoft_OnMouseDoubleClick,   
    'onMouseRightClick':Dynamsoft_OnMouseRightClick,   
    'onTopImageInTheViewChanged':Dynamsoft_OnTopImageInTheViewChanged,
    'onImageAreaDeSelected': Dynamsoft_OnImageAreaDeselected,
    'onGetFilePath': Dynamsoft_OnGetFilePath
   
};


var gWebTwain;
(function() {
    gWebTwain = new Dynamsoft.WebTwain(_dwtParam);
})();


//--------------------------------------------------------------------------------------
//************************** Don't change these properties *****************************
//--------------------------------------------------------------------------------------
var DWObject;            // The DWT Object
var _bInIE;               // If it is in IE
var _bInWindows;          // If it is in Windows OS
var _bInWindowsX86;       // If it is in X86 platform
var _divMessageContainer;   // For message display
var _strTempStr = "";       // Store the temp string for display
var _iWidth = 580;        // The width of the main control. User can change it.
var _iHeight = 600;       // The width of the main control. User can change it.

//--------------------------------------------------------------------------------------
//****************** Default value provided. User can change it accordingly ************
//--------------------------------------------------------------------------------------
var _bDiscardBlankImage = false;  // User can change it.
var _bShowMessagePanel = true;
var _bShowNavigatorPanel = true;
var _divDWTSourceContainerID = "source";     // The ID of the container (Usually <select>) which is used to show the available sources. User must specify it.
var _iLeft, _iTop, _iRight, _iBottom; //These variables are used to remember the selected area
var _txtFileNameforSave, _txtFileName, _chkMultiPageTIFF_save, _chkMultiPagePDF_save, _chkMultiPageTIFF, _chkMultiPagePDF;
//--------------------------------------------------------------------------------------
//****************** User must specify it before using DWT *****************************
//--------------------------------------------------------------------------------------
var _divDWTContainerID = "dwtcontrolContainer"; //"DWTContainerID"; // The ID of the container (Usually a DIV) which is used to contain DWT object. User must specify it.
var _divDWTNonInstallContainerID = "DWTNonInstallContainerID" // The ID of the container (Usually a DIV) which is used to show a message if DWT is not installed. User must specify it.
var _strDefaultSaveImageName = "ImageFile";
var _strNoDrivers = "No TWAIN compatible drivers detected:";
var _strMSIPath = "Resources/DynamicWebTWAINPlugIn.msi";
var _strPKGPath = "Resources/DynamicWebTWAINMacEdition.pkg";
var _strProductName = "Dynamic Web TWAIN";


//Upload
var _strServerName = location.hostname; //Demo: "www.dynamsoft.com";
var _strPort = location.port == "" ? 80 : location.port; //Demo: 80;

//Sample
//var _strActionPage = "SaveToFile.aspx";
var _strActionPage = "SaveToDB.aspx";
var _strDynamsoftWithClose = "<div style='height:40px'><a href=\"http://www.dynamsoft.com/\" style='padding-right:60px'><img src=\"Images/logo.gif\" alt=\"Dynamsoft: provider of version control solution and TWAIN SDK\" name=\"logo\" width=\"159\" height=\"34\" border=\"0\" align=\"left\" id=\"logo\" title=\"Dynamsoft: provider of version control solution and TWAIN SDK\" /></a><div style='height:30px;padding-left:48px; position:absolute; top:5px; left:110px'><a href='javascript: void(0)' style='text-decoration:none; padding-left:210px' class='ClosetblCanNotScan'>X</a></div></div>";

var _strCanNotScanDetail = "<div class=\"D-dailog-body-Scan-sample\" style=\"width:380px\">" + _strDynamsoftWithClose + "<div class=\"box_title_scan\">Fail to use your scanner on the demo? Please try:</div><ul>"
    + "<li><div class=\"box_scan_subtitle\">Add the website to the zone of trusted sites.</div><div class=\"box_scan_detail\">IE | Tools | Internet Options | Security | Trusted Sites.</div></li>"
    + "<li><div class=\"box_scan_subtitle\">Turn Protected Mode off. </div><div class=\"box_scan_detail\">To turn off the protected mode of IE, you can go to Tools | Internet Options | Security and uncheck \"Enable Protected Mode(requires restarting Internet Explorer)\" option.</div></li>"
    + "</ul></div>";
var _iCanNotScanDialogHeigth = 242;

// Assign the page onload fucntion.
function S_get(id) {
    return document.getElementById(id);
}

var S = KISSY, Event = S.Event, Dom = S.DOM;

var seed;
function pageonload() {
    getEnvironment();
    
    initMessageBox(false);  //Messagebox
    initCustomScan();       //CustomScan

    initiateInputs();
    seed = setInterval(controlDetect, 500);     
}


function getEnvironment() {
    // Get User Agent Value
    ua = (navigator.userAgent.toLowerCase());
    if (ua.indexOf("wow64") == -1) {
        var samplesource32bitCtr = document.getElementById("samplesource32bit");
        if (samplesource32bitCtr)
            samplesource32bitCtr.href = "http://www.dynamsoft.com/demo/DWT/Sources/twainkit.exe";
    }

    // Set the Explorer Type
    if (ua.indexOf("msie") != -1 || ua.indexOf('trident') != -1)
        _bInIE = true;
    else
        _bInIE = false;

    // Set the Operating System Type
    if (ua.indexOf("macintosh") != -1)
        _bInWindows = false;
    else
        _bInWindows = true;

    // Set the x86 and x64 type
    if (ua.indexOf("win64") != -1 && ua.indexOf("x64") != -1)
        _bInWindowsX86 = false;
    else
        _bInWindowsX86 = true;
}

function initCustomScan() {
    var ObjString = "<ul id='divTwainType' style='height:70px; background:#f0f0f0;'> ";
    ObjString += "<li style='padding-left:12px;'>";
    ObjString += "<label for = 'ShowUI'><input type='checkbox' id='ShowUI' />Show UI&nbsp;</label>";
    ObjString += "<label for = 'ADF'><input type='checkbox' id='ADF' />ADF&nbsp;</label>";
    ObjString += "<label for = 'Duplex'><input type='checkbox' id='Duplex'/>Duplex</label></li>";
    ObjString += "<li style='padding-left:15px;'>Pixel Type:";
    ObjString += "<label for='BW'><input type='radio' id='BW' name='PixelType'/>B&amp;W </label>";
    ObjString += "<label for='Gray'><input type='radio' id='Gray' name='PixelType'/>Gray</label>";
    ObjString += "<label for='RGB'><input type='radio' id='RGB' name='PixelType'/>Color</label></li>";
    ObjString += "<li style='padding-left:15px;'>";
    ObjString += "<label for='Resolution'>Resolution:<select size='1' id='Resolution'><option value = ''></option></select></label></li>";
    ObjString += "</ul>";
    document.getElementById("divProductDetail").innerHTML = ObjString;

    var vResolution = document.getElementById("Resolution");
    vResolution.options.length = 0;
    vResolution.options.add(new Option("100", 100));
    vResolution.options.add(new Option("150", 150));
    vResolution.options.add(new Option("200", 200));
    vResolution.options.add(new Option("300", 300));
}

function initiateInputs() {

    var allinputs = document.getElementsByTagName("input");
    for (var i = 0; i < allinputs.length; i++) {
        if (allinputs[i].type == "checkbox") {
            allinputs[i].checked = false;
        }
        else if (allinputs[i].type == "text") {
            allinputs[i].value = "";
        }
    }

    if (!_bInWindows) {
        document.getElementById("btnEditor").style.display = "none";
        document.getElementById("tblLoadImage").style.height = "170";
        document.getElementById("notformac1").style.display = "none";
    }

    if (_bInIE == true && _bInWindowsX86 == false) {
        document.getElementById("samplesource64bit").style.display = "inline";
        document.getElementById("samplesource32bit").style.display = "none";
    }

    vShowNoControl = false;
    vNotAllowedForChrome = false;
    if (!_bInIE)
        vPluginLength = navigator.plugins.length;

}

function initMessageBox(bNeebBack) {
    var objString = "";

    // The container for navigator, view mode and remove button
    objString += "<div style='text-align:center; width:" + _iWidth + "px; background-color:#FFFFFF;";
    if (_bShowNavigatorPanel)
        objString += "display:block'>";
    else
        objString += "display:none'>";
    objString += "<div style='position:relative; background:white; float:left; width:430px; height:35px; z-index:2;'>";
    objString += "<input id='DW_btnFirstImage' onclick='btnFirstImage_onclick()' type='button' value=' |&lt; '/>&nbsp;";
    objString += "<input id='DW_btnPreImage' onclick='btnPreImage_onclick()' type='button' value=' &lt; '/>&nbsp;&nbsp;";
    objString += "<input type='text' size='2' id='DW_CurrentImage' readonly='readonly'/>/";
    objString += "<input type='text' size='2' id='DW_TotalImage' readonly='readonly'/>&nbsp;&nbsp;";
    objString += "<input id='DW_btnNextImage' onclick='btnNextImage_onclick()' type='button' value=' &gt; '/>&nbsp;";
    objString += "<input id='DW_btnLastImage' onclick='btnLastImage_onclick()' type='button' value=' &gt;| '/></div>";
    objString += "<div style='position:relative; background:white; float:left; width:150px; height:35px;z-index:2;'>Preview Mode";
    objString += "<select size='1' id='DW_PreviewMode' onchange ='setlPreviewMode();'>";
    objString += "    <option value='0'>1X1</option>";
    objString += "</select><br /></div>";
    objString += "<div style='position:relative;'><input id='DW_btnRemoveCurrentImage' onclick='btnRemoveCurrentImage_onclick()' type='button' value='Remove Selected Images'/>";
    if (bNeebBack) {
        objString += "<input id='DW_btnRemoveAllImages' onclick='btnRemoveAllImages_onclick()' type='button' value='Remove All Images'/><br /><br />";
        objString += "<span style=\"font-size:larger\"><a href =\"OnlineDemoList.aspx\"><b>Back</b></a></span><br /></div>";
    }
    else
        objString += "<input id='DW_btnRemoveAllImages' onclick='btnRemoveAllImages_onclick()' type='button' value='Remove All Images'/><br /></div>";
    objString += "</div>";

    // The container for the error message
    objString += "<div id='DWTdivMsg' style='width:" + _iWidth + "px;";
    if (_bShowMessagePanel)
        objString += "display:inline'>";
    else
        objString += "display:none'>";
    objString += "Message:<br />"
    objString += "<div id='DWTemessage' style='width:" + _iWidth + "px;height:80px; overflow:scroll; background-color:#ffffff; border:1px #303030; border-style:solid; text-align:left; position:relative' >";
    objString += "</div></div>";

    var DWTemessageContainer = document.getElementById("DWTemessageContainer");
    DWTemessageContainer.innerHTML = objString;

    // Fill the init data for preview mode selection
    var varPreviewMode = document.getElementById("DW_PreviewMode");
    varPreviewMode.options.length = 0;
    varPreviewMode.options.add(new Option("1X1", 0));
    varPreviewMode.options.add(new Option("2X2", 1));
    varPreviewMode.options.add(new Option("3X3", 2));
    varPreviewMode.options.add(new Option("4X4", 3));
    varPreviewMode.options.add(new Option("5X5", 4));
    varPreviewMode.selectedIndex = 0;

    _divMessageContainer = document.getElementById("DWTemessage");
    _divMessageContainer.ondblclick = function() {
        this.innerHTML = "";
        _strTempStr = "";
    }

}

function initDllForChangeImageSize() {

    var vInterpolationMethod = document.getElementById("InterpolationMethod");
    vInterpolationMethod.options.length = 0;
    vInterpolationMethod.options.add(new Option("NearestNeighbor", 1));
    vInterpolationMethod.options.add(new Option("Bilinear", 2));
    vInterpolationMethod.options.add(new Option("Bicubic", 3));

}

function setDefaultValue() {
    document.getElementById("Gray").checked = true;
    //document.getElementById("imgTypejpeg2").checked = true;
    document.getElementById("imgTypejpeg").checked = true;

    _txtFileNameforSave = document.getElementById("txt_fileNameforSave");
    _txtFileNameforSave.value = _strDefaultSaveImageName;

    //_txtFileName = document.getElementById("txt_fileName");
    //_txtFileName.value = _strDefaultSaveImageName;
    _txtFileName = document.getElementById("txtFileName");
    _txtFileName.value = _strDefaultSaveImageName;

    _chkMultiPageTIFF_save = document.getElementById("MultiPageTIFF_save");
    _chkMultiPageTIFF_save.disabled = true;
    _chkMultiPagePDF_save = document.getElementById("MultiPagePDF_save");
    _chkMultiPagePDF_save.disabled = true;
    _chkMultiPageTIFF = document.getElementById("MultiPageTIFF");
    _chkMultiPageTIFF.disabled = true;
    _chkMultiPagePDF = document.getElementById("MultiPagePDF");
    _chkMultiPagePDF.disabled = true;
}



// Check if the control is fully loaded.
var vShowNoControl;
var vNotAllowedForChrome;
var vPluginLength = 0;
function controlDetect() {
    var liNoScanner = document.getElementById("pNoScanner");
    // If the ErrorCode is 0, it means everything is fine for the control. It is fully loaded.
    DWObject = gWebTwain.getInstance();
    if (DWObject) {
        if (DWObject.ErrorCode == 0) {
            clearInterval(seed);
            DWObject.MaxImagesInBuffer = 64;     // This is default value. User can change this value later
            DWObject.loglevel = 1;
            DWObject.BrokerProcessType = 1;

            document.getElementById(_divDWTSourceContainerID).options.length = 0;
            // If source list need to be displayed, fill in the source items.
            if (_divDWTSourceContainerID != "") {
                if (DWObject.SourceCount == 0) {

                    if (_bInWindows) {
                        liNoScanner.style.display = "block";
                        liNoScanner.style.textAlign = "center";
                    }
                    else
                        liNoScanner.style.display = "none";
                }
                for (var i = 0; i < DWObject.SourceCount; i++) {
                    document.getElementById(_divDWTSourceContainerID).options.add(new Option(DWObject.GetSourceNameItems(i), i));
                }

                if (DWObject.SourceCount > 0) {
                    source_onchange();
                }
            }

            if (_bInWindows)
                DWObject.MouseShape = false;

            if (DWObject.SourceCount == 0)
                document.getElementById("btnScan").disabled = true;
            else {
                document.getElementById("btnScan").disabled = false;
                //document.getElementById("btnScan").style.color = "#FE8E14";
            }

            initDllForChangeImageSize();
            setDefaultValue();

            re = /^\d+$/;
            strre = /^[\s\w]+$/;
            refloat = /^\d+\.*\d*$/i;

            _iLeft = 0;
            _iTop = 0;
            _iRight = 0;
            _iBottom = 0;

            for (var i = 0; i < document.links.length; i++) {
                if (document.links[i].className == "ShowtblLoadImage") {
                    document.links[i].onclick = showtblLoadImage_onclick;
                }
                if (document.links[i].className == "ClosetblLoadImage") {
                    document.links[i].onclick = closetblLoadImage_onclick;
                }
            }
            if (DWObject.SourceCount == 0) {
                if (_bInWindows) {
                    document.getElementById("aNoScanner").style.color = "Red";
                    document.getElementById("aNoScanner").innerHTML = "<b>" + _strNoDrivers + "<b/>";
                    document.getElementById("Resolution").style.display = "none";
                    showtblLoadImage_onclick();
                }

            }
            else
                document.getElementById("divBlank").style.display = "none";

            updatePageInfo();
            ua = (navigator.userAgent.toLowerCase());
            if (!ua.indexOf("msie 6.0")) {
                ShowSiteTour();
            }
        }
        else {
            if (!_bInIE) {
                    for (var i = 0; i < navigator.mimeTypes.length; i++) {
                        if (navigator.mimeTypes[i].type.toLowerCase().indexOf("Application/DynamicWebTwain-Plugin".toLowerCase()) > -1) {
                            if (vNotAllowedForChrome == false) {

                                notAllowedForChrome();
                                vNotAllowedForChrome = true;
                            }
                            
                        }
                    }
            }

            if (vNotAllowedForChrome == false) {
                if (vShowNoControl == false) {
                    noControl();
                    vShowNoControl = true;

                    for (var i = 0; i < document.links.length; i++) {
                        if (document.links[i].className == "ClosetblCanNotScan") {
                            document.links[i].onclick = closetblInstall_onclick;
                        }
                    }
                }
            }
        }
    }
}

var dlgInstall;
function noControl() {
    ua = (navigator.userAgent.toLowerCase());
    // For mac, create the message to tell the user to install the plugin.
    if (!_bInWindows) {
        createNonInstallDivMac();
        // Display the message and hide the main control
        document.getElementById(_divDWTNonInstallContainerID).style.display = "inline";
        document.getElementById(_divDWTContainerID).style.display = "none";
        document.getElementById("DWTemessageContainer").style.display = "none";
        document.getElementById("ScanWrapper").style.display = "none";

        var logo = S.one('#divLogo');
        if (logo) {
            var vComm100 = S.one('#linkComm100');
            if (vComm100)
                vComm100.appendTo(logo);
        }

        S.use("overlay", function(S, o) {

            dlgInstall = new o.Dialog({
                srcNode: "#J_waiting",
                width: 392,
                height: 277,
                closable: false,
                mask: true,
                align: {
                    points: ['cc', 'cc']
                }
            });
            dlgInstall.show();
        });
    }
    // For other browsers on Windows, create the message to tell the user to install the plugin.
    else if (ua.match(/chrome\/([\d.]+)/) || ua.match(/opera.([\d.]+)/) || ua.match(/version\/([\d.]+).*safari/) || ua.match(/firefox\/([\d.]+)/)) {
        createNonInstallDivPlugin();

        // Display the message and hide the main control
        document.getElementById(_divDWTNonInstallContainerID).style.display = "inline";
        document.getElementById(_divDWTContainerID).style.display = "none";
        document.getElementById("DWTemessageContainer").style.display = "none";
        document.getElementById("ScanWrapper").style.display = "none";

        var divBlankCtrl = document.getElementById("divBlank");
        if (divBlankCtrl)
            divBlankCtrl.style.display = "inline";

        var logo = S.one('#divLogo');
        if (logo) {
            var vComm100 = S.one('#linkComm100');
            if (vComm100)
                vComm100.appendTo(logo);
        }

        S.use("overlay", function(S, o) {

            dlgInstall = new o.Dialog({
                srcNode: "#J_waiting",
                width: 392,
                height: 242,
                closable: false,
                mask: true,
                align: {
                    points: ['cc', 'cc']
                }
            });
            dlgInstall.show();
        });
    }
}

function notAllowedForChrome() {
    ua = (navigator.userAgent.toLowerCase());
    // For mac, create the message to tell the user to install the plugin.
    if (ua.match(/chrome\/([\d.]+)/)) {
        createNonAllowedDivPlugin();
        // Display the message and hide the main control
        document.getElementById(_divDWTNonInstallContainerID).style.display = "inline";
        document.getElementById(_divDWTContainerID).style.display = "none";
        document.getElementById("DWTemessageContainer").style.display = "none";
        document.getElementById("ScanWrapper").style.display = "none";

        var divBlankCtrl = document.getElementById("divBlank");
        if (divBlankCtrl)
            divBlankCtrl.style.display = "inline";

        var logo = S.one('#divLogo');
        if (logo) {
            var vComm100 = S.one('#linkComm100');
            if (vComm100)
                vComm100.appendTo(logo);
        }

        S.use("overlay", function(S, o) {

            dlgInstall = new o.Dialog({
                srcNode: "#J_waiting",
                width: 392,
                height: 227,
                closable: false,
                mask: true,
                align: {
                    points: ['cc', 'cc']
                }
            });
            dlgInstall.show();
        });
    }   
}

function createNonAllowedDivPlugin() {
    var varHref = "";
    if (location.hostname != "")
        varHref = "http://" + location.host + location.pathname.substring(0, location.pathname.lastIndexOf('/')) + "/" + _strMSIPath;
    else
        varHref = _strMSIPath;

    var ObjString = "<div class=\"D-dailog-body-NotAllowed\" style=\"width:350px\">" + _strDynamsoftWithClose + "<div class=\"box_title\">" + _strProductName + " plugin is not allowed to run on this site.</div>"
    ObjString += "<ul>";
    ObjString += "<li>Please click \"Always run on this site\" for the prompt \"" + _strProductName + " Plugin needs your permission to run\", refresh/restart the browser and try again.</li>";
    ObjString += "</ul>";
    ObjString += "</div>";
    document.getElementById("InstallBody").innerHTML = ObjString;
}

function createNonInstallDivPlugin() {

    var varHref = "";
    if (location.hostname != "")
        varHref = "http://" + location.host + location.pathname.substring(0, location.pathname.lastIndexOf('/')) + "/" + _strMSIPath;
    else
        varHref = _strMSIPath;

    var ObjString = "<div class=\"D-dailog-body\" style=\"width:350px\">" + _strDynamsoftWithClose + "<div class=\"box_title\">" + _strProductName + " is not installed</div>"
    ObjString += "<ul>";
    ObjString += "<li>Please click the below button to start downloading. You need manually install it after the downloading.</li>";
    ObjString += "</ul>";
    ObjString += "<p class=\"red\">If you still see this dialog after the installation, please RESTART your browser.</p>";
    //ObjString += "<a href='" + varHref + "'><div class=\"button\"></div></a></div>";
    ObjString += "<a id='btnInstall' href='" + varHref + "' onclick='onClickInstallButton()'><div class=\"button\"></div></a>";
    ObjString += "</div>";
    document.getElementById("InstallBody").innerHTML = ObjString;
}

function onClickInstallButton() {
    document.getElementById("btnInstall").style.display = "none";
    document.getElementById("txtDetect").style.display = "";
    document.getElementById("imgWait").style.display = "";
}

function createNonInstallDivMac() {

    var varHref = "";
    if (location.hostname != "")
        varHref = "http://" + location.host + location.pathname.substring(0, location.pathname.lastIndexOf('/')) + "/" + _strPKGPath;
    else
        varHref = _strPKGPath;

    var ObjString = "<div class=\"D-dailog-body-Mac\" style=\"width:350px\">" + _strDynamsoftWithClose + "<div class=\"box_title\">" + _strProductName + " is not installed</div>"
    ObjString += "<ul>";
    ObjString += "<li>Please click the below button to start downloading. You need manually install it after the downloading.</li>";
    ObjString += "</ul>";
    ObjString += "<p class=\"red\">If you still see this dialog after the installation, please RESTART your browser.</p>";
    ObjString += "If you are using Safari 5.0, you need to <a href='http://kb.dynamsoft.com/questions/666/How+to+run+Safari+5.0+in+32-bit+mode+on+Mac+OS+X'><span class=\"link\">run the browser in 32-bit Mode</span></a>.";
    ObjString += "<a id='btnInstall' href='" + varHref + "' onclick='onClickInstallButton()'><div class=\"button\"></div></a>";
    ObjString += "</div>";    
    document.getElementById("InstallBody").innerHTML = ObjString;
}

function closetblInstall_onclick() {
    if (dlgInstall) {
        dlgInstall.hide();
    }
}

function showtblLoadImage_onclick() {
    switch (document.getElementById("tblLoadImage").style.visibility) {
        case "hidden": document.getElementById("tblLoadImage").style.visibility = "visible";
            document.getElementById("Resolution").style.visibility = "hidden";
            break;
        case "visible":
            document.getElementById("tblLoadImage").style.visibility = "hidden";
            document.getElementById("Resolution").style.visibility = "visible";
            break;
        default: break;
    }
    document.getElementById("tblLoadImage").style.top = ds_gettop(document.getElementById("pNoScanner")) + pNoScanner.offsetHeight + "px";
    document.getElementById("tblLoadImage").style.left = ds_getleft(document.getElementById("pNoScanner")) + 0 + "px";
    return false;
}
function closetblLoadImage_onclick() {
    document.getElementById("tblLoadImage").style.visibility = "hidden";
    document.getElementById("Resolution").style.visibility = "visible";
    return false;
}

//--------------------------------------------------------------------------------------
//************************** Used a lot *****************************
//--------------------------------------------------------------------------------------
function updatePageInfo() {
    document.getElementById("DW_TotalImage").value = DWObject.HowManyImagesInBuffer;
    document.getElementById("DW_CurrentImage").value = DWObject.CurrentImageIndexInBuffer + 1;
}

function appendMessage(strMessage) {
    _strTempStr += strMessage;
    _divMessageContainer.innerHTML = _strTempStr;
    _divMessageContainer.scrollTop = _divMessageContainer.scrollHeight;
}

function checkIfImagesInBuffer() {
    if (DWObject.HowManyImagesInBuffer == 0) {
        appendMessage("There is no image in buffer.<br />")
        return false;
    }
    else
        return true;
}


function checkErrorString() {
    if (DWObject.ErrorCode == 0) {
        appendMessage("<span style='color:#cE5E04'><b>" + DWObject.ErrorString + "</b></span><br />");

        return true;
    }
    if (DWObject.ErrorCode == -2115) //Cancel file dialog
        return true;
    else {
        if (DWObject.ErrorCode == -2003) {
            var ErrorMessageWin = window.open("", "ErrorMessage", "height=500,width=750,top=0,left=0,toolbar=no,menubar=no,scrollbars=no, resizable=no,location=no, status=no");
            ErrorMessageWin.document.writeln(DWObject.HTTPPostResponseString);
        }
        appendMessage("<span style='color:#cE5E04'><b>" + DWObject.ErrorString + "</b></span><br />");
        return false;
    }
}

//--------------------------------------------------------------------------------------
//************************** Used a lot *****************************
//--------------------------------------------------------------------------------------
function ds_getleft(el) {
    var tmp = el.offsetLeft;
    el = el.offsetParent
    while (el) {
        tmp += el.offsetLeft;
        el = el.offsetParent;
    }
    return tmp;
}
function ds_gettop(el) {
    var tmp = el.offsetTop;
    el = el.offsetParent
    while (el) {
        tmp += el.offsetTop;
        el = el.offsetParent;
    }
    return tmp;
}

function Over_Out_DemoImage(obj, url) {
    obj.src = url;
}
