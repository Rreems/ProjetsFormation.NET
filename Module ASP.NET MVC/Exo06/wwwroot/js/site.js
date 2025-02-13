// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let movieSeen = true;

const movieStatusBtnElement = document.querySelector("#movie-status")

const switchButton = (event) => {
    if (movieSeen) {
        movieStatusBtnElement.className = "button-class button-status--checked";
        movieStatusBtnElement.textContent = "☑";
    } else {
        movieStatusBtnElement.className = "button-class button-status--unchecked";
        movieStatusBtnElement.textContent = "☐";
    }
    movieSeen = !movieSeen;
};

movieStatusBtnElement.addEventListener('click', switchButton);

switchButton();