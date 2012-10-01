var AjaxDataAccess = (function () {

    var ajax = function (method, url, successCallback) {
        $.ajax({
            headers:
                {
                    t: constants.token
                },
            url: url,
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                successCallback(response);
            }
        });
    };


    var get = function (url, success) {
        ajax('get', url, success);
    };

    return {
        get: get
    };
});