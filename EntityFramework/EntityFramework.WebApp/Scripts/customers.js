$(function () {
    $("input[data-customers-autocomplete]").each(function () {
        var $input = $(this);

        var submitAutoCompleteForm = function (event, ui) {

            var $input = $(this);
            $input.val(ui.item.label);

            var $form = $input.parents("form:first");
            $form.submit();
        };

        var options = {
            source: $input.attr("data-customers-autocomplete"),
            select: submitAutoCompleteForm
        };

        $input.autocomplete(options);
    });
});