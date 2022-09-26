// LOGIN POST ACTION
function loginPost() {
    debugger;
    var data = {};
    data.Email = $("#Email").val();
    data.Password = $("#Passwrd").val();
    let loginViewModel = JSON.stringify(data);
    $.ajax({
        type: 'POST',
        dataType: 'Json',
        url: '/Home/Login',
        data:
        {
            loginViewModel: loginViewModel
        },
        success: function (result) {
            debugger;
            if (!result.isError)
            {
                successAlertWithRedirect(result.msg, result.dashboard)
            }
            else
            {
                errorAlert(result.msg)
            }
        },
        Error: function (ex) {
            errorAlert(ex);
        }
    });
    
}

// Admin Registration POST ACTION
function RegisterAdmin(){
    debugger;
    var data = {};
    data.FirstName = $('#FirstName').val();
    data.LastName = $('#LastName').val();
    data.Email = $('#Email').val();
    data.UserName = $('#UserName').val();
    data.Password = $('#Passwrd').val();
    data.ConfirmPassword = $('#Cpasswrd').val();
    let applicationViewModel = JSON.stringify(data);
    $.ajax({
        type: 'POST',
        dataType: 'Json',
        url: '/Accounts/CreateAdminAccount',
        data:
        {
            applicationUserViewModel: applicationViewModel,
        },
        success: function (result) {
            debugger;
            if (!result.isError) {
                var url = '/Home/Index';
                successAlertWithRedirect(result.msg, url)
            }
            else {
                errorAlert(result.msg)
            }
        },
        Error: function (ex) {
            errorAlert(ex);
        }
    });
}

// CREATE BRANCH POST ACTION
function CreateBranch() {
    debugger;
    var data = {};
    data.Name = $("#Branch").val();
    let newBranchModel = data;
    $.ajax({
        type: 'POST',
        dataType: 'Json',
        url: '/Admin/CreateBranch',
        data:
        {
            newBranch: newBranchModel
        },
        success: function (result) {
            debugger;
            if (!result.isError) {
                successAlert(result.msg)
                window.location.reload();
            }
            else {
                errorAlert(result.msg)
            }
        },
        Error: function (ex) {
            errorAlert(ex);
        }
    });

}

// CREATE DEPARTMENT POST ACTION
function CreateDepartment() {
    debugger;
    var data = {};
    data.Name = $("#Department").val();
    let newDepartmentModel = data;
    $.ajax({
        type: 'POST',
        dataType: 'Json',
        url: '/Admin/CreateDepartment',
        data:
        {
            newDepartment: newDepartmentModel
        },
        success: function (result) {
            debugger;
            if (!result.isError) {
                successAlert(result.msg)
                window.location.reload();
            }
            else {
                errorAlert(result.msg)
            }
        },
        Error: function (ex) {
            errorAlert(ex);
        }
    });

}
