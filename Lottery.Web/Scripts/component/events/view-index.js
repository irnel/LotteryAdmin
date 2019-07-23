$(document).ready(function () {
    // Table all events settings
    $('#all_events').DataTable({
        createdRow: function (row, data, index) {
            if (data[5] == 'Closed') {
                $('td', row).eq(5).addClass('red-text');
            } else if (data[5] == 'In progress') {
                $('td', row).eq(5).addClass('purple-text');
            } else {
                $('td', row).eq(5).addClass('orange-text');
            }
        }
    });

    // Table available events settings
    $('#available_events').DataTable();

    // Table in progress events settings
    $('#in_progress_events').DataTable();

    // Table closed events settings
    $('#closed_events').DataTable();
});
