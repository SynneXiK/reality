document.addEventListener("DOMContentLoaded", function () {
    const labelsDiv = document.querySelector('.labelsInputs');
    const selectElement = document.getElementById('labelSelect');

    selectElement.addEventListener('change', function () {
        const selectedLabelName = selectElement.options[selectElement.selectedIndex].text;

        const newDiv = document.createElement('div');

        const hiddenId = document.createElement('input');
        hiddenId.type = 'hidden';
        hiddenId.value = selectElement.options[selectElement.selectedIndex].value;
        newDiv.appendChild(hiddenId);

        const labelSpan = document.createElement('span');
        labelSpan.textContent = selectedLabelName;
        newDiv.appendChild(labelSpan);

        const inputText = document.createElement('input');
        inputText.type = 'text';
        newDiv.appendChild(inputText);

        labelsDiv.appendChild(newDiv);
        selectElement.options[selectElement.selectedIndex].style.display = 'none';
    });
});

const submitButton = $('#submitButton');
const hiddenId = $('#offerid').val();

$('#submitButton').on('click', function () {
    $('.labelsInputs div').each(function () {
        const labelId = $(this).find('input[type="hidden"]').val();
        const inputValue = $(this).find('input[type="text"]').val();

        var value = {
            id: 0,
            idLabel: labelId,
            idOffer: hiddenId,
            value: inputValue,
        }
        console.log(value);
        $.ajax({
            type: "POST",
            url: '/api/value',
            data: value,
        });
    });
});