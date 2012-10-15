

function NewEventViewModel() {
    var self = this;
    self.facebookUrl = ko.observable();
    self.title = ko.observable();
    self.description = ko.observable();
    self.facebookEventId = ko.observable();
    self.facebookToken = ko.observable();
    self.results = ko.observableArray();
    
    self.createFromFacebook = function () {
        console.log('create from facebook');
        $("#step1").fadeOut(200);
        $("#step2_facebook").fadeIn(200);
    };

    self.throttleSearch = new ThrottleSearch();

    self.setFacebookToken = function (token) {
        console.log("Facebook token: " + token);
        self.facebookToken(token);
        
        self.throttleSearch.init("https://graph.facebook.com/search?type=event&q=&access_token="+self.facebookToken(), "q", function (data) {
            if (data !== null)
                self.results(data.data);
        });

    };

    self.selectFacebookEvent = function(item) {
        self.facebookEventId(item.id);
        API.event.create(ko.toJSON({ FacebookEventId: self.facebookEventId() }), function () {
            $("#step2_facebook").fadeOut(200);
            $("#finish_facebook").fadeIn(200);
            amplify.publish(Resources.amplify.eventWasAdded);
        });
    };

    self.facebookUrl.subscribe(function () {
        self.throttleSearch.query(self.facebookUrl());
    });
   
    self.reset = function() {
        self.facebookUrl('');
        self.description('');
        self.facebookEventId('');
        self.title('');
        self.results([]);
    };
    self.facebookDone = function () {
        $("#finish_facebook").fadeOut(400, function () {
            $("#step1").show();
        });
        self.reset();
    };
}

Startup.registerStart(function () {
    

    var newEventViewModel = new NewEventViewModel();
    ko.applyBindings(newEventViewModel, document.getElementById("new-event"));
    
    var facebookTokenAccess = new AjaxDataAccess();

    API.facebookToken.get(function (data) {
        newEventViewModel.setFacebookToken(data);
    });

});