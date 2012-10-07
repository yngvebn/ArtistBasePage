var dialog = {
    open: function (id) {
        var modaloverlay = $("<div />");
        modaloverlay.addClass('modal-overlay');
        modaloverlay.hide();
        
        var dialogElement = $("#" + id);
        dialogElement.find("[data-action='close']").on('click', function() {
            dialog.close(id);
        });
        dialogElement.css('margin-top', '5%');
        dialogElement.animate({ marginTop: '10%', opacity: 1 }, 200, 'swing');
        $('body').append(modaloverlay);
        
        modaloverlay.fadeTo(50, 0.3);
    },
    close:function (id) {
        var modaloverlay = $("div.modal-overlay");
        var dialogElement = $("#" + id);
        dialogElement.animate({ marginTop: '12%', opacity: 0 }, 200, 'swing');
        modaloverlay.animate({ opacity: 0 }, function() {
            modaloverlay.remove();
        });
    }
    
};
Startup.registerStart(function() {
    $('body').on('click', 'button[data-dialog]', function () {
        var dialogId = $(this).attr('data-dialog');
        console.log('opening dialog: #'+dialogId);
        dialog.open(dialogId);
    });
});