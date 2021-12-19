var ForgotPassword = (function () {
    var init = function () {
        //ForgotPassword.bindPageEvents();
    };

    var sendEmail = function () {
        debugger;
        var userName = $("#userName").val();
        if (userName != '') {

            $.ajax({
                url: '/Login/SendEmail/',
                type: 'POST',
                data: { userName: userName },
                dataType: "json",
                async: true,
                success: function (data) {
                    if (data == 'Success') {
                        ForgotPassword.SuccessMessage("Email has been sent on your Email ID. Please check your inbox.");
                    }
                    else {
                        ForgotPassword.ErrorMessage("An Error occured while sending email");
                    }

                },
                error: function (er) {
                    ForgotPassword.ErrorMessage('An Error occured while sending email.');
                }
            });
        }
        else {
            ForgotPassword.ErrorMessage('User Name is must required.');
        }

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
        sendEmail: sendEmail,
        ErrorMessage: ErrorMessage,
        SuccessMessage: SuccessMessage
    };
})();

$(document).ready(function () {
    ForgotPassword.init();
});