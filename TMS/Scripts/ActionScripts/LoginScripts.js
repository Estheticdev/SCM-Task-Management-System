var Login = (function () {
    var init = function () {
    };

    var ValidForm = function () {
        var msg = '';
        alertMsgFlag = false;

        var UserType = $("#ddlUserType").val()
        if (UserType == '' || UserType == null) {
            alertMsgFlag = true;
            msg = msg + "- User Type <br/>";
        }

        var member = $("#ddlMember").val()
        var text = $("#lblStaffMember").text()
        if (text == 'Doctor' && (member == '' || member == null)) {
            alertMsgFlag = true;
            msg = msg + "- Doctor <br/>";
        }

        if (alertMsgFlag) {
            bootbox.alert({ title: "Please provide value for following field(s):", message: msg });
            return false;
        }
        else {
            return true;
        }
    }

    var LoginUser = function () {
        var userName = $("#userName").val();
        var password = $("#password").val();
        $.ajax({
            url: '/Login/LoginAuthentication/',
            type: 'GET',
            data: { userName: userName, password: password },
            dataType: "json",
            async: true,
            success: function (data) {
                
                //if (data == '57') {
                //    window.location.href = "/Doctor/DoctorAppointmentCalandar";
                //}
                //if (data == '56') {
                //    window.location.href = "/Appointment/SearchAppointment";
                //}
                if (data != 'Error') {
                    window.location.href = data;
                }
                if (data == 'Error') {
                    Login.ErrorMessage("Incorrect User Name or Password");
                }
            },
            error: function (er) {
                Login.ErrorMessage('An Error occured while singin user.');
            }
        });

        return false;
    }

    var LogOut = function () {
        $.ajax({
            url: '/Login/LogOut/',
            type: 'GET',
            dataType: "json",
            async: true,
            success: function (data) {
                if (data) {
                    window.location.href = "/Login/LoginUser";
                }
                else {
                    errorMessage("An Error occured while logout user.");
                }

            },
            error: function (er) {
                errorMessage('An Error occured while logout user.');
            }
        });

        return false;
    }

    var SuccessMessage = function (msg) {
        $.notify({
            icon: 'fa fa-check-circle',
            //title: '<strong>Heads up!</strong>',
            message: msg
        }, {
            type: 'success',
            allow_dismiss: true,
            placement: {
                from: "bottom",
                align: "right"
            },
            z_index: 1031,
            animate: {
                enter: 'animated fadeInDown',
                exit: 'animated fadeOutUp'
            },
        });

        return;
    };

    var ErrorMessage = function (msg) {
        $.notify({
            icon: 'fa fa-exclamation-circle',
            //title: '<strong>Heads up!</strong>',
            message: msg
        }, {
            type: 'danger',
            allow_dismiss: true,
            placement: {
                from: "bottom",
                align: "right"
            },
            z_index: 1031,
            animate: {
                enter: 'animated fadeInDown',
                exit: 'animated fadeOutUp'
            },
        });

        return;
    };
    return {
        init: init,
        LoginUser: LoginUser,
        ValidForm: ValidForm,
        LogOut: LogOut,
        ErrorMessage: ErrorMessage,
        SuccessMessage: SuccessMessage
    };
})();

$(document).ready(function () {
    Login.init();
});