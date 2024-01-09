const mainImage = document.querySelector('.mainImg');
const thumbnailImages = document.querySelectorAll('.imageSliderImage');

thumbnailImages.forEach(thumbnail => {
    thumbnail.addEventListener('click', () => {
        const tempSrc = mainImage.src;
        mainImage.src = thumbnail.src;
        thumbnail.src = tempSrc;
    });
});