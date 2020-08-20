
function deleteCategory(e, elem, id) {
    e.preventDefault();
    bootbox.confirm({
        title: `Delete Collaborator ${elem.dataset.name}?`,
        message: "Do you want to remove this collaborator?",
        buttons: {
            cancel: {
                label: '<i class="fa fa-times"></i> Cancel'
            },
            confirm: {
                label: '<i class="fa fa-check"></i> Confirm',
                className: 'btn btn-danger'
            }
        },
        callback: function (result) {
            if (result) {
                $.ajax({
                    url: 'Collaborator/Delete',
                    data: { id: id },
                    type: "GET",
                    success: (result) => {
                        if (result.status) {
                            window.location.href = './Collaborator';
                        }
                    }
                })
            }
        }
    });
}
