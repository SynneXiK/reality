document.addEventListener("DOMContentLoaded", function () {
    var extraTextboxContainer = document.getElementById("extraTextboxContainer");
    var addTextboxButton = document.getElementById("addTextboxButton");

    function addNewTextbox() {
        var newTextbox = document.createElement("input");
        newTextbox.type = "text";

        extraTextboxContainer.appendChild(newTextbox);
    }

    addTextboxButton.addEventListener("click", addNewTextbox);

});
