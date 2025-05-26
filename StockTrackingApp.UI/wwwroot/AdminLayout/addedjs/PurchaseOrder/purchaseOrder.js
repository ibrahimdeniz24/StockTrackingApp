$(document).ready(function () {
    // Dinamik olarak değişen inputlar için event bağlama (Create ve Update modalde çalışır)
    $(document).on("input", ".quantity, .unitPrice, .vatRate", function () {
        calculateTotal(this);
    });
});

// 🟢 Toplam hesaplayan fonksiyon (Create ve Update modalde çalışır)
function calculateTotal(input) {
    var row = $(input).closest("tr");

    // Input değerlerini al ve virgülü noktaya çevir
    var quantity = row.find(".quantity").val().trim().replace(",", ".");
    var unitPrice = row.find(".unitPrice").val().trim().replace(",", ".");
    var vatRate = row.find(".vatRate").val().trim().replace(",", ".");

    // Sayılara çevir (geçersizse 0 yap)
    quantity = isNaN(parseFloat(quantity)) ? 0 : parseFloat(quantity);
    unitPrice = isNaN(parseFloat(unitPrice)) ? 0 : parseFloat(unitPrice);
    vatRate = isNaN(parseFloat(vatRate)) ? 0 : parseFloat(vatRate);

    // Negatif değerleri engelle
    if (quantity < 0 || unitPrice < 0 || vatRate < 0) {
        alert("Geçersiz değerler! Miktar, birim fiyat ve KDV oranı sıfırdan küçük olamaz.");
        return;
    }

    // Toplam hesaplamalar
    var total = quantity * unitPrice;
    var vatAmount = total * vatRate / 100;
    var totalWithVat = total + vatAmount;

    // Değerleri Türkçe formatta yaz (noktayı tekrar virgüle çevir)
    row.find(".TotalPriceExcludingVAT").val(total.toFixed(2).replace(".", ","));
    row.find(".totalVat").val(vatAmount.toFixed(2).replace(".", ","));
    row.find(".totalPriceVat").val(totalWithVat.toFixed(2).replace(".", ","));

    // Sipariş toplamını güncelle
    updateTotalOrderAmount();
    updateTotalOrderAmount1();
}

// 🟢 Genel toplamları hesaplayan fonksiyon  create için
function updateTotalOrderAmount() {
    var totalExcludingAmount = 0;
    var totalVat = 0;
    var totalWithVat = 0;

    $(".TotalPriceExcludingVAT").each(function () {
        var amount = parseFloat($(this).val().replace(",", ".")) || 0;
        totalExcludingAmount += amount;
    });

    $(".totalPriceVat").each(function () {
        var amountWithVat = parseFloat($(this).val().replace(",", ".")) || 0;
        totalWithVat += amountWithVat;
    });

    totalVat = totalWithVat - totalExcludingAmount;

    // Değerleri ilgili input alanlarına yaz
    $("#TotalExcludingVATAmount").val(totalExcludingAmount.toFixed(2).replace(".", ","));
    $("#TotalVATAmount").val(totalVat.toFixed(2).replace(".", ","));
    $("#TotalAmount").val(totalWithVat.toFixed(2).replace(".", ","));
}

// 🟢 Genel toplamları hesaplayan fonksiyon  update için
function updateTotalOrderAmount1() {
    var totalExcludingAmount = 0;
    var totalVat = 0;
    var totalWithVat = 0;

    $(".TotalPriceExcludingVAT").each(function () {
        var amount = parseFloat($(this).val().replace(",", ".")) || 0;
        totalExcludingAmount += amount;
    });

    $(".totalPriceVat").each(function () {
        var amountWithVat = parseFloat($(this).val().replace(",", ".")) || 0;
        totalWithVat += amountWithVat;
    });

    totalVat = totalWithVat - totalExcludingAmount;

    // Değerleri ilgili input alanlarına yaz
    $("#update_TotalExcludingVATAmount").val(totalExcludingAmount.toFixed(2).replace(".", ","));
    $("#update_TotalVATAmount").val(totalVat.toFixed(2).replace(".", ","));
    $("#update_TotalAmount").val(totalWithVat.toFixed(2).replace(".", ","));
}

// 🟢 Sipariş detay satırları silindiğinde index'leri güncelleyen fonksiyon
function updateOrderDetailIndexes() {
    $("#orderDetailsBody tr, #updateOrderDetailsBody tr").each(function (index, row) {
        $(row).find("select, input").each(function () {
            var nameAttr = $(this).attr("name");
            if (nameAttr) {
                var newName = nameAttr.replace(/\[\d+\]/, `[${index}]`);
                $(this).attr("name", newName);
            }
        });

        // ID güncelleme
        var stockDropdown = $(row).find(".stockDropdown");
        stockDropdown.attr("id", `stockDropdown${index}`);
        initSelect2(index);
    });
}

// 🟢 Select2 başlatma fonksiyonu
function initSelect2(index) {
    $(`#stockDropdown${index}`).select2({
        placeholder: "Ürün seçiniz",
        allowClear: true
    });
}