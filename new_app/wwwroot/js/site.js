// JavaScript file for client-side functionality

// Ensure DOM is fully loaded
$(document).ready(function() {
    // Form validation
    $('form').on('submit', function(event) {
        let isValid = true;

        // Example validation: Ensure required fields are filled
        $(this).find('[required]').each(function() {
            if ($(this).val().trim() === '') {
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
            success: function(response) {
                $('#dataContainer').html(response);
            },
            error: function() {
                alert('Failed to load data.');
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
        $(this).val(value);
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