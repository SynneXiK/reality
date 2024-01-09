const favorites = document.querySelectorAll('#favoriteSubmit');
favorites.forEach((input) => {
    input.addEventListener('click', function (e) {
        e.preventDefault();
        let offer = input.childNodes[1];
        console.log(input);


        var formData = {
            id: "0",
            idOffer: $(offer).val(),
            idUser: $("#idUser").val(),
        };
        $.ajax({
            type: "POST",
            url: "/api/favorite",
            data: formData,
        }).done(function (data) {
            console.log(data);
        });

        let star = input.childNodes[3];
        star.classList.toggle('bi-star-fill');
        star.classList.toggle('bi-star');
    })
})