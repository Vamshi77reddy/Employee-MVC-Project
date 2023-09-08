function validateDateTime() {
    var datetimeInput = document.getElementById('datetimeInput')
    var selectedDate = new Date(datetimeInput.value);
    var currentDate = new Date()
    currentDate.setHours(0, 0, 0, 0);
    if (selectedDate < currentDate) {
        alert('Please select a date from today and further')
        datetimeInput.value = '';
    }
}