var msg = "", type = "";
function flashMessage(tag, msg, type) {

    var insert = '<div class="flashMsg alert alert-' + type + ' alert-dismissible fade in" role="alert">' +
        '<button type="button" class="close" data-dismiss="alert" onclick="closeMsg()">' +
        '<span aria-hidden="true">×</span>' +
        '</button>' +
        '<strong>' + msg + '</strong>' +
        '</div>';
    if (!$(tag).html() || !$(tag).html().trim()) { $(tag).hide().html(insert).slideToggle(400); }
    else
        $(tag).animate({ 'opacity': 0 }, 400, function () {
            $(this).html(insert).animate({ 'opacity': 1 }, 400);
        });
    $(".flashMsg").addClass('show');
}
function closeMsg() {
    $('.flashMsg').remove();
    $(".flashMsg").removeClass('show');
}