var Resources = {
    accessToken: '',
    api: {
        artist: '/api/v1/artist',
        event: '/api/v1/event'
    },
    amplify: {
        eventWasAdded: 'eventWasAdded'
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
