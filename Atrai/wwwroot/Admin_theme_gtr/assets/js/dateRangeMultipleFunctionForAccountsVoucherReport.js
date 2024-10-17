
$('#start-date, #end-date').datepicker({
    beforeShow: setDateRange,
    dateFormat: "mm/dd/yy",
    firstDay: 1,
    changeFirstDay: false,
    onChange: function () { $(this).valid(); },
    onSelect: function () {
        if (this.id == 'start-date') {
            // If selected start date is later than currently selected
            // end date, set end date to start date + 1 day
            var date = $('#start-date').datepicker('getDate');
            if (date) { date.setDate(date.getDate() + 1); }
            $('#end-date').datepicker('option', 'minDate', date);
        }
    }
});

function setDateRange(criteria) {
    var min = null, dateMin = min, dateMax = null, dayRange = 30;
    var opt = $('#select1'), start = $('#start-date'), end = $('#end-date'); //
    var months = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul",
        "Aug", "Sep", "Oct", "Nov", "Dec"];

    if (criteria == 'Today') {
        let d = new Date();
        let currentdate = d;

        let finaldateformat = currentdate.getDate() + "-" + months[currentdate.getMonth()] + "-" + currentdate.getFullYear(); //value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear();

        $("#start-date").val(finaldateformat);
        $("#end-date").val(finaldateformat);

    }
    else if (criteria == "Yesterday") {
        let d = new Date();
        d.setDate(d.getDate() - 1);
        //var currentdate = new Date() ;
        let currentdate = d;
        let finaldateformat = currentdate.getDate() + "-" + months[currentdate.getMonth()] + "-" + currentdate.getFullYear(); //value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear();

        $("#start-date").val(finaldateformat);
        $("#end-date").val(finaldateformat);
    }

    //else if (criteria == "This Week") {
    //    let d = new Date();
    //    let d2 = new Date();
    //    const daysToSaturday = 6 - d.getDay(); // days remaining until Saturday
    //    const daysToFriday = 5 + daysToSaturday; // days remaining until Friday
    //    d.setDate(d.getDate() + daysToFriday); // set to Friday
    //    d2.setDate(d2.getDate() - daysToSaturday); // set to Saturday
    //    let currentdate = d;
    //    let today = d2;
    //    let finaldateformat = currentdate.getDate() + "-" + months[currentdate.getMonth()] + "-" + currentdate.getFullYear();
    //    let finaldateformat2 = today.getDate() + "-" + months[today.getMonth()] + "-" + today.getFullYear();

    //    $("#start-date").val(finaldateformat2);
    //    $("#end-date").val(finaldateformat);
    //}

    if (criteria == "This Week") {
        let today = new Date();
        let currentDay = today.getDay(); // Get the current day (0 = Sunday, 1 = Monday, ..., 6 = Saturday)

        // Calculate the number of days to subtract from the current date to get to the start of the week (Saturday)
        let daysToStartOfWeek = currentDay;

        // Calculate the number of days to add to the current date to get to the end of the week (Friday)
        let daysToEndOfWeek = 6 - currentDay;

        // Calculate the start and end dates of "This Week"
        let startDate = new Date(today);
        startDate.setDate(today.getDate() - daysToStartOfWeek);

        let endDate = new Date(today);
        endDate.setDate(today.getDate() + daysToEndOfWeek);

        let finalStartDate = startDate.getDate() + "-" + months[startDate.getMonth()] + "-" + startDate.getFullYear();
        let finalEndDate = endDate.getDate() + "-" + months[endDate.getMonth()] + "-" + endDate.getFullYear();

        $("#start-date").val(finalStartDate);
        $("#end-date").val(finalEndDate);
    }

    //else if (criteria == "This Week-to-date") {
    //    let d = new Date();
    //    let d2 = new Date();
    //    const daysToSaturday = 6 - d.getDay();
    //    d.setDate(d.getDate() + 6);
    //    let currentdate = d;
    //    d2.setDate(d2.getDate() - daysToSaturday);
    //    let today = d2;
    //    let finaldateformat = currentdate.getDate() + "-" + months[currentdate.getMonth()] + "-" + currentdate.getFullYear(); //value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear();
    //    let finaldateformat2 = today.getDate() + "-" + months[today.getMonth()] + "-" + today.getFullYear();

    //    $("#start-date").val(finaldateformat2);
    //    $("#end-date").val(finaldateformat);
    //}

    else if (criteria == "This Week-to-date") {
        let today = new Date();
        let currentDay = today.getDay(); // Get the current day (0 = Sunday, 1 = Monday, ..., 6 = Saturday)

        // Calculate the number of days to subtract from the current date to get to the start of the week (Saturday)
        let daysToStartOfWeek = currentDay;

        // Calculate the start date of "This Week-to-date"
        let startDate = new Date(today);
        startDate.setDate(today.getDate() - daysToStartOfWeek);

        // Calculate the end date of "This Week-to-date" (which is today)
        let finalEndDate = today.getDate() + "-" + months[today.getMonth()] + "-" + today.getFullYear();

        let finalStartDate = startDate.getDate() + "-" + months[startDate.getMonth()] + "-" + startDate.getFullYear();

        $("#start-date").val(finalStartDate);
        $("#end-date").val(finalEndDate);
    }

    //else if (criteria == "Next Week") {
    //    let d = new Date(); y = date.getFullYear(), m = date.getMonth();
    //    let firstDay = new Date(y, m, 19)
    //    let d2 = new Date();

    //    d.setDate(d.getDate() + 13);
    //    d2.setDate(d.getDate() + 19);
    //    //var currentdate = new Date() ;
    //    let currentdate = d;
    //    let today = d2;
    //    let finaldateformat = currentdate.getDate() + "-" + months[currentdate.getMonth()] + "-" + currentdate.getFullYear(); //value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear();
    //    let finaldateformat2 = firstDay.getDate() + "-" + months[firstDay.getMonth()] + "-" + firstDay.getFullYear(); //value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear();

    //    $("#start-date").val(finaldateformat2);
    //    $("#end-date").val(finaldateformat);
    //}  

    else if (criteria == "Next Week") {
        let today = new Date();
        let currentDay = today.getDay(); // Get the current day (0 = Sunday, 1 = Monday, ..., 6 = Saturday)

        // Calculate the number of days remaining until the start of next week (Saturday)
        let daysToNextWeek = 6 - currentDay + 1; // Add 1 to move to the start of next week

        // Calculate the number of days remaining until the end of next week (Friday)
        let daysToEndOfNextWeek = daysToNextWeek + 6; // Add 6 to reach the end of next week

        // Calculate the start date of "Next Week"
        let startDate = new Date(today);
        startDate.setDate(today.getDate() + daysToNextWeek);

        // Calculate the end date of "Next Week"
        let endDate = new Date(today);
        endDate.setDate(today.getDate() + daysToEndOfNextWeek);

        let finalStartDate = startDate.getDate() + "-" + months[startDate.getMonth()] + "-" + startDate.getFullYear();
        let finalEndDate = endDate.getDate() + "-" + months[endDate.getMonth()] + "-" + endDate.getFullYear();

        $("#start-date").val(finalStartDate);
        $("#end-date").val(finalEndDate);
    }

    //else if (criteria == "Next 4 Weeks") {
    //    let today = new Date();

    //    // Calculate the start date of "Next 4 Weeks" (the next day after today)
    //    let startDate = new Date(today);
    //    startDate.setDate(today.getDate() + 1);

    //    // Calculate the end date of "Next 4 Weeks" (28 days from today)
    //    let endDate = new Date(today);
    //    endDate.setDate(today.getDate() + 28);

    //    let finalStartDate = startDate.getDate() + "-" + months[startDate.getMonth()] + "-" + startDate.getFullYear();
    //    let finalEndDate = endDate.getDate() + "-" + months[endDate.getMonth()] + "-" + endDate.getFullYear();

    //    $("#start-date").val(finalStartDate);
    //    $("#end-date").val(finalEndDate);
    //}

    else if (criteria == "Next 4 Weeks") {
        let today = new Date();
        let currentDay = today.getDay(); // Get the current day (0 = Saturday, 1 = Sunday, ..., 6 = Friday)

        // Calculate the number of days remaining until the start of the next week (Saturday)
        let daysToNextWeekStart = 6 - currentDay + 1; // Add 1 to move to the start of next week

        // Calculate the number of days remaining until the end of the next 4 weeks (28 days)
        let daysToEndOfNext4Weeks = daysToNextWeekStart + 27; // Add 27 to reach the end of the next 4 weeks

        // Calculate the start date of "Next 4 Weeks"
        let startDate = new Date(today);
        startDate.setDate(today.getDate() + daysToNextWeekStart);

        // Calculate the end date of "Next 4 Weeks"
        let endDate = new Date(today);
        endDate.setDate(today.getDate() + daysToEndOfNext4Weeks);

        let finalStartDate = startDate.getDate() + "-" + months[startDate.getMonth()] + "-" + startDate.getFullYear();
        let finalEndDate = endDate.getDate() + "-" + months[endDate.getMonth()] + "-" + endDate.getFullYear();

        $("#start-date").val(finalStartDate);
        $("#end-date").val(finalEndDate);
    }


    //else if (criteria == "Last Week") {
    //    let d = new Date();
    //    let d2 = new Date();

    //    d.setDate(d.getDate() - 7);
    //    //var currentdate = new Date() ;
    //    let currentdate = d;
    //    let today = d2;
    //    let finaldateformat = currentdate.getDate() + "-" + months[currentdate.getMonth()] + "-" + currentdate.getFullYear(); //value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear();
    //    let finaldateformat2 = today.getDate() + "-" + months[today.getMonth()] + "-" + today.getFullYear(); //value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear();

    //    $("#start-date").val(finaldateformat);
    //    $("#end-date").val(finaldateformat2);
    //}

    else if (criteria == "Last Week") {
        let today = new Date();
        let currentDay = today.getDay(); // Get the current day (0 = Saturday, 1 = Sunday, ..., 6 = Friday)

        // Calculate the number of days to subtract from the current date to get to the end of last week (Friday)
        let daysToEndOfLastWeek = currentDay === 6 ? 0 : currentDay + 1; // If today is Saturday, we want to go back to the same day

        // Calculate the number of days to subtract from the current date to get to the start of last week (Saturday)
        let daysToStartOfLastWeek = daysToEndOfLastWeek + 6; // Add 6 to go back one full week

        // Calculate the start date of "Last Week"
        let startDate = new Date(today);
        startDate.setDate(today.getDate() - daysToStartOfLastWeek);

        // Calculate the end date of "Last Week"
        let endDate = new Date(today);
        endDate.setDate(today.getDate() - daysToEndOfLastWeek);

        let finalStartDate = startDate.getDate() + "-" + months[startDate.getMonth()] + "-" + startDate.getFullYear();
        let finalEndDate = endDate.getDate() + "-" + months[endDate.getMonth()] + "-" + endDate.getFullYear();

        $("#start-date").val(finalStartDate);
        $("#end-date").val(finalEndDate);
    }

    //else if (criteria == "Last Week-to-date") {
    //    let d = new Date();
    //    let d2 = new Date();

    //    d.setDate(d.getDate() - 7);
    //    //var currentdate = new Date() ;
    //    let currentdate = d;
    //    let today = d2;
    //    let finaldateformat = currentdate.getDate() + "-" + months[currentdate.getMonth()] + "-" + currentdate.getFullYear(); //value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear();
    //    let finaldateformat2 = currentdate.getDate() + "-" + months[currentdate.getMonth()] + "-" + currentdate.getFullYear(); //value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear();

    //    $("#start-date").val(finaldateformat);
    //    $("#end-date").val(finaldateformat2);
    //}

    else if (criteria == "Last Week-to-date") {
        let today = new Date();
        let currentDay = today.getDay(); // Get the current day (0 = Saturday, 1 = Sunday, ..., 6 = Friday)

        // Calculate the number of days to subtract from the current date to get to the end of last week (Friday)
        let daysToEndOfLastWeek = currentDay === 6 ? 0 : currentDay + 1; // If today is Saturday, we want to go back to the same day

        // Calculate the number of days to subtract from the current date to get to the start of last week (Saturday)
        let daysToStartOfLastWeek = daysToEndOfLastWeek + 6; // Add 6 to go back one full week

        // Calculate the start date of "Last Week-to-date"
        let startDate = new Date(today);
        startDate.setDate(today.getDate() - daysToStartOfLastWeek);

        // Calculate the end date of "Last Week-to-date" (which is today)
        let finalEndDate = today.getDate() + "-" + months[today.getMonth()] + "-" + today.getFullYear();

        let finalStartDate = startDate.getDate() + "-" + months[startDate.getMonth()] + "-" + startDate.getFullYear();

        $("#start-date").val(finalStartDate);
        $("#end-date").val(finalEndDate);
    }

    else if (criteria == "Since 30 days ago") {
        let d = new Date();
        let d2 = new Date();

        d.setDate(d.getDate() - 30);
        //var currentdate = new Date() ;
        let currentdate = d;
        let today = d2;
        let finaldateformat = currentdate.getDate() + "-" + months[currentdate.getMonth()] + "-" + currentdate.getFullYear(); //value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear();
        let finaldateformat2 = today.getDate() + "-" + months[today.getMonth()] + "-" + today.getFullYear(); //value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear();

        $("#start-date").val(finaldateformat);
        $("#end-date").val(finaldateformat2);
    }
    else if (criteria == "Since 60 days ago") {
        let d = new Date();
        let d2 = new Date();

        d.setDate(d.getDate() - 60);
        //var currentdate = new Date() ;
        let currentdate = d;
        let today = d2;
        let finaldateformat = currentdate.getDate() + "-" + months[currentdate.getMonth()] + "-" + currentdate.getFullYear(); //value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear();
        let finaldateformat2 = today.getDate() + "-" + months[today.getMonth()] + "-" + today.getFullYear(); //value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear();

        $("#start-date").val(finaldateformat);
        $("#end-date").val(finaldateformat2);
    }
    else if (criteria == "Since 90 days ago") {
        let d = new Date();
        let d2 = new Date();

        d.setDate(d.getDate() - 90);
        //var currentdate = new Date() ;
        let currentdate = d;
        let today = d2;
        let finaldateformat = currentdate.getDate() + "-" + months[currentdate.getMonth()] + "-" + currentdate.getFullYear(); //value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear();
        let finaldateformat2 = today.getDate() + "-" + months[today.getMonth()] + "-" + today.getFullYear(); //value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear();

        $("#start-date").val(finaldateformat);
        $("#end-date").val(finaldateformat2);
    }
    else if (criteria == "Since 365 days ago") {
        let d = new Date();
        let d2 = new Date();

        d.setDate(d.getDate() - 365);
        //var currentdate = new Date() ;
        let currentdate = d;
        let today = d2;
        let finaldateformat = currentdate.getDate() + "-" + months[currentdate.getMonth()] + "-" + currentdate.getFullYear(); //value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear();
        let finaldateformat2 = today.getDate() + "-" + months[today.getMonth()] + "-" + today.getFullYear(); //value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear();

        $("#start-date").val(finaldateformat);
        $("#end-date").val(finaldateformat2);
    }
    else if (criteria == "This Month") {
        let d = new Date(), y = date.getFullYear(), m = date.getMonth();
        let firstDay = new Date(y, m, 1)
        let lastDay = new Date(y, m + 1, 0);
        d.setDate(d.getDate());
        //let date = d.getDate();
        //let month = d.getMonth() + 1; // Since getMonth() returns month from 0-11 not 1-12
        //let year = d.getFullYear();

        let finaldateformat = firstDay.getDate() + "-" + months[firstDay.getMonth()] + "-" + firstDay.getFullYear();
        let finaldateformat2 = lastDay.getDate() + "-" + months[lastDay.getMonth()] + "-" + lastDay.getFullYear();
        //let finaldateformat2 = firstDay + "/" + lastDay + "/" + year;

        $("#start-date").val(finaldateformat);
        $("#end-date").val(finaldateformat2);
    }
    else if (criteria == "Next Month") {
        let d = new Date(), y = date.getFullYear(), m = date.getMonth();
        let firstDay = new Date(y, m+1, 1)
        let lastDay = new Date(y, m + 2, 0);
        d.setDate(d.getDate());
        //let date = d.getDate();
        //let month = d.getMonth() + 1; // Since getMonth() returns month from 0-11 not 1-12
        //let year = d.getFullYear();

        let finaldateformat = firstDay.getDate() + "-" + months[firstDay.getMonth()] + "-" + firstDay.getFullYear();
        let finaldateformat2 = lastDay.getDate() + "-" + months[lastDay.getMonth()] + "-" + lastDay.getFullYear();
        //let finaldateformat2 = firstDay + "/" + lastDay + "/" + year;

        $("#start-date").val(finaldateformat);
        $("#end-date").val(finaldateformat2);
    }
    else if (criteria == "This Month-to-date") {
        let d = new Date(), y = date.getFullYear(), m = date.getMonth();
        let currentdate = d;
        let firstDay = new Date(y, m, 1)
        let lastDay = new Date(y, m + 1, 0);
        d.setDate(d.getDate());
        //let date = d.getDate();
        //let month = d.getMonth() + 1; // Since getMonth() returns month from 0-11 not 1-12
        //let year = d.getFullYear();

        let finaldateformat = firstDay.getDate() + "-" + months[firstDay.getMonth()] + "-" + firstDay.getFullYear();
        let finaldateformat2 = currentdate.getDate() + "-" + months[currentdate.getMonth()] + "-" + currentdate.getFullYear();
        //let finaldateformat2 = firstDay + "/" + lastDay + "/" + year;

        $("#start-date").val(finaldateformat);
        $("#end-date").val(finaldateformat2);
    }
    //else if (criteria == "This Quarter") {
    //    let d = new Date(), y = date.getFullYear(), m = date.getMonth();
    //    let firstDay = new Date(y, 0, 1);
    //    let currentdate = d;
    //    let lastDay = new Date(y, 3, 0);
    //    d.setDate(d.getDate());
    //    //let date = d.getDate();
    //    //let month = d.getMonth() + 1; // Since getMonth() returns month from 0-11 not 1-12
    //    //let year = d.getFullYear();

    //    let finaldateformat = firstDay.getDate() + "-" + months[firstDay.getMonth()] + "-" + firstDay.getFullYear();
    //    let finaldateformat2 = lastDay.getDate() + "-" + months[lastDay.getMonth()] + "-" + lastDay.getFullYear();
    //    //let finaldateformat2 = firstDay + "/" + lastDay + "/" + year;

    //    $("#start-date").val(finaldateformat);
    //    $("#end-date").val(finaldateformat2);
    //}


    else if (criteria == "This Quarter") {
        let today = new Date();
        let currentMonth = today.getMonth(); // Get the current month (0 = January, 1 = February, ..., 11 = December)

        // Determine the start month of the quarter (e.g., for January, February, or March, the start month is January)
        let startMonth = currentMonth - (currentMonth % 3);

        // Calculate the start date of "This Quarter" (always the first day of the start month)
        let startDate = new Date(today.getFullYear(), startMonth, 1);

        // Determine the end month of the quarter (e.g., for January, February, or March, the end month is March)
        let endMonth = startMonth + 2;

        // Calculate the last day of the end month
        let endDate = new Date(today.getFullYear(), endMonth + 1, 0);

        let finalStartDate = startDate.getDate() + "-" + months[startDate.getMonth()] + "-" + startDate.getFullYear();
        let finalEndDate = endDate.getDate() + "-" + months[endDate.getMonth()] + "-" + endDate.getFullYear();

        $("#start-date").val(finalStartDate);
        $("#end-date").val(finalEndDate);
    }


    //else if (criteria == "Next Quarter") {
    //    let d = new Date(), y = date.getFullYear(), m = date.getMonth();
    //    let firstDay = new Date(y, 3, 1);
    //    let currentdate = d;
    //    let lastDay = new Date(y, 6, 0);
    //    d.setDate(d.getDate());
    //    //let date = d.getDate();
    //    //let month = d.getMonth() + 1; // Since getMonth() returns month from 0-11 not 1-12
    //    //let year = d.getFullYear();

    //    let finaldateformat = firstDay.getDate() + "-" + months[firstDay.getMonth()] + "-" + firstDay.getFullYear();
    //    let finaldateformat2 = lastDay.getDate() + "-" + months[lastDay.getMonth()] + "-" + lastDay.getFullYear();
    //    //let finaldateformat2 = firstDay + "/" + lastDay + "/" + year;

    //    $("#start-date").val(finaldateformat);
    //    $("#end-date").val(finaldateformat2);
    //}

    else if (criteria == "Next Quarter") {
        let today = new Date();
        let currentMonth = today.getMonth(); // Get the current month (0 = January, 1 = February, ..., 11 = December)

        // Determine the start month of the next quarter
        let startMonth = currentMonth + 1;

        // Check if we need to adjust for the end of the year
        if (startMonth > 11) {
            startMonth = 0; // If the calculated start month is greater than 11, set it to January
        }

        // Calculate the start date of "Next Quarter" (always the first day of the start month)
        let startDate = new Date(today.getFullYear(), startMonth, 1);

        // Determine the end month of the next quarter
        let endMonth = startMonth + 2;

        // Check if we need to adjust for the end of the year
        if (endMonth > 11) {
            endMonth = 11; // If the calculated end month is greater than 11, set it to December
        }

        // Calculate the end date of "Next Quarter" (always the last day of the end month)
        let endDate = new Date(today.getFullYear(), endMonth + 1, 0);

        let finalStartDate = startDate.getDate() + "-" + months[startDate.getMonth()] + "-" + startDate.getFullYear();
        let finalEndDate = endDate.getDate() + "-" + months[endDate.getMonth()] + "-" + endDate.getFullYear();

        $("#start-date").val(finalStartDate);
        $("#end-date").val(finalEndDate);
    }

    //else if (criteria == "This Quarter-to-date") {
    //    let d = new Date(), y = date.getFullYear(), m = date.getMonth();
    //    let firstDay = new Date(y, 0, 1);
    //    let currentdate = d;
    //    let lastDay = new Date(y, 3, 0);
    //    d.setDate(d.getDate());
    //    //let date = d.getDate();
    //    //let month = d.getMonth() + 1; // Since getMonth() returns month from 0-11 not 1-12
    //    //let year = d.getFullYear();

    //    let finaldateformat = firstDay.getDate() + "-" + months[firstDay.getMonth()] + "-" + firstDay.getFullYear();
    //    let finaldateformat2 = currentdate.getDate() + "-" + months[currentdate.getMonth()] + "-" + currentdate.getFullYear();
    //    //let finaldateformat2 = firstDay + "/" + lastDay + "/" + year;

    //    $("#start-date").val(finaldateformat);
    //    $("#end-date").val(finaldateformat2);
    //}

    else if (criteria == "This Quarter-to-date") {
        let today = new Date();
        let currentMonth = today.getMonth(); // Get the current month (0 = January, 1 = February, ..., 11 = December)

        // Determine the start month of the quarter (e.g., for January, February, or March, the start month is January)
        let startMonth = currentMonth - (currentMonth % 3);

        // Calculate the start date of "This Quarter-to-date" (always the first day of the start month)
        let startDate = new Date(today.getFullYear(), startMonth, 1);

        // Calculate the end date of "This Quarter-to-date" (which is today)
        let finalEndDate = today.getDate() + "-" + months[today.getMonth()] + "-" + today.getFullYear();

        let finalStartDate = startDate.getDate() + "-" + months[startDate.getMonth()] + "-" + startDate.getFullYear();

        $("#start-date").val(finalStartDate);
        $("#end-date").val(finalEndDate);
    }

    else if (criteria == "This Year") {
        let d = new Date(), y = date.getFullYear(), m = date.getMonth();
        let firstDay = new Date(y, 0, 1);
        let lastDay = new Date(y, 11, 31); // set last day to 31-Dec-2023
        d.setDate(d.getDate());

        let finaldateformat = firstDay.getDate() + "-" + months[firstDay.getMonth()] + "-" + firstDay.getFullYear();
        let finaldateformat2 = lastDay.getDate() + "-" + months[lastDay.getMonth()] + "-" + lastDay.getFullYear();

        $("#start-date").val(finaldateformat);
        $("#end-date").val(finaldateformat2);

    }
    else if (criteria == "All Dates") {
        let d = new Date(), y = date.getFullYear(), m = date.getMonth();
        let firstDay = new Date(y, 0, 1);
        let lastDay = new Date(y, 11, 31); // set last day to 31-Dec-2023
        d.setDate(d.getDate());

        let finaldateformat = firstDay.getDate() + "-" + months[firstDay.getMonth()] + "-" + firstDay.getFullYear();
        let finaldateformat2 = lastDay.getDate() + "-" + months[lastDay.getMonth()] + "-" + lastDay.getFullYear();

        $("#start-date").val(finaldateformat);
        $("#end-date").val(finaldateformat2);

    }
    //else if (criteria == "Next Year") {
    //    let d = new Date(), y = date.getFullYear(), m = date.getMonth();
    //    let firstDay = new Date(y+1, 0, 1)
    //    let lastDay = new Date(y, m + 11, 0);
    //    d.setDate(d.getDate());
    //    //let date = d.getDate();
    //    //let month = d.getMonth() + 1; // Since getMonth() returns month from 0-11 not 1-12
    //    //let year = d.getFullYear();

    //    let finaldateformat = firstDay.getDate() + "-" + months[firstDay.getMonth()] + "-" + firstDay.getFullYear();
    //    let finaldateformat2 = lastDay.getDate() + "-" + months[lastDay.getMonth()] + "-" + lastDay.getFullYear();
    //    //let finaldateformat2 = firstDay + "/" + lastDay + "/" + year;

    //    $("#start-date").val(finaldateformat);
    //    $("#end-date").val(finaldateformat2);
    //}

    else if (criteria == "Next Year") {
        let today = new Date();

        // Calculate the start date of "Next Year" (January 1 of the next year)
        let startDate = new Date(today.getFullYear() + 1, 0, 1);

        // Calculate the end date of "Next Year" (December 31 of the next year)
        let endDate = new Date(today.getFullYear() + 1, 11, 31);

        let finalStartDate = startDate.getDate() + "-" + months[startDate.getMonth()] + "-" + startDate.getFullYear();
        let finalEndDate = endDate.getDate() + "-" + months[endDate.getMonth()] + "-" + endDate.getFullYear();

        $("#start-date").val(finalStartDate);
        $("#end-date").val(finalEndDate);
    }

    //else if (criteria == "Last Year") {
    //    let d = new Date(), y = date.getFullYear(), m = date.getMonth();
    //    let firstDay = new Date(y-1, 0, 1)
    //    let lastDay = new Date(y-1, m + 11, 0);
    //    d.setDate(d.getDate());
    //    //let date = d.getDate();
    //    //let month = d.getMonth() + 1; // Since getMonth() returns month from 0-11 not 1-12
    //    //let year = d.getFullYear();

    //    let finaldateformat = firstDay.getDate() + "-" + months[firstDay.getMonth()] + "-" + firstDay.getFullYear();
    //    let finaldateformat2 = lastDay.getDate() + "-" + months[lastDay.getMonth()] + "-" + lastDay.getFullYear();
    //    //let finaldateformat2 = firstDay + "/" + lastDay + "/" + year;

    //    $("#start-date").val(finaldateformat);
    //    $("#end-date").val(finaldateformat2);
    //}

   else if (criteria == "Last Year") {
        let today = new Date();

        // Calculate the start date of "Last Year" (January 1 of the previous year)
        let startDate = new Date(today.getFullYear() - 1, 0, 1);

        // Calculate the end date of "Last Year" (December 31 of the previous year)
        let endDate = new Date(today.getFullYear() - 1, 11, 31);

        let finalStartDate = startDate.getDate() + "-" + months[startDate.getMonth()] + "-" + startDate.getFullYear();
        let finalEndDate = endDate.getDate() + "-" + months[endDate.getMonth()] + "-" + endDate.getFullYear();

        $("#start-date").val(finalStartDate);
        $("#end-date").val(finalEndDate);
    }

    else if (criteria == "Last Year-to-date") {
        let d = new Date(), y = date.getFullYear(), m = date.getMonth();
        let firstDay = new Date(y-1, 0, 1)
        let lastDay = new Date(y - 1, m + 11, 0);
        let currentdate = d;
        d.setDate(d.getDate());
        //let date = d.getDate();
        //let month = d.getMonth() + 1; // Since getMonth() returns month from 0-11 not 1-12
        //let year = d.getFullYear();

        let finaldateformat = firstDay.getDate() + "-" + months[firstDay.getMonth()] + "-" + firstDay.getFullYear();
        let finaldateformat2 = currentdate.getDate() + "-" + months[currentdate.getMonth()] + "-" + currentdate.getFullYear();
        //let finaldateformat2 = firstDay + "/" + lastDay + "/" + year;

        $("#start-date").val(finaldateformat);
        $("#end-date").val(finaldateformat2);
    }
    else if (criteria == "This Year-to-date") {
        let d = new Date(), y = date.getFullYear(), m = date.getMonth();
        let firstDay = new Date(y, 0, 1)
        let currentdate = d;
        d.setDate(d.getDate());
        //let date = d.getDate();
        //let month = d.getMonth() + 1; // Since getMonth() returns month from 0-11 not 1-12
        //let year = d.getFullYear();

        let finaldateformat = firstDay.getDate() + "-" + months[firstDay.getMonth()] + "-" + firstDay.getFullYear();
        let finaldateformat2 = currentdate.getDate() + "-" + months[currentdate.getMonth()] + "-" + currentdate.getFullYear();
        //let finaldateformat2 = firstDay + "/" + lastDay + "/" + year;

        $("#start-date").val(finaldateformat);
        $("#end-date").val(finaldateformat2);
    }
    else if (criteria == "This Year-to-last-month") {
        let d = new Date(), y = date.getFullYear(), m = date.getMonth() - 1;
        let firstDay = new Date(y, 0, 1);
        let lastDay = new Date(y, m + 1, 0);
        d.setDate(d.getDate());

        let finaldateformat = firstDay.getDate() + "-" + months[firstDay.getMonth()] + "-" + firstDay.getFullYear();
        let finaldateformat2 = lastDay.getDate() + "-" + months[lastDay.getMonth()] + "-" + lastDay.getFullYear();

        $("#start-date").val(finaldateformat);
        $("#end-date").val(finaldateformat2);
    }
    else if (criteria == "Recent") {
        let d = new Date(), y = date.getFullYear(), m = date.getMonth();
        let firstDay = new Date(y, m, 8)
        let currentdate = d;
        d.setDate(d.getDate());
        //let date = d.getDate();
        //let month = d.getMonth() + 1; // Since getMonth() returns month from 0-11 not 1-12
        //let year = d.getFullYear();

        let finaldateformat = firstDay.getDate() + "-" + months[firstDay.getMonth()] + "-" + firstDay.getFullYear();
        let finaldateformat2 = currentdate.getDate() + "-" + months[currentdate.getMonth()] + "-" + currentdate.getFullYear();
        //let finaldateformat2 = firstDay + "/" + lastDay + "/" + year;

        $("#start-date").val(finaldateformat);
        $("#end-date").val(finaldateformat2);
    }

    else if (criteria == "Last Month-to-date") {
        let d = new Date(), y = date.getFullYear(), m = date.getMonth() - 1;
        let firstDay = new Date(y, m, 1)
        let lastDay = new Date(y, m + 1, 0);
        let currentdate = d;
        d.setDate(d.getDate());

        let finaldateformat = firstDay.getDate() + "-" + months[firstDay.getMonth()] + "-" + firstDay.getFullYear();
        let finaldateformat2 = currentdate.getDate() + "-" + months[currentdate.getMonth()] + "-" + currentdate.getFullYear();

        $("#start-date").val(finaldateformat);
        $("#end-date").val(finaldateformat2);
    }


    else if (criteria == "Last Month") {
        let d = new Date(), y = date.getFullYear(), m = date.getMonth() - 1;
        let firstDay = new Date(y, m, 1)
        let lastDay = new Date(y, m + 1, 0);
        d.setDate(d.getDate());

        let finaldateformat = firstDay.getDate() + "-" + months[firstDay.getMonth()] + "-" + firstDay.getFullYear();
        let finaldateformat2 = lastDay.getDate() + "-" + months[lastDay.getMonth()] + "-" + lastDay.getFullYear();

        $("#start-date").val(finaldateformat);
        $("#end-date").val(finaldateformat2);
    }

    //else if (criteria == "Last Quarter") {
    //    let d = new Date(), y = date.getFullYear(), m = date.getMonth() - 1;
    //    let firstDay = new Date(y, m+7, 1)
    //    let lastDay = new Date(y, m + 11, 0);
    //    d.setDate(d.getDate());

    //    let finaldateformat = firstDay.getDate() + "-" + months[firstDay.getMonth()] + "-" + firstDay.getFullYear();
    //    let finaldateformat2 = lastDay.getDate() + "-" + months[lastDay.getMonth()] + "-" + lastDay.getFullYear();

    //    $("#start-date").val(finaldateformat);
    //    $("#end-date").val(finaldateformat2);
    //}

    else if (criteria == "Last Quarter") {
        let today = new Date();
        let currentMonth = today.getMonth(); // Get the current month (0 = January, 1 = February, ..., 11 = December)

        // Determine the end month of the last quarter
        let endMonth = Math.floor(currentMonth / 3) * 3 - 1;

        // Determine the start month of the last quarter
        let startMonth = endMonth - 2;

        // Adjust for the beginning of the year
        if (startMonth < 0) {
            startMonth = 0;
        }

        // Calculate the start date of "Last Quarter" (always the first day of the start month)
        let startDate = new Date(today.getFullYear(), startMonth, 1);

        // Calculate the end date of "Last Quarter" (always the last day of the end month)
        let endDate = new Date(today.getFullYear(), endMonth + 1, 0);

        let finalStartDate = startDate.getDate() + "-" + months[startDate.getMonth()] + "-" + startDate.getFullYear();
        let finalEndDate = endDate.getDate() + "-" + months[endDate.getMonth()] + "-" + endDate.getFullYear();

        $("#start-date").val(finalStartDate);
        $("#end-date").val(finalEndDate);
    }

    //else if (criteria == "Last Quarter-to-date") {
    //    let d = new Date(), y = date.getFullYear(), m = date.getMonth() - 1;
    //    let firstDay = new Date(y, m+7, 1)
    //    let lastDay = new Date(y, m + 11, 0);
    //    let currentdate = d;
    //    d.setDate(d.getDate());

    //    let finaldateformat = firstDay.getDate() + "-" + months[firstDay.getMonth()] + "-" + firstDay.getFullYear();
    //    let finaldateformat2 = currentdate.getDate() + "-" + months[currentdate.getMonth()] + "-" + currentdate.getFullYear();

    //    $("#start-date").val(finaldateformat);
    //    $("#end-date").val(finaldateformat2);
    //}

    if (criteria == "Last Quarter-to-date") {
        let today = new Date();
        let currentMonth = today.getMonth(); // Get the current month (0 = January, 1 = February, ..., 11 = December)

        // Determine the end month of the last quarter (e.g., for January, February, or March, the end month is December)
        let endMonth = currentMonth - 1; // Subtract 1 to go back one month

        // Determine the start month of the last quarter
        let startMonth = endMonth - 2; // Subtract 2 to go back three months from the end of the quarter

        // Check if we need to adjust for the beginning of the year
        if (startMonth < 0) {
            startMonth = 0; // If the calculated start month is negative, set it to January
        }

        // Calculate the start date of "Last Quarter-to-date" (always the first day of the start month)
        let startDate = new Date(today.getFullYear(), startMonth, 1);

        // Calculate the end date of "Last Quarter-to-date" (which is today)
        let finalEndDate = today.getDate() + "-" + months[today.getMonth()] + "-" + today.getFullYear();

        let finalStartDate = startDate.getDate() + "-" + months[startDate.getMonth()] + "-" + startDate.getFullYear();

        $("#start-date").val(finalStartDate);
        $("#end-date").val(finalEndDate);
    }

    else if (criteria == "Custom") {
        let d = new Date();
        let d2 = new Date();

        d.setDate(d.getDate() - 30);
        //var currentdate = new Date() ;
        let currentdate = d;
        let today = d2;
        let finaldateformat = currentdate.getDate() + "-" + months[currentdate.getMonth()] + "-" + currentdate.getFullYear(); //value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear();
        let finaldateformat2 = today.getDate() + "-" + months[today.getMonth()] + "-" + today.getFullYear(); //value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear();

        $("#start-date").val(finaldateformat);
        $("#end-date").val(finaldateformat2);
    }

}

$('#select2').change(function () {
    $('#start-date, #end-date').val('');
    $('#start-date, #end-date').removeAttr('disabled');

    var txt = $("#select2 option:selected").text();
    setDateRange(txt);
});

//its return daterange object

function GetDateRange(criteria) {
    var min = null, dateMin = min, dateMax = null, dayRange = 30;
    var months = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul",
        "Aug", "Sep", "Oct", "Nov", "Dec"];

    var dateRange = {}; 

    if (criteria == 'Today') {
        let d = new Date();
        let currentdate = d;

        let finaldateformat = currentdate.getDate() + "-" + months[currentdate.getMonth()] + "-" + currentdate.getFullYear();

        dateRange.startDate = finaldateformat;
        dateRange.endDate = finaldateformat;
    }
    else if (criteria == "Yesterday") {
        let d = new Date();
        d.setDate(d.getDate() - 1);
        let currentdate = d;
        let finaldateformat = currentdate.getDate() + "-" + months[currentdate.getMonth()] + "-" + currentdate.getFullYear();

        dateRange.startDate = finaldateformat;
        dateRange.endDate = finaldateformat;
    }

    if (criteria == "This Week") {
        let today = new Date();
        let currentDay = today.getDay();

        let daysToStartOfWeek = currentDay;
        let daysToEndOfWeek = 6 - currentDay;

        let startDate = new Date(today);
        startDate.setDate(today.getDate() - daysToStartOfWeek);

        let endDate = new Date(today);
        endDate.setDate(today.getDate() + daysToEndOfWeek);

        let finalStartDate = startDate.getDate() + "-" + months[startDate.getMonth()] + "-" + startDate.getFullYear();
        let finalEndDate = endDate.getDate() + "-" + months[endDate.getMonth()] + "-" + endDate.getFullYear();

        dateRange.startDate = finalStartDate;
        dateRange.endDate = finalEndDate;
    }
    if (criteria == "This Week") {
        let today = new Date();
        let currentDay = today.getDay(); 
        let daysToStartOfWeek = currentDay;
       let daysToEndOfWeek = 6 - currentDay;
       let startDate = new Date(today);
        startDate.setDate(today.getDate() - daysToStartOfWeek);
        let endDate = new Date(today);
        endDate.setDate(today.getDate() + daysToEndOfWeek);
        let finalStartDate = startDate.getDate() + "-" + months[startDate.getMonth()] + "-" + startDate.getFullYear();
        let finalEndDate = endDate.getDate() + "-" + months[endDate.getMonth()] + "-" + endDate.getFullYear();

        dateRange.startDate = finalStartDate;
        dateRange.endDate = finalEndDate;
    }
    else if (criteria == "This Week-to-date") {
        let today = new Date();
        let currentDay = today.getDay(); 
        let daysToStartOfWeek = currentDay;
        let startDate = new Date(today);
        startDate.setDate(today.getDate() - daysToStartOfWeek);
        let finalEndDate = today.getDate() + "-" + months[today.getMonth()] + "-" + today.getFullYear();
        let finalStartDate = startDate.getDate() + "-" + months[startDate.getMonth()] + "-" + startDate.getFullYear();

        dateRange.startDate = finalStartDate;
        dateRange.endDate = finalEndDate;
    }
    else if (criteria == "Next Week") {
        let today = new Date();
        let currentDay = today.getDay(); 
        let daysToNextWeek = 6 - currentDay + 1; 
        let daysToEndOfNextWeek = daysToNextWeek + 6;
        let startDate = new Date(today);
        startDate.setDate(today.getDate() + daysToNextWeek);
        let endDate = new Date(today);
        endDate.setDate(today.getDate() + daysToEndOfNextWeek);
        let finalStartDate = startDate.getDate() + "-" + months[startDate.getMonth()] + "-" + startDate.getFullYear();
        let finalEndDate = endDate.getDate() + "-" + months[endDate.getMonth()] + "-" + endDate.getFullYear();

        dateRange.startDate = finalStartDate;
        dateRange.endDate = finalEndDate;
    }
    else if (criteria == "Next 4 Weeks") {
        let today = new Date();
        let currentDay = today.getDay(); 
        let daysToNextWeekStart = 6 - currentDay + 1; 
        let daysToEndOfNext4Weeks = daysToNextWeekStart + 27;
        let startDate = new Date(today);
        startDate.setDate(today.getDate() + daysToNextWeekStart);
        let endDate = new Date(today);
        endDate.setDate(today.getDate() + daysToEndOfNext4Weeks);

        let finalStartDate = startDate.getDate() + "-" + months[startDate.getMonth()] + "-" + startDate.getFullYear();
        let finalEndDate = endDate.getDate() + "-" + months[endDate.getMonth()] + "-" + endDate.getFullYear();

        dateRange.startDate = finalStartDate;
        dateRange.endDate = finalEndDate;
    }
    else if (criteria == "Last Week") {
        let today = new Date();
        let currentDay = today.getDay(); 
          let daysToEndOfLastWeek = currentDay === 6 ? 0 : currentDay + 1; 
          let daysToStartOfLastWeek = daysToEndOfLastWeek + 6; 
        let startDate = new Date(today);
        startDate.setDate(today.getDate() - daysToStartOfLastWeek);
        let endDate = new Date(today);
        endDate.setDate(today.getDate() - daysToEndOfLastWeek);
        let finalStartDate = startDate.getDate() + "-" + months[startDate.getMonth()] + "-" + startDate.getFullYear();
        let finalEndDate = endDate.getDate() + "-" + months[endDate.getMonth()] + "-" + endDate.getFullYear();

        dateRange.startDate = finalStartDate;
        dateRange.endDate = finalEndDate;
    }
    else if (criteria == "Last Week-to-date") {
        let today = new Date();
        let currentDay = today.getDay(); 
        let daysToEndOfLastWeek = currentDay === 6 ? 0 : currentDay + 1;
         let daysToStartOfLastWeek = daysToEndOfLastWeek + 6;
        let startDate = new Date(today);
        startDate.setDate(today.getDate() - daysToStartOfLastWeek);
        let finalEndDate = today.getDate() + "-" + months[today.getMonth()] + "-" + today.getFullYear();
        let finalStartDate = startDate.getDate() + "-" + months[startDate.getMonth()] + "-" + startDate.getFullYear();

        dateRange.startDate = finalStartDate;
        dateRange.endDate = finalEndDate;
    }

    else if (criteria == "Since 30 days ago") {
        let d = new Date();
        let d2 = new Date();
        d.setDate(d.getDate() - 30);        
        let currentdate = d;
        let today = d2;
        let finalStartDate = currentdate.getDate() + "-" + months[currentdate.getMonth()] + "-" + currentdate.getFullYear(); //value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear();
        let finalEndDate = today.getDate() + "-" + months[today.getMonth()] + "-" + today.getFullYear(); //value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear();

        dateRange.startDate = finalStartDate;
        dateRange.endDate = finalEndDate;
    }
    else if (criteria == "Since 60 days ago") {
        let d = new Date();
        let d2 = new Date();
        d.setDate(d.getDate() - 60);
        let currentdate = d;
        let today = d2;
        let finaldateformat = currentdate.getDate() + "-" + months[currentdate.getMonth()] + "-" + currentdate.getFullYear(); //value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear();
        let finaldateformat2 = today.getDate() + "-" + months[today.getMonth()] + "-" + today.getFullYear(); //value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear();

        dateRange.startDate = finaldateformat;
        dateRange.endDate = finaldateformat2;
    }
    else if (criteria == "Since 90 days ago") {
        let d = new Date();
        let d2 = new Date();
        d.setDate(d.getDate() - 90);
        let currentdate = d;
        let today = d2;
        let finaldateformat = currentdate.getDate() + "-" + months[currentdate.getMonth()] + "-" + currentdate.getFullYear(); //value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear();
        let finaldateformat2 = today.getDate() + "-" + months[today.getMonth()] + "-" + today.getFullYear(); //value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear();

        dateRange.startDate = finaldateformat;
        dateRange.endDate = finaldateformat2;
    }
    else if (criteria == "Since 365 days ago") {
        let d = new Date();
        let d2 = new Date();
        d.setDate(d.getDate() - 365);        
        let currentdate = d;
        let today = d2;
        let finaldateformat = currentdate.getDate() + "-" + months[currentdate.getMonth()] + "-" + currentdate.getFullYear(); //value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear();
        let finaldateformat2 = today.getDate() + "-" + months[today.getMonth()] + "-" + today.getFullYear(); //value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear();

        dateRange.startDate = finaldateformat;
        dateRange.endDate = finaldateformat2;
    }
    else if (criteria == "This Month") {
        let d = new Date(), y = date.getFullYear(), m = date.getMonth();
        let firstDay = new Date(y, m, 1)
        let lastDay = new Date(y, m + 1, 0);
        d.setDate(d.getDate());
        let finaldateformat = firstDay.getDate() + "-" + months[firstDay.getMonth()] + "-" + firstDay.getFullYear();
        let finaldateformat2 = lastDay.getDate() + "-" + months[lastDay.getMonth()] + "-" + lastDay.getFullYear();
        dateRange.startDate = finaldateformat;
        dateRange.endDate = finaldateformat2;
    }
    else if (criteria == "Next Month") {
        let d = new Date(), y = date.getFullYear(), m = date.getMonth();
        let firstDay = new Date(y, m+1, 1)
        let lastDay = new Date(y, m + 2, 0);
        d.setDate(d.getDate());
        let finaldateformat = firstDay.getDate() + "-" + months[firstDay.getMonth()] + "-" + firstDay.getFullYear();
        let finaldateformat2 = lastDay.getDate() + "-" + months[lastDay.getMonth()] + "-" + lastDay.getFullYear();
       
        dateRange.startDate = finaldateformat;
        dateRange.endDate = finaldateformat2;
    }
    else if (criteria == "This Month-to-date") {
        let d = new Date(), y = date.getFullYear(), m = date.getMonth();
        let currentdate = d;
        let firstDay = new Date(y, m, 1)
        let lastDay = new Date(y, m + 1, 0);
        d.setDate(d.getDate());        
        let finaldateformat = firstDay.getDate() + "-" + months[firstDay.getMonth()] + "-" + firstDay.getFullYear();
        let finaldateformat2 = currentdate.getDate() + "-" + months[currentdate.getMonth()] + "-" + currentdate.getFullYear();
        dateRange.startDate = finaldateformat;
        dateRange.endDate = finaldateformat2;
    }
    
    else if (criteria == "This Quarter") {
        let today = new Date();
        let currentMonth = today.getMonth(); 
         let startMonth = currentMonth - (currentMonth % 3);
        let startDate = new Date(today.getFullYear(), startMonth, 1);
         let endMonth = startMonth + 2;
        let endDate = new Date(today.getFullYear(), endMonth + 1, 0);
        let finalStartDate = startDate.getDate() + "-" + months[startDate.getMonth()] + "-" + startDate.getFullYear();
        let finalEndDate = endDate.getDate() + "-" + months[endDate.getMonth()] + "-" + endDate.getFullYear();
        dateRange.startDate = finalStartDate;
        dateRange.endDate = finalEndDate;
    }
    else if (criteria == "Next Quarter") {
        let today = new Date();
        let currentMonth = today.getMonth(); 
        let startMonth = currentMonth + 1;
        if (startMonth > 11) {
            startMonth = 0; 
        }
        let startDate = new Date(today.getFullYear(), startMonth, 1);
        let endMonth = startMonth + 2;
        if (endMonth > 11) {
            endMonth = 11; 
        }
        let endDate = new Date(today.getFullYear(), endMonth + 1, 0);
        let finalStartDate = startDate.getDate() + "-" + months[startDate.getMonth()] + "-" + startDate.getFullYear();
        let finalEndDate = endDate.getDate() + "-" + months[endDate.getMonth()] + "-" + endDate.getFullYear();

        dateRange.startDate = finaldateformat;
        dateRange.endDate = finaldateformat2;
    }

    else if (criteria == "This Quarter-to-date") {
        let today = new Date();
        let currentMonth = today.getMonth(); 
        let startMonth = currentMonth - (currentMonth % 3);
        let startDate = new Date(today.getFullYear(), startMonth, 1);
        let finalEndDate = today.getDate() + "-" + months[today.getMonth()] + "-" + today.getFullYear();
        let finalStartDate = startDate.getDate() + "-" + months[startDate.getMonth()] + "-" + startDate.getFullYear();

        dateRange.startDate = finalStartDate;
        dateRange.endDate = finalEndDate;
    }

    else if (criteria == "This Year") {
        let d = new Date(), y = date.getFullYear(), m = date.getMonth();
        let firstDay = new Date(y, 0, 1);
        let lastDay = new Date(y, 11, 31); 
        d.setDate(d.getDate());

        let finaldateformat = firstDay.getDate() + "-" + months[firstDay.getMonth()] + "-" + firstDay.getFullYear();
        let finaldateformat2 = lastDay.getDate() + "-" + months[lastDay.getMonth()] + "-" + lastDay.getFullYear();

        dateRange.startDate = finaldateformat;
        dateRange.endDate = finaldateformat2;

    }
    else if (criteria == "All Dates") {
        let d = new Date(), y = date.getFullYear(), m = date.getMonth();
        let firstDay = new Date(y, 0, 1);
        let lastDay = new Date(y, 11, 31); 
        d.setDate(d.getDate());
        let finaldateformat = firstDay.getDate() + "-" + months[firstDay.getMonth()] + "-" + firstDay.getFullYear();
        let finaldateformat2 = lastDay.getDate() + "-" + months[lastDay.getMonth()] + "-" + lastDay.getFullYear();
        dateRange.startDate = finaldateformat;
        dateRange.endDate = finaldateformat2;

    }
    else if (criteria == "Next Year") {
        let today = new Date();
        let startDate = new Date(today.getFullYear() + 1, 0, 1);
        let endDate = new Date(today.getFullYear() + 1, 11, 31);
        let finalStartDate = startDate.getDate() + "-" + months[startDate.getMonth()] + "-" + startDate.getFullYear();
        let finalEndDate = endDate.getDate() + "-" + months[endDate.getMonth()] + "-" + endDate.getFullYear();
        dateRange.startDate = finalStartDate;
        dateRange.endDate = finalEndDate;
    }

   else if (criteria == "Last Year") {
        let today = new Date();
        let startDate = new Date(today.getFullYear() - 1, 0, 1);
        let endDate = new Date(today.getFullYear() - 1, 11, 31);
        let finalStartDate = startDate.getDate() + "-" + months[startDate.getMonth()] + "-" + startDate.getFullYear();
        let finalEndDate = endDate.getDate() + "-" + months[endDate.getMonth()] + "-" + endDate.getFullYear();
        dateRange.startDate = finalStartDate;
        dateRange.endDate = finalEndDate;
    }

    else if (criteria == "Last Year-to-date") {
        let d = new Date(), y = date.getFullYear(), m = date.getMonth();
        let firstDay = new Date(y-1, 0, 1)
        let lastDay = new Date(y - 1, m + 11, 0);
        let currentdate = d;
        d.setDate(d.getDate());
        let finaldateformat = firstDay.getDate() + "-" + months[firstDay.getMonth()] + "-" + firstDay.getFullYear();
        let finaldateformat2 = currentdate.getDate() + "-" + months[currentdate.getMonth()] + "-" + currentdate.getFullYear();
        dateRange.startDate = finaldateformat;
        dateRange.endDate = finaldateformat2;
    }
    else if (criteria == "This Year-to-date") {
        let d = new Date(), y = date.getFullYear(), m = date.getMonth();
        let firstDay = new Date(y, 0, 1)
        let currentdate = d;
        d.setDate(d.getDate());
        let finaldateformat = firstDay.getDate() + "-" + months[firstDay.getMonth()] + "-" + firstDay.getFullYear();
        let finaldateformat2 = currentdate.getDate() + "-" + months[currentdate.getMonth()] + "-" + currentdate.getFullYear();
        dateRange.startDate = finaldateformat;
        dateRange.endDate = finaldateformat2;
    }
    else if (criteria == "This Year-to-last-month") {
        let d = new Date(), y = date.getFullYear(), m = date.getMonth() - 1;
        let firstDay = new Date(y, 0, 1);
        let lastDay = new Date(y, m + 1, 0);
        d.setDate(d.getDate());

        let finaldateformat = firstDay.getDate() + "-" + months[firstDay.getMonth()] + "-" + firstDay.getFullYear();
        let finaldateformat2 = lastDay.getDate() + "-" + months[lastDay.getMonth()] + "-" + lastDay.getFullYear();

        dateRange.startDate = finaldateformat;
        dateRange.endDate = finaldateformat2;
    }
    else if (criteria == "Recent") {
        let d = new Date(), y = date.getFullYear(), m = date.getMonth();
        let firstDay = new Date(y, m, 8)
        let currentdate = d;
        d.setDate(d.getDate());
        let finaldateformat = firstDay.getDate() + "-" + months[firstDay.getMonth()] + "-" + firstDay.getFullYear();
        let finaldateformat2 = currentdate.getDate() + "-" + months[currentdate.getMonth()] + "-" + currentdate.getFullYear();
        dateRange.startDate = finaldateformat;
        dateRange.endDate = finaldateformat2;
    }

    else if (criteria == "Last Month-to-date") {
        let d = new Date(), y = date.getFullYear(), m = date.getMonth() - 1;
        let firstDay = new Date(y, m, 1)
        let lastDay = new Date(y, m + 1, 0);
        let currentdate = d;
        d.setDate(d.getDate());
        let finaldateformat = firstDay.getDate() + "-" + months[firstDay.getMonth()] + "-" + firstDay.getFullYear();
        let finaldateformat2 = currentdate.getDate() + "-" + months[currentdate.getMonth()] + "-" + currentdate.getFullYear();
        dateRange.startDate = finaldateformat;
        dateRange.endDate = finaldateformat2;
    }


    else if (criteria == "Last Month") {
        let d = new Date(), y = date.getFullYear(), m = date.getMonth() - 1;
        let firstDay = new Date(y, m, 1)
        let lastDay = new Date(y, m + 1, 0);
        d.setDate(d.getDate());

        let finaldateformat = firstDay.getDate() + "-" + months[firstDay.getMonth()] + "-" + firstDay.getFullYear();
        let finaldateformat2 = lastDay.getDate() + "-" + months[lastDay.getMonth()] + "-" + lastDay.getFullYear();

        dateRange.startDate = finaldateformat;
        dateRange.endDate = finaldateformat2;
    }

    else if (criteria == "Last Quarter") {
        let today = new Date();
        let currentMonth = today.getMonth(); 
        let endMonth = Math.floor(currentMonth / 3) * 3 - 1;
        let startMonth = endMonth - 2;
        if (startMonth < 0) {
            startMonth = 0;
        }
        let startDate = new Date(today.getFullYear(), startMonth, 1);
        let endDate = new Date(today.getFullYear(), endMonth + 1, 0);

        let finalStartDate = startDate.getDate() + "-" + months[startDate.getMonth()] + "-" + startDate.getFullYear();
        let finalEndDate = endDate.getDate() + "-" + months[endDate.getMonth()] + "-" + endDate.getFullYear();

        dateRange.startDate = finalStartDate;
        dateRange.endDate = finalEndDate;
    }
    if (criteria == "Last Quarter-to-date") {
        let today = new Date();
        let currentMonth = today.getMonth(); 
         let endMonth = currentMonth - 1; 
        let startMonth = endMonth - 2; 
        if (startMonth < 0) {
            startMonth = 0; 
        }
        let startDate = new Date(today.getFullYear(), startMonth, 1);
        let finalEndDate = today.getDate() + "-" + months[today.getMonth()] + "-" + today.getFullYear();
        let finalStartDate = startDate.getDate() + "-" + months[startDate.getMonth()] + "-" + startDate.getFullYear();

        dateRange.startDate = finalStartDate;
        dateRange.endDate = finalEndDate;
    }

    else if (criteria == "Custom") {
        let d = new Date();
        let d2 = new Date();
        d.setDate(d.getDate() - 30);
        let currentdate = d;
        let today = d2;
        let finaldateformat = currentdate.getDate() + "-" + months[currentdate.getMonth()] + "-" + currentdate.getFullYear(); //value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear();
        let finaldateformat2 = today.getDate() + "-" + months[today.getMonth()] + "-" + today.getFullYear(); //value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear();

        dateRange.startDate = finaldateformat;
        dateRange.endDate = finaldateformat2;
    }
    return dateRange;
}



