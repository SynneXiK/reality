let rangeMin = 100;
const range = document.querySelector(".range-selected");
const rangeInput = document.querySelectorAll(".range-input input");
const rangePrice = document.querySelectorAll(".range-price input");

rangeInput.forEach((input) => {
    input.addEventListener("change", (e) => {
        let minRange = parseInt(rangeInput[0].value);
        let maxRange = parseInt(rangeInput[1].value);
        if (maxRange - minRange < rangeMin) {
            if (e.target.className === "min") {
                rangeInput[0].value = maxRange - rangeMin;
            } else {
                rangeInput[1].value = minRange + rangeMin;
            }
        } else {
            rangePrice[0].value = minRange;
            rangePrice[1].value = maxRange;
            range.style.left = (minRange / rangeInput[0].max) * 100 + "%";
            range.style.right = 100 - (maxRange / rangeInput[1].max) * 100 + "%";
        }
    });
});

rangePrice.forEach((input) => {
    input.addEventListener("change", (e) => {
        let minPrice = rangePrice[0].value;
        let maxPrice = rangePrice[1].value;
        if (maxPrice - minPrice >= rangeMin && maxPrice <= rangeInput[1].max) {
            if (e.target.className === "min") {
                rangeInput[0].value = minPrice;
                range.style.left = (minPrice / rangeInput[0].max) * 100 + "%";
            } else {
                rangeInput[1].value = maxPrice;
                range.style.right = 100 - (maxPrice / rangeInput[1].max) * 100 + "%";
            }
        }
    });
});

let rangeMinArea = 100;
const rangeArea = document.querySelector(".range-selectedArea");
const rangeInputArea = document.querySelectorAll(".range-inputArea input");
const rangePriceArea = document.querySelectorAll(".range-area input");

rangeInputArea.forEach((input) => {
    input.addEventListener("change", (e) => {
        let minRange = parseInt(rangeInputArea[0].value);
        let maxRange = parseInt(rangeInputArea[1].value);
        if (maxRange - minRange < rangeMin) {
            if (e.target.className === "min") {
                rangeInputArea[0].value = maxRange - rangeMin;
            } else {
                rangeInputArea[1].value = minRange + rangeMin;
            }
        } else {
            rangePriceArea[0].value = minRange;
            rangePriceArea[1].value = maxRange;
            rangeArea.style.left = (minRange / rangeInputArea[0].max) * 100 + "%";
            rangeArea.style.right = 100 - (maxRange / rangeInputArea[1].max) * 100 + "%";
        }
    });
});

rangePriceArea.forEach((input) => {
    input.addEventListener("change", (e) => {
        let minPrice = rangePriceArea[0].value;
        let maxPrice = rangePriceArea[1].value;
        if (maxPrice - minPrice >= rangeMin && maxPrice <= rangeInputArea[1].max) {
            if (e.target.className === "min") {
                rangeInputArea[0].value = minPrice;
                rangeArea.style.left = (minPrice / rangeInputArea[0].max) * 100 + "%";
            } else {
                rangeInputArea[1].value = maxPrice;
                rangeArea.style.right = 100 - (maxPrice / rangeInputArea[1].max) * 100 + "%";
            }
        }
    });
});