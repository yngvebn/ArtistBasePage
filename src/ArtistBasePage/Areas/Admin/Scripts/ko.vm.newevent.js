function NewEventViewModel() {
    var eventDataAccess = new AjaxDataAccess();

    var self = this;
    self.facebookUrl = ko.observable();
    self.title = ko.observable();
    self.description = ko.observable();
    self.facebookEventId = ko.observable();
    self.createFromFacebook = function () {
        console.log('create from facebook');
        $("#step1").fadeOut(200);
        $("#step2_facebook").fadeIn(200);
    };

    self.lookupFacebookEvent = function () {
        eventDataAccess.get(Resources.api.event + "/facebook?url=" + self.facebookUrl(), function (data) {
            console.log(data);
            $("#step2_facebook").fadeOut(200);
            self.facebookEventId(data.id);
            self.title(data.title);
            self.description(data.shortDescription);
            $("#step3_facebook").fadeIn(200);
        });
    };

    self.addFacebookEvent = function () {
        eventDataAccess.create(Resources.api.event, ko.toJSON({ FacebookEventId: self.facebookEventId() }), function () {
            $("#step3_facebook").fadeOut(200);
            $("#finish_facebook").fadeIn(200);
            amplify.publish(Resources.amplify.eventWasAdded);
        });
    };
    self.reset = function() {
        self.facebookUrl('');
        self.description('');
        self.facebookEventId('');
        self.title('');
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
});