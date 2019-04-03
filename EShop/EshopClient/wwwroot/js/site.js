// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
(function () {
    var defaultOptions = {
        highlight: function (element) {
            var $formGroup = $(element).closest(".form-group");
            $formGroup.find(".form-control").addClass('is-invalid');
        },
        unhighlight: function (element) {
            var $formGroup = $(element).closest(".form-group");
            $formGroup.find(".form-control").removeClass('is-invalid');
            $formGroup.find(".form-control").addClass('is-valid');
        }
    };

    $.validator.setDefaults(defaultOptions);
})();