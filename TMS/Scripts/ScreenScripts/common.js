var common = (function () {


    var init = function () {
        common.MaskingCheck();
        common.AlphabetsOnly();
        common.DecimalNumberOnly();
        common.NumberOnly();
        common.DateTimePicker();
        
        $('.readOnly').keypress(function (e) {
            e.preventDefault();
        });
    };

    var DateTimePicker = function () {
        $('.datePickerForward').datepicker({
            language: 'en',
            minDate: new Date() // Now can select only dates, which goes after today
        })

        $('.datePickerBackward').datepicker({
            language: 'en',
            maxDate: new Date()
        })

        var d = new Date();
        d.setDate(1);
        var month = d.getMonth() - 1;
        d.setMonth(month);
        $('.AppointmentDatePicker').datepicker({
            language: 'en',
            minDate: d
        })
    }

    var MaskingCheck = function () {
        $(".bottomBorder").removeClass("bottomBorder");
        $('.ZipMasking').mask('######');
        $('.NTNNumberMasking').mask('##-########');
        $('.DateMasking').mask('00/00/0000');
        $('.DateMaskingForDTP').mask('0000-00-00');
        $('.PhoneNoMasking').mask('(+00)-000-0000000');
        $('.CnicNoMasking').mask('00000-0000000-0');
        $('.CellNoMasking').mask('+00-000-0000000');
        $('.currencyFormat').mask("#,##0.00", { reverse: true });
    };

    var AlphabetsOnly = function () {
        $('.AlphabetsOnly').on('keypress keyup blur', function () {
            var node = $(this);
            node.val(node.val().replace(/[^a-zA-Z\s\b]/g, ''));
        });
    };

    var DecimalNumberOnly = function () {
        $(".DecimalNumberOnly").on("keypress keyup blur", function (event) {
            //this.value = this.value.replace(/[^0-9\.]/g,'');
            $(this).val($(this).val().replace(/[^0-9\.]/g, ''));
            if ((event.which != 46 || $(this).val().indexOf('.') != -1) && (event.which < 48 || event.which > 57)) {
                event.preventDefault();
            }
        });
    };
    
    var NumberOnly = function () {
        $(".NumberOnly").on("keypress keyup blur", function (event) {
            $(this).val($(this).val().replace(/[^\d].+/, ""));
            if ((event.which < 48 || event.which > 57)) {
                event.preventDefault();
            }
        });
    };
    
    var RemoveDashes = function (str) {
        return str.replace(new RegExp('-', 'g'), "")
    };

    var ValidEmail = function (email) {
        var expression = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
        if (expression.test(email)) {
            return true;
        }
        else {
            return false;
        }
    };

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

    var Notifactions = function () {
        $.notify({
            // options
            icon: 'glyphicon glyphicon-warning-sign',
            title: 'Bootstrap notify',
            message: 'Turning standard Bootstrap alerts into "notify" like notifications',
            url: '',
            target: '_blank'
        }, {
            // settings
            element: 'body',
            position: null,
            type: "info",
            allow_dismiss: false,
            newest_on_top: false,
            showProgressbar: false,
            placement: {
                from: "top",
                align: "right"
            },
            offset: 20,
            spacing: 10,
            z_index: 1031,
            delay: 5000,
            timer: 1000,
            url_target: '_blank',
            mouse_over: null,
            animate: {
                enter: 'animated fadeInDown',
                exit: 'animated fadeOutUp'
            },
            onShow: null,
            onShown: null,
            onClose: null,
            onClosed: null,
            icon_type: 'class',
            template: '<div data-notify="container" class="col-xs-11 col-sm-3 alert alert-{0}" role="alert">' +
                '<button type="button" aria-hidden="true" class="close" data-notify="dismiss">×</button>' +
                '<span data-notify="icon"></span> ' +
                '<span data-notify="title">{1}</span> ' +
                '<span data-notify="message">{2}</span>' +
                '<div class="progress" data-notify="progressbar">' +
                    '<div class="progress-bar progress-bar-{0}" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" style="width: 0%;"></div>' +
                '</div>' +
                '<a href="{3}" target="{4}" data-notify="url"></a>' +
            '</div>'
        });
    };

    var GridView = function (TableName, URL, Columns) {
        //debugger;
        $('#' + TableName).DataTable().destroy();
        $('#' + TableName + ' > tbody').empty();
        var table = $('#' + TableName).DataTable({
            "sAjaxSource": URL,
            "sAjaxDataProp": "",
            "bProcessing": true,
            "bPaginate": true,
            "lengthMenu": [[5, 10, 25, 50, -1], [5, 10, 25, 50, "All"]],
            "pageLength": 50,
            "iDisplayLength": 50,
            "stateSave": true,
            searching: true,
            "aoColumns": Columns,                       
           "dom": '<"top">rt<"bottom"<"row"<"col-lg-4 col-md-4 col-sm-12"i><"col-lg-3 col-md-3 col-sm-12"fl><"col-lg-5 col-md-5 col-sm-12"p>>>'
        });

        return $('#' + TableName);
    }

    var ClosePopupLvl1Button = function () {
        $("#first-modal-window .modal-body").empty();
        $("#first-modal-window .modal-title").empty();
        $("#first-modal-window .modal-body").html("");
        $("#first-modal-window").modal("hide");
    }

    var getFormElementById = function (elementId, formId) {
        if (elementId) {
            if (formId) {
                return $("#" + formId).find(elementId);
            }
            else {
                return $(elementId);
            }
        }
        else {
            alert("getFormElementById is missing elementId parameter")
        }
    }

    var openBSModelPopupLvl1 = function (URL, modelSize, modelTitle) {
        try {
            //debugger;
            //var urlObj = getKeyValuePairFromQueryString(URL);
            $("#first-modal-window").find('.modal-dialog').removeClass('modal-sm');
            $("#first-modal-window").find('.modal-dialog').removeClass('modal-lg');
            if (modelSize) {
                if (modelSize.toLowerCase() === "large") {
                    $("#first-modal-window").find('.modal-dialog').addClass('modal-lg');
                }
                else if (modelSize.toLowerCase() === "extrasmall") {
                    $("#first-modal-window").find('.modal-dialog').addClass('modal-sm');
                }
            }
            else {
                $("#first-modal-window").find('.modal-dialog').addClass('modal-lg');
            }
            //showSpinner();

            //setUrlQueryObject("145", urlObj);
            //urlObj.url = URL;
            $.ajax({
                cache: false,
                url: URL,
                contentType: 'application/html; charset=utf-8',
                type: 'GET',
                dataType: 'html',
                success: function (data) {
                    console.log(data);
                    $("#first-modal-window .modal-body").html(data);
                    $("#first-modal-window").modal("show");
                    $('.modal-title').text(modelTitle);
                    //$('#first-modal-window').attr('title', modelTitle);
                },
                error: function (err) {
                    // hideSpinner();
                    alert("Error loading Popup : " + err.message.toString());
                }
            });
        } catch (e) {
            // hideSpinner();
            alert(e);
        }

    }

    var openBSModelPopupLvl3 = function (HTML, modelSize, modelTitle) {
        debugger;
        //var urlObj = getKeyValuePairFromQueryString(URL);
        $("#first-modal-window").find('.modal-dialog').removeClass('modal-sm');
        $("#first-modal-window").find('.modal-dialog').removeClass('modal-lg');
        if (modelSize) {
            if (modelSize.toLowerCase() === "large") {
                $("#first-modal-window").find('.modal-dialog').addClass('modal-lg');
            }
            else if (modelSize.toLowerCase() === "extrasmall") {
                $("#first-modal-window").find('.modal-dialog').addClass('modal-sm');
            }
        }
        else {
            $("#first-modal-window").find('.modal-dialog').addClass('modal-lg');
        }

        $("#first-modal-window .modal-body").html(HTML);
        $("#first-modal-window").modal("show");
        $('.modal-title').text(modelTitle);
        $('#first-modal-window').attr('title', modelTitle);
    }

    var CloseButton = function () {
        window.location.href = "/Admin/Index";
    }

    var toDate = function (data) {
        return moment(data).format('MM/DD/YYYY');
    }
    var toDatetime = function (data) {
       // return moment(data).format('MM/DD/YYYY hh:MM:ss');
        return moment(data).format('MM/DD/YYYY hh:MM:ss');
    }
    var totime = function (data) {
        // return moment(data).format('MM/DD/YYYY hh:MM:ss');
        return moment(data).format('0 hh:MM:ss');
    }
    var toDateForDTP = function (data) {
        return moment(data).format('YYYY-MM-DD');
    }

    var SetFormLabel = function () {
        $(".floating-Input").blur();
        $(".floating-TextArea").blur();
        $(".floating-Select").blur();
    }

    var ResetForm = function () {
        $(".clearText").val('');
        $(".resetDDL").val(-1);
        $(".clearHdnText").val(0);
        $(".resetCheckbox").prop('checked', false);
    }

    var GetParameterFromURL = function (param) {
        debugger;
        var results = new RegExp('[\?&]' + param + '=([^&#]*)').exec(window.location.href);
        if (results == null) {
            return null;
        }
        else {
            return decodeURI(results[1]) || 0;
        }
    }

    var SaveFileOrImage = function (inputID, Type, imageName) {
        debugger;
        var file, img;
        var ImageUpload = false;
        var URL = window.location.origin + '\\' + 'Handler.ashx'
        file = $('#'+inputID)[0].files[0];
        if (file != null) {
            var formData = new FormData();
            formData.append('file', $('#' + inputID)[0].files[0]);
            formData.append("ImageType", Type);
            formData.append("ImageName", imageName);

            $.ajax({
                type: 'post',
                url: URL,
                data: formData,
                success: function (status) {
                    if (status != 'error') {
                        //var my_path = "MediaUploader/" + status;
                        //$("#myUploadedImg").attr("src", my_path);
                        ImageUpload = true;
                    }
                },
                processData: false,
                contentType: false,
                error: function () {
                    alert("Whoops something went wrong!");
                }
            });
        }

        return ImageUpload;
    }

    var ConfirmBox = function (callback, message, cancelBtnText, confirmBtnText) {
        var resurlt = false;
        var Cancelbtn = "Cancel";
        var confirmBtnText = "Confirm";
        if (cancelBtnText) { Cancelbtn = cancelBtnText }
        if (confirmBtnText) { confirmBtnText = confirmBtnText }
        bootbox.confirm({
            // title: "Delete Document",
            message: (message ? message : common.Message.Confirm),
            buttons: {
                cancel: {
                    label: '<i class="fa fa-times"></i> ' + Cancelbtn
                },
                confirm: {
                    label: '<i class="fa fa-check"></i> ' + confirmBtnText
                }
            },
            callback: function (result) {
                return callback(result)
            }
        });
    }

    var FillDropDownList = function (ddlName, placeHolder, url, errorMsg) {
        if (ddlName !== "") {
            ddlName.empty().append('<option selected="selected" value="0" disabled = "disabled">Loading.....</option>');
            $.ajax({
                url: url,
                type: 'GET',
                dataType: "json",
                async: true,
                success: function (nameList) {
                    ddlName.empty().append('<option selected="selected" value="0">' + placeHolder + '</option>');
                    $.each(nameList, function () {
                        ddlName.append($("<option></option>").val(this['Id']).html(this['Value']));
                    });
                },
                error: function (er) {
                    CommonJs.errorMessage('Error occured while loading ' + errorMsg + ' list.');
                }
            });
        }
    };

    var FillDropDownListWithParem = function (ddlName, placeHolder, URL, arr, dropDown, errorMsg) {
        if (ddlName !== "") {
            $('#' + ddlName).empty().append('<option selected="selected" value="0" disabled = "disabled">Loading.....</option>');
            $.ajax({
                url: URL,
                type: 'POST',
                data: { param: arr, DropDown: dropDown },
                async: false,
                success: function (data) {
                    $('#' + ddlName).empty().append('<option value=""></option>');
                    $.each(data, function () {
                        $('#' + ddlName).append($("<option></option>").val(this['ID']).html(this['Value']));
                    });
                },
                error: function (er) {
                    Common.ErrorMessage('Error occured while loading ' + errorMsg + ' list.');
                }
            });
        }
    };

    GetURLParameter = function (param) {
        alert(param);
        var results = new RegExp('[\?&]' + param + '=([^&#]*)').exec(window.location.href);
        if (results == null) {
            return null;
        }
        else {
            return decodeURI(results[1]) || 0;
        }
    }

    var DropDown = function(id, value) {
        var self = this;
        self.ID=  id,
        self.Value= value
    }

    var Message = {
        Success: "Record has been saved successfully.",
        Error: "Something went wrong. Please Contact to Administrator.",
        Confirm: "Are you sure you want to perfrom this action?",
        Delete: "Record has been deleted successfully"
    }

    var CommonURLs = {
        GetDropDownData: "/Common/GetDropDownData/"
    }

    var CallAjaxMethod = function (httpMethod, url, data, type, successCallBack, async, cache) {
        if (typeof async == "undefined") {
            async = true;
        }
        if (typeof cache == "undefined") {
            cache = false;
        }

        var ajaxObj = $.ajax({
            type: httpMethod.toUpperCase(),
            url: url,
            data: data,
            dataType: type,
            async: async,
            cache: cache,
            success: successCallBack,
            error: function (err, type, httpStatus) {
                Common.AjaxFailureCallback(err, type, httpStatus);
            }
        });

        return ajaxObj;
    }

    var DisplaySuccess = function (message) {
        Common.ShowSuccessSavedMessage(message);
    }

    var DisplayError = function (error) {
        Common.ShowFailSavedMessage(message);
    }

    var AjaxFailureCallback = function (err, type, httpStatus) {
        var failureMessage = 'Error occurred in ajax call' + err.status + " - " + err.responseText + " - " + httpStatus;
        console.log(failureMessage);
    }
	
    var ShowSuccessSavedMessage = function (messageText) {

        //use jquery BlockUI library to display message

        $.blockUI({ message: messageText });
        setTimeout($.unblockUI, 1500);
    }

    var ShowFailSavedMessage = function (messageText) {

        //use jquery BlockUI library to display message

        $.blockUI({ message: messageText });
        setTimeout($.unblockUI, 1500);
    }

    return {
        init: init,
        MaskingCheck: MaskingCheck,
        AlphabetsOnly: AlphabetsOnly,
        NumberOnly: NumberOnly,
        DecimalNumberOnly: DecimalNumberOnly,
        openBSModelPopupLvl1: openBSModelPopupLvl1,
        ClosePopupLvl1Button: ClosePopupLvl1Button,
        RemoveDashes: RemoveDashes,
        ValidEmail: ValidEmail,
        ErrorMessage: ErrorMessage,
        SuccessMessage: SuccessMessage,
        Message: Message,
        ConfirmBox: ConfirmBox,
        Notifactions: Notifactions,
        GetParameterFromURL: GetParameterFromURL,
        toDate: toDate,
        toDatetime: toDatetime,
        toDateForDTP: toDateForDTP ,
        SetFormLabel: SetFormLabel,
        ResetForm: ResetForm,
        getFormElementById: getFormElementById,
        GridView: GridView,
        SaveFileOrImage: SaveFileOrImage,
        FillDropDownList: FillDropDownList,
        FillDropDownListWithParem: FillDropDownListWithParem,
        DateTimePicker: DateTimePicker,
        GetURLParameter: GetURLParameter,
        DropDown: DropDown,
        CommonURLs: CommonURLs,
        CallAjaxMethod: CallAjaxMethod
        
    };
})();

$(document).ready(function () {
    common.init();
});