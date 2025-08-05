# Bootstrap 5.2.3 for .NET Core 8 Migration

This folder contains the Bootstrap 5.2.3 library files necessary for the migrated .NET Core 8 application.

## Usage in .NET Core 8

### Option 1: Local Files (current implementation)
The files in this directory can be referenced in your views by using the built-in tag helpers:

```cshtml
<link rel="stylesheet" href="~/lib/bootstrap/dist/css/bootstrap.min.css" />
<script src="~/lib/bootstrap/dist/js/bootstrap.bundle.min.js"></script>
```

### Option 2: LibMan (Recommended for Production)
In a production .NET Core 8 application, it's recommended to use LibMan to manage client-side libraries:

1. Create a `libman.json` file in the project root:
```json
{
  "version": "1.0",
  "defaultProvider": "cdnjs",
  "libraries": [
    {
      "library": "bootstrap@5.2.3",
      "destination": "wwwroot/lib/bootstrap/"
    }
  ]
}
```

2. Use the LibMan CLI or Visual Studio LibMan UI to restore packages.

### Option 3: CDN References (Recommended for Production)
For performance benefits, consider using CDN references in your layout:

```cshtml
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" integrity="sha384-rbsA2VBKQhggwzxH7pPCaAqO46MgnOM80zW1RWuH61DGLwZJEdK2Kadq2F9CUG65" crossorigin="anonymous">
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-kenU1KFdBIe4zVF0s0G1M5b4hcpxyD9F7jL+jjXkk+Q2h455rYXK/7HAuoJl+0I4" crossorigin="anonymous"></script>
```

## Bootstrap Components in .NET Core 8 

When using Bootstrap with ASP.NET Core MVC tag helpers, you can leverage the built-in integration:

```cshtml
<form asp-controller="Home" asp-action="Index" method="post">
    <div class="mb-3">
        <label asp-for="Name" class="form-label"></label>
        <input asp-for="Name" class="form-control" />
        <span asp-validation-for="Name" class="text-danger"></span>
    </div>
    <button type="submit" class="btn btn-primary">Submit</button>
</form>
```

## Additional Resources

- [Official Bootstrap Documentation](https://getbootstrap.com/docs/5.2/)
- [ASP.NET Core Tag Helpers Documentation](https://docs.microsoft.com/en-us/aspnet/core/mvc/views/tag-helpers/intro)
- [LibMan Documentation](https://docs.microsoft.com/en-us/aspnet/core/client-side/libman/)