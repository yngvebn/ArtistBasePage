var ThrottleSearch = (function () {
    var searchInterval = 1500;
    var isInitialized = false;
    var performNewSearch = false;
    var uri = undefined;
    var queryStringKey = "";
    var queryStringValue = "";
    var previousQuery = "";
    var currentRequest = undefined;
    var isPreparingSearch = false;
    var results = [];
    var onResults = undefined;
    function doRequest(requestUrl, completeCallback) {
        $.ajax({
            url: requestUrl,
            type: 'get',
            dataType: 'json',
            error: function (e) {
                console.log('error', e);
            },
            complete: function () {
            },
            success: function (data, textStatus, jqXHR) {
                completeCallback(data);
            }
        });
        isPreparingSearch = false;
    }
    function search() {
        if (queryStringValue == "" || previousQuery == queryStringValue) {
            if(queryStringValue == "") {
                onResults(null);
            }

            isPreparingSearch = false;
            setTimeout(function () {
                search();
            }, searchInterval);
        }
        else {
            if (isPreparingSearch) return;
            if (!isInitialized) return;
            isPreparingSearch = true;
            console.log(queryStringValue);

            uri.replaceQueryParam(queryStringKey, queryStringValue);
            if (currentRequest !== 4 && currentRequest !== undefined) {
                currentRequest.abort();
            }
            doRequest(uri, function (data) {
                previousQuery = queryStringValue;
                results = data;
                onResults(results);
                setTimeout(function () {
                    search();
                }, searchInterval);
            });
            performNewSearch = false;
        }


    }

    function query(q) {
        if (q !== queryStringValue) {
            queryStringValue = q;
            performNewSearch = true;
        }
        else {
            performNewSearch = false;
        }
    };

    function startSearch() {
        setTimeout(function () {
            search();
        }, searchInterval);
    };

    function stopSearch() {

    };

    function initialized(val) {
        isInitialized = val;
        if (isInitialized)
            startSearch();
        else {
            stopSearch();
        }
    };

    function stop() {
        initialized(false);
    };

    function init(url, q, onResultsCallback) {
        uri = new Uri(url);
        queryStringKey = q;
        onResults = onResultsCallback;
        initialized(true);
    }



    return {
        init: init,
        stop: stop,
        query: query,
    };
});