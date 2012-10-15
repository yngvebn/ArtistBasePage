function GeneralViewModel() {
    var self = this;
    self.loading = ko.observable(true);
    self.saving = ko.observable(false);
    self.name = ko.observable();
    self.email = ko.observable();
    self.phone = ko.observable();
    self.bio = ko.observable();

    self.save = function () {
        self.saving(true);
        API.artist.save(ko.mapping.toJSON(this), function (data) {
            self.saving(false);
        });
    };

}

function MainViewModel() {
    var self = this;
    self.general = ko.observable(new GeneralViewModel());
    API.artist.get(function (data) {
        ko.mapping.fromJS(data, {}, self.general);
        self.general().loading(false);
    });
}

Startup.registerStart(function() {
    var mainViewModel = new MainViewModel();
    ko.applyBindings(mainViewModel, document.getElementById("main"));
});