$(document).ready(function () {
    initCustomerDropdown1();
    initSelect21(0);
});

function initCustomerDropdown1() {
    $("#customerDropdown1").select2({
        placeholder: "Müşteri Ara...",
        allowClear: true,
        minimumInputLength: 1,
        dropdownParent: $("#customerDropdown1").parent(), // Modal içinde olduğu için eklendi
        ajax: {
            url: customerDropdownUrl, // Razor tarafında değişken olarak set edilmeli
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

function initSelect21(index) {
    $(`#stockDropdown1${index}`).select2({
        placeholder: "Stok Ara...",
        allowClear: true,
        minimumInputLength: 1,
        dropdownParent: $(`#stockDropdown1${index}`).parent(),
        ajax: {
            url: stockDropdownUrl, // Razor tarafında değişken olarak set edilmeli
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

function addOrderDetail1() {
    var index = $("#orderDetailsBody1 tr").length;
    var rowHtml = `
    <tr>
        <td>
            <select id="stockDropdown1${index}" name="AdminOrderDetailCreateVMs[${index}].StockId" class="form-control stockDropdown" required></select>
        </td>
        <td>
            <input name="AdminOrderDetailCreateVMs[${index}].Quantity" pattern="[0-9]+"  class="form-control quantity" min="1" oninput="calculateTotal(this)" required />
        </td>
        <td>
            <input name="AdminOrderDetailCreateVMs[${index}].UnitPrice" pattern="[0-9]+([,][0-9]+)?" step="0.01" class="form-control unitPrice" min="0" oninput="calculateTotal(this)" required />
        </td>
        <td>
            <input name="AdminOrderDetailCreateVMs[${index}].TotalPriceExcludingVAT"  step="0.01" class="form-control TotalPriceExcludingVAT" readonly />
        </td>
        <td>
            <select name="AdminOrderDetailCreateVMs[${index}].VatRate" class="form-control vatRate" required onchange="calculateTotal(this)">
                ${vatRatesHtml} <!-- Razor tarafında oluşturulmalı -->
            </select>
        </td>
        <td>
            <input name="AdminOrderDetailCreateVMs[${index}].TotalPriceIncludingVAT"  step="0.01" class="form-control totalVat" readonly />
        </td>
        <td>
            <input name="AdminOrderDetailCreateVMs[${index}].TotalPriceIncludingVAT"  step="0.01" class="form-control totalPriceVat" readonly />
        </td>
        <td>
            <button type="button" class="btn btn-danger" onclick="removeOrderDetail1(this)">Sil</button>
        </td>
    </tr>`;

    $("#orderDetailsBody1").append(rowHtml);
    initSelect21(index); // Yeni eklenen dropdown için Select2 başlat
    updateOrderDetailIndexes(); // Index'leri güncelle
}

function removeOrderDetail1(button) {
    $(button).closest("tr").remove();
    updateOrderDetailIndexes(); // Silme işleminden sonra index'leri güncelle
    updateTotalOrderAmount1(); // Toplam tutarı güncelle
}
