$('form').hide();

var visible = false;

var show_form = function () {
    $('form').slideDown('slow');
    setTimeout(function () {
        $('.form-inputs').addClass('show');
    }, 600);
    m.set('times');
    visible = true;
}

var hide_form = function () {
    $('.form-inputs').removeClass('show');
    setTimeout(function () {
        $('form').slideUp('slow');
    }, 600);
    m.set('chevron');
    visible = false;
}

var m = new Marka('#icon');
m.set('chevron')
    .color('#ffffff')
    .size('50')
    .rotate('down');


$('.form-icon, .form-button__cancel').on('click', function () {
    if (visible) {
        hide_form();
    }
    else {
        show_form();
    }
});
$('.form-heading').on('click', function () {
    if (!visible) {
        show_form();
    }
});