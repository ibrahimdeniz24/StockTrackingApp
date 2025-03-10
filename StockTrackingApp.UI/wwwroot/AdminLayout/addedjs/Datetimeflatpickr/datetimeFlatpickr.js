
document.addEventListener("DOMContentLoaded", function () {
    // Türkiye saati (GMT+3) ile bugünün tarih ve saatini alıyoruz
    var today = new Date();
    today.setHours(today.getHours() + 3); // Türkiye saati için saat farkını ekliyoruz
    var todayISO = today.toISOString().slice(0, 16); // ISO formatına çeviriyoruz

    flatpickr("#OrderDate", {
        enableTime: true,
        dateFormat: "Y-m-d H:i",
        time_24hr: true,
        locale: "tr",
        defaultDate: todayISO // Bugünün tarihi ve saati Türkiye saatiyle varsayılan olarak ayarlanacak
    });

    flatpickr("#DeliveryDate", {
        enableTime: true,
        dateFormat: "Y-m-d H:i",
        time_24hr: true,
        locale: "tr",
        defaultDate: todayISO // Teslimat tarihi de aynı şekilde ayarlanacak
    });
});
