
function deleteCategory( id) {
    event.preventDefault();
    deleteAction('./Category', 'Category/Delete', id);
}
