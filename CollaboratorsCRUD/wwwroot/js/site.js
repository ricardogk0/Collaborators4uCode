function OpenModalCreate(){
    $('#createModal').modal('show');
}

function deleteItem(id) {
    if (confirm('Are you sure you want to delete this item?')) {
        fetch('Collaborator?handler=Delete&id=' + id, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'RequestVerificationToken': document.getElementsByName('__RequestVerificationToken')[0].value
            }
        })
        .then(response => {
            console.log('Response status:', response.status);
            if (response.ok) {
                alert('Item deleted successfully.');
                setTimeout(() => { window.location.reload(); }, 500);
            } else {
                alert('Failed to delete item.');
            }
        });
    }
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