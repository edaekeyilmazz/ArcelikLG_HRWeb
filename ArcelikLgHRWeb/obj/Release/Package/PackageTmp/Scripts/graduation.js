var $validator = $('form').validate({
    rules: {
        HighSchoolName: {
            required: true
        },
        HighSchoolProvince: {
            required: true
        },
        HighSchoolType: {
            required: true
        },
        HighSchoolDepartment: {
            required: true
        },
        UniversityName: {
            required: true
        },
        UniversityProvince: {
            required: true
        },
        MYOName: {
            required: true
        },
        DepartmentName: {
            required: true
        },
    },
    messages: {
        required: "Bu alan boş geçilemez."
    }
});
jQuery.extend(jQuery.validator.messages, {
    required: "Bu alan boş geçilemez."
});

$(document).ready(function () {
    $(function () {
        var indx = $("#ddlUniversityName").prop('selectedIndex');
        if (indx == 1) { $("#txtOtherUniversityName").prop("disabled", false); $("#txtOtherUniversityName").val(); }
        else { $("#txtOtherUniversityName").prop("disabled", true); $("#txtOtherUniversityName").val(); }
    });
    $("#ddlUniversityName").change(function () {
        var indx = this.selectedIndex;
        if (indx == 1) { $("#txtOtherUniversityName").prop("disabled", false); }
        else { $("#txtOtherUniversityName").prop("disabled", true); }
    });
});