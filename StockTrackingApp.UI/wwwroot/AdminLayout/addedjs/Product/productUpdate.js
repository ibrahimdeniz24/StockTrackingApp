$(document).ready(function () {
    $('#updateProductModal').on('show.bs.modal', function (event) {
        let button = $(event.relatedTarget);
        let itemId = button.data('item-id');
        let itemName = button.data('item-name');
        let itemSku = button.data('item-sku');
        let selectedCategoryId = button.data('category-id'); // Seçili kategori id'si

        let modal = $(this);
        modal.find('input[name="Id"]').val(itemId);
        modal.find('input[name="Name"]').val(itemName);
        modal.find('input[name="SKU"]').val(itemSku);

        // Select2 için seçili kategoriyi set et
        modal.find('select[name="CategoryId"]').val(selectedCategoryId).trigger('change');  // Select2 ile trigger et
    });


    // Category Dropdown
    $("#categoryDropdown1").select2({
        placeholder: "Kategori Ara...",
        allowClear: true,
        minimumInputLength: 1,
        dropdownParent: $("#categoryDropdown1").parent(), // Modal içinde olduğu için ekledik
        ajax: {
            url: categoryUrl, // URL, Index.cshtml'den gelecek
            dataType: "json",
            delay: 250,
            data: function (params) {
                return { term: params.term };
            },
            processResults: function (data) {
                return {
                    results: $.map(data, function (item) {
                        return { id: item.id, text: item.text };
                    })
                };
            },
            cache: true
        }
    });
});

