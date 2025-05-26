
document.addEventListener("DOMContentLoaded", function () {
    // Türkiye saatini (GMT+3) al
    const getTodayInTR = () => {
        const date = new Date();
        date.setHours(date.getHours() + 3);
        return date.toISOString().slice(0, 16); // "yyyy-MM-ddTHH:mm"
    };

    const defaultDate = getTodayInTR();

    // Tüm .datetime-picker class'larına flatpickr uygula
    document.querySelectorAll(".datetime-picker").forEach(function (input) {
        flatpickr(input, {
            enableTime: true,
            dateFormat: "Y-m-d H:i",
            time_24hr: true,
            locale: "tr",
            defaultDate: defaultDate
        });
    });
});
