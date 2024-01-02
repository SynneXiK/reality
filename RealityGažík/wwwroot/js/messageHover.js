document.addEventListener('DOMContentLoaded', function () {
    var messages = document.querySelectorAll('.singleMessage');

    messages.forEach(function (message) {
        message.addEventListener('mouseover', function () {
            var textTime = message.querySelector('.textTime');
            textTime.classList.add('textTimeOnHover');
        });

        message.addEventListener('mouseout', function () {
            var textTime = message.querySelector('.textTime');
            textTime.classList.remove('textTimeOnHover');
        });
    });
});