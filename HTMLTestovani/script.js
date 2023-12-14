'use strict';

// alert('Alert ze souboru');

// const para = document.querySelector('p');
// console.log('para', para);

//para.innerText = 'Nový text';
// para.innerHTML = '<strong>Nový text</strong>';

// para.style.color = 'red';
// para.style.backgroundColor = 'yellow';

// para.classList.add('alert', 'blue');
// para.classList.remove('alert');
// para.classList.toggle('alert');
// para.classList.contains('alert');

// para.addEventListener('click', changeToAlert);
//
// function changeToAlert(){
//     para.classList.toggle('alert');
//     para.style.fontFamily = 'Comic Sans MS';
// }

const paras = document.querySelectorAll('p');
paras.forEach((p) => {
    p.addEventListener('click', () => {
        p.classList.toggle('alert');

        p.querySelector('span').classList.add('alert');
    });
});

const tableParts = document.querySelectorAll('td');
tableParts.forEach((x) => {
    x.addEventListener('click', () => {
        x.classList.toggle('yellow');
    });
});

