//--------------------------------------------------------------------------------------
//************************** Import Image*****************************
//--------------------------------------------------------------------------------------
/*-----------------select source---------------------*/
function source_onchange() {
    document.getElementById("divTwainType").style.display = "";
    document.getElementById("btnScan").value = "Scan";
}


/*-----------------Acquire Image---------------------*/
function acquireImage() {
    if (_divDWTSourceContainerID == "")
        DWObject.SelectSource();
    else
        DWObject.SelectSourceByIndex(document.getElementById(_divDWTSourceContainerID).selectedIndex);
    DWObject.CloseSource();
    DWObject.OpenSource();
    DWObject.IfShowUI = document.getElementById("ShowUI").checked;

    var i;
    for (i = 0; i < 3; i++) {
        if (document.getElementsByName("PixelType").item(i).checked == true)
            DWObject.PixelType = i;
    }
    DWObject.Resolution = document.getElementById("Resolution").value;
    DWObject.IfFeederEnabled = document.getElementById("ADF").checked;
    DWObject.IfDuplexEnabled = document.getElementById("Duplex").checked;
    appendMessage("Pixel Type: " + DWObject.PixelType + "<br />Resolution: " + DWObject.Resolution + "<br />");

    DWObject.IfDisableSourceAfterAcquire = true;
    DWObject.AcquireImage();
}

/*-----------------Load Image---------------------*/
function btnLoad_onclick() {
    DWObject.IfShowFileDialog = true;
    DWObject.LoadImageEx("", 5);
    if (checkErrorString()) {
        appendMessage("Loaded an image successfully.<br/>");
    }
}
function loadSampleImage(nIndex) {
    var ImgArr;

    switch (nIndex) {
        case 1:
            ImgArr = "/Images/twain_associate1.png";
            break;
        case 2:
            ImgArr = "/Images/twain_associate2.png";
            break;
        case 3:
            ImgArr = "/Images/twain_associate3.png";
            break;
    }

    if (location.hostname != "") {
        DWObject.HTTPPort = location.port == "" ? 80 : location.port;
        DWObject.HTTPDownload(location.hostname, location.pathname.substring(0, location.pathname.lastIndexOf('/')) + ImgArr);
    }
    else {
        DWObject.IfShowFileDialog = false;
        if (location.pathname.lastIndexOf('\\') > 1) {
            var ImgArr_replaced = ImgArr.replace(new RegExp("/", 'g'), "\\\\");
            DWObject.LoadImage(location.pathname.substring(1, location.pathname.lastIndexOf('\\')).replace(/%20/g, " ") + ImgArr_replaced);
        }
        else
            DWObject.LoadImage(location.pathname.substring(1, location.pathname.lastIndexOf('/')).replace(/%20/g, " ") + ImgArr);
    }

    updatePageInfo();
    if (checkErrorString()) {
        appendMessage("Added a demo image successfully.<br/>");
    }
}

//--------------------------------------------------------------------------------------
//************************** Edit Image ******************************

//--------------------------------------------------------------------------------------
function btnShowImageEditor_onclick() {
    if (!checkIfImagesInBuffer()) {
        return;
    }
    DWObject.ShowImageEditor();
    _strTempStr = _strTempStr + "<b>Show Image Editor: </b>";
    if (checkErrorString()) {
        return;
    }
}

function btnRotateRight_onclick() {
    if (!checkIfImagesInBuffer()) {
        return;
    }
    DWObject.RotateRight(DWObject.CurrentImageIndexInBuffer);
    _strTempStr = _strTempStr + "<b>Rotate right: </b>";
    if (checkErrorString()) {
        return;
    }
}
function btnRotateLeft_onclick() {
    if (!checkIfImagesInBuffer()) {
        return;
    }
    DWObject.RotateLeft(DWObject.CurrentImageIndexInBuffer);
    _strTempStr = _strTempStr + "<b>Rotate left: </b>";
    if (checkErrorString()) {
        return;
    }
}

function btnMirror_onclick() {
    if (!checkIfImagesInBuffer()) {
        return;
    }
    DWObject.Mirror(DWObject.CurrentImageIndexInBuffer);
    _strTempStr = _strTempStr + "<b>Mirror: </b>";
    if (checkErrorString()) {
        return;
    }
}
function btnFlip_onclick() {
    if (!checkIfImagesInBuffer()) {
        return;
    }
    DWObject.Flip(DWObject.CurrentImageIndexInBuffer);
    _strTempStr = _strTempStr + "<b>Flip: </b>";
    if (checkErrorString()) {
        return;
    }
}

/*----------------------Crop Method---------------------*/
function btnCrop_onclick() {
    if (!checkIfImagesInBuffer()) {
        return;
    }
    if (_iLeft != 0 || _iTop != 0 || _iRight != 0 || _iBottom != 0) {
        DWObject.Crop(
            DWObject.CurrentImageIndexInBuffer,
            _iLeft, _iTop, _iRight, _iBottom
        );
        _iLeft = 0;
        _iTop = 0;
        _iRight = 0;
        _iBottom = 0;
        _strTempStr = _strTempStr + "<b>Crop: </b>";
        if (checkErrorString()) {
            return;
        }
        return;
    }
    switch (document.getElementById("Crop").style.visibility) {
        case "visible": document.getElementById("Crop").style.visibility = "hidden"; break;
        case "hidden": document.getElementById("Crop").style.visibility = "visible"; break;
        default: break;
    }
    document.getElementById("Crop").style.top = ds_gettop(document.getElementById("btnCrop")) + document.getElementById("btnCrop").offsetHeight + "px";
    document.getElementById("Crop").style.left = ds_getleft(document.getElementById("btnCrop")) - 80 + "px";
}

function btnCropCancel_onclick() {
    document.getElementById("Crop").style.visibility = "hidden";
}
function btnCropOK_onclick() {
    document.getElementById("img_left").className = "";
    document.getElementById("img_top").className = "";
    document.getElementById("img_right").className = "";
    document.getElementById("img_bottom").className = "";
    if (!re.test(document.getElementById("img_left").value)) {
        document.getElementById("img_left").className += " invalid";
        document.getElementById("img_left").focus();
        appendMessage("Please input a valid <b>left</b> value.<br />");
        return;
    }
    if (!re.test(document.getElementById("img_top").value)) {
        document.getElementById("img_top").className += " invalid";
        document.getElementById("img_top").focus();
        appendMessage("Please input a valid <b>top</top> value.<br />");
        return;
    }
    if (!re.test(document.getElementById("img_right").value)) {
        document.getElementById("img_right").className += " invalid";
        document.getElementById("img_right").focus();
        appendMessage("Please input a valid <b>right</b> value.<br />");
        return;
    }
    if (!re.test(document.getElementById("img_bottom").value)) {
        document.getElementById("img_bottom").className += " invalid";
        document.getElementById("img_bottom").focus();
        appendMessage("Please input a valid <b>bottom</b> value.<br />");
        return;
    }
    DWObject.Crop(
        DWObject.CurrentImageIndexInBuffer,
        document.getElementById("img_left").value,
        document.getElementById("img_top").value,
        document.getElementById("img_right").value,
        document.getElementById("img_bottom").value
    );
    _strTempStr = _strTempStr + "<b>Crop: </b>";
    if (checkErrorString()) {
        document.getElementById("Crop").style.visibility = "hidden";
        return;
    }
}

/*----------------Change Image Size--------------------*/
function btnChangeImageSize_onclick() {
    if (!checkIfImagesInBuffer()) {
        return;
    }
    switch (document.getElementById("ImgSizeEditor").style.visibility) {
        case "visible": document.getElementById("ImgSizeEditor").style.visibility = "hidden"; break;
        case "hidden": document.getElementById("ImgSizeEditor").style.visibility = "visible"; break;
        default: break;
    }
    document.getElementById("ImgSizeEditor").style.top = ds_gettop(document.getElementById("btnChangeImageSize")) + document.getElementById("btnChangeImageSize").offsetHeight + "px";
    document.getElementById("ImgSizeEditor").style.left = ds_getleft(document.getElementById("btnChangeImageSize")) - 30 + "px";
}
function btnCancelChange_onclick() {
    document.getElementById("ImgSizeEditor").style.visibility = "hidden";
}

function btnChangeImageSizeOK_onclick() {
    document.getElementById("img_height").className = "";
    document.getElementById("img_width").className = "";
    if (!re.test(document.getElementById("img_height").value)) {
        document.getElementById("img_height").className += " invalid";
        document.getElementById("img_height").focus();
        appendMessage("Please input a valid <b>height</b>.<br />");
        return;
    }
    if (!re.test(document.getElementById("img_width").value)) {
        document.getElementById("img_width").className += " invalid";
        document.getElementById("img_width").focus();
        appendMessage("Please input a valid <b>width</b>.<br />");
        return;
    }
    DWObject.ChangeImageSize(
        DWObject.CurrentImageIndexInBuffer,
        document.getElementById("img_width").value,
        document.getElementById("img_height").value,
        document.getElementById("InterpolationMethod").selectedIndex + 1
    );
    _strTempStr = _strTempStr + "<b>Change Image Size: </b>";
    if (checkErrorString()) {
        document.getElementById("ImgSizeEditor").style.visibility = "hidden";
        return;
    }
}
//--------------------------------------------------------------------------------------
//************************** Save Image***********************************
//--------------------------------------------------------------------------------------
function btnSave_onclick() {
    if (!checkIfImagesInBuffer()) {
        return;
    }
    var i, strimgType_save;
    var NM_imgType_save = document.getElementsByName("imgType_save");
    for (i = 0; i < 5; i++) {
        if (NM_imgType_save.item(i).checked == true) {
            strimgType_save = NM_imgType_save.item(i).value;
            break;
        }
    }
    DWObject.IfShowFileDialog = true;
    _txtFileNameforSave.className = "";
    var bSave = false;
    if (!strre.test(_txtFileNameforSave.value)) {
        _txtFileNameforSave.className += " invalid";
        _txtFileNameforSave.focus();
        appendMessage("Please input <b>file name</b>.<br />Currently only English names are allowed.<br />");
        return;
    }
    var strFilePath = "C:\\" + _txtFileNameforSave.value + "." + strimgType_save;
    if (strimgType_save == "tif" && _chkMultiPageTIFF_save.checked) {
        if ((DWObject.SelectedImagesCount == 1) || (DWObject.SelectedImagesCount == DWObject.HowManyImagesInBuffer)) {
            bSave = DWObject.SaveAllAsMultiPageTIFF(strFilePath);
        }
        else {
            bSave = DWObject.SaveSelectedImagesAsMultiPageTIFF(strFilePath);
        }
    }
    else if (strimgType_save == "pdf" && document.getElementById("MultiPagePDF_save").checked) {
        if ((DWObject.SelectedImagesCount == 1) || (DWObject.SelectedImagesCount == DWObject.HowManyImagesInBuffer)) {
            bSave = DWObject.SaveAllAsPDF(strFilePath);
        }
        else {
            bSave = DWObject.SaveSelectedImagesAsMultiPagePDF(strFilePath);
        }
    }
    else {
        switch (i) {
            case 0: bSave = DWObject.SaveAsBMP(strFilePath, DWObject.CurrentImageIndexInBuffer); break;
            case 1: bSave = DWObject.SaveAsJPEG(strFilePath, DWObject.CurrentImageIndexInBuffer); break;
            case 2: bSave = DWObject.SaveAsTIFF(strFilePath, DWObject.CurrentImageIndexInBuffer); break;
            case 3: bSave = DWObject.SaveAsPNG(strFilePath, DWObject.CurrentImageIndexInBuffer); break;
            case 4: bSave = DWObject.SaveAsPDF(strFilePath, DWObject.CurrentImageIndexInBuffer); break;
        }
    }

    if (bSave)
        _strTempStr = _strTempStr + "<b>Save Image: </b>";
    if (checkErrorString()) {
        return;
    }
}
//--------------------------------------------------------------------------------------
//************************** Upload Image***********************************
//--------------------------------------------------------------------------------------
function btnUpload_onclick() {
    /* Windows Authentication */
    //DWObject.HTTPUserName = "quanlh";
    //DWObject.HTTPPassword = "Tv1@)!)2010";

    /* Forms Authentication */
    DWObject.SetCookie(FormsCookie);

    if (!checkIfImagesInBuffer()) {
        return;
    }
    var i, strHTTPServer, strActionPage, strImageType;
    _txtFileName.className = "";
    if (!strre.test(_txtFileName.value)) {
        _txtFileName.className += " invalid";
        _txtFileName.focus();
        appendMessage("Please input <b>file name</b>.<br />Currently only English names are allowed.<br />");
        return;
    }
    //DWObject.MaxInternetTransferThreads = 5;
    strHTTPServer = _strServerName;
    DWObject.HTTPPort = _strPort;
    var CurrentPathName = unescape(location.pathname); // get current PathName in plain ASCII	
    var CurrentPath = CurrentPathName.substring(0, CurrentPathName.lastIndexOf("/") + 1);
    strActionPage = CurrentPath + _strActionPage; //the ActionPage's file path
    //var redirectURLifOK = CurrentPath + "online_demo_list.aspx";
    var redirectURLifOK = CurrentPath + "OnlineDemoList.aspx";
    for (i = 0; i < 4; i++) {
        if (document.getElementsByName("ImageType").item(i).checked == true) {
            strImageType = i + 1;
            break;
        }
    }

    var uploadfilename = _txtFileName.value + "." + document.getElementsByName("ImageType").item(i).value;
    if (strImageType == 2 && document.getElementById("MultiPageTIFF").checked) {
        if ((DWObject.SelectedImagesCount == 1) || (DWObject.SelectedImagesCount == DWObject.HowManyImagesInBuffer)) {
            DWObject.HTTPUploadAllThroughPostAsMultiPageTIFF(
                strHTTPServer,
                strActionPage,
                uploadfilename
            );
        }
        else {
            DWObject.HTTPUploadThroughPostAsMultiPageTIFF(
                strHTTPServer,
                strActionPage,
                uploadfilename
            );
        }
    }
    else if (strImageType == 4 && document.getElementById("MultiPagePDF").checked) {
        if ((DWObject.SelectedImagesCount == 1) || (DWObject.SelectedImagesCount == DWObject.HowManyImagesInBuffer)) {
            DWObject.HTTPUploadAllThroughPostAsPDF(
                strHTTPServer,
                strActionPage,
                uploadfilename
            );
        }
        else {
            DWObject.HTTPUploadThroughPostAsMultiPagePDF(
                strHTTPServer,
                strActionPage,
                uploadfilename
            );
        }
    }
    else {
        DWObject.HTTPUploadThroughPostEx(
            strHTTPServer,
            DWObject.CurrentImageIndexInBuffer,
            strActionPage,
            uploadfilename,
            strImageType
        );
    }
    _strTempStr = _strTempStr + "<b>Upload: </b>";
    if (checkErrorString()) {
        if (strActionPage.indexOf("SaveToFile") != -1)
            alert(DWObject.ErrorString)//if save to file.
        else
            //window.location = redirectURLifOK;
            ;
    }
}



function btnUploadToFTP_onclick() {
    if (!checkIfImagesInBuffer()) {
        return;
    }

    _txtFileName.className = "";

    var strFTPServer = "192.168.1.20";
    DWObject.FTPPort = 21;
    DWObject.FTPUserName = "DWT";
    DWObject.FTPPassword = "DWT";
    var remoteDirectory = "/images/";

    for (i = 0; i < 4; i++) {
        if (document.getElementsByName("ImageType").item(i).checked == true) {
            strImageType = i + 1;
            break;
        }
    }
    var uploadfilename = _txtFileName.value + "." + document.getElementsByName("ImageType").item(i).value;
    var uploadFullPath = remoteDirectory + uploadfilename;

    if (strImageType == 2 && _chkMultiPageTIFF.checked) {
        if ((DWObject.SelectedImagesCount == 1) || (DWObject.SelectedImagesCount == DWObject.HowManyImagesInBuffer)) {
            DWObject.FTPUploadAllAsMultiPageTIFF(strFTPServer, uploadFullPath);
        }
        else {
            DWObject.FTPUploadAsMultiPageTIFF(strFTPServer, uploadFullPath);
        }
    }
    else if (strImageType == 4 && MultiPagePDF.checked) {
        if ((DWObject.SelectedImagesCount == 1) || (DWObject.SelectedImagesCount == DWObject.HowManyImagesInBuffer)) {
            DWObject.FTPUploadAllAsPDF(strFTPServer, uploadFullPath);
        }
        else {
            DWObject.FTPUploadAsMultiPagePDF(strFTPServer, uploadFullPath);
        }
    }
    else {
        DWObject.FTPUploadEx(
            strFTPServer,
            DWObject.CurrentImageIndexInBuffer,
            uploadFullPath,
            strImageType
        );
    }
    _strTempStr = _strTempStr + "<b>Upload: </b>";
    checkErrorString();
}


//--------------------------------------------------------------------------------------
//************************** Navigator functions***********************************
//--------------------------------------------------------------------------------------

function btnFirstImage_onclick() {
    if (!checkIfImagesInBuffer()) {
        return;
    }
    DWObject.CurrentImageIndexInBuffer = 0;
    updatePageInfo();
}

function btnPreImage_onclick() {
    if (!checkIfImagesInBuffer()) {
        return;
    }
    else if (DWObject.CurrentImageIndexInBuffer == 0) {
        return;
    }
    DWObject.CurrentImageIndexInBuffer = DWObject.CurrentImageIndexInBuffer - 1;
    updatePageInfo();
}
function btnNextImage_onclick() {
    if (!checkIfImagesInBuffer()) {
        return;
    }
    else if (DWObject.CurrentImageIndexInBuffer == DWObject.HowManyImagesInBuffer - 1) {
        return;
    }
    DWObject.CurrentImageIndexInBuffer = DWObject.CurrentImageIndexInBuffer + 1;
    updatePageInfo();
}


function btnLastImage_onclick() {
    if (!checkIfImagesInBuffer()) {
        return;
    }
    DWObject.CurrentImageIndexInBuffer = DWObject.HowManyImagesInBuffer - 1;
    updatePageInfo();
}

function btnRemoveCurrentImage_onclick() {
    if (!checkIfImagesInBuffer()) {
        return;
    }
    DWObject.RemoveAllSelectedImages();
    if (DWObject.HowManyImagesInBuffer == 0) {
        document.getElementById("DW_TotalImage").value = DWObject.HowManyImagesInBuffer;
        document.getElementById("DW_CurrentImage").value = "";
        return;
    }
    else {
        updatePageInfo();
    }
}


function btnRemoveAllImages_onclick() {
    if (!checkIfImagesInBuffer()) {
        return;
    }
    DWObject.RemoveAllImages();
    document.getElementById("DW_TotalImage").value = "0";
    document.getElementById("DW_CurrentImage").value = "";
}
function setlPreviewMode() {
    DWObject.SetViewMode(parseInt(document.getElementById("DW_PreviewMode").selectedIndex + 1), parseInt(document.getElementById("DW_PreviewMode").selectedIndex + 1));
    if (!_bInWindows) {
        return;
    }
    else if (document.getElementById("DW_PreviewMode").selectedIndex != 0) {
        DWObject.MouseShape = true;
    }
    else {
        DWObject.MouseShape = false;
    }
}

//--------------------------------------------------------------------------------------
//*********************************radio response***************************************
//--------------------------------------------------------------------------------------
function rdTIFFsave_onclick() {
    _chkMultiPageTIFF_save.disabled = false;

    _chkMultiPageTIFF_save.checked = false;
    _chkMultiPagePDF_save.checked = false;
    _chkMultiPagePDF_save.disabled = true;
}
function rdPDFsave_onclick() {
    _chkMultiPagePDF_save.disabled = false;

    _chkMultiPageTIFF_save.checked = false;
    _chkMultiPagePDF_save.checked = false;
    _chkMultiPageTIFF_save.disabled = true;
}
function rdsave_onclick() {
    _chkMultiPageTIFF_save.checked = false;
    _chkMultiPagePDF_save.checked = false;

    _chkMultiPageTIFF_save.disabled = true;
    _chkMultiPagePDF_save.disabled = true;
}
function rdTIFF_onclick() {
    _chkMultiPageTIFF.disabled = false;

    _chkMultiPageTIFF.checked = false;
    _chkMultiPagePDF.checked = false;
    _chkMultiPagePDF.disabled = true;
}
function rdPDF_onclick() {
    _chkMultiPagePDF.disabled = false;

    _chkMultiPageTIFF.checked = false;
    _chkMultiPagePDF.checked = false;
    _chkMultiPageTIFF.disabled = true;
}
function rd_onclick() {
    _chkMultiPageTIFF.checked = false;
    _chkMultiPagePDF.checked = false;

    _chkMultiPageTIFF.disabled = true;
    _chkMultiPagePDF.disabled = true;
}



//--------------------------------------------------------------------------------------
//************************** Dynamic Web TWAIN Events***********************************
//--------------------------------------------------------------------------------------

function Dynamsoft_OnPostTransfer() {
    if (_bDiscardBlankImage) {
        var NewlyScannedImage = DWObject.CurrentImageIndexInBuffer;
        if (DWObject.IsBlankImage(NewlyScannedImage)) {
            DWObject.RemoveImage(NewlyScannedImage);
        }
        _strTempStr += "<b>Blank Discard (On PostTransfer): </b>";

        if (checkErrorString()) {
            updatePageInfo();
        }
    }
    updatePageInfo();
}

function Dynamsoft_OnPostLoadfunction(path, name, type) {
    if (_bDiscardBlankImage) {
        var NewlyScannedImage = DWObject.CurrentImageIndexInBuffer;
        if (DWObject.IsBlankImage(NewlyScannedImage)) {
            DWObject.RemoveImage(NewlyScannedImage);
        }
        _strTempStr += "<b>Blank Discard (On PostLoad): </b>";
        if (checkErrorString()) {
            updatePageInfo();
        }
    }
    updatePageInfo();
}

function Dynamsoft_OnPostAllTransfers() {
    DWObject.CloseSource();
    updatePageInfo();
    checkErrorString();
}

function Dynamsoft_OnMouseClick(index) {
    updatePageInfo();
}

function Dynamsoft_OnMouseRightClick(index) {
    // To add
}


function Dynamsoft_OnImageAreaSelected(index, left, top, right, bottom) {
    _iLeft = left;
    _iTop = top;
    _iRight = right;
    _iBottom = bottom;
}

function Dynamsoft_OnImageAreaDeselected(index) {
    _iLeft = 0;
    _iTop = 0;
    _iRight = 0;
    _iBottom = 0;
}

function Dynamsoft_OnMouseDoubleClick() {
    return;
}


function Dynamsoft_OnTopImageInTheViewChanged(index) {
    DWObject.CurrentImageIndexInBuffer = index;
    updatePageInfo();
}

function Dynamsoft_OnGetFilePath(bSave, count, index, path, name) {
}
