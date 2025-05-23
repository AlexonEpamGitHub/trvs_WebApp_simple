// Initialize DOM interactions
document.addEventListener('DOMContentLoaded', () => {
  console.log("Application JavaScript initialized.");

  // Example event binding for form submission
  const formElement = document.querySelector('#sampleForm');
  if (formElement) {
    formElement.addEventListener('submit', async (event) => {
      event.preventDefault(); // Stop default form submission
      const formData = new FormData(formElement);

      try {
        const response = await fetch('/api/submit', {
          method: 'POST',
          body: formData,
        });
        
        if (!response.ok) {
          throw new Error(`HTTP error! status: ${response.status}`);
        }

        const responseData = await response.json();
        console.log('Form submitted successfully', responseData);
      } catch (error) {
        console.error('Error submitting the form:', error);
      }
    });
  }

  // Example of click event handling
  const buttonElement = document.querySelector('#exampleButton');
  if (buttonElement) {
    buttonElement.addEventListener('click', () => {
      console.log('Button was clicked!');
    });
  }
});