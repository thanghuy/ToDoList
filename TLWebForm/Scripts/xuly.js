$(function () {
    $('#save_value').click(function () {
        var val = [];
        $(':checkbox:checked').each(function (i) {
            val[i] = $(this).val();
        });
        console.log(val);
        $("#idPartner").val(val);
    });
});

//// xử lý form check bõx

$("input.form-check-input").click(function () {
    // Loop all these checkboxes which are checked
    var val = [];
    $("input.form-check-input:checked").each(function (i) {
        val[i] = $(this).val();
        // Use $(this).val() to get the Bike, Car etc.. value
    });
    console.log(val);
    $("#idPartner").val(val);
})


/// xử lý ngày tháng

