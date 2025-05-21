/*!
 * jQuery Validation Plugin - Documentation for Visual Studio IntelliSense
 * Updated for compatibility with the latest jQuery Validation Plugin
 */

(function($) {
    // Updated configuration methods for the latest jQuery validation plugin
    $.validator.setDefaults({
        debug: true,
        success: "valid"
    });

    // Example of modernized custom validation method
    $.validator.addMethod("pattern", function(value, element, param) {
        return this.optional(element) || new RegExp(param).test(value);
    }, "Invalid format.");

    // Updated initialization example
    $(document).ready(function() {
        $("#myForm").validate({
            rules: {
                fieldName: {
                    required: true,
                    pattern: "^[a-zA-Z]+$"
                }
            },
            messages: {
                fieldName: {
                    required: "This field is required.",
                    pattern: "Only letters are allowed."
                }
            }
        });
    });
})(jQuery);