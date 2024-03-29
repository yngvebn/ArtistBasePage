﻿if (Resources.token != "") {
    $.connection.hub.start().done(function () {
        $.each(Startup.signalRFunctions, function (i, func) {
            func();
        });
    });

    $.connection.adminHub.redirect = function (url) {
        document.location = url;
    };
}

Startup.registerStart(function () {


    if (Resources.token !== '') {
        var controlsViewModel = new ControlsViewModel();
        ko.applyBindings(controlsViewModel, document.getElementById('main-controls'));
    }
});

function ControlsViewModel() {
    var self = this;
    self.unreadNotifications = ko.observableArray([]);
    self.hasUnread = ko.computed(function () {
        return self.unreadNotifications().length > 0;
    })
    self.unreadCount = ko.computed(function () {
        return self.unreadNotifications().length;
    });

    API.notification.get(function (data) {
        self.unreadNotifications.push(data);
    });

    $.connection.adminHub.notify = function (message) {
        self.unreadNotifications.push(message);

        

        var notificationBox = $(".notification");
        notificationBox.find("h3").text(message.Title);
        var content = notificationBox.find("section");
        content.text(message.Content);
        notificationBox.find("button").text(message.CancelText);
        content.click(function () {
            var apiDataAccess = new AjaxDataAccess(message.AcceptAction);
            apiDataAccess.create({}, function () {
                console.log('done');
            });
        });
        notificationBox.fadeIn(200, function () {
            setTimeout(function () {
                notificationBox.fadeOut(800);
            }, 15000);
        });
    };
}
