/*============================================================
Some simple javascript (charactercount.js)
This code works as is and I take no responsibility for any 
alterations that happen afterwards.
If it can be improved upon, would be great to hear back.
============================================================*/
function Count() {
    var editAbstract = CKEDITOR.instances.NoiDung;
    editAbstract.on("key", function (e) {
        var maxLength = e.editor.config.maxlength;
        //e.editor.document.on("keyup", function () { KeyUp(e.editor, maxLength, "letterCount"); });
        e.editor.document.on("keyup", function () { KeyUp(e.editor, maxLength); });
        e.editor.document.on("paste", function () { KeyUp(e.editor, maxLength); });
        e.editor.document.on("blur", function () { KeyUp(e.editor, maxLength); });
    }, editAbstract.element.$);

    //function to handle the count check
    function KeyUp(editorID, maxLimit) {

        //If you want it to count all html code then just remove everything from and after '.replace...'
        var text = editorID.getData().replace(/<("[^"]*"|'[^']*'|[^'">])*>/gi, '').replace(/^\s+|\s+$/g, '');
        //$("#" + infoID).text(text.length);

        if (text.length > maxLimit) {
            //alert("You cannot have more than " + maxLimit + " characters");
            editorID.setData(text.substr(0, maxLimit));
            editor.cancel();
        }
        //else if (text.length == maxLimit - 1) {
        //    alert("WARNING:\nYou are one character away from your limit.\nIf you continue you could lose any formatting");
        //    editor.cancel();
        //}
    }
}