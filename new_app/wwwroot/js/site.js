// Modern JavaScript functionality for ASP.NET Core applications

// Example: AJAX call to fetch data
function fetchData(endpoint) {
    fetch(endpoint)
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then(data => {
            console.log('Data fetched:', data);
        })
        .catch(error => {
            console.error('Error during fetch:', error);
        });
}

// Example: Form validation
function validateForm(event) {
    event.preventDefault();
    const form = document.querySelector('#myForm');
    const inputs = form.querySelectorAll('input');
    let isValid = true;

    inputs.forEach(input => {
        if (!input.value) {
            input.classList.add('error');
            isValid = false;
        } else {
            input.classList.remove('error');
        }
    });

    if (isValid) {
        alert('Form submitted successfully.');
    } else {
        alert('Please fill out all required fields.');
    }
}

// Example: Dynamic DOM manipulation
function addElement() {
    const div = document.createElement('div');
    div.textContent = 'This is a new element';
    document.body.appendChild(div);
}

// Attach event listeners
window.onload = function () {
    document.querySelector('#fetchButton').addEventListener('click', () => fetchData('/api/data'));
    document.querySelector('#addButton').addEventListener('click', addElement);
    document.querySelector('#myForm').addEventListener('submit', validateForm);
};