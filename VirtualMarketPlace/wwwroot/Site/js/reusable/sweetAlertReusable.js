function deleteAction(urlCallback, urlAction, id) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.value) {
            $.ajax({
                url: urlAction,
                data: { id: id },
                type: "GET",
                success: (result) => {
                    if (result.status) {
                        window.location.href = urlCallback;
                    }
                    else {
                        swalWithBootstrapButtons.fire(
                            'Error',
                            'We are having problems to complete your action',
                            'error'
                        )
                    }
                }
            })
        }
    })
}