// Custom JavaScript functionality

// Helper function for AJAX calls
function sendAjaxRequest(url, method, data, successCallback, errorCallback) {
    $.ajax({
        url: url,
        type: method,
        data: JSON.stringify(data),
        contentType: 'application/json',
        success: successCallback,
        error: errorCallback
    });
}

// Form validation
$(document).ready(function () {
    $("form").validate({
        rules: {
            name: "required",
            email: {
                required: true,
                email: true
            }
        },
        messages: {
            name: "Please enter your name",
            email: "Please enter a valid email address"
        },
        submitHandler: function (form) {
            form.submit();
        }
    });

    // Event listener for dynamic content
    $(".dynamic-button").on("click", function () {
        alert("Button clicked!");
    });

    // Responsive animations
    if (Modernizr.touch) {
        $(".animation-element").addClass("touch-enabled");
    }
});