// JavaScript to pick date
document.addEventListener('DOMContentLoaded', function() {
    // Get the input element for date picker
    var datepickerInput = document.getElementById('datepicker');
    
    // Add click event listener to show the date picker when the input is clicked
    datepickerInput.addEventListener('click', function() {
        // Create a new date picker instance
        var datePicker = new Datepicker(datepickerInput, {
            // You can customize the options for the date picker here
            // For example, you can set the format of the selected date
            format: 'yyyy-mm-dd',
            // You can also set the start view of the date picker
            // (e.g., 'day', 'month', 'year')
            startView: 'days'
        });
        // Show the date picker
        datePicker.show();
    });
});