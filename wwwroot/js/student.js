// Below is a jQuery page-on-load function
$(function () {
    // When selecting one of the items from the dropdown menu, below click functions will get triggered
    $("#selector-1").click(function () {
        // When selecting applied project item, all other items will disappear from the page
        $(".advance-web-dev").hide();
        $(".online-business-sys").hide();
        $(".ict-bus-analytics").hide();
        $(".applied-project").show();
        // Change text of dropdown menu
        $("#dropdown-unit").text("Applied Project");
    })

    $("#selector-2").click(function () {
        $(".applied-project").hide();
        $(".online-business-sys").hide();
        $(".ict-bus-analytics").hide();
        $(".advance-web-dev").show();
        $("#dropdown-unit").text("Advance Web Development");
    })

    $("#selector-3").click(function () {
        $(".applied-project").hide();
        $(".advance-web-dev").hide();
        $(".ict-bus-analytics").hide();
        $(".online-business-sys").show();
        $("#dropdown-unit").text("Online Business System Development");
        
    })
    $("#selector-4").click(function () {
        $(".applied-project").hide();
        $(".advance-web-dev").hide();
        $(".online-business-sys").hide();
        $(".ict-bus-analytics").show();
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

