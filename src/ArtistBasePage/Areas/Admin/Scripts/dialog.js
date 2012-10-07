var dialog = {
    open: function (id) {
        var modaloverlay = $("<div />");
        modaloverlay.addClass('modal-overlay');
        modaloverlay.hide();
        
        var dialogElement = $("#" + id);
        dialogElement.css('position', 'relative');
        dialogElement.css('z-index', '20000');
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
        dialogElement.css('position', 'absolute');
        dialogElement.animate({ marginTop: '12%', opacity: 0 }, 200, 'swing');
        modaloverlay.animate({ opacity: 0 }, function() {
            modaloverlay.remove();
        });
        dialogElement.css('z-index', '-20000');
    },
    confirm: function (title, text, onOk, onCancel) {
        var dialogBox = $("#confirm-box");
        dialogBox.find('.title').text(title);
        dialogBox.find('.confirm-text').text(text);
        dialogBox.find('[data-action="ok"]').off('click');
        dialogBox.find('[data-action="ok"]').on('click', function () {
            onOk();
            dialog.close("confirm-box");
        });
        dialogBox.find('[data-action="close"]').off('click', onOk);
        dialogBox.find('[data-action="close"]').on('click', onCancel);
        dialog.open("confirm-box");

    }
    
    
};
Startup.registerStart(function() {
    $('body').on('click', 'button[data-dialog]', function () {
        var dialogId = $(this).attr('data-dialog');
        console.log('opening dialog: #'+dialogId);
        dialog.open(dialogId);
    });
});