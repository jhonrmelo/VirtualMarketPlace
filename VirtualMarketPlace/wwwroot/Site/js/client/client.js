function changeStatus(id, elem) {
    let name = $(elem).data('name');

    Swal.fire({
        title: 'Are you sure?',
        text: `You are changing the client ${name} status!`,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, change it!'
    }).then((result) => {
        if (result.value) {
            $.ajax({
                url: 'Client/ChangeClientStatus',
                data: { id: id },
                type: "GET",
                success: (response) => {
                    if (response.status) {
                        window.location.href = './Client'
                    }
                    else {
                        const swalWithBootstrapButtons = Swal.mixin({
                            customClass: {
                                confirmButton: 'btn btn-success',
                                cancelButton: 'btn btn-danger'
                            },
                            buttonsStyling: false
                        })


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
