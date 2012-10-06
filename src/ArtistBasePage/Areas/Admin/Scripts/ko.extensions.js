ko.bindingHandlers.displaySaveSuccess = {
    update: function (element, valueAccessor, allBindingsAccessor) {
        var saveOverlay = $(element).find(".save-overlay");

        if (valueAccessor()) {
            saveOverlay.fadeIn(100);
        }
        else {
            saveOverlay.fadeOut(800);
        }

    }
};