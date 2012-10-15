var AjaxDataAccess = (function (apiUrl) {
    var url = apiUrl;
    
    var ajax = function (method, successCallback, data) {
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


    var get = function (success) {
        ajax('get', success);
    };
    var save = function(data, success) {
        ajax('put', success, data);
    };
    var create = function(data, success) {
        ajax('post', success, data);
    };
    var remove = function (data, success) {
        ajax('delete', success, data);
    };

    return {
        get: get,
        save: save,
        create: create,
        remove: remove
    };
});