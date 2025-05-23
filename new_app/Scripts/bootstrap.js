// Bootstrap JavaScript dynamic functionality handler
import 'bootstrap';

document.addEventListener('DOMContentLoaded', () => {
  // Initialize Bootstrap tooltips globally
  const tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
  const tooltipList = tooltipTriggerList.map(tooltipTriggerEl => new bootstrap.Tooltip(tooltipTriggerEl));

  // Initialize Bootstrap modals globally
  const modalElement = document.getElementById('exampleModal');
  if (modalElement) {
    const modalInstance = new bootstrap.Modal(modalElement);
    modalElement.addEventListener('shown.bs.modal', () => {
      console.log('Bootstrap modal is open!');
    });
  }

  // Responsive behavior for offcanvas menu
  const offcanvasElementList = [].slice.call(document.querySelectorAll('.offcanvas'));
  const offcanvasList = offcanvasElementList.map(offcanvasEl => new bootstrap.Offcanvas(offcanvasEl));

  console.log('Bootstrap functionalities initialized successfully.');
});