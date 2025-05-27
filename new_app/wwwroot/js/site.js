(() => {
    // Add event listener for button click
    document.addEventListener('DOMContentLoaded', () => {
        const button = document.getElementById('interactButton');
        if (button) {
            button.addEventListener('click', () => {
                // Example: Interact with backend API
                fetch('/api/example', {
                    method: 'GET'
                })
                .then(response => response.json())
                .then(data => {
                    console.log('API Response:', data);
                    // Dynamically update UI
                    const resultDiv = document.getElementById('result');
                    if (resultDiv) {
                        resultDiv.innerText = `Result: ${data.message}`;
                    }
                })
                .catch(error => {
                    console.error('Error:', error);
                });
            });
        }
    });

    // Real-time Input Validation
    const form = document.getElementById('form');
    if (form) {
        form.addEventListener('input', event => {
            const input = event.target;
            if (input && input.type === 'text') {
                if (input.value.length < 3) {
                    input.setCustomValidity('Input must be at least 3 characters long.');
                } else {
                    input.setCustomValidity('');
                }
            }
        });
    }
})();