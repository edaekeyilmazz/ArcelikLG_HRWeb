$.validator.addMethod('phoneNumber', function (value, element) {
    return this.optional(element) || /^(0(\d{3})(\d{3})(\d{2})(\d{2}))$/.test(value);
});

$.validator.addMethod("containsAtLeastOneDigitOneCharacter", function (value, element) {
    return this.optional(element) || /^[a-z]+[A-Z]+[0-9]/i.test(value);
});

var $validator = $('form').validate({
    rules: {
        TCNo: {
            required: true,
            minlength: 11,
            maxlength: 11
        },
        Name: {
            required: true
        },
        Surname: {
            required: true
        },
        Password: {
            minlength: 5,
            maxlength: 10,
            required: true,
            containsAtLeastOneDigitOneCharacter: true
        },

        PasswordConfirm: {
            minlength: 5,
            maxlength: 10,
            required: true,
            equalTo: "#Password"
        },
        Email: {
            email: true,
            required: true
        },
        MobilePhone: {
            phoneNumber: true,
            required: true,

        }
    },
    messages: {
        TCNo: {
            required: "Lütfen 11 haneli T.C. numaranızı giriniz.",
            minlength: "T.C kimlik numaranız 11 haneli olmalıdır.",
            maxlength: "T.C kimlik numaranız 11 haneli olmalıdır."
        },
        Name: {
            required: "İsim alanı boş geçilemez."
        },
        Surname: {
            required: "Soyadı alanı boş geçilemez."
        },
        Password: {
            required: "Lütfen şifrenizi giriniz.",
            minlength: "Lütfen 5 ile 10 karakter arası bir şifre giriniz.",
            maxlength: "Lütfen 5 ile 10 karakter arası bir şifre giriniz.",
            containsAtLeastOneDigitOneCharacter: "Şifreniz 1 küçük harf, 1 büyük harf ve 1 rakam içermelidir."
        },
        PasswordConfirm: {
            required: "Lütfen şifrenizi tekrar giriniz.",
            equalTo: "Girdiğiniz şifreler aynı olmalıdır.",
            minlength: "Lütfen 5 ile 10 karakter arası bir şifre giriniz.",
            maxlength: "Lütfen 5 ile 10 karakter arası bir şifre giriniz."
        },
        Email: {
            required: "Lütfen email adresinizi giriniz.",
            email: "Lütfen geçerli bir email giriniz."
        },
        MobilePhone: {
            required: "Lüten cep telefonu numaranızı giriniz.",
            phoneNumber: "Lütfen geçerli bir cep telefonu numarası giriniz."
        }

    }
});


$(document).ready(function () {
    $("#lnkContract").click(function () {
        $("#popupContract").modal('show');
    });

    $("#btnHideContract").click(function () {
        $("#popupContract").modal('hide');
    });
});


function ToUpper(obj) {
    if (obj.value != "") {
        obj.value = obj.value.toUpperCase();
    }
}