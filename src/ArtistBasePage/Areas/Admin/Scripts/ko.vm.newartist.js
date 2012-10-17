function NewArtistViewModel(loggedInUsername) {
    var self = this;
    self.name = ko.observable();
    self.creator = ko.observable(loggedInUsername);

    self.create = function() {
        API.artist.create(JSON.stringify({ creator: self.creator(), name: self.name() }));
    };
}

var scriptTag = Helpers.currentScriptTag();
Startup.registerStart(function() {
    var loggedInUsername = $(scriptTag).data('username');
    console.log(loggedInUsername);
    var newArtistViewModel = new NewArtistViewModel(loggedInUsername);
    ko.applyBindings(newArtistViewModel, document.getElementById("main"));
});