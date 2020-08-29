
function deleteCollaborator(e, elem, id) {
    e.preventDefault();
    deleteAction('./Collaborator', 'Collaborator/Delete', id);
}

function CreatePassword(e, id) {
    e.preventDefault();
    $.ajax(
        {
            url: 'Collaborator/CreatePassword',
            data: { id: id },
            type: "Get",
            success: (result) => {
                if (result.status) {
                    Swal.fire({
                        position: 'top-end',
                        icon: 'success',
                        title: 'Password successfuly generated!',
                        showConfirmButton: false,
                        timer: 1500
                    })
                }
            }
        })

}
