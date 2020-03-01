$(document).ready(function () {
    applyDatePicker();

    $('.multiple').select2();

    $(function () {
        $.validator.methods.date = function (value, element) {
            return this.optional(element) || moment(value, "DD/MM/YYYY", true).isValid();
        }
    });
});

function applyDatePicker() {
    $('.datepicker').datepicker({
        format: 'dd/mm/yyyy',
    });
}
