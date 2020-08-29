
function deleteCategory(e, id) {
    e.preventDefault();
    deleteAction('./Category', 'Category/Delete', id);
}
