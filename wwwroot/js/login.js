$(function () {
    $("#btn-submit").click(function () {
        let sid = $("#sid").val();
        let pass = $("#pass").val();

        // Student login
        if (sid == "11111" && pass == "123456") {
            // Add user type into cookie to change home page dynamically later
            //document.cookie = "user_type=student";
            // Send user to student page
            window.location.href = "/Home/Student";
        } else {
            console.log("error");
        }

        // Staff login
        if (sid == "22222" && pass == "123456") {
            // Add user type into cookie to change home page dynamically later
            //document.cookie = "user_type=staff";
            // Send user to staff page
            window.location.href = "/Home/Staff";
        } else {
            console.log("error");
        }
    });
});