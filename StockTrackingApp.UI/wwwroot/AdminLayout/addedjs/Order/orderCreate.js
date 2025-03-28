$(document).ready(function () {
    initCustomerDropdown();
    initSelect2(0);

});

function initCustomerDropdown() {
    $("#customerDropdown").select2({
        placeholder: "Müşteri Ara...",
        allowClear: true,
        minimumInputLength: 1,
        dropdownParent: $("#customerDropdown").parent(), // Modal içinde olduğu için eklendi
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

function initSelect2(index) {
    $(`#stockDropdown${index}`).select2({
        placeholder: "Stok Ara...",
        allowClear: true,
        minimumInputLength: 1,
        dropdownParent: $(`#stockDropdown${index}`).parent(),
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

function addOrderDetail() {
    var index = $("#orderDetailsBody tr").length;
    var rowHtml = `
    <tr>
        <td>
            <select id="stockDropdown${index}" name="AdminOrderDetailCreateVMs[${index}].StockId" class="form-control stockDropdown" required></select>
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
            <button type="button" class="btn btn-danger" onclick="removeOrderDetail(this)">Sil</button>
        </td>
    </tr>`;

    $("#orderDetailsBody").append(rowHtml);
    initSelect2(index); // Yeni eklenen dropdown için Select2 başlat
    updateOrderDetailIndexes(); // Index'leri güncelle
}

function removeOrderDetail(button) {
    $(button).closest("tr").remove();
    updateOrderDetailIndexes(); // Silme işleminden sonra index'leri güncelle
    updateTotalOrderAmount(); // Toplam tutarı güncelle
}


