var Resources = {
    accessToken: '',
    api: {
        artist: '/api/v1/artist',
        event: '/api/v1/event',
        facebookToken: '/api/v1/facebookToken',
        notification: '/api/v1/notification',
        lastfm: '/api/v1/lastfm'
    },
    amplify: {
        eventWasAdded: 'eventWasAdded'
    }
};

var API = {
    event: new AjaxDataAccess(Resources.api.event),
    artist: new AjaxDataAccess(Resources.api.artist),
    notification: new AjaxDataAccess(Resources.api.notification),
    facebookToken: new AjaxDataAccess(Resources.api.facebookToken),
    lastfm: new AjaxDataAccess(Resources.api.lastfm)
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
