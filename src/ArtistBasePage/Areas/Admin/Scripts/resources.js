var Resources = {
    accessToken: '',
    api: {
        artist: '/api/v1/artist',
        event: '/api/v1/event',
        facebookToken: '/api/v1/facebookToken'
    },
    amplify: {
        eventWasAdded: 'eventWasAdded'
    }
};

var Helpers = {
    currentScriptTag: function() {
        var thisScript = document.getElementsByTagName('script');
        return $(thisScript[thisScript.length - 1]);
    }
};

var Startup = {
    startFunctions: [],
    signalRFunctions: [],
    registerSignalR: function (callback) {
        this.signalRFunctions.push(callback);
    },
    registerStart: function(callback) {
        this.startFunctions.push(callback);
    }
};
