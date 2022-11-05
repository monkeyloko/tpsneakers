// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// remap jQuery to $
(function ($) {

    /* trigger when page is ready */
    $(document).ready(function () {

        // your functions go here
        $('#email-field').click(function () {
            $(this).addClass("active");
            $(this).attr('placeholder', 'Ingrese un nombre');
            $('#subscribe-button').addClass("show");
        });

    });

})(window.jQuery);