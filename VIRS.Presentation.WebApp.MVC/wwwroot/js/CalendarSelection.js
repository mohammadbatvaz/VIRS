document.addEventListener("DOMContentLoaded", function ()
{
    const calendarDays = document.querySelectorAll('.calendar-table td:not(.empty):not(.past)');
    const hiddenInput = document.getElementById('InspectionDate');

    calendarDays.forEach(day =>
    {
        day.addEventListener('click', function ()
        {

            calendarDays.forEach(d => d.classList.remove('selected'));
            this.classList.add('selected');

            if (hiddenInput)
            {
                hiddenInput.value = this.dataset.value;
            }
        });
    });
});
