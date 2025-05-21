// Include necessary Bootstrap functionalities for enabling responsive design

document.addEventListener('DOMContentLoaded', function () {
    // Activate Bootstrap tooltips globally
    var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
    var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
        return new bootstrap.Tooltip(tooltipTriggerEl);
    });

    // Activate Bootstrap popovers globally
    var popoverTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="popover"]'));
    var popoverList = popoverTriggerList.map(function (popoverTriggerEl) {
        return new bootstrap.Popover(popoverTriggerEl);
    });

    // Enable responsive navbar toggling
    var navbarToggle = document.querySelector('.navbar-toggler');
    if (navbarToggle) {
        navbarToggle.addEventListener('click', function () {
            var navbarCollapse = document.querySelector('.navbar-collapse');
            if (navbarCollapse) {
                navbarCollapse.classList.toggle('show');
            }
        });
    }
});