// JavaScript file for client-side functionality

/**
 * Sanitize user input to prevent injection attacks.
 * @param {string} input - The user input to sanitize.
 * @returns {string} - The sanitized input.
 */
function sanitizeInput(input) {
    return input.replace(/[<>]/g, ''); // Remove potentially harmful characters
}

// Ensure DOM is fully loaded
$(document).ready(function() {
    // Form validation
    $('form').on('submit', function(event) {
        let isValid = true;

        // Example validation: Ensure required fields are filled
        $(this).find('[required]').each(function() {
            const sanitizedValue = sanitizeInput($(this).val());
            if (sanitizedValue.trim() === '') {
                isValid = false;
                $(this).addClass('error');
            } else {
                $(this).removeClass('error');
            }
        });

        if (!isValid) {
            event.preventDefault();
            alert('Please fill out all required fields.');
        }
    });

    // AJAX call example
    $('#loadDataButton').on('click', function() {
        $.ajax({
            url: '/api/data',
            method: 'GET',
            dataType: 'json',
            success: function(response) {
                try {
                    // Ensure response is sanitized before rendering
                    const sanitizedResponse = sanitizeInput(JSON.stringify(response));
                    $('#dataContainer').html(sanitizedResponse);
                } catch (error) {
                    console.error('Error processing response:', error);
                    alert('An error occurred while processing the data.');
                }
            },
            error: function(jqXHR, textStatus, errorThrown) {
                console.error('AJAX Error:', textStatus, errorThrown);
                alert('Failed to load data. Please try again later.');
            }
        });
    });

    // Example DOM manipulation
    $('#toggleVisibilityButton').on('click', function() {
        $('#targetElement').toggle();
    });

    // Input field masking
    $('.phone-input').on('input', function() {
        let value = $(this).val().replace(/[^0-9]/g, '');
        $(this).val(sanitizeInput(value));
    });

    // Keyboard event handling
    $(document).on('keydown', function(event) {
        if (event.key === 'Escape') {
            $('#popupElement').hide();
        }
    });

    // Utility animation example
    $('#fadeInButton').on('click', function() {
        $('#fadeTarget').fadeIn();
    });

    $('#fadeOutButton').on('click', function() {
        $('#fadeTarget').fadeOut();
    });

    // Cookie management example
    function setCookie(name, value, days) {
        const date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        document.cookie = `${name}=${value};expires=${date.toUTCString()};path=/`;
    }

    function getCookie(name) {
        const cookies = document.cookie.split(';');
        for (let i = 0; i < cookies.length; i++) {
            const cookie = cookies[i].trim();
            if (cookie.startsWith(`${name}=`)) {
                return cookie.substring(name.length + 1);
            }
        }
        return null;
    }

    // Example usage
    setCookie('user', 'JohnDoe', 7);
    console.log(getCookie('user'));
});
