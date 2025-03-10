$(document).ready(function () {
    // Category Dropdown
    $("#categoryDropdown").select2({
        placeholder: "Kategori Ara...",
        allowClear: true,
        minimumInputLength: 1,
        dropdownParent: $("#categoryDropdown").parent(), // Modal içinde olduğu için ekledik
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
