// Application-specific JavaScript for the hotel application
// This file contains client-side functionality for the .NET 8 migrated application

// Document ready function to ensure DOM is fully loaded before executing scripts
$(document).ready(function () {
    // Initialize Bootstrap 5 tooltips
    const tooltipTriggerList = document.querySelectorAll('[data-bs-toggle="tooltip"]');
    const tooltipList = [...tooltipTriggerList].map(tooltipTriggerEl => new bootstrap.Tooltip(tooltipTriggerEl));
    
    // Initialize Bootstrap 5 popovers
    const popoverTriggerList = document.querySelectorAll('[data-bs-toggle="popover"]');
    const popoverList = [...popoverTriggerList].map(popoverTriggerEl => new bootstrap.Popover(popoverTriggerEl));
    
    // Format currency fields (for hotel prices)
    $('.price-field').each(function() {
        const value = parseFloat($(this).text());
        if (!isNaN(value)) {
            $(this).text(new Intl.NumberFormat('en-US', { 
                style: 'currency', 
                currency: 'USD' 
            }).format(value));
        }
    });
    
    // Add star rating visual representation
    $('.star-rating').each(function() {
        const stars = parseInt($(this).data('stars')) || 0;
        let html = '';
        for (let i = 0; i < 5; i++) {
            if (i < stars) {
                html += '<i class="bi bi-star-fill text-warning"></i>';
            } else {
                html += '<i class="bi bi-star text-secondary"></i>';
            }
        }
        $(this).html(html);
    });
    
    // Form validation enhancements using modern Bootstrap 5 validation classes
    if ($.validator) {
        $.validator.setDefaults({
            errorElement: 'div',
            errorClass: 'invalid-feedback',
            highlight: function (element) {
                $(element).addClass('is-invalid').removeClass('is-valid');
            },
            unhighlight: function (element) {
                $(element).removeClass('is-invalid').addClass('is-valid');
            },
            errorPlacement: function (error, element) {
                error.addClass('invalid-feedback');
                if (element.prop('type') === 'checkbox') {
                    error.insertAfter(element.parent('label'));
                } else {
                    error.insertAfter(element);
                }
            }
        });
    }
    
    // AJAX handling for country and hotel selection
    $('#CountryId').change(function() {
        const selectedCountryId = $(this).val();
        if (selectedCountryId) {
            // Get hotels for the selected country using fetch API
            fetch(`/api/countries/${selectedCountryId}/hotels`)
                .then(response => {
                    if (!response.ok) {
                        throw new Error('Network response was not ok');
                    }
                    return response.json();
                })
                .then(data => {
                    const hotelSelect = $('#HotelId');
                    hotelSelect.empty();
                    hotelSelect.append(new Option('-- Select Hotel --', ''));
                    
                    data.forEach(hotel => {
                        hotelSelect.append(new Option(hotel.name, hotel.id));
                    });
                    
                    // Enable the hotel dropdown
                    hotelSelect.prop('disabled', false);
                })
                .catch(error => {
                    console.error('Error fetching hotels:', error);
                });
        } else {
            // Reset and disable the hotel dropdown if no country is selected
            const hotelSelect = $('#HotelId');
            hotelSelect.empty();
            hotelSelect.append(new Option('-- Select Country First --', ''));
            hotelSelect.prop('disabled', true);
        }
    });
    
    // Date range picker initialization for booking dates
    if ($.fn.daterangepicker) {
        $('.date-range-picker').daterangepicker({
            autoApply: true,
            minDate: moment(),
            locale: {
                format: 'YYYY-MM-DD'
            }
        });
    }
    
    // Confirmation dialogs for delete actions
    $('.delete-confirmation').click(function(e) {
        if (!confirm('Are you sure you want to delete this item?')) {
            e.preventDefault();
        }
    });
    
    // Handle responsive navigation menu toggle
    $('.navbar-toggler').on('click', function () {
        const target = $(this).data('bs-target');
        $(target).toggleClass('show');
    });
    
    // Enable responsive tables with horizontal scrolling on small screens
    $('.table-responsive').each(function() {
        const table = $(this).find('table');
        if (table.width() > $(this).width()) {
            $(this).css('overflow-x', 'auto');
        }
    });
    
    // Initialize any custom UI components or plugins
    initializeCustomComponents();
});

// Function to initialize any custom UI components
function initializeCustomComponents() {
    // Example: Initialize any third-party components or custom widgets
    
    // Fade out alert messages after 5 seconds
    setTimeout(function() {
        $('.alert-dismissible').fadeOut('slow');
    }, 5000);
    
    // Add print functionality to print buttons
    $('.btn-print').click(function() {
        window.print();
        return false;
    });
}

// Expose globally accessible functions if needed
window.refreshData = function() {
    location.reload();
};

window.scrollToTop = function() {
    window.scrollTo({ top: 0, behavior: 'smooth' });
};