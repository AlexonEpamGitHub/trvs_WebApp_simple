// JavaScript for interactive UI features

// Smooth scrolling for anchor links
document.querySelectorAll('a[href^="#"]').forEach(anchor => {
    anchor.addEventListener('click', function(event) {
        event.preventDefault();
        document.querySelector(this.getAttribute('href')).scrollIntoView({
            behavior: 'smooth'
        });
    });
});

// Modal handling
document.addEventListener('DOMContentLoaded', function() {
    const modal = document.querySelector('.modal');
    if (modal) {
        const openModalButton = document.querySelector('#openModal');
        const closeModalButton = document.querySelector('#closeModal');

        openModalButton?.addEventListener('click', () => {
            modal.style.display = 'block';
        });

        closeModalButton?.addEventListener('click', () => {
            modal.style.display = 'none';
        });

        window.addEventListener('click', (event) => {
            if (event.target === modal) {
                modal.style.display = 'none';
            }
        });
    }
});

// AJAX call example
document.querySelector('#loadDataButton')?.addEventListener('click', () => {
    fetch('/api/data')
        .then(response => response.json())
        .then(data => {
            console.log('Data loaded:', data);
            // Handle data rendering
        })
        .catch(error => console.error('Error loading data:', error));
});