
$('#startDate, #endDate').datepicker({
    beforeShow: setDateRange,
    dateFormat: "mm/dd/yy",
    firstDay: 1,
    changeFirstDay: false,
    onChange: function () { $(this).valid(); },
    onSelect: function () {
        if (this.id == 'startDate') {
            // If selected start date is later than currently selected
            // end date, set end date to start date + 1 day
            var date = $('#startDate').datepicker('getDate');
            if (date) { date.setDate(date.getDate() + 1); }
            $('#endDate').datepicker('option', 'minDate', date);
        }
    }
});

function setDateRange(criteria) {
    debugger
    var min = null, dateMin = min, dateMax = null, dayRange = 30;
    var opt = $('#select1'), start = $('#startDate'), end = $('#endDate'); //
    var months = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul",
        "Aug", "Sep", "Oct", "Nov", "Dec"];

    if (criteria == 'Today') {
        let d = new Date();
        let currentdate = d;

        let finaldateformat = currentdate.getDate() + "-" + months[currentdate.getMonth()] + "-" + currentdate.getFullYear(); //value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear();

        $("#startDate").val(finaldateformat);
        $("#endDate").val(finaldateformat);

    }
    else if (criteria == "Yesterday") {
        let d = new Date();
        d.setDate(d.getDate() - 1);
        //var currentdate = new Date() ;
        let currentdate = d;
        let finaldateformat = currentdate.getDate() + "-" + months[currentdate.getMonth()] + "-" + currentdate.getFullYear(); //value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear();

        $("#startDate").val(finaldateformat);
        $("#endDate").val(finaldateformat);
    }
    else if (criteria == "Last 7 days") {
        let d = new Date();
        let d2 = new Date();

        d.setDate(d.getDate() - 7);
        //var currentdate = new Date() ;
        let currentdate = d;
        let today = d2;
        let finaldateformat = currentdate.getDate() + "-" + months[currentdate.getMonth()] + "-" + currentdate.getFullYear(); //value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear();
        let finaldateformat2 = today.getDate() + "-" + months[today.getMonth()] + "-" + today.getFullYear(); //value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear();

        $("#startDate").val(finaldateformat);
        $("#endDate").val(finaldateformat2);
    }
    else if (criteria == "Last 30 Days") {
        let d = new Date();
        let d2 = new Date();

        d.setDate(d.getDate() - 30);
        //var currentdate = new Date() ;
        let currentdate = d;
        let today = d2;
        let finaldateformat = currentdate.getDate() + "-" + months[currentdate.getMonth()] + "-" + currentdate.getFullYear(); //value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear();
        let finaldateformat2 = today.getDate() + "-" + months[today.getMonth()] + "-" + today.getFullYear(); //value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear();

        $("#startDate").val(finaldateformat);
        $("#endDate").val(finaldateformat2);
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

        $("#startDate").val(finaldateformat);
        $("#endDate").val(finaldateformat2);
    }

    else if (criteria == "Last Month") {
        let d = new Date(), y = date.getFullYear(), m = date.getMonth() - 1;
        let firstDay = new Date(y, m, 1)
        let lastDay = new Date(y, m + 1, 0);
        d.setDate(d.getDate());

        let finaldateformat = firstDay.getDate() + "-" + months[firstDay.getMonth()] + "-" + firstDay.getFullYear();
        let finaldateformat2 = lastDay.getDate() + "-" + months[lastDay.getMonth()] + "-" + lastDay.getFullYear();

        $("#startDate").val(finaldateformat);
        $("#endDate").val(finaldateformat2);
    }
    else if (criteria == "Custom Date") {
        let d = new Date();
        let d2 = new Date();

        d.setDate(d.getDate() - 30);
        //var currentdate = new Date() ;
        let currentdate = d;
        let today = d2;
        let finaldateformat = currentdate.getDate() + "-" + months[currentdate.getMonth()] + "-" + currentdate.getFullYear(); //value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear();
        let finaldateformat2 = today.getDate() + "-" + months[today.getMonth()] + "-" + today.getFullYear(); //value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear();

        $("#startDate").val(finaldateformat);
        $("#endDate").val(finaldateformat2);
    }

}

$('#select1').change(function () {
    $('#startDate, #endDate').val('');
    $('#startDate, #endDate').removeAttr('disabled');

    var txt = $("#select1 option:selected").text();
    debugger
    setDateRange(txt);
});




