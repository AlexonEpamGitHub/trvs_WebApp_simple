// Bootstrap Bundle (Refactored for Modern Compatibility)

(function (global, factory) {
  if (typeof define === "function" && define.amd) {
    define(["jquery"], factory);
  } else if (typeof exports !== "undefined") {
    module.exports = factory(require("jquery"));
  } else {
    global.BootstrapBundle = factory(global.jQuery);
  }
}(this, function ($) {
  "use strict";

  // Ensure compatibility with modern browsers
  const module = {};

  // Example ES6 syntax usage
  const toggleClass = (element, className) => {
    element.classList.toggle(className);
  };

  // Example of a modern API
  const addEventListeners = (element, events, handler) => {
    events.forEach(event => element.addEventListener(event, handler));
  };

  // Refactored code
  module.init = function () {
    const buttons = document.querySelectorAll(".btn-toggle");
    buttons.forEach(button => {
      addEventListeners(button, ["click", "touchstart"], () => toggleClass(button, "active"));
    });
  };

  // Initialize the module
  $(document).ready(function () {
    module.init();
  });

  return module;

}));