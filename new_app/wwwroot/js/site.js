// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// This file contains site-wide JavaScript functionality for the application
$(document).ready(function () {
    // Initialize Bootstrap tooltips
    $('[data-bs-toggle="tooltip"]').tooltip();

    // Initialize Bootstrap popovers
    $('[data-bs-toggle="popover"]').popover();

    // Example of custom functionality for the site
    $('.navbar-toggler').on('click', function() {
        // Custom handling for navbar toggler if needed
    });

    // Example of a form validation helper
    $('.needs-validation').on('submit', function(event) {
        if (!this.checkValidity()) {
            event.preventDefault();
            event.stopPropagation();
        }
        
        $(this).addClass('was-validated');
    });
});

// Add any other site-wide JavaScript functions below