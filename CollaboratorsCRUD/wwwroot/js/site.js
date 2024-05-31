function OpenModalCreate(){
    $('#createModal').modal('show');
}

function deleteItem(id) {
    if (confirm('Are you sure you want to delete this item?')) {
        debugger;
        fetch('Collaborator?handler=Delete&id=' + id, {
            method: 'POST',
            headers: {
                'RequestVerificationToken': document.getElementsByName('__RequestVerificationToken')[0].value
            }
        })
        .then(response => {
            if (response.ok) {
                alert('Item deleted successfully.');
                window.location.reload();
            } else {
                alert('Failed to delete item.');
            }
        });
    }
    window.location.reload();
}

function createCollaborator(){
    var collaborator = {
        Name: $('#name').val(),
        Email: $('#email').val(),
        Phone: $('#phone').val(),
        RoleId: $('#role').val()
    };

    $.ajax({
        url: '/Collaborator',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(collaborator),
        success: function (result) {
            if (result.success) {
                $('#createModal').modal('hide');
                location.reload();
            } else {
                alert('Error saving collaborator');
            }
        },
        error: function (xhr, status, error) {
            alert('Error: ' + error);
        }
    });
}