function OpenModalCreate(){
    $('#createModal').modal('show');
}

function createCollaborator(){
    var collaborator = {
        Name: $('#name').val(),
        Email: $('#email').val(),
        Phone: $('#phone').val(),
        RoleId: $('#role').val()
    };

    $.ajax({
        url: '@Url.Page("/Collaborator", "Create")',
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