$(document).ready(function () {

    $("#txtYear1").keypress(function (e) {
        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
            //  $('#txtYear1').attr("style", "border-color: red");
            return false;
        }
    });

    $("#txtDOB").datepicker();

    var id = 2;
    $('#lnkAdd').click(function () {
        var count = $('#tbl tr').length;
        if (count < 6) {
            $('#tbl').append("<tr id='trbdy'>" +
                                                    "<td><input type='text' class='form-control txtIns' id='txtIns" + id + "'></td>" +
                                                    "<td><input type='text' class='form-control txtDeg' id='txtDeg" + id + "'></td>" +
                                                    "<td><input type='text' class='form-control txtYear' id='txtYear" + id + "'></td>" +
                                                    "<td><input type='file' class='form-control fileCert' id='fileCert" + id + "'></td>" +
                                                    "<td><a id='lnkCancel' class='btn btn-danger btn-sm' href='#'><i class='fa fa-times'></i></a></td>" +
                                                "</tr>");
            id++;
        }
    });

    $("#tbl").on("click", "a#lnkCancel", function () {
        $(this).closest("Tr").remove();
    });

    $("#lnkSave").click(function () {

        if ($('#txtIns1').val() == "") {
            $('#txtIns1').attr("style", "border-color: red");
            return false;
        }

        var ins = '';
        var deg = '';
        var yr = '';
        var doc = '';
        var arr = [];
        var arr2 = [];
        var arr3 = [];
        var arr4 = [];

        $('#tbl tr#trbdy').each(function (index, row) {
            ins = $(row).find('.txtIns').val();
            arr.push(ins);
            deg = $(row).find('.txtDeg').val();
            arr2.push(deg);
            yr = $(row).find('.txtYear').val();
            arr3.push(yr);
            doc = $(row).find('.fileCert').val().split('\\').pop();
            var chk = doc + "_" + index;
            arr4.push(doc + "_" + row);
        });

        $.ajax({
            type: "POST",
            url: "/Employee/New",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify({ "Ins": arr, "Deg": arr2, "Year": arr3, "Docs": arr4 }),
            success: function (datas) {
                for (var i = 0; i < datas.length ; i++) {
                    var Val = datas[i].Name + " " + datas[i].Id;
                    alert(Val);
                }
            },
            error: function (request, status, error) {
                alert(request, status, error);
            }
        });
    });
});