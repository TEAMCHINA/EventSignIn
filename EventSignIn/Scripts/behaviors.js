/// <reference path="Definitions/jquery.d.ts" />
(function ($) {
    $(behaviors);

    function behaviors() {
        var timeoutId = 0;

        init();

        function init() {
            $.fn.applyBehaviors = wireElement;
            $.behaviorsEnabled = true;

            $.each(['append', 'prepend', 'after', 'before', 'wrap', 'html'], hookJquery);
            wireElements();

            if (window.Sys && window.Sys.WebForms && window.Sys.WebForms.PageRequestManager) {
                var prm = window.Sys.WebForms.PageRequestManager.getInstance();
                prm.add_endRequest(wireElements);
            }
        }

        function wireElements() {
            timeoutId = 0;

            var behaviors = $('[data-behavior]');
            for (var i = 0; i < behaviors.length; i++) {
                wireElement.apply(behaviors[i]);
            }
        }

        function wireElement() {
            var element = $(this), behaviors = element.attr('data-behavior').split(','), configured = element.data('behaviorsConfigured') || {};

            element.data('behaviorsConfigured', configured);
            behaviors = $.grep(behaviors, filterBehaviors);

            for (var i = 0; i < behaviors.length; i++) {
                applyBehavior(behaviors[i]);
            }

            function applyBehavior(name) {
                var trimmedName = name.trim();

                if ($.fn[trimmedName]) {
                    configured[name] = true;
                    $.fn[trimmedName].apply(element);
                } else if (console && typeof (console.log) === 'function') {
                    console.log('Behavior could not find the requested plugin: ' + trimmedName);
                }
            }

            function filterBehaviors(name) {
                return (!!name && !configured[name]);
            }
        }

        function hookJquery(i, method) {
            var jquerymethod = $.fn[method];
            $.fn[method] = hookedJquery;

            function hookedJquery() {
                var result = jquerymethod.apply(this, arguments);
                if ($.behaviorsEnabled === true && timeoutId === 0) {
                    timeoutId = setTimeout(wireElements, 0);
                }
                return result;
            }
        }
        ;
    }
})(jQuery);
