// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

console.log("dasdasdsaddsa")


// Get the initial list of employee names based on the selected product ID
var initialProductId = $("#productDropdown").val();
getEmployeeNames(initialProductId);

console.log(getEmployeeNames(initialProductId));

// Handle the change event of the product dropdown
$("#productDropdown").change(function () {
    console.log("changed");
    var selectedProductId = $(this).val();
    getEmployeeNames(selectedProductId);
});

// Function to retrieve employee names based on the selected product ID
function getEmployeeNames(productId) {
    $.ajax({
        url: "/Projects/GetEmployeeNames?productId=" + productId,
        type: "GET",
        data: { productId: productId },
        success: function (result) {
            // Clear the employee dropdown
            $("#employeeDropdown").empty();
            console.log(result);
            // Add the new employee names to the dropdown
            $.each(result, function (index, name) {
                $("#employeeDropdown").append($('<option></option>').val(name).text(name));
            });
        },
        error: function (xhr, status, error) {
            console.error(error);
        }
    });
}
