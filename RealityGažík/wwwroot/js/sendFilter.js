      $("#submitFilter").on('click', function (e) {
          e.preventDefault();
          var newCount = parseInt($("#count").val(), 10);

            var filter = {
                lowestPrice: $("#lowestPrice").val(),
                highestPrice: $("#highestPrice").val(),
                region: $("#aspect").val(),
                areaMin: $("#areaMin").val(),
                areaMax: $("#areaMax").val(),
                count: $("#count").val(),
                categoryId: $("#categoryid").val(),
            }

            const jsonString = `{"lowestPrice":${filter.lowestPrice},"highestPrice":${filter.highestPrice},"region":"${filter.region}","areaMin":${filter.areaMin},"areaMax":${filter.areaMax},"count":${filter.count},"categoryId":${filter.categoryId}}`;

            const base64 = btoa(jsonString);
            window.history.pushState(null, null, '?filter=' + base64);


            $.ajax({
                type: "POST",
                url: '/api/offers',
                data: filter,
            }).then(function (data) {
                var numOffers = $(data).filter('.nabidka').length;

                $(".nabidkaMenu").html(data);

                if (numOffers <= newCount) {
                    $("#showmore").hide();
                }
            });
        })
    $("#showmore").on('click', function (e) {
        e.preventDefault();
        var newCount = parseInt($("#count").val(), 10) + 6;

        $("#count").val(newCount);
        var filter = {
            lowestPrice: $("#lowestPrice").val(),
            highestPrice: $("#highestPrice").val(),
            region: $("#aspect").val(),
            areaMin: $("#areaMin").val(),
            areaMax: $("#areaMax").val(),
            count: newCount,
            categoryId: $("#categoryid").val(),
            }
    const jsonString = `{"lowestPrice":${filter.lowestPrice},"highestPrice":${filter.highestPrice},"region":"${filter.region}","areaMin":${filter.areaMin},"areaMax":${filter.areaMax},"count":${filter.count},"categoryId":${filter.categoryId}}`;

    const base64 = btoa(jsonString);
    window.history.pushState(null, null, '?filter=' + base64);

    $.ajax({
        type: "POST",
    url: '/api/offers',
    data: filter,
    }).then(function (data) {
        var numOffers = $(data).filter('.nabidka').length;

        $(".nabidkaMenu").html(data);

        if (numOffers <= newCount) {
            $("#showmore").hide();
        }
        });
    })


