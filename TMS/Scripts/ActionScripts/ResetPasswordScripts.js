var ResetPassword = (function () {
    var init = function () {
        //ForgotPassword.bindPageEvents();
    };

    var ResetPasswordAfterForgotten = function () {
        //if (ValidatePassword()) {
            var password = $("#newPassword").val();
            var token = common.GetURLParameter('token');

            $.ajax({
                url: '/Login/ResetPasswordAfterForgotten/',
                type: 'POST',
                data: { token: token, password: password },
                dataType: "json",
                async: true,
                success: function (data) {
                    if (data) {

                        bootbox.alert("Password has been reset.");
                        //successMessage("Password Has been reset.");
                        window.location.href = "/Login/LoginUser";
                    }
                    else {
                        common.SuccessMessage("An Error occured while reseting password.");
                    }

                },
                error: function (er) {
                    common.ErrorMessage('An Error occured while reseting password.');
                }
            });
        //}

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
        ResetPasswordAfterForgotten: ResetPasswordAfterForgotten,
        ErrorMessage: ErrorMessage,
        SuccessMessage: SuccessMessage
    };
})();

$(document).ready(function () {
    ResetPasswordScripts.init();
});