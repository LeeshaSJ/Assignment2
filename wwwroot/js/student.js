$(function () {
    $("#selector-1").click(function () {
        $(".applied-project").show();
        $(".advance-web-dev").hide();
        $(".online-business-sys").hide();
        $(".ict-bus-analytics").hide();
        $("#dropdown-unit").text("Applied Project");
    })

    $("#selector-2").click(function () {
        $(".advance-web-dev").show();
        $(".applied-project").hide();
        $(".online-business-sys").hide();
        $(".ict-bus-analytics").hide();
        $("#dropdown-unit").text("Advance Web Development");
    })

    $("#selector-3").click(function () {
        $(".online-business-sys").show();
        $(".applied-project").hide();
        $(".advance-web-dev").hide();
        $(".ict-bus-analytics").hide();
        $("#dropdown-unit").text("Online Business System Development");
        
    })
    $("#selector-4").click(function () {
        $(".ict-bus-analytics").show();
        $(".applied-project").hide();
        $(".advance-web-dev").hide();
        $(".online-business-sys").hide();
        $("#dropdown-unit").text("ICT Business Analytics and Data Visualization");
    })
   
    $("#dropdown-books").click(function () {
        $("#books").show();
        $("#devices").hide();
        $("#dropdown-category").text("Books");
    });

    $("#dropdown-devices").click(function () {
        $("#devices").show();
        $("#books").hide();
        $("#dropdown-category").text("Devices");
    });
})

