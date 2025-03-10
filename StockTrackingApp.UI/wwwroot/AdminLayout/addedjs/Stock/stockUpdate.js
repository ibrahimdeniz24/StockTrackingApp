$(document).ready(function () {
    $('#stockUpdateModal').on('show.bs.modal', function (event) {
        let button = $(event.relatedTarget);
        let itemId = button.data('item-id');  // Seçilen item ID'si
        console.log('Selected Item ID:', itemId); // ID'yi kontrol et

        let modal = $(this);
        modal.find('input[name="Id"]').val(itemId); // Id'yi input'a yerleştir

        // Ürün bilgilerini AJAX ile al ve Select2'yi güncelle
        $.ajax({
            url: "/Admin/Stock/GetProductById",  // Ürünü ID ile alacağımız URL
            method: "GET",
            data: { id: itemId },
            success: function (data) {
                console.log('Received Data:', data); // Geri dönen veriyi kontrol et
                if (data) {
                    // Select2'ye ürün verisini yerleştir
                    $('#productDropdown').val(data.id).trigger('change'); // ID ile seçili yap

                    // Ekstra olarak Select2'i refresh yap
                    $('#productDropdown').select2('data', { id: data.id, text: data.text });
                    $('#productDropdown').trigger('change');
                }
            },
            error: function (xhr, status, error) {
                console.log('AJAX Error:', error); // Hata kontrolü
            }
        });
    });
});

$(document).ready(function () {
    $('#stockUpdateModal').on('show.bs.modal', function () {
        $.getJSON(warehouseUrl, function (data) {
            var dropdown = $('#warehouseDropdown1');
            dropdown.empty();
            dropdown.append('<option value="">Depo Seçin</option>');

            // Eğer JSON'daki "name" property yerine başka bir isim kullanılmışsa, burayı güncelle!
            $.each(data, function (index, supplier) {
                dropdown.append($('<option></option>').attr('value', supplier.id).text(supplier.name));
            });
        });
    });
});
