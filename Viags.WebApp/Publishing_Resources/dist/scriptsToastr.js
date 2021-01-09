function DialogAlert(Title, Messages, type) { //type : '',error,info,question,warning
    toastr.options = {
        "closeButton": true,
        "debug": false,
        "progressBar": true,
        "positionClass": "toast-top-right",
        "onclick": null,
        "showDuration": "400",
        "hideDuration": "200",
        "timeOut": "3000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }
    switch (type) {
        case "error": toastr.error(Messages, Title); break;
        case "info": toastr.info(Messages, Title); break;
        case "question": toastr.question(Messages, Title); break;
        case "warning": toastr.warning(Messages, Title); break;
        case "success": toastr.success(Messages, Title); break;

        default:
    }
}