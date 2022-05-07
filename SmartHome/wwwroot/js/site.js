/* ------------------------------------------------------------sidebar----------------------------------------*/
const sidebar = document.querySelector("#sidebar");
const sidebarBtn = document.querySelector("#sidebar-button");
sidebarBtn.addEventListener("click", () => {
    sidebar.classList.toggle("active");
});

const sidebarElement = window.location.pathname.split('/');
let elementName = "";
if (sidebarElement.length > 1) {
     elementName = sidebarElement[1];
}

const currentLink = document.getElementById(elementName);
const movieBtn = document.querySelectorAll(".btn-active");
if (currentLink != null) {
    movieBtn.forEach(btn => {
        btn.classList.remove("active");
    })
    currentLink.classList.add("active");
}

