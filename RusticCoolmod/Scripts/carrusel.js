let arr = ["../Assets/Carrusel/aorus.jpg", "../Assets/Carrusel/corsair.jpg", "../Assets/Carrusel/rtx.jpg", "../Assets/Carrusel/ryzen.jpg"];
let i = 0;

function main() {
    timeout();
}


function timeout() {
    let pic = document.getElementById("pic");
    setTimeout(function () {
        $("#pic").fadeOut();
        setTimeout(function () {
            pic.src = arr[i];
        }, 400);
        $("#pic").fadeIn();
        if (i == arr.length - 1) {
            i = 0;
        }
        else i++;
        timeout();
    }, 3000);
}

window.addEventListener('load', main, false);