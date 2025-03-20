//var myData = "";
//Prevent any kind of SYMBOL in input
$("input").keypress(function (e) {
    var character = String.fromCharCode(e.keyCode);
    if (/[~`!@#$%\^&*()_=\-\[\]\\';,/{}|\\":<>\?]/g.test(character)) {
        return false; //replace false to all characters above
    }
})

//Prevent NUMBER in NAME field
$("#txtName").keypress(function (e) {
    var charCode = (typeof e.which == "undefined") ? e.keyCode : e.which;
    var charStr = String.fromCharCode(charCode);
    if (/[+0-9]/.test(charStr)) {
        return false;
    }
})

//Prevent CHARACTER in PHONE field
$("#txtPhone").keypress(function (e) {
    var charCode = (typeof e.which == "underfined") ? e.keyCode : e.which;
    var charStr = String.fromCharCode(charCode);

    if (/[+0-9]/.test(charStr)) {
        return true;
    }
    else if ($("#txtPhone").val().length >= 13) {
        return false;
    }
    else {
        return false;
    }
})

//NUMBER ONLY in ID filed 
$("#txtID").keypress(function (e) {
    var charCode = (typeof e.which == "undefined") ? e.keyCode : e.which;
    var charStr = String.fromCharCode(charCode);
    if (!/[+0-9]/.test(charStr)) {
        return false;
    }
})

//Trigger Search button to click
$('#txtID').on("keyup", function (e) {
    if (e.key === "Enter") {
        $("#btnSearch").click();
    }
});

//SEARCH Button
$('#btnSearch, #btnCancel').on('click', function () {
    var obj = {};
    obj.id = $('input[name=sid]').val();

    if ($('#txtID').val().length === 0) {
        alert("Please input 'ID' to SEARCH");

        $('#txtName, #txtSex, #txtDOB, #txtPhone').val("");

        $('#txtID').focus();
    }
    else {
        $.ajax({
            url: '../Services/UserInput.svc/ajaxUserInput/SelectUserInput',
            type: 'POST',
            data: JSON.stringify(obj),
            dataType: 'JSON',
            contentType: 'application/json',

            success: function (data) {

                myData = JSON.parse(data.d);

                if (myData.name == myData.sex) {
                    alert("ID not found!");
                    $('#txtName, #txtSex, #txtDOB, #txtPhone').val("");
                }
                else {
                    const d = new Date(myData.dob);
                    formattedDate = d.getFullYear() + '-' + ("0" + (d.getMonth() + 1)).slice(-2) + '-' + ("0" + d.getDate()).slice(-2)

                    $('#txtName').val(myData.name);
                    $('#txtSex').val(myData.sex);
                    $('#txtDOB').val(formattedDate);
                    $('#txtPhone').val(myData.phone);

                    $('#btnEdit').show();
                    $('#btnEdit').prop("disabled", false);

                    $('#btnUpdate, #btnCancel, #btnDelete').hide();
                }
            },
            error: function (data) {

                if (data.d == "Error") {
                    alert('Something went wrong!');
                }
            }
        })
    }
})

// EDIT Button
$('#btnEdit').click(function () {
    if ($('#txtName').val().length === 0) {
        alert("There is no data to Edit!");
    }
    else {

        $('#txtName, #txtSex, #txtDOB, #txtPhone').css("cursor", "auto"); //Enabled input field
        $('#txtName, #txtSex, #txtDOB, #txtPhone').prop("disabled", false); //Disabled -> false

        $('#txtName').focus();

        $('#btnCancel').show();
        $('#btnCancel').prop("disabled", false);

        $('#btnDelete').show();
        $('#btnDelete').prop("disabled", false);

        $('#btnUpdate').show();
        $('#btnUpdate').prop("disabled", true);

        //Hide Edit Button
        $('#btnEdit').hide();
    }
})


//Prevent user SUBMIT when there is no different from the previous data /*click mouseleave*/
$('#txtName, #txtDOB, #txtSex, #txtPhone').on('keyup change', function () {

    if ( !(myData.name == $("#txtName").val() &&
        myData.sex == $("#txtSex").val() &&
        formattedDate == $("#txtDOB").val() &&
        myData.phone == $("#txtPhone").val()) ) {

        $('#btnUpdate').prop("disabled", false);
    }
    else {
        $('#btnUpdate').prop("disabled", true);
    }
})

//UPDATE Button
$('#btnUpdate').click(function () {
    var obj = {};
    obj.id = $('#txtID').val();
    obj.name = $('#txtName').val();
    obj.sex = $('#txtSex').val();
    obj.dob = $('#txtDOB').val();
    obj.phone = $('#txtPhone').val();

    if (myData.name == $("#txtName").val() &&
        myData.sex == $("#txtSex").val() &&
        formattedDate == $("#txtDOB").val() &&
        myData.phone == $("#txtPhone").val()) {

        alert("Nothing change!");

        $('#btnSubmit').prop('disabled', true);
        $('#txtName').focus();
    }
    else if (confirm("Are you sure?\nClick OK to UPDATE!") == true) {

        $.ajax({
            url: '../Services/UserInput.svc/ajaxUserInput/UpdateUserInput',
            type: 'POST',
            data: JSON.stringify(obj),
            dataType: 'JSON',
            contentType: 'application/json',

            success: function (data) {
                var result = data.d;

                if (result == "name") {
                    alert("Please fill your NAME!")
                    $('#txtName').focus();
                }
                else if (result == "sex") {
                    alert("Please choose your GENDER!");
                    $('#txtSex').focus();
                }
                else if (result == "dob") {
                    alert("Please fill your DATE OF BIRTH");
                    $('#txtDOB').focus();
                }
                else if (result == "phone") {
                    alert("Please fill your PHONE NUMBER!");
                    $('#txtPhone').focus();
                }
                else if (result == "Success") {
                    $('#btnUpdate').hide();
                    $('#btnCancel').hide();
                    $('#btnDelete').hide();

                    //Disabled typing in Result fields
                    $('#txtName, #txtSex, #txtDOB, #txtPhone').css("cursor", "not-allowed"); //Disabled input field
                    $('#txtName, #txtSex, #txtDOB, #txtPhone').prop("disabled", true); //Disabled -> true

                    $('#txtID').css("cursor", "auto");
                    $('#txtID').prop("disabled", false);

                    $('#btnSearch').prop("disabled", false);
                    $('#txtID').focus();

                    //Show BUTTON
                    $('#btnEdit').show();
                }
            },

            error: function (data) {
                var result = data.d;
                if (result === 'Error') {
                    alert("Something went wrong!");
                }
            }
        })
    }
    else {
        $('#txtName').focus();
    }
})

//DELETE Button
$('#btnDelete').click(function () {
    var obj = {};
    obj.id = $('#txtID').val();
    if (confirm("Are you sure?\nClick OK to DELETE!") == true) {

        if ($('#txtID').val().length === 0) {
            alert("Please input 'ID' to DELETE");
        }
        else {
            $.ajax({
                url: '../Services/UserInput.svc/ajaxUserInput/DeleteUserInput',
                type: 'POST',
                data: JSON.stringify(obj),
                dataType: 'JSON',
                contentType: 'application/json',

                success: function (data) {
                    var result = data.d;
                    if (result === "id") {
                        alert("Please input ID to DELETE")
                    }
                    else if (result === "Success") {

                        $('#txtName, #txtSex, #txtDOB, #txtPhone').val("");
                        $('#txtName, #txtSex, #txtDOB, #txtPhone').css("cursor", "not-allowed");
                        $('#txtName, #txtSex, #txtDOB, #txtPhone').prop("disabled", true);

                        $('#txtID').focus();

                        //Disabled typing in Result fields
                        $('#txtName, #txtSex, #txtDOB, #txtPhone').css("cursor", "not-allowed"); //Disabled input field
                        $('#txtName, #txtSex, #txtDOB, #txtPhone').prop("disabled", true); //Disabled -> true

                        $('#btnUpdate').hide();
                        $('#btnCancel').hide();
                        $('#btnDelete').hide();

                        $('#btnEdit').show();
                        $('#btnEdit').prop("disabled", true);
                    }
                },

                error: function () {
                    alert("Someting went wrong!");
                }
            })
        }
    }
    else {
        $('#txtName').focus();
    }
})

//CANCEL Button
$('#btnCancel').click(function () {
    //Enabled user typing another ID
    $('#txtID').css("cursor", "auto");
    $('#txtID').prop("disabled", false);
    $('#btnSearch').prop("disabled", false);

    //Hide BUTTONS
    $('#btnUpdate').hide();
    $('#btnCancel').hide();

    //Disabled typing in Result fields
    $('#txtName, #txtSex, #txtDOB, #txtPhone').css("cursor", "not-allowed"); //Disabled input field
    $('#txtName, #txtSex, #txtDOB, #txtPhone').prop("disabled", true); //Disabled -> true

    //Clear input
    //$('#txtName, #txtSex, #txtDOB, #txtPhone').val("");
    $('#txtID').focus();

    $('#btnEdit').show();
})