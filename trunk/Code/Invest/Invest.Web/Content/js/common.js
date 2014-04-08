function popUp(isAlert, message, isRedirect, url) {
    if (isAlert) {
        $("#spanError").html("<strong>" + message + "</strong>");
        $('#divPopupError').slideDown(1000, function () {
            setTimeout(function () {
                $('#divPopupError').slideUp(1000, function () {
                    $("#spanError").html("");
                });
            }, 1000);
        });
    } else {
        $("#spanInfo").html("<strong>" + message + "</strong>");
        $('#divPopupInfo').slideDown(1000, function () {
            setTimeout(function () {
                $('#divPopupInfo').slideUp(1000, function () {
                    if (isRedirect) {
                        if (url)
                            window.location = url;
                        else
                            window.location = document.referrer;
                    }
                });
            }, 1000);
        });
    }
}

function showPopUpStatus(message) {
    $("#spanInfo").html("<strong>" + message + "</strong>");
    $('#divPopupInfo').slideDown();
}

function hidePopUpStatus(message) {
    $("#spanInfo").html("");
    $('#divPopupInfo').slideUp();
}

$('input[datatype="number"]').focus(function () {
    if (this.value === '0') {
        this.value = '';
    }
}).blur(function () {
    if (this.value === '') {
        this.value = '0';
    }
});

function isValidEmailAddress(emailAddress) {
    var pattern = new RegExp(/^(("[\w-\s]+")|([\w-]+(?:\.[\w-]+)*)|("[\w-\s]+")([\w-]+(?:\.[\w-]+)*))(@@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$)|(@@\[?((25[0-5]\.|2[0-4][0-9]\.|1[0-9]{2}\.|[0-9]{1,2}\.))((25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\.){2}(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\]?$)/i);
    return pattern.test(emailAddress);
}

function changeTab(url) {
    setTimeout(function () {
        var tabName = url.substring(url.lastIndexOf('#'));
        $("a[href='" + tabName + "']").click();
    }, 0);
};

function removeTime(selector) {
    if (typeof selector === 'undefined' || $(selector).length == 0) {
        return;
    };
    var index = $(selector).val().indexOf(' ');
    if (index > 0)
        $(selector).val($(selector).val().substring(0, index));
}