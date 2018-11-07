$(function () {

    var field = $("#field");

    field.on('input', function () {
        fieldValue = $(this).val();


        if (fieldValue > 0 && fieldValue < 11) {
            return fieldValue;
        }

        else {
            field.val(""), alert("Enter a number between 1 and 10")
        };

    });

    $("#buttonAdd").on('click', function () {
        numberOfRowsToAdd = fieldValue;
        var confirmationAdd = confirm(numberOfRowsToAdd + " rows will be added");
        if (confirmationAdd === true) {

            for (var i = 0; i < numberOfRowsToAdd; i++) 
            {
                $('<tr> <td>example</td> <td>example</td> <td>example</td> </tr>').appendTo($("tbody"));
            }
        }
        else {
            return;
        }
    });

    $("#buttonRemove").on('click', function () {
        numberOfRowsToRemove = fieldValue;
        var confirmationRemove = confirm(numberOfRowsToRemove + " rows will be removed")
        if (confirmationRemove === true) {

            for (var i = 0; i < numberOfRowsToRemove; i++) 
            {
                $('#table tr:last').remove();
            }
        }
        else {
            return;
        }
    });

    $('#checkbox').change(function () {
        $('#table').toggle(!this.checked);
    }).change();



});



