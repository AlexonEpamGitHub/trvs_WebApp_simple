(function () {
    'use strict';

    // DOM is fully loaded
    document.addEventListener('DOMContentLoaded', function () {
        console.log('Application initialized.');

        // Example: Event listener for a button click
        const button = document.getElementById('exampleButton');
        if (button) {
            button.addEventListener('click', function () {
                alert('Button clicked!');
            });
        }

        // Example: Form submission
        const form = document.getElementById('exampleForm');
        if (form) {
            form.addEventListener('submit', function (event) {
                event.preventDefault();
                const formData = new FormData(form);

                // Simple form validation
                const name = formData.get('name') || '';
                if (name.trim() === '') {
                    alert('Name is required.');
                    return;
                }

                // Example AJAX post
                fetch('/api/submit', {
                    method: 'POST',
                    body: formData,
                }).then(response => response.json())
                  .then(data => {
                      console.log('Form submitted successfully:', data);
                  }).catch(error => {
                      console.error('Error:', error);
                  });
            });
        }
    });
})();