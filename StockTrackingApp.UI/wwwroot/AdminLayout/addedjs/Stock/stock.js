$(document).ready(function () {
    // Genel bir Select2 fonksiyonu oluşturduk
    function initializeSelect2(selector, url) {
        $(selector).select2({
            placeholder: $(selector).attr("data-placeholder"), // HTML içinde placeholder belirtebiliriz
            allowClear: true,
            minimumInputLength: 1,
            dropdownParent: $(selector).parent(), // Modal içinde olduğu için parent belirtiyoruz
            ajax: {
                url: url, // Dışarıdan gelen URL
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
                }
            }
        });
    }

    // Dropdownları başlat
    initializeSelect2("#productDropdown", productUrl);
    initializeSelect2("#supplierDropdown", supplierUrl);
    initializeSelect2("#productDropdown1", productUrl);
    initializeSelect2("#supplierDropdown1", supplierUrl);
});
