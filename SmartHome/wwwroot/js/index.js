/* ------------------------------------------------------------sidebar----------------------------------------*/
const sidebar = document.querySelector("#sidebar");
const sidebarBtn = document.querySelector("#sidebar-button");

sidebarBtn.addEventListener("click", () => {
    sidebar.classList.toggle("active");
})
/* --------------------------------------------------Change the weather background----------------------------*/
const currentTime = new Date().getHours();
const weatherContainer = document.querySelector(".weather-container");
if(weatherContainer !=null){
if (currentTime >= 6 && currentTime <= 19) {
	weatherContainer.classList.remove("night");
} else {
	weatherContainer.classList.add("night");
}
}

