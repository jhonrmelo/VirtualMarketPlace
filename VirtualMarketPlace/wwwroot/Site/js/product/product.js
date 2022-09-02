Dropzone.autoDiscover = false;


$(document).ready(() => {
    let dropzoneDiv = $("div#dropzoneUpload");
    dropzoneDiv.dropzone({
        url: "./Image/Store",
        uploadMultiple: true,
        maxFilesize: 5,
        clickable: false,
        addedfile: (file) => {
            console.log(file);
            $("#images").append(`<img data-dz-thumbnail src=${file.dataURL}> </img>`)
        }
    });
});


function deleteProduct(id) {
    event.preventDefault();
    deleteAction('./Product', 'Product/Delete', id);
}


const UploadImage = () => {

}