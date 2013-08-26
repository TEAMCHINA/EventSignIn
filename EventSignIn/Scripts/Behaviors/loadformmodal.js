/// <reference path="../Definitions/jquery.d.ts" />
(function ($) {
    $.fn.loadformmodal = loadformmodal;

    function loadformmodal() {
        var $this = $(this), modal = $("#page_modal"), formUrl = $this.attr("data-formurl");

        $this.click(function () {
            $.ajax({
                url: formUrl,
                type: 'POST',
                success: onLoad,
                error: onError
            });
        });

        function onLoad(data) {
            modal.html(data);
            modal.modal('show');
        }

        function onError() {
            alert("Unable to load form");
        }
    }
})(jQuery);
