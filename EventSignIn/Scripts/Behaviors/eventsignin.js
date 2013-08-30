/// <reference path="../Definitions/jquery.d.ts" />
(function ($) {
    $.fn.eventsignin = eventsignin;

    function eventsignin() {
        var $this = $(this), $userModal = $this.find("#userlookup"), lookup_url = $this.attr("data-lookupuser-url"), signin_url = $this.attr("data-signin-url");

        $this.on("click", ".signin", function () {
            $userModal.modal('show');
        });

        $this.on("click", ".lookupuser", lookupUser);
        $this.on("keypress", "#lookupEmail", function (e) {
            if (e.which == 13) {
                lookupUser();
            }
        });

        $this.on("click", "#register_error > a", function () {
            $userModal.modal('hide');
        });

        function lookupUser() {
            var emailAddress = $("#lookupEmail").val();

            $.ajax({
                url: lookup_url,
                data: { emailAddress: emailAddress },
                type: 'POST',
                success: onSuccess,
                error: onError
            });

            function onSuccess(data) {
                if (data) {
                    $.ajax({
                        url: signin_url,
                        data: { userId: data.Id },
                        type: 'POST',
                        success: function () {
                            alert("Found and registered user: " + data.FirstName + " " + data.LastName + "!");
                            window.location.reload();
                        }
                    });
                }
            }

            function onError() {
                $userModal.find("#register_error > a").attr("data-formdata", JSON.stringify({ emailAddress: emailAddress }));
                $userModal.find("#register_error").show();
            }
        }
    }
})(jQuery);
