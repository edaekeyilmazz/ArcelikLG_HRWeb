var $validator = $('form').validate({
    rules: {
        SgkNumber: {
            minlength: 13,
            maxlength: 13
        },
        MotherName: {
            required: true
        },
        FatherName: {
            required: true
        },
        BirthPlace: {
            required: true
        },
        BirthDate: {
            required: true
        },
        Gender: {
            required: true
        },
        Education: {
            required: true
        },
        NightShift: {
            required: true
        },
        WorkBeforeArcelikLg: {
            required: true
        },
        MilitaryStatus: {
            required: true
        },
        ProfessionalJob: {
            required: true
        }
    }
});
jQuery.extend(jQuery.validator.messages, {
    required: "Bu alan boş geçilemez.",
    minlength: "Lütfen 13 haneli SGK numaranızı giriniz.",
    maxlength: "Lütfen 13 haneli SGK numaranızı giriniz."
});


$(document).ready(function () {
    if (window.navigator.language.indexOf("tr") >= 0) {
        $(".DatePicker").datepicker({
            dateFormat: "dd.mm.yy",
            monthNames: ["Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık"],
            dayNamesMin: ["Pa", "Pt", "Sl", "Ça", "Pe", "Cu", "Ct"],
            firstDay: 1
        });
    }

    $(function () {
        var indx = $("#ddlMilitaryStatus").prop('selectedIndex');
        if (indx == 2) { $("#ddlDefermentDate").prop("disabled", false); }
        //else if (indx == 3) { $("#ddlDefermentDate").prop("disabled", true); $("#ddlDefermentDate").val(""); $("#ddlExemptReason").prop("disabled", false); }
        else { $("#ddlDefermentDate").prop("disabled", true); $("#ddlDefermentDate").val(" ");}
    });

    $("#ddlMilitaryStatus").change(function () {
        var indx = this.selectedIndex;
        if (indx == 2) { $("#ddlDefermentDate").prop("disabled", false);  }
        //else if (indx == 3) { $("#ddlDefermentDate").prop("disabled", true); $("#ddlDefermentDate").val(""); $("#ddlExemptReason").prop("disabled", false); }
        else { $("#ddlDefermentDate").prop("disabled", true); $("#ddlDefermentDate").val(" "); }
    });
    //$("#ddlExemptReason").prop("disabled", true); $("#ddlExemptReason").val(0);
    //$("#ddlExemptReason").prop("disabled", true); $("#ddlExemptReason").val(0);
    //$("#ddlExemptReason").prop("disabled", true); $("#ddlExemptReason").val(0);
    //$("#ddlExemptReason").prop("disabled", true); $("#ddlExemptReason").val(0);
});