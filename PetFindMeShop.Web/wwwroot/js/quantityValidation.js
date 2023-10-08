$(".minus").click(function () {
    val = parseInt($(".num").val());

    if (val > 1) {
        $(".num").val(val - 1);
    }
})

$(".plus").click(function () {
    val = parseInt($(".num").val());

    if (val < 100) {
        $(".num").val(val + 1);
    }
})

$(".num").change(function () {
    val = parseInt($(".num").val());

    if ($.isNumeric(val)) {
        if (val > 100) {
            $(".num").val(100);
        } else if (val < 1) {
            $(".num").val(1);
        }
    } else {
        $(".num").val(1);
    }
}); 