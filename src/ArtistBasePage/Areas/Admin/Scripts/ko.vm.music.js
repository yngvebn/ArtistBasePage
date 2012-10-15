function SongViewModel(data) {
    self.title = ko.observable(data.title);
    self.album = ko.observable(data.album);
}

function MusicViewModel() {
    var self = this;
    self.songs = ko.observableArray();

    self.remove = function() {

    };
}

Startup.registerStart(function() {
    var musicViewModel = new MusicViewModel();
    ko.applyBindings(musicViewModel, document.getElementById("main"));
});