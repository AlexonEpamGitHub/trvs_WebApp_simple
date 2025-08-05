# jQuery Unobtrusive Validation

This is a copy of jQuery Unobtrusive Validation library for ASP.NET Core MVC applications.

## Version

The current version is 3.2.13.

## Description

The jQuery Unobtrusive Validation library complements jQuery Validation by adding support for specifying validation options as HTML5 data-* attributes.

This package is included in ASP.NET Core MVC to provide client-side validation capabilities. It works in conjunction with the server-side validation provided by ASP.NET Core MVC's model validation.

## Dependencies

- jQuery
- jQuery Validation

## Usage

In ASP.NET Core, this library is typically referenced via the _ValidationScriptsPartial.cshtml partial view, which would include:

```html
<script src="~/lib/jquery-validation/dist/jquery.validate.min.js"></script>
<script src="~/lib/jquery-validation-unobtrusive/jquery.validate.unobtrusive.min.js"></script>
```

For more information about client-side validation in ASP.NET Core MVC, see the [Microsoft documentation](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/validation).