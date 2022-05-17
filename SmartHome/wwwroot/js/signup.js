/* -------------------------------------  Show Image after Select it ---------------------------------------*/
const formImage = document.getElementById("form-image");
const imageURL = document.getElementById("image-url");

if (imageURL !== null) {
    imageURL.addEventListener("change", (event) => {
        formImage.src = URL.createObjectURL(event.target.files[0]);
        formImage.style.visibility = "visible";
    });
}
/* ------------------------------------------------------------Show/Hide user details----------------------------------------*/
const userType = document.getElementById("userType");
const homeUser = document.querySelectorAll(".home-user");
const appUser = document.querySelectorAll(".app-user");
const allUser = document.querySelectorAll(".all-user");

userType.addEventListener("change", () => {
    allUser.forEach(user => {
        user.classList.add("d-flex");
        user.classList.remove("d-none");
    });
    homeUser.forEach(user => {
        if (userType.value == "1") {
            user.classList.add("d-flex");
            user.classList.remove("d-none");
        }
        else {
            user.classList.remove("d-flex");
            user.classList.add("d-none");
        }
    });

    appUser.forEach(user => {
        if (userType.value == "2") {
            user.classList.add("d-flex");
            user.classList.remove("d-none");
        }
        else {
            user.classList.remove("d-flex");
            user.classList.add("d-none");
        }
    });
});

document.addEventListener("DOMContentLoaded", () => {
    allUser.forEach(user => {
        user.classList.add("d-flex");
        user.classList.remove("d-none");
    });
    if (userType.value == "1") {
        user.classList.add("d-flex");
        user.classList.remove("d-none");
    }
    else {
        user.classList.remove("d-flex");
        user.classList.add("d-none");
    }
});

