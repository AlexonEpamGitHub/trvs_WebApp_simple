# jQuery Validation Plugin

This directory contains the jQuery Validation Plugin files for client-side form validation in the ASP.NET Core application.

## Structure

- `jquery.validate.js` - The core validation library
- `jquery.validate.min.js` - Minified version of the validation library
- `jquery.validate.unobtrusive.js` - ASP.NET Core MVC unobtrusive validation extension
- `jquery.validate.unobtrusive.min.js` - Minified version of unobtrusive validation
- `dist/` - Distribution folder containing:
  - Core library files (duplicate of root level for compatibility)
  - `additional-methods.js` - Additional validation methods
  - `localization/` - Localization files for different languages

## Usage

These libraries are referenced in the layout views and used automatically by ASP.NET Core MVC's TagHelpers for client-side validation of form inputs.

## Version

jQuery Validation Plugin v1.19.5