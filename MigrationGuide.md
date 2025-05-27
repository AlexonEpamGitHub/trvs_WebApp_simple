# .NET Framework 4.5.2 to .NET 8 Migration Guide

## View Migration: Hotels/Index.cshtml

The following changes are required to update the Views/Hotels/Index.cshtml file from ASP.NET MVC 5 to ASP.NET Core MVC:

### Original File (ASP.NET MVC 5)

```cshtml
@model IEnumerable<WebApplication452_simple.Models.Hotel>

@{
    ViewBag.Title = "Index";
}

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(model => model.Country.Name)
        </th>
        <th>
            @Html.DisplayNameFor(model => model.Name)
        </th>
        <th>
            @Html.DisplayNameFor(model => model.City)
        </th>
        <th>
            @Html.DisplayNameFor(model => model.Stars)
        </th>
        <th>
            @Html.DisplayNameFor(model => model.PricePerNight)
        </th>
        <th>
            @Html.DisplayNameFor(model => model.IsAllInclusive)
        </th>
        <th></th>
    </tr>

@foreach (var item in Model) {
    <tr>
        <td>
            @Html.DisplayFor(modelItem => item.Country.Name)
        </td>
        <td>
            @Html.DisplayFor(modelItem => item.Name)
        </td>
        <td>
            @Html.DisplayFor(modelItem => item.City)
        </td>
        <td>
            @Html.DisplayFor(modelItem => item.Stars)
        </td>
        <td>
            @Html.DisplayFor(modelItem => item.PricePerNight)
        </td>
        <td>
            @Html.DisplayFor(modelItem => item.IsAllInclusive)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", new { id=item.Id }) |
            @Html.ActionLink("Details", "Details", new { id=item.Id }) |
            @Html.ActionLink("Delete", "Delete", new { id=item.Id })
        </td>
    </tr>
}

</table>
```

### Updated File (ASP.NET Core MVC)

```cshtml
@model IEnumerable<HotelReservationSystem.Models.Hotel>

@{
    ViewData["Title"] = "Index";
}

<h2>Index</h2>

<p>
    <a asp-action="Create" class="btn btn-primary">Create New</a>
</p>
<table class="table">
    <thead>
        <tr>
            <th>
                @Html.DisplayNameFor(model => model.Country.Name)
            </th>
            <th>
                @Html.DisplayNameFor(model => model.Name)
            </th>
            <th>
                @Html.DisplayNameFor(model => model.City)
            </th>
            <th>
                @Html.DisplayNameFor(model => model.Stars)
            </th>
            <th>
                @Html.DisplayNameFor(model => model.PricePerNight)
            </th>
            <th>
                @Html.DisplayNameFor(model => model.IsAllInclusive)
            </th>
            <th></th>
        </tr>
    </thead>
    <tbody>
        @foreach (var item in Model) {
            <tr>
                <td>
                    @Html.DisplayFor(modelItem => item.Country.Name)
                </td>
                <td>
                    @Html.DisplayFor(modelItem => item.Name)
                </td>
                <td>
                    @Html.DisplayFor(modelItem => item.City)
                </td>
                <td>
                    @Html.DisplayFor(modelItem => item.Stars)
                </td>
                <td>
                    @Html.DisplayFor(modelItem => item.PricePerNight)
                </td>
                <td>
                    @Html.DisplayFor(modelItem => item.IsAllInclusive)
                </td>
                <td>
                    <a asp-action="Edit" asp-route-id="@item.Id" class="btn btn-sm btn-primary">Edit</a> |
                    <a asp-action="Details" asp-route-id="@item.Id" class="btn btn-sm btn-info">Details</a> |
                    <a asp-action="Delete" asp-route-id="@item.Id" class="btn btn-sm btn-danger">Delete</a>
                </td>
            </tr>
        }
    </tbody>
</table>
```

### Key Changes

1. **Namespace Update**: Changed model reference from `WebApplication452_simple.Models.Hotel` to `HotelReservationSystem.Models.Hotel`.

2. **Tag Helpers**: Replaced `@Html.ActionLink` with tag helpers (`<a asp-action="..." asp-route-id="...">`) for better readability and type safety.

3. **Table Structure**: Added `<thead>` and `<tbody>` tags for proper HTML5 table structure.

4. **Button Styling**: Added Bootstrap button styling to action links using `class="btn btn-sm btn-primary"` etc.

5. **Configuration**: Changed `ViewBag.Title` to `ViewData["Title"]` for consistency with ASP.NET Core conventions.

These changes maintain the same functionality while updating the syntax to follow ASP.NET Core MVC best practices.