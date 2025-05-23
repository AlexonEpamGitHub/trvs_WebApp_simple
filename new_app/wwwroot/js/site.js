// Custom JavaScript logic for the application
// Add logic for form validation and dynamic data rendering

// Example: Validate form inputs
document.addEventListener('DOMContentLoaded', function () {
    const forms = document.querySelectorAll('form');
    forms.forEach(form => {
        form.addEventListener('submit', e => {
            const inputs = form.querySelectorAll('input');
            inputs.forEach(input => {
                if (!input.value.trim()) {
                    e.preventDefault();
                    alert('Please fill out all fields.');
                    input.classList.add('error');
                } else {
                    input.classList.remove('error');
                }
            });
        });
    });
});

// Example: Dynamic data rendering
async function fetchData(url) {
    try {
        const response = await fetch(url);
        const data = await response.json();
        const target = document.getElementById('dynamic-content');
        data.forEach(item => {
            const div = document.createElement('div');
            div.textContent = item.name;
            target.appendChild(div);
        });
    } catch (error) {
        console.error('Error fetching data:', error);
    }
}
fetchData('/api/data');