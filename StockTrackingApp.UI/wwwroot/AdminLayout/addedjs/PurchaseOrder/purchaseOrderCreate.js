$(document).ready(function () {
    initSupplierDropdown();
    initSelect2(0);

});

function initSupplierDropdown() {
    $("#supplierDropdown").select2({
        placeholder: "Tedarikçi Ara...",
        allowClear: true,
        minimumInputLength: 1,
        dropdownParent: $("#supplierDropdown").parent(), // Modal içinde olduğu için eklendi
        ajax: {
            url: supplierDropdownUrl, // Razor tarafında değişken olarak set edilmeli
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
            <select id="stockDropdown${index}" name="AdminPurcaserOrderDetailCreateVMs[${index}].StockId" class="form-control stockDropdown" required></select>
        </td>
        <td>
            <input name="AdminPurcaserOrderDetailCreateVMs[${index}].Quantity" pattern="[0-9]+"  class="form-control quantity" min="1" oninput="calculateTotal(this)" required />
        </td>
        <td>
            <input name="AdminPurcaserOrderDetailCreateVMs[${index}].UnitPrice" pattern="[0-9]+([,][0-9]+)?" step="0.01" class="form-control unitPrice" min="0" oninput="calculateTotal(this)" required />
        </td>
        <td>
            <input name="AdminPurcaserOrderDetailCreateVMs[${index}].TotalPriceExcludingVAT"  step="0.01" class="form-control TotalPriceExcludingVAT" readonly />
        </td>
        <td>
            <select name="AdminPurcaserOrderDetailCreateVMs[${index}].VatRate" class="form-control vatRate" required onchange="calculateTotal(this)">
                ${vatRatesHtml} <!-- Razor tarafında oluşturulmalı -->
            </select>
        </td>
        <td>
            <input name="AdminPurcaserOrderDetailCreateVMs[${index}].TotalPriceIncludingVAT"  step="0.01" class="form-control totalVat" readonly />
        </td>
        <td>
            <input name="AdminPurcaserOrderDetailCreateVMs[${index}].TotalPriceIncludingVAT"  step="0.01" class="form-control totalPriceVat" readonly />
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


