var Resources = {
    accessToken: '',
    api: {
        artist: '/api/v1/artist',
        event: '/api/v1/event'
    }
};

var Startup = {
    startFunctions: [],
    registerStart: function(callback) {
        this.startFunctions.push(callback);
    }
};
