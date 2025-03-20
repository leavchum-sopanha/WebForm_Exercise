$('#btnSearch').on("click", function () {
    var obj = {};
    obj.startDate = $('#startDate').val();
    obj.endDate = $('#endDate').val();

    //let report = $('#ReportViewer1').val();
    //let endDate = report[0].endDate;

    //alert(obj.startDate + " and " + obj.endDate);

    window.open(['/Report2/DateRange.aspx?viewtype=pdf','&', 'startDate=', obj.startDate].join(""), '_blank');

    //$.ajax({
    //    url: '../Report2/Report_Service.svc/ajaxDateRange/DateRange',
    //    type: 'POST',
    //    data: JSON.stringify(obj),
    //    dataType: 'JSON',
    //    contentType: 'application/json',
    //    success: function (data) {
    //        if (data.d == "1") {
    //            alert(obj.startDate + " and " + obj.endDate)
    //        }
    //    },
    //    error: function (data) {
    //        var result = data.d;
    //        if (result === 'Error') {
    //            alert("Something went wrong!");
    //        }
    //    }
    //})
});