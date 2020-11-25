
function deleteProduct(id) {
    event.preventDefault();
    deleteAction('./Product', 'Product/Delete', id);
}
