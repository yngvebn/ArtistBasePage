function EventViewModel(data) {
    var self = this;
    self.location = ko.observable(data.location);
    self.title = ko.observable(data.title);
    self.when = ko.observable(moment(data.startTime).format('LLLL'));
    self.source = ko.observable(data.source);
    self.id = ko.observable(data.id);
    self.sourceImageUrl = ko.computed(function() {
        if(self.source() == 1) {
            return "/content/images/social/24x24/24x24-facebook.png";
        }
        if (self.source() == 2) {
            return "/content/images/social/24x24/24x24-lastfm.png";
        }
    });
    self.remove = function(item) {
        var deleteText = "";
        if (self.source() == 1) {
            deleteText = "This event is created on Facebook. Deleting it will only hide it from your site, it will still exist on Facebook. To permanently delete it you have to do so on Facebook";
        }

        dialog.confirm("Really delete this event?", deleteText, function() {
            API.event.remove({ id: item.id(), source: self.source() }, function() {
                amplify.publish(Resources.amplify.eventWasAdded);
            });
        });
    };
}

function EventsViewModel() {
    var self = this;
    self.events = ko.observableArray();

    self.load = function() {
        API.event.get(function (data) {
            self.events([]);
            $.each(data, function(i, ev) {
                self.events.push(new EventViewModel(ev));
            });
        });
    };
    amplify.subscribe(Resources.amplify.eventWasAdded, function() {
        self.load();
    });
}


Startup.registerStart(function() {
    var eventsViewModel = new EventsViewModel();
    eventsViewModel.load();
    ko.applyBindings(eventsViewModel, document.getElementById('main'));


});