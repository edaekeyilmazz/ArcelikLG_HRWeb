$.validator.addMethod('phoneNumber', function (value, element) {
    return this.optional(element) || /^(0(\d{3})(\d{3})(\d{2})(\d{2}))$/.test(value);
});
var $validator = $('form').validate({
    rules: {
        HomeAddress: {
            required: true
        },
        ProvinceOfHomeAddress: {
            required: true
        },
        TownOfHomeAddress: {
            required: true
        },
        HomePhone: {
            phoneNumber: true
        },
    },
    messages: {
        HomeAddress: {
            required: "Bu alan boş geçilemez."
        },
        ProvinceOfHomeAddress: {
            required: "Bu alan boş geçilemez."
        },
        TownOfHomeAddress: {
            required: "Bu alan boş geçilemez."
        },
        HomePhone: {
            phoneNumber: "Lütfen geçerli bir cep telefonu numarası giriniz."
        },
    }

});
jQuery.extend(jQuery.validator.messages, {
    required: "Bu alan boş geçilemez."
});

