$(document).ready(function () {
    applyDatePicker();

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