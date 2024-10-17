$(function () {
    "use strict";


    //$(document).ready(function () {
    //    $('#myTable').DataTable();
    //    $(document).ready(function () {
    //        var table = $('#example').DataTable({
    //            "columnDefs": [{
    //                "visible": false,
    //                "targets": 2
    //            }],
    //            "order": [
    //                [2, 'asc']
    //            ],
    //            "displayLength": 25,
    //            "drawCallback": function (settings) {
    //                var api = this.api();
    //                var rows = api.rows({
    //                    page: 'current'
    //                }).nodes();
    //                var last = null;
    //                api.column(2, {
    //                    page: 'current'
    //                }).data().each(function (group, i) {
    //                    if (last !== group) {
    //                        $(rows).eq(i).before('<tr class="group"><td colspan="5">' + group + '</td></tr>');
    //                        last = group;
    //                    }
    //                });
    //            }
    //        });
    //        // Order by the grouping
    //        $('#example tbody').on('click', 'tr.group', function () {
    //            var currentOrder = table.order()[0];
    //            if (currentOrder[0] === 2 && currentOrder[1] === 'asc') {
    //                table.order([2, 'desc']).draw();
    //            } else {
    //                table.order([2, 'asc']).draw();
    //            }
    //        });
    //    });
    //});

    var table= $('#example23').DataTable({
        dom: 'fBlrtip',

        "language": {
            "lengthMenu": "_MENU_",
            search: '<i class="bi bi-search" aria-hidden="true"></i>',
            searchPlaceholder: 'Search',
            "paginate": {
                "previous": '<i class="bi bi-chevron-double-left" style="font-size:12px;"></i>',
                "next": '<i class="bi bi-chevron-double-right" style="font-size:12px;"></i>'
            }

        },
 
        //dom: 'Bfrtip',
        //buttons: ['copy', 'excel', 'pdf', 'print'],
        buttons: [


            {
                targets: 1,
                extend: 'colvis',
                collectionLayout: 'fixed columns',
                collectionTitle: 'Column visibility control',
                className: 'rounded-0 btn-light',
                text: '<i class="bi bi-gear"></i>'

            },
            //{
            //    extend: 'pdf',
            //   // split: ['csv', 'excel'],
            //    text: '<i class="bi bi-file-earmark-pdf-fill"></i>',
            //    className: 'btn-warning rounded-0'
            //},
            {
                extend: 'excel',
                text:'<i class="bi bi-file-earmark-excel-fill"></i>',
                //split: ['pdf', 'excel'],             
                className: 'btn-success btn-sm  rounded'
            }
        

        ],
        "columnDefs": [
            {
                visible: true,
                "targets": [0],
               

            }

        ],
        rowReorder: {
            selector: 'td:nth-child(4)'
        },
        responsive: true
    });


    //table.buttons().container()
    //    .appendTo('#example23_wrapper.col-md-6:eq(0)');


});