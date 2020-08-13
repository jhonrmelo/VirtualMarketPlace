
function deleteCategory(e, id) {
    e.preventDefault();
    bootbox.confirm({
        title: "Delete Category?",
        message: "Do you want to remove this category?",
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
                    url: 'Category/Delete',
                    data: { id: id },
                    type: "GET",
                    success: (result) => {
                        if (result.status) {
                            window.location.href = './Category';
                        }
                    }
                })
            }
        }
    });
}
