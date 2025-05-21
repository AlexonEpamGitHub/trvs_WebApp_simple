/*
 * jQuery Unobtrusive Validation for ASP.NET Core MVC
 * Provides client-side validation support for ASP.NET Core MVC applications.
 */

(function ($) {
    'use strict';

    // Define unobtrusive validation methods
    var validation = {
        init: function () {
            $(document).ready(function () {
                $("form").each(function () {
                    $(this).validate({
                        errorClass: 'text-danger',
                        highlight: function (element) {
                            $(element).addClass('is-invalid');
                        },
                        unhighlight: function (element) {
                            $(element).removeClass('is-invalid');
                        },
                        errorPlacement: function (error, element) {
                            error.insertAfter(element);
                        }
                    });
                });
            });
        },

        addValidationAttributes: function () {
            // Parse validation attributes added by the server
            $("[data-val=true]").each(function () {
                $(this).rules("add", $(this).data());
            });
        }
    };

    // Initialize validation on document ready
    validation.init();
    validation.addValidationAttributes();

})(jQuery);