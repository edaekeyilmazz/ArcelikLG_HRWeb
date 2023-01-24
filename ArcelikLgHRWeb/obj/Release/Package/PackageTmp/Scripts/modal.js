$(document).ready(function () {
    $("#btnShowModal").click(function () {
        $("#loginModal").modal('show');
    });

    $("#btnHideModal").click(function () {
        $("#loginModal").modal('hide');
    });
});

$(document).ready(function () {
    $("#lnkContract").click(function () {
        $("#Contract").modal('show');
    });

    $("#btnHideContract").click(function () {
        //$("#Contract").modal('hide');
        $("#Contract").modal('hide');
    });
});