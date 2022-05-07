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

/* --------------------------------------------------Edit/Remove Devices to page----------------------------*/

$("#edit-button").click(function () {
	$(".devices-layer").addClass("clicked");
});

$("#close-button").click(function () {
	$(".devices-layer").removeClass("clicked");
})



