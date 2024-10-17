$(document).ready(function() {
        $('#myTable').DataTable();
        $(document).ready(function() {
            var table = $('#example').DataTable({
                "columnDefs": [{
                    "visible": false,
                    "targets": 2
                }],
                "order": [
                    [2, 'asc']
                ],
                "displayLength": 25,
                "drawCallback": function(settings) {
                    var api = this.api();
                    var rows = api.rows({
                        page: 'current'
                    }).nodes();
                    var last = null;
                    api.column(2, {
                        page: 'current'
                    }).data().each(function(group, i) {
                        if (last !== group) {
                            $(rows).eq(i).before('<tr class="group"><td colspan="5">' + group + '</td></tr>');
                            last = group;
                        }
                    });
                }
            });
            // Order by the grouping
            $('#example tbody').on('click', 'tr.group', function() {
                var currentOrder = table.order()[0];
                if (currentOrder[0] === 2 && currentOrder[1] === 'asc') {
                    table.order([2, 'desc']).draw();
                } else {
                    table.order([2, 'asc']).draw();
                }
            });
        });
    });
$('#example23').DataTable({
    dom: 'Bflrtip',
    "columnDefs": [
        {
            visible: false,
            "targets": [0],
           /* className: 'select-checkbox',*/

        }

    ],
    "language": {
        "lengthMenu": "_MENU_",
        search: '<i class="bi bi-search" aria-hidden="true"></i>',
        searchPlaceholder: 'Search',
        //"paginate": {
        //    "previous": '<i class="bi bi-chevron-left"></i>',
        //    "next": '<i class="bi bi-chevron-right"></i>'
        //}

    },
    //dom: 'Bfrtip',
    //buttons: ['copy', 'excel', 'pdf', 'print'],
    buttons: [
   
  
        {
            targets: 1,
            extend: 'colvis',
            collectionLayout: 'fixed columns',
            collectionTitle: 'Column visibility control',
          
        },
        {
            extend: 'csv',
            split: ['pdf', 'excel'],
        }
   
    ],

    rowReorder: {
        selector: 'td:nth-child(4)'
    },
    responsive: true
});


