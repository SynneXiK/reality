document.addEventListener('DOMContentLoaded', function () {
    var messages = document.querySelectorAll('.singleMessage');

    messages.forEach(function (message) {
        message.addEventListener('mouseover', function () {
            // On hover, add the class 'hovered' to the 'textTime' element
            var textTime = message.querySelector('.textTime');
            textTime.classList.add('textTimeOnHover');
        });

        message.addEventListener('mouseout', function () {
            // On mouseout, remove the class 'hovered' from the 'textTime' element
            var textTime = message.querySelector('.textTime');
            textTime.classList.remove('textTimeOnHover');
        });
    });
});