$(function () {
    $("#selector-1").click(function () {
        $(".applied-project").hide();
    })
    $("#books").hide();
    $("#devices").hide();



    $("#dropdown-books").click(function () {
        $("#books").show();
        $("#devices").hide();
    });



    $("#dropdown-devices").click(function () {
        $("#devices").show();
        $("#books").hide();
    });
})

