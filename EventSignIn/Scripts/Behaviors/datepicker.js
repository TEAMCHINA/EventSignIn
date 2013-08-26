/// <reference path="../Definitions/jquery.d.ts" />
(function ($) {
    $.fn.datepicker = datepicker;

    function datepicker() {
        $(this).datetimepicker({
            language: 'en',
            pick12HourFormat: true
        });
    }
})(jQuery);
