var $validator = $('.wizard-card form').validate({
    rules: {
        Password: {
            required: true
        },
        TCNo: {
            required: true,
            minlength: 11,
            maxlength: 11,
            PersonalID: true
        },
        messages: {
            TCNo: "Lütfen geçerli bir T.C kimlik numarası giriniz.",
        }
    }
});

jQuery.extend(jQuery.validator.messages, {
    required: "Bu alan boş geçilemez",
    minlength: "Lütfen 11 haneli T.C numaranızı giriniz.",
    maxlength: "Lütfen 11 haneli T.C numaranızı giriniz."
});

$(document).ready(function () {
    $("#btnShowModal").click(function () {
        $("#loginmodal").modal('show');
    });

    $("#btnHideModal").click(function () {
        $("#loginmodal").modal('hide');
    });
});
