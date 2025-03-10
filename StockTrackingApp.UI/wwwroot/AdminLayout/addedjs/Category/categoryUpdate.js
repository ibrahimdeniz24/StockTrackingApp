$(document).ready(function () {
    $('#updateCategoryModal').on('show.bs.modal', function (event) {
        let button = $(event.relatedTarget);
        let itemId = button.data('item-id');
        let itemName = button.data('item-name');
        let description = button.data('item-desc');

        let modal = $(this);
        modal.find('input[name="Id"]').val(itemId);
        modal.find('input[name="CategoryName"]').val(itemName);
        modal.find('textarea[name="Description"]').val(description);
    });
});
