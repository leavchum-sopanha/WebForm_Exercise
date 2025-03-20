//$(document).ready(function ($) {

//Input Validation (prevent symbol)
$("input").keypress(function (e) {
    var character = String.fromCharCode(e.keyCode);
    //return isValid(character);
    if (/[~`!@#$%\^&*()_=\-\[\]\\';,/{}|\\":<>\?]/g.test(character)) {
        return false; //replace false to all characters above
    }
});

// Name Validation
$("#txtName").keypress(function (e) {
    var charCode = (typeof e.which == "undefined") ? e.keyCode : e.which;
    var charStr = String.fromCharCode(charCode);
    if (/[+0-9]/.test(charStr)) {
        return false;
    }
})

// Phone Number Validation
$("#txtPhone").keypress(function (e) {
    var charCode = (typeof e.which == "undefined") ? e.keyCode : e.which;
    var charStr = String.fromCharCode(charCode);
    if (!/[+0-9]/.test(charStr)) {
        return false;
    } 

    // Limit the length of input
    if ($("#txtPhone").val().length >= 13) {
        return false;
    }
})

// Clear Button
$('#btnClear').click(function () {
    $('#txtName').val('');
    $('#txtSex').val('');
    $('#txtDOB').val('');
    $('#txtPhone').val('+855');

});

//Prevent user SUBMIT when there is no data in textbox
$('#txtName').on('keyup', function () {
    if ($("#txtName").val() != "" || 
        $("#txtSex").val() != "" ||
        //$("#txtDOB").val() != "" &&
        $("#txtPhone").val() != "")
    {

        $('#btnSubmit').prop("disabled", false)
    }
    else {

        $('#btnSubmit').prop("disabled", true);
    }
});


//Trigger Search button to click
$('#txtName, #txtSex, #txtPhone, #txtDOB').on("keyup", function (e) {
    if (e.key === "Enter") {
        $("#btnSubmit").click();
    }
});

// Submit Button
$('#btnSubmit').click(function () {
    $('btnSubmit').prop('disabled', false);
    var obj = {};
    obj.name = $('#txtName').val();
    obj.sex = $('#txtSex').val();
    obj.dob = $('#txtDOB').val();
    obj.phone = $('#txtPhone').val();

    //if ($("#txtName").val("")
    //    //&&
    //    //$("#txtSex").val("") &&
    //    //$("#txtDOB").val("")
    //    //&&
    //    //$("#txtPhone").val("")
    //) {

    //    alert("Please input all the information!");
    //    $('btnSubmit').prop('disabled', true);
    //}
    //else if
    (confirm("Are you sure?\nClick OK to SUBMIT!") == true)
    /*{*/
        $.ajax({
            url: '../Services/UserInput.svc/ajaxUserInput/InsertUserInput',
            type: 'POST',
            data: JSON.stringify(obj),
            dataType: 'JSON',
            contentType: 'application/json',

            success: function (data) {
                var result = data.d;
                alert("Hey");
                 
                    if (result == "Success") {

                    //$("#icon").css("color", "lightgreen");
                    //$("#msg").css({ "border": "5px solid lightgreen", "box- shadow": " 0 0 5px lightgreen" });

                    //$("#msg").css({ "border": "5px solid lightgreen", "box- shadow": " 0 0 5px lightgreen", "width": "300px", "height": "200px" });
                    //$("#header").html("DONE").css("color", "#059862");
                    //$(".form").hide();
                    //$(".form-btn").hide();

                    alert("បញ្ចូលទិន្នន័យ​បានជោគជ័យ, សូមអរគុណ!");
                }
            },

            error: function () {
                alert('ព្យាយាមម្ដងទៀត, កុំយំ!');

                var error = data.d;

                if (error == "Error") {

                    alert('Somethings went wrong!');
                }
            }
        })
    //}    
})
//});
