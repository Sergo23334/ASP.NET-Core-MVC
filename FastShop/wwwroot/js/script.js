$(document).ready(function () {
    $("#AddToCart").on("click", function () {
        $.ajax({
            type: "POST",
            url: "/Cart/AddToCart",
            dataType: "html",
            data: { "id": $("#AddToCart").attr("value") },
            success: success
        });
    });

    function success() {
        alert("Успешно добавлено");
    }
});