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
function validateForm() {
    var dateStart = $('#dateS').val();
    var dateEnd = $('#dateE').val();
    var comment = $('#comment').val();

    var ds = new Date(dateStart);
    var de = new Date(dateEnd);
    var today = new Date();
    if (dateStart == "" || dateEnd == "" || comment == "") {
        $(".form-control").addClass("is-invalid");
        $('#errorDateS').html('Chọn ngày không hợp lệ');
        $('#errorDateE').html('Chọn ngày không hợp lệ');
        $('#errorComment').html('Không được để trống');
        return false;
    }

    if (ds.getTime() > de.getTime()) {
        $(".form-control").removeClass("is-invalid");
        $("#dateS").addClass("is-invalid");
        $("#dateE").addClass("is-invalid");
        $('#errorDateS').html('Ngày không hợp lệ');
        $('#errorDateE').html('Ngày không hợp lệ');
        return false;
    }
    $(".form-control").removeClass("is-invalid");
    return true;
}
