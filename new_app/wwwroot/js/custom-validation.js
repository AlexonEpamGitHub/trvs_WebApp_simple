// Custom validation script for ASP.NET Core MVC

(function ($) {
  $(document).ready(function () {
    // Custom rule: example for validating username
    $.validator.addMethod("usernameRule", function (value, element) {
      return /^[a-zA-Z0-9_]+$/.test(value);
    }, "Username can only contain alphanumeric characters and underscores.");

    // Customize existing messages
    $.extend($.validator.messages, {
      required: "This field is required.",
      email: "Please enter a valid email address."
    });

    // Apply validation to forms
    $("form.validate-form").validate({
      rules: {
        username: {
          required: true,
          usernameRule: true
        },
        email: {
          required: true,
          email: true
        }
      },
      errorPlacement: function (error, element) {
        error.insertAfter(element);
      }
    });
  });
})(jQuery);