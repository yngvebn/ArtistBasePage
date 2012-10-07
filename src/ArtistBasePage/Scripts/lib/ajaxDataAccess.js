var AjaxDataAccess = (function () {

    var ajax = function (method, url, successCallback, data) {
        $.ajax({
            headers:
                {
                    t: Resources.token
                },
            url: url,
            type: method,
            data: data === undefined ? null : data,
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
    var save = function(url, data, success) {
        ajax('put', url, success, data);
    };
    var create = function(url, data, success) {
        ajax('post', url, success, data);
    };
    var remove = function (url, data, success) {
        ajax('delete', url, success, data);
    };

    return {
        get: get,
        save: save,
        create: create,
        remove: remove
    };
});