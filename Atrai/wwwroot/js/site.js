// Write your JavaScript code.

$(document).ready(function () {

    //(function () {
    //    "use strict";
    //    alert('hit');
    //    $("#detailsTable").on("change", "input", function () {
    //        var row = $(this).closest("tr");
    //        var qty = parseFloat(row.find(".quantity").val());
    //        var price = parseFloat(row.find(".price").val());
    //        var total = qty * price;
    //        row.find(".amount").val(isNaN(total) ? "" : total);
    //    });
    //})();








    $(function () {
        var idGen = new Generator();
        $('#Code').val(idGen.getId());

        //$('#Date').datepicker({
        //    format: 'mm/dd/yyyy'
        //});

        $('.mydatepicker').datepicker({
            dateFormat: 'dd-M-yy',
            todayHighlight: true,
            autoclose: true
        });



        var months = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
        var value = new Date();
        var ret = value.getDate() + "-" + months[value.getMonth()] + "-" + value.getFullYear(); //value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear();
        $("#Date").val(ret);


        //alert('found');
        //get suppliers
        $.ajax({
            type: "GET",
            url: "../Sales/GetCustomers",
            datatype: "Json",
            success: function (data) {

                //console.log(data);

                $.each(data, function (index, value) {

                    //console.log(value);
                    //console.log(value.Id);
                    //console.log(value.Name);

                    $('#Customer').append('<option value="' + value.Id + '">' + value.Name + '</option>');
                });
            }
        });

        //var availableTags = [
        //    "Australia",
        //    "Belgium",
        //    "Canada",
        //    "Denmark",
        //    "Ethiopia",
        //    "France",
        //    "Bangladesh"
        //];


        //var arr = [{
        //    val: 1,
        //    text: 'One'
        //}, {
        //    val: 2,
        //    text: 'Two'
        //}, {
        //    val: 3,
        //    text: 'Three'
        //}, {
        //    val: 4,
        //    text: 'Four'
        //}];

        $("#Search").autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: '../admin/ProductSearch/',
                    dataType: "json",
                    data: { query: $("#Search").val() },
                    success: function (data) {
                        console.log(data);
                        response($.map(data, function (item) {
                            return { ProductId: item.Id, description: item.Description, label: item.Name, Price: item.Price };
                        }));
                    },
                    error: function (xhr, status, error) {
                        alert("Error");
                    },
                });
            },
            minLength: 1,
            select: function (event, ui) {
                //console.log(ui.item);
                //var idGenrow = new Generator();
                //var rowid = idGenrow.getId();

                //alert(generateRandom());
                //var idGenrow = new generateRandom();
                //console.log(idGenrow);
                var rowid = generateRandom();

                //alert(ui.item.label);
                //alert();



                detailsTableBody = $("#detailsTable tbody");
                var productItem = '<tr> + <td class="d-none SalesItemId">' + 0 +
                    '</td><td class="d-none ProductId" id = \'PI' + rowid + '\'>' + ui.item.ProductId +
                    '</td><td>' + '<input class="name form-control"  id = \'N' + rowid + '\'      type= "text" value= "1"  />' +
                    '</td><td>' + '<input class="description form-control"  id = \'D' + rowid + '\' type= "text" value= "2" />' +
                    '</td><td style="min-width:80px;max-width:100px">' + '<input class="price text-center form-control" type= "text"  id = \'P' + rowid + '\'   value= "1"  />' +
                    '</td><td style="min-width:80px;max-width:100px">' + '<input class="quantity text-center form-control" type= "number"  id = \'Q' + rowid + '\' min= "1" step= "1" value= "1"  max="99" />' +
                    '</td><td style="min-width:80px;max-width:100px" class="amount" id = \'A' + rowid + '\' >' + ui.item.Price + '</td><td><a data-itemId="' + 0 + '" href="#" class="deleteItem"><i class="bi bi-trash"></i></a></td></tr>';
                detailsTableBody.append(productItem);

                $("#N" + rowid).val(ui.item.label);
                $("#D" + rowid).val(ui.item.description);
                $("#P" + rowid).val(ui.item.Price);

                //alert('found fahad');
                //$("#A" + rowid).html(ui.item.Price);



                $("#N" + rowid).autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: '../admin/ProductSearch/',
                            dataType: "json",
                            data: { query: $("#N" + rowid).val() },
                            success: function (data) {
                                //console.log(data);
                                response($.map(data, function (item) {
                                    return { ProductId: item.Id, Description: item.Description, label: item.Name, Price: item.Price };
                                }));
                            },
                            error: function (xhr, status, error) {
                                alert("Error");
                            },
                        });
                    },
                    minLength: 1,
                    select: function (event, uirow) {

                        //alert("#P" + rowid);
                        $("#PI" + rowid).html(uirow.item.ProductId);
                        $("#P" + rowid).val(uirow.item.Price);
                        $("#D" + rowid).val(uirow.item.Description);
                        var quantity = $("#Q" + rowid).val();

                        $("#A" + rowid).html(uirow.item.Price * quantity);
                        //$("#A" + rowid).html(uirow.item.Price);

                        calculateSum();
                        //return false;
                        //alert(uirow.item.ProductId);
                    }
                });

                //ui.item.description


                //var myTable = document.getElementById('detailsTable');
                //myTable.rows[myTable.length-1].cells[1].innerHTML = 'Hello';

                //$(productItem).closest('tr').children('td:eq(4)').text('abcdef'); 

                //var lastRow = $('#detailsTable tbody tr:last').html();
                //console.log(lastRow);
                //var row = table.insertRow(0);
                //var Description_cell = lastRow(4);
                //var cell2 = row.insertCell(1);
                //Description_cell.innerHTML = "NEW CELL1";



                //alert('you have selected ' + ui.item.label + ' ID: ' + ui.item.value);
                $('#Search').val("");
                calculateSum();


                //$("#detailsTable").DataTable();
                return false;
            }
        });
    });
    $(document).on('click', 'a.deleteItem', function (e) {
        e.preventDefault();
        var $self = $(this);
        $(this).parents('tr').css("background-color", "#1f306f").fadeOut(800, function () {
            $(this).remove();
            calculateSum();
        });
    });

    //$('#detailsTable').on('input', function (e) {
    //    alert('Changed!')
    //});

    $('#detailsTable').on('change', ".quantity , .price", update);

    function update() {

        var qty = parseFloat($(this).parents('tr').find(".quantity").val());
        var price = parseFloat($(this).parents('tr').find(".price").val());
        var amount = qty * price;
        $(this).parents('tr').find(".amount").text(amount);
        calculateSum();
        //$(".grandTotal").text('$' + calculateSum());

        //function calculateSum() {
        //    var sum = 0;
        //    $(".total_price").each(function () {
        //        var value = $(this).text().replace('$', '');
        //        if (!isNaN(value) && value.length != 0) {
        //            sum += parseFloat(value);
        //        }
        //    });
        //    return sum;
        //}
    }


    //$(document).on('change', '.quantity', function (e) {

    //    var id = $(this).attr('id');
    //    //alert(id);
    //    var quantity = $(id).val();
    //    alert(quantity);
    //    //var quantity = parseInt($(this).val());
    //    //var price = parseFloat($(this).closest('tr').children('td:eq(4)').text());

    //    var price = parseFloat($(this).closest('tr').children('td:eq(4)').val());

    //    var sum = quantity * price;
    //    $(this).closest('tr').children('td:eq(6)').text(sum.toFixed(2));
    //    calculateSum();

    //})

    //$(document).on('update', '.price', function (e) {
    //    alert('hit');
    //    var price = parseInt($(this).val());
    //    var quantity = parseFloat($(this).closest('tr').children('td:eq(5)').text());
    //    var sum = quantity * price;
    //    $(this).closest('tr').children('td:eq(6)').text(sum.toFixed(2));
    //    calculateSum();
    //})


    //save button click
    $("#BtnSave").click(function (e) {
        e.preventDefault();

        if (submitValidation()) {

            var discount;
            if (parseFloat($('#Discount').val()).toFixed(2) == "NaN") {
                discount = 0;
            }
            else {
                discount = $('#Discount').val();
            }



            var orderArr = [];
            orderArr.length = 0;

            $.each($("#detailsTable tbody tr"), function () {

                //alert($(this).find('td:eq(3)').html());
                //alert($(this).find('td:eq(3)').text());

                orderArr.push({

                    Id: $(this).find('td:eq(0)').html(),
                    ProductId: $(this).find('td:eq(1)').html(),

                    //Name: $(this).find('td:eq(2)').html(),
                    Name: $(this).find('.name').val(),
                    Description: $(this).find('.description').val(),
                    Price: $(this).find('.price').val(),

                    //Price: parseFloat($(this).find('td:eq(4)').html()),
                    Quantity: parseInt($(this).find('.quantity').val()),
                    Amount: parseFloat($(this).find('td:eq(6)').html())
                });
            });

            var data = JSON.stringify({
                CustomerId: $("#Customer").val(),
                SaleCode: $("#Code").val(),
                SalesDate: $("#Date").val(),
                PaymentMethod: $("#Payment").val(),
                Total: parseFloat($("#SubTotal").text()),
                Notes: $("#Notes").val(),
                Status: $("#Status").val(),
                Discount: discount,
                GrandTotal: parseFloat($('#GrandTotal').val()).toFixed(2),
                Items: orderArr
            });

            console.log(data);
            //alert('Wait');
            $.when(saveOrder(data)).then(function (response) {
                console.log(response);
                location.href = "../Sales/index";
            }).fail(function (err) {

            });
        }
    });


    $('#BtnUpdate').click(function (e) {
        e.preventDefault();

        if (submitValidation()) {



            var discount;
            if (parseFloat($('#Discount').val()).toFixed(2) == "NaN") {
                discount = 0;
            }
            else {
                discount = $('#Discount').val();
            }


            var orderArr = [];
            orderArr.length = 0;

            $.each($("#detailsTable tbody tr"), function () {
                orderArr.push({

                    Id: $(this).find('td:eq(0)').html(),
                    ProductId: $(this).find('td:eq(1)').html(),

                    //Name: $(this).find('td:eq(2)').html(),
                    Name: $(this).find('.name').val(),
                    Description: $(this).find('.description').val(),
                    Price: $(this).find('.price').val(),

                    //Price: parseFloat($(this).find('td:eq(4)').html()),
                    Quantity: parseInt($(this).find('.quantity').val()),
                    Amount: parseFloat($(this).find('td:eq(6)').html())

                    //Id: $(this).find('td:eq(0)').html(),
                    //ProductId: $(this).find('td:eq(1)').html(),

                    //Name: $(this).find('td:eq(2)').html(),
                    ////Description: $(this).find('td:eq(3)').html(),
                    //Description: $(this).find('.description').val(),

                    //Price: parseFloat($(this).find('td:eq(4)').html()),
                    //Quantity: parseInt($(this).find('.quantity').val()),
                    //Amount: parseFloat($(this).find('td:eq(6)').html())
                });
            });

            var data = {
                Id: parseInt($("#BtnUpdate").attr("data-sale-Id")),
                CustomerId: parseInt($("#Customer").val()),
                SaleCode: $("#Code").val(),
                SalesDate: $("#Date").val(),
                PaymentMethod: $("#Payment").val(),
                Total: parseFloat($("#SubTotal").text()),
                Notes: $("#Notes").val(),
                Status: $("#Status").val(),
                Discount: discount,//parseFloat($('#Discount').val()).toFixed(2),
                GrandTotal: parseFloat($('#GrandTotal').val()).toFixed(2),
                Items: orderArr
            };

            console.log(data);
            $.when(updateOrder(data)).then(function (response) {
                console.log(response);
                location.href = "../Sales/index";
            }).fail(function (err) {
                console.log(err);
            });
        }

    });


    ////total calculation
    function calculateSum() {
        var sum = 0;
        // iterate through each td based on class and add the values
        $(".amount").each(function () {

            var value = $(this).text();
            // add only if the value is number
            if (!isNaN(value) && value.length !== 0) {
                sum += parseFloat(value);
            }
        });

        if (sum == 0.0) {
            $('#Discount').text("0");
            $('#GrandTotal').text("0");
        }
        //console.log(sum);
        $('#SubTotal').text(sum.toFixed(2));
        $('#GrandTotal').val(sum.toFixed(2));

        var b = parseFloat($('#Discount').val()).toFixed(2);
        if (isNaN(b)) return;
        var a = parseFloat($('#SubTotal').text()).toFixed(2);
        var c = parseFloat(a - b).toFixed(2);
        $('#GrandTotal').val(c);
    };
    $('.amount').each(function () {
        calculateSum();
    });

});

//function submitValidation() {

//    var customer = document.getElementById("Customer").value;
//    var code = document.getElementById("Code").value;
//    var date = document.getElementById("Date").value;
//    var paymentmethod = document.getElementById("Payment").value;
//    var pStaus = document.getElementById("Status").value;
//    var total = parseFloat($("#SubTotal").text());
//    var gtotal = parseFloat($("#GrandTotal").val());

//    if (customer == "" || pStaus == "" || code == "" || date == "" || paymentmethod == "" || (total == "" || total == 0.00 || isNaN(total)) || (gtotal == "" || gtotal == 0.00 || isNaN(gtotal))) {

//        if (pStaus == "") {
//            document.getElementById("error_Status").style.display = "block";
//        }
//        else {
//            document.getElementById("error_Status").style.display = "none";
//        }

//        if (customer == "") {
//            document.getElementById("error_Customer").style.display = "block";
//        }
//        else {
//            document.getElementById("error_Customer").style.display = "none";
//        }
//        if (code == "") {
//            document.getElementById("error_Code").style.display = "block";
//        }
//        else {
//            document.getElementById("error_Code").style.display = "none";
//        }
//        if (date == "") {
//            document.getElementById("error_Date").style.display = "block";
//        }
//        else {
//            document.getElementById("error_Date").style.display = "none";
//        }
//        if (paymentmethod == "") {
//            document.getElementById("error_Payment").style.display = "block";
//        }
//        else {
//            document.getElementById("error_Payment").style.display = "none";
//        }
//        if (total == "" || total === 0.00 || isNaN(total)) {
//            document.getElementById("error_SubTotal").style.display = "block";
//        }
//        else {
//            document.getElementById("error_SubTotal").style.display = "none";
//        }
//        if (gtotal == "" || gtotal === 0.00 || isNaN(gtotal)) {
//            document.getElementById("error_GrandTotal").style.display = "block";
//        }
//        else {
//            document.getElementById("error_GrandTotal").style.display = "none";
//        }

//        return false;
//    }
//    else {
//        return true;
//    }


//}
function blankme(id) {

    var val = document.getElementById(id).value;
    var error_id = "error_" + id;

    if (val == "" || val === 0.00) {

        document.getElementById(error_id).style.display = "block";
    }
    else {
        document.getElementById(error_id).style.display = "none";
    }
}
function DiscountAmount() {
    //blankme("Discount");
    //blankme("GrandTotal");
    var b = parseFloat($('#Discount').val()).toFixed(2);
    if (isNaN(b)) return;
    var a = parseFloat($('#SubTotal').text()).toFixed(2);
    var c = parseFloat(a - b).toFixed(2);
    $('#GrandTotal').val(c);
}
function saveOrder(data) {

    //alert('Fahad found sales');
    //console.log(data);
    return $.ajax({
        contentType: 'application/json; charset=utf-8',
        //contentType: "application/json",
        dataType: 'json',
        type: 'POST',
        url: "../Sales/AddSale",
        data: data
    });
}
function updateOrder(data) {
    return $.ajax({
        dataType: 'json',
        type: 'POST',
        url: "../Sales/EditSale",
        data: data
    });
}
function Generator() { };
Generator.prototype.rand = Math.floor(Math.random() * 26) + Date.now();
Generator.prototype.getId = function () {
    return this.rand++;
};
function generateRandom() {
    const randomNum = 100000 + Math.random() * 100000;
    return Math.round(randomNum / 10) * 10;
}
