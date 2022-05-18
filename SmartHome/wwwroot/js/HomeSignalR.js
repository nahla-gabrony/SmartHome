"use strict";
var connectionAlert = new signalR.HubConnectionBuilder().withUrl("/dashboardHub").build();
connectionAlert.start().then(function () {
	InvokeDevicesSystems();
	InvokeNotificationsSystems();

}).catch(function (err) {
	return console.error(err.toString());
});

// Devices 
function InvokeDevicesSystems() {
	connectionAlert.invoke("SendDevicesData").catch(function (err) {
		return console.error(err.toString());
	});
}
connectionAlert.on("ReceivedDevicesData", function (data) {
	BindHomeSystemToGrid(data);
	BindGarageSystemToGrid(data);
	BindDevice(data);
});

// Home System
function BindHomeSystemToGrid(data) {
	$('#tblHomeSystems tbody').empty();

	var tr;
	$.each(data, function (index, data) {
		if (data.deviceId == 1 || data.deviceId == 3 || data.deviceId == 4 || data.deviceId == 5) {
			tr = $('<tr class="alert-secondary"/>');
			var style = data.status == 1 ? "bg-danger" : "bg-success";
			if (data.deviceId == 1) {
				var text = data.status == 1 ? "Unsafe" : "Safe";
				var system = "Home Security";
				var icon = "fas fa-hotel";

			}
			else if (data.deviceId == 3) {
				var text = data.status == 1 ? "Fire" : "Safe";
				var system = "Fire System";
				var icon = "fas fa-fire-extinguisher";
			}
			else if (data.deviceId == 4) {
				var text = data.status == 1 ? "Smoke" : "Safe";
				var system = "Smoke System";
				var icon = "fab fa-gripfire";
			}
			else if (data.deviceId == 5) {
				style = data.status == 1 ? "bg-success" : "bg-danger";
				var text = data.status == 1 ? "On" : "Off";
				var system = "Outdoor Light";
				var icon = "far fa-lightbulb";
			}
			tr.append(`<td><i class=" ${icon} fs-4 p-2"></i></td>`);
			tr.append(`<td><span>${system}</span></td>`);
			tr.append(`<td class="status">
                        <span class="badge fs-6 ${style}">${text}</span>
                        </td>`);
			tr.append(`<td>
						<button class="btn-notification" onclick ="historyLocation(${data.deviceId})">
							<i class="fas fa-history history-icon fs-3"></i>  </a>
						</button>   
						</td>`);

			$('#tblHomeSystems').append(tr);

		}
	});
}
// Garage System
function BindGarageSystemToGrid(data) {
	$('#tblGarageSystems tbody').empty();
	var tr;
	$.each(data, function (index, data) {
		if (data.deviceId == 38 || data.deviceId == 39 || data.deviceId == 40 || data.deviceId == 42) {
			tr = $('<tr class="alert-secondary"/>');
			var style = data.status == 1 ? "bg-danger" : "bg-success";
			if (data.deviceId == 38) {
				var text = data.status == 1 ? "Unsafe" : "Safe";
				var system = "Garage Security";
				var icon = "fas fa-warehouse";
			}
			else if (data.deviceId == 39) {
				var text = data.status == 1 ? "Busy" : "Empty";
				var system = "Left Parking";
				var icon = "fas fa-parking";
			}
			else if (data.deviceId == 40) {
				var text = data.status == 1 ? "Busy" : "Empty";
				var system = "Right Parking";
				var icon = "fas fa-parking";
			}
			else if (data.deviceId == 42) {
				style = data.status == 1 ? "bg-success" : "bg-danger";
				var text = data.status == 1 ? "On" : "Off";
				var system = "Garage Light";
				var icon = "far fa-lightbulb";
			}
			tr.append(`<td><i class=" ${icon} fs-4 p-2"></i></td>`);
			tr.append(`<td><span>${system}</span></td>`);
			tr.append(`<td class="status">
                        <span class="badge fs-6 ${style}">${text}</span>
                        </td>`);
			tr.append(`<td>
						<button class="btn-notification" onclick ="historyLocation(${data.deviceId})">
							<i class="fas fa-history history-icon fs-3"></i>  </a>
						</button>   
						</td>`);

			$('#tblGarageSystems').append(tr);

		}
	});
	
}
// Room One
let airStatusRoomOne = "";
let soundStatusRoomOne = "";
let lightStatusRoomOne = "";

// Room Two
let airStatusRoomTwo = "";
let soundStatusRoomTwo = "";
let lightStatusRoomTwo = "";

// Room Three
let airStatusRoomThree = "";
let soundStatusRoomThree = "";
let lightStatusRoomThree = "";

// Living Room
let airStatusLiving = "";
let soundStatusLiving = "";
let lightStatusLiving = "";

// Dining Room
let airStatusDining = "";
let soundStatusDining = "";
let lightStatusDining = "";

// Office Room
let airStatusOffice = "";
let soundStatusOffice = "";
let lightStatusOffice = "";

function BindDevice(data) {
	//Main System
	$('#homeDoor').empty();
	$('#outdoorLight').empty();

	//Storager Room
	$('#storageDoor').empty();
	$('#storageLight').empty();

	//Rooms
	$('.tv-checkbox').empty();
	$('.door-checkbox').empty();
	$('.sound-checkbox').empty();
	$('.light-checkbox').empty();
	$('.ac-checkbox').empty();
	$('.rs-tooltip').empty();

	//Garage System
	$('#garageDoor').empty();
	$('#garageLight').empty();

	// Garden
	$('#WaterTank').empty();
	$('#WaterTankProgress').empty();
	$('#garden').empty();
	$('#gardenProgress').empty();

	$.each(data, function (index, data) {
		//Main System
		if (data.deviceId == 2 || data.deviceId == 5) {
			if (data.deviceId == 2) {
				if (data.status == 1) {
					$('#homeDoor').append(`<input class="form-check-input send-checkbox input-checkbox mb-2" type="checkbox"  data-id="2" checked />`);
					$('#homeDoor').append(` <label class="form-check-label label-checkbox fw-bold"   data-id="2" > Open  </label>`);
				}
				else {
					$('#homeDoor').append(`<input class="form-check-input send-checkbox input-checkbox mb-2" type="checkbox" id="flexSwitchCheckChecked" data-id="2"/>`);
					$('#homeDoor').append(` <label class="form-check-label label-checkbox fw-bold"  for="flexSwitchCheckChecked" data-id="2" > Close  </label>`);
				}

			}
			else if (data.deviceId == 5) {
				if (data.status == 1) {
					$('#outdoorLight').append(`<input class="form-check-input send-checkbox input-checkbox mb-2" type="checkbox" id="flexSwitchCheckChecked" data-id="5" checked />`);
					$('#outdoorLight').append(` <label class="form-check-label label-checkbox fw-bold"  for="flexSwitchCheckChecked" data-id="5"> On  </label>`);
				}
				else {
					$('#outdoorLight').append(`<input class="form-check-input send-checkbox input-checkbox mb-2" type="checkbox" id="flexSwitchCheckChecked" data-id="5"/>`);
					$('#outdoorLight').append(`<label class="form-check-label label-checkbox fw-bold"  for="flexSwitchCheckChecked" data-id="5"> Off  </label>`);
				}

			}
		}
	
		//Bedroom 1
		if (data.deviceId == 8 || data.deviceId == 9 || data.deviceId == 10 || data.deviceId == 11 || data.deviceId == 12) {


			if (data.deviceId == 8) {
				if (data.status == 1) {
					$('#RoomOne .tv-checkbox').append(`<input type="checkbox" class="checkbox send-checkbox" checked  data-id="8"/>`);
					$('#RoomOne .tv-checkbox').append(`<div class="checkbox-btn"></div>`);
					$('#RoomOne .tv-checkbox').append(` <div class="checkbox-layer" ></div>`);
				}
				else {
					$('#RoomOne .tv-checkbox').append(`<input type="checkbox" class="checkbox send-checkbox"  data-id="8"/>`);
					$('#RoomOne .tv-checkbox').append(`<div class="checkbox-btn" ></div>`);
					$('#RoomOne .tv-checkbox').append(`<div class="checkbox-layer" ></div>`);
				}

			}
			else if (data.deviceId == 9) {
				if (data.status == 1) {
					$('#RoomOne .door-checkbox').append(`<input type="checkbox" class="checkbox send-checkbox" checked  data-id="9"/>`);
					$('#RoomOne .door-checkbox').append(`<div class="checkbox-btn-door"></div>`);
					$('#RoomOne .door-checkbox').append(` <div class="checkbox-layer" ></div>`);
				}
				else {
					$('#RoomOne .door-checkbox').append(`<input type="checkbox" class="checkbox send-checkbox"  data-id="9"/>`);
					$('#RoomOne .door-checkbox').append(`<div class="checkbox-btn-door" ></div>`);
					$('#RoomOne .door-checkbox').append(`<div class="checkbox-layer" ></div>`);
				}

			}



			else if (data.deviceId == 10) {
				if (data.status >= 1) {
					soundStatusRoomOne = data.status;

					$('#RoomOne .sound-checkbox').append(`<input type="hidden" class="input-checkbox"   data-id="10" data-value="0" />`);
					$('#RoomOne .sound-checkbox').append(`<input type="checkbox" class="slider-checkbox" checked  data-id="10"/>`);
					$('#RoomOne .sound-checkbox').append(`<div class="checkbox-btn"></div>`);
					$('#RoomOne .sound-checkbox').append(` <div class="checkbox-layer" ></div>`);


					let SoundSliderdegree = (soundStatusRoomOne * 2.7) + 315;
					$("#RoomOne #sound-slider .rs-first").css("transform", `rotate(${SoundSliderdegree}deg)`);
					$("#RoomOne #sound-slider .rs-path-color:first").css("transform", `rotate(${SoundSliderdegree}deg)`);
					$("#RoomOne #sound-slider .rs-range-color:not(:first)").css("transform", `rotate(${SoundSliderdegree - 180}deg)`);

					$('#RoomOne #sound-slider .rs-tooltip').append(soundStatusRoomOne);
					$('#RoomOne input[name=sound-slider]').val(soundStatusRoomOne);
					$("#RoomOne #sound-slider .rs-handle").attr("aria-valuenow", soundStatusRoomOne);
					$("#RoomOne #sound-slider .sound-gradient").css("background", `hsl(${-255 + (soundStatusRoomOne * 5.1)}, 100%, 57%)`);

				}
				else {
					$('#RoomOne .sound-checkbox').append(`<input type="hidden" class="input-checkbox"   data-id="10" data-value="${soundStatusRoomOne}" />`);
					$('#RoomOne .sound-checkbox').append(`<input type="checkbox" class="slider-checkbox" />`);
					$('#RoomOne .sound-checkbox').append(`<div class="checkbox-btn" ></div>`);
					$('#RoomOne .sound-checkbox').append(`<div class="checkbox-layer" ></div>`);

				}

			}

			else if (data.deviceId == 11) {
				if (data.status >= 1) {

					lightStatusRoomOne = data.status;

					$('#RoomOne .light-checkbox').append(`<input type="hidden" class="input-checkbox"   data-id="11" data-value="0" />`);
					$('#RoomOne .light-checkbox').append(`<input type="checkbox" class="slider-checkbox" checked />`);
					$('#RoomOne .light-checkbox').append(`<div class="checkbox-btn"></div>`);
					$('#RoomOne .light-checkbox').append(` <div class="checkbox-layer" ></div>`);


					let lightSliderDegree = (lightStatusRoomOne * 2.7) + 315;
					$("#RoomOne #light-slider .rs-first").css("transform", `rotate(${lightSliderDegree}deg)`);
					$("#RoomOne #light-slider .rs-path-color:first").css("transform", `rotate(${lightSliderDegree}deg)`);
					$("#RoomOne #light-slider .rs-range-color:not(:first)").css("transform", `rotate(${lightSliderDegree - 180}deg)`);


					$('#RoomOne #light-slider .rs-tooltip').append(lightStatusRoomOne);
					$('#RoomOne input[name=light-slider]').val(lightStatusRoomOne);
					$("#RoomOne #light-slider .rs-handle").attr("aria-valuenow", lightStatusRoomOne);
					$("#RoomOne #light-slider .light-gradient").css("background", `hsl(${-255 + (lightStatusRoomOne * 5.1)}, 100%, 57%)`);

				}
				else {
					$('#RoomOne .light-checkbox').append(`<input type="hidden" class="input-checkbox"   data-id="11" data-value="${lightStatusRoomOne}" />`);
					$('#RoomOne .light-checkbox').append(`<input type="checkbox" class="slider-checkbox" />`);
					$('#RoomOne .light-checkbox').append(`<div class="checkbox-btn" ></div>`);
					$('#RoomOne .light-checkbox').append(`<div class="checkbox-layer" ></div>`);

				}

			}

			else if (data.deviceId == 12) {

				if (data.status > 10) {

					airStatusRoomOne = data.status;

					$('#RoomOne .ac-checkbox').append(`<input type="hidden" class="input-checkbox"   data-id="12" data-value="0" />`);
					$('#RoomOne .ac-checkbox').append(`<input type="checkbox" class="slider-checkbox" data-id="12" checked />`);
					$('#RoomOne .ac-checkbox').append(`<div class="checkbox-btn"></div>`);
					$('#RoomOne .ac-checkbox').append(` <div class="checkbox-layer" ></div>`);


					let airSliderDegree = (airStatusRoomOne * 5.4) + 261;
					$("#RoomOne #air-slider .rs-first").css("transform", `rotate(${airSliderDegree}deg)`);
					$("#RoomOne #air-slider .rs-path-color:first").css("transform", `rotate(${airSliderDegree}deg)`);
					$("#RoomOne #air-slider .rs-range-color:not(:first)").css("transform", `rotate(${airSliderDegree - 180}deg)`);


					$('#RoomOne #air-slider .rs-tooltip').append(airStatusRoomOne);
					$('#RoomOne input[name=air-slider]').val(airStatusRoomOne);
					$("#RoomOne #air-slider .rs-handle").attr("aria-valuenow", airStatusRoomOne);
					$("#RoomOne #air-slider .air-gradient").css("background", `hsl(${-255 + (airStatusRoomOne * 4.25)}, 100%, 57%)`);
				}

				else {
					$('#RoomOne .ac-checkbox').append(`<input type="hidden" class="input-checkbox"   data-id="12" data-value="${airStatusRoomOne}" />`);
					$('#RoomOne .ac-checkbox').append(`<input type="checkbox" class="slider-checkbox"/>`);
					$('#RoomOne .ac-checkbox').append(`<div class="checkbox-btn" ></div>`);
					$('#RoomOne .ac-checkbox').append(`<div class="checkbox-layer" ></div>`);

				}

			}
		}

		//Bedroom 2
		else if (data.deviceId == 13 || data.deviceId == 14 || data.deviceId == 15 || data.deviceId == 16 || data.deviceId == 17) {


			if (data.deviceId == 13) {
				if (data.status == 1) {
					$('#RoomTwo .tv-checkbox').append(`<input type="checkbox" class="checkbox send-checkbox" checked  data-id="13"/>`);
					$('#RoomTwo .tv-checkbox').append(`<div class="checkbox-btn"></div>`);
					$('#RoomTwo .tv-checkbox').append(` <div class="checkbox-layer" ></div>`);
				}
				else {
					$('#RoomTwo .tv-checkbox').append(`<input type="checkbox" class="checkbox send-checkbox"  data-id="13"/>`);
					$('#RoomTwo .tv-checkbox').append(`<div class="checkbox-btn" ></div>`);
					$('#RoomTwo .tv-checkbox').append(`<div class="checkbox-layer" ></div>`);
				}

			}
			else if (data.deviceId == 14) {
				if (data.status == 1) {
					$('#RoomTwo .door-checkbox').append(`<input type="checkbox" class="checkbox send-checkbox" checked  data-id="14"/>`);
					$('#RoomTwo .door-checkbox').append(`<div class="checkbox-btn-door"></div>`);
					$('#RoomTwo .door-checkbox').append(` <div class="checkbox-layer" ></div>`);
				}
				else {
					$('#RoomTwo .door-checkbox').append(`<input type="checkbox" class="checkbox"  data-id="14"/>`);
					$('#RoomTwo .door-checkbox').append(`<div class="checkbox-btn-door" ></div>`);
					$('#RoomTwo .door-checkbox').append(`<div class="checkbox-layer" ></div>`);
				}

			}


			else if (data.deviceId == 15) {
				if (data.status >= 1) {
					soundStatusRoomTwo = data.status;

					$('#RoomTwo .sound-checkbox').append(`<input type="hidden" class="input-checkbox"   data-id="15" data-value="0" />`);
					$('#RoomTwo .sound-checkbox').append(`<input type="checkbox" class="slider-checkbox" checked  data-id="15"/>`);
					$('#RoomTwo .sound-checkbox').append(`<div class="checkbox-btn"></div>`);
					$('#RoomTwo .sound-checkbox').append(` <div class="checkbox-layer" ></div>`);


					let SoundSliderdegree = (soundStatusRoomTwo * 2.7) + 315;
					$("#RoomTwo #sound-slider .rs-first").css("transform", `rotate(${SoundSliderdegree}deg)`);
					$("#RoomTwo #sound-slider .rs-path-color:first").css("transform", `rotate(${SoundSliderdegree}deg)`);
					$("#RoomTwo #sound-slider .rs-range-color:not(:first)").css("transform", `rotate(${SoundSliderdegree - 180}deg)`);

					$('#RoomTwo #sound-slider .rs-tooltip').append(soundStatusRoomTwo);
					$('#RoomTwo input[name=sound-slider]').val(soundStatusRoomTwo);
					$("#RoomTwo #sound-slider .rs-handle").attr("aria-valuenow", soundStatusRoomTwo);
					$("#RoomTwo #sound-slider .sound-gradient").css("background", `hsl(${-255 + (soundStatusRoomTwo * 5.1)}, 100%, 57%)`);

				}
				else {
					$('#RoomTwo .sound-checkbox').append(`<input type="hidden" class="input-checkbox"   data-id="15" data-value="${soundStatusRoomTwo}" />`);
					$('#RoomTwo .sound-checkbox').append(`<input type="checkbox" class="slider-checkbox" />`);
					$('#RoomTwo .sound-checkbox').append(`<div class="checkbox-btn" ></div>`);
					$('#RoomTwo .sound-checkbox').append(`<div class="checkbox-layer" ></div>`);

				}

			}

			else if (data.deviceId == 16) {
				if (data.status >= 1) {

					lightStatusRoomTwo = data.status;

					$('#RoomTwo .light-checkbox').append(`<input type="hidden" class="input-checkbox"   data-id="16" data-value="0" />`);
					$('#RoomTwo .light-checkbox').append(`<input type="checkbox" class="slider-checkbox" checked />`);
					$('#RoomTwo .light-checkbox').append(`<div class="checkbox-btn"></div>`);
					$('#RoomTwo .light-checkbox').append(` <div class="checkbox-layer" ></div>`);


					let lightSliderDegree = (lightStatusRoomTwo * 2.7) + 315;
					$("#RoomTwo #light-slider .rs-first").css("transform", `rotate(${lightSliderDegree}deg)`);
					$("#RoomTwo #light-slider .rs-path-color:first").css("transform", `rotate(${lightSliderDegree}deg)`);
					$("#RoomTwo #light-slider .rs-range-color:not(:first)").css("transform", `rotate(${lightSliderDegree - 180}deg)`);


					$('#RoomTwo #light-slider .rs-tooltip').append(lightStatusRoomTwo);
					$('#RoomTwo input[name=light-slider]').val(lightStatusRoomTwo);
					$("#RoomTwo #light-slider.rs-handle").attr("aria-valuenow", lightStatusRoomTwo);
					$("#RoomTwo #light-slider .light-gradient").css("background", `hsl(${-255 + (lightStatusRoomTwo * 5.1)}, 100%, 57%)`);

				}
				else {
					$('#RoomTwo .light-checkbox').append(`<input type="hidden" class="input-checkbox"   data-id="16" data-value="${lightStatusRoomTwo}" />`);
					$('#RoomTwo .light-checkbox').append(`<input type="checkbox" class="slider-checkbox" />`);
					$('#RoomTwo .light-checkbox').append(`<div class="checkbox-btn" ></div>`);
					$('#RoomTwo .light-checkbox').append(`<div class="checkbox-layer" ></div>`);

				}

			}

			else if (data.deviceId == 17) {

				if (data.status > 10) {

					airStatusRoomTwo = data.status;

					$('#RoomTwo .ac-checkbox').append(`<input type="hidden" class="input-checkbox"   data-id="17" data-value="0" />`);
					$('#RoomTwo .ac-checkbox').append(`<input type="checkbox" class="slider-checkbox" data-id="17" checked />`);
					$('#RoomTwo .ac-checkbox').append(`<div class="checkbox-btn"></div>`);
					$('#RoomTwo .ac-checkbox').append(` <div class="checkbox-layer" ></div>`);


					let airSliderDegree = (airStatusRoomTwo * 5.4) + 261;
					$("#RoomTwo #air-slider .rs-first").css("transform", `rotate(${airSliderDegree}deg)`);
					$("#RoomTwo #air-slider .rs-path-color:first").css("transform", `rotate(${airSliderDegree}deg)`);
					$("#RoomTwo #air-slider .rs-range-color:not(:first)").css("transform", `rotate(${airSliderDegree - 180}deg)`);


					$('#RoomTwo #air-slider .rs-tooltip').append(airStatusRoomTwo);
					$('#RoomTwo input[name=air-slider]').val(airStatusRoomTwo);
					$("#RoomTwo #air-slider .rs-handle").attr("aria-valuenow", airStatusRoomTwo);
					$("#RoomTwo #air-slider .air-gradient").css("background", `hsl(${-255 + (airStatusRoomTwo * 4.25)}, 100%, 57%)`);
				}

				else {
					$('#RoomTwo .ac-checkbox').append(`<input type="hidden" class="input-checkbox"   data-id="17" data-value="${airStatusRoomTwo}" />`);
					$('#RoomTwo .ac-checkbox').append(`<input type="checkbox" class="slider-checkbox"/>`);
					$('#RoomTwo .ac-checkbox').append(`<div class="checkbox-btn" ></div>`);
					$('#RoomTwo .ac-checkbox').append(`<div class="checkbox-layer" ></div>`);

				}

			}
		}

		//Bedroom 3
		else if (data.deviceId == 18 || data.deviceId == 19 || data.deviceId == 20 || data.deviceId == 21 || data.deviceId == 22) {


			if (data.deviceId == 18) {
				if (data.status == 1) {
					$('#RoomThree .tv-checkbox').append(`<input type="checkbox" class="checkbox send-checkbox" checked  data-id="18"/>`);
					$('#RoomThree .tv-checkbox').append(`<div class="checkbox-btn"></div>`);
					$('#RoomThree .tv-checkbox').append(` <div class="checkbox-layer" ></div>`);
				}
				else {
					$('#RoomThree .tv-checkbox').append(`<input type="checkbox" class="checkbox send-checkbox"  data-id="18"/>`);
					$('#RoomThree .tv-checkbox').append(`<div class="checkbox-btn" ></div>`);
					$('#RoomThree .tv-checkbox').append(`<div class="checkbox-layer" ></div>`);
				}

			}
			else if (data.deviceId == 19) {
				if (data.status == 1) {
					$('#RoomThree .door-checkbox').append(`<input type="checkbox" class="checkbox send-checkbox" checked  data-id="19"/>`);
					$('#RoomThree .door-checkbox').append(`<div class="checkbox-btn-door"></div>`);
					$('#RoomThree .door-checkbox').append(` <div class="checkbox-layer" ></div>`);
				}
				else {
					$('#RoomThree .door-checkbox').append(`<input type="checkbox" class="checkbox send-checkbox"  data-id="19"/>`);
					$('#RoomThree .door-checkbox').append(`<div class="checkbox-btn-door" ></div>`);
					$('#RoomThree .door-checkbox').append(`<div class="checkbox-layer" ></div>`);
				}

			}


			else if (data.deviceId == 20) {
				if (data.status >= 1) {
					soundStatusRoomThree = data.status;

					$('#RoomThree .sound-checkbox').append(`<input type="hidden" class="input-checkbox"   data-id="20" data-value="0" />`);
					$('#RoomThree .sound-checkbox').append(`<input type="checkbox" class="slider-checkbox" checked  />`);
					$('#RoomThree .sound-checkbox').append(`<div class="checkbox-btn"></div>`);
					$('#RoomThree .sound-checkbox').append(` <div class="checkbox-layer" ></div>`);


					let SoundSliderdegree = (soundStatusRoomThree * 2.7) + 315;
					$("#RoomThree #sound-slider .rs-first").css("transform", `rotate(${SoundSliderdegree}deg)`);
					$("#RoomThree #sound-slider .rs-path-color:first").css("transform", `rotate(${SoundSliderdegree}deg)`);
					$("#RoomThree #sound-slider .rs-range-color:not(:first)").css("transform", `rotate(${SoundSliderdegree - 180}deg)`);

					$('#RoomThree #sound-slider .rs-tooltip').append(soundStatusRoomThree);
					$('#RoomThree input[name=sound-slider]').val(soundStatusRoomThree);
					$("#RoomThree #sound-slider .rs-handle").attr("aria-valuenow", soundStatusRoomThree);
					$("#RoomThree #sound-slider .sound-gradient").css("background", `hsl(${-255 + (soundStatusRoomThree * 5.1)}, 100%, 57%)`);

				}
				else {
					$('#RoomThree .sound-checkbox').append(`<input type="hidden" class="input-checkbox"   data-id="20" data-value="${soundStatusRoomThree}" />`);
					$('#RoomThree .sound-checkbox').append(`<input type="checkbox" class="slider-checkbox" />`);
					$('#RoomThree .sound-checkbox').append(`<div class="checkbox-btn" ></div>`);
					$('#RoomThree .sound-checkbox').append(`<div class="checkbox-layer" ></div>`);

				}

			}

			else if (data.deviceId == 21) {
				if (data.status >= 1) {

					lightStatusRoomThree = data.status;

					$('#RoomThree .light-checkbox').append(`<input type="hidden" class="input-checkbox"   data-id="21" data-value="0" />`);
					$('#RoomThree .light-checkbox').append(`<input type="checkbox" class="slider-checkbox" checked />`);
					$('#RoomThree .light-checkbox').append(`<div class="checkbox-btn"></div>`);
					$('#RoomThree .light-checkbox').append(` <div class="checkbox-layer" ></div>`);


					let lightSliderDegree = (lightStatusRoomThree * 2.7) + 315;
					$("#RoomThree #light-slider .rs-first").css("transform", `rotate(${lightSliderDegree}deg)`);
					$("#RoomThree #light-slider .rs-path-color:first").css("transform", `rotate(${lightSliderDegree}deg)`);
					$("#RoomThree #light-slider .rs-range-color:not(:first)").css("transform", `rotate(${lightSliderDegree - 180}deg)`);


					$('#RoomThree #light-slider .rs-tooltip').append(lightStatusRoomThree);
					$('#RoomThree input[name=light-slider]').val(lightStatusRoomThree);
					$("#RoomThree #light-slider.rs-handle").attr("aria-valuenow", lightStatusRoomThree);
					$("#RoomThree #light-slider .light-gradient").css("background", `hsl(${-255 + (lightStatusRoomThree * 5.1)}, 100%, 57%)`);

				}
				else {
					$('#RoomThree .light-checkbox').append(`<input type="hidden" class="input-checkbox"   data-id="21" data-value="${lightStatusRoomThree}" />`);
					$('#RoomThree .light-checkbox').append(`<input type="checkbox" class="slider-checkbox" />`);
					$('#RoomThree .light-checkbox').append(`<div class="checkbox-btn" ></div>`);
					$('#RoomThree .light-checkbox').append(`<div class="checkbox-layer" ></div>`);

				}

			}

			else if (data.deviceId == 22) {

				if (data.status > 10) {

					airStatusRoomThree = data.status;

					$('#RoomThree .ac-checkbox').append(`<input type="hidden" class="input-checkbox"   data-id="22" data-value="0" />`);
					$('#RoomThree .ac-checkbox').append(`<input type="checkbox" class="slider-checkbox"  checked />`);
					$('#RoomThree .ac-checkbox').append(`<div class="checkbox-btn"></div>`);
					$('#RoomThree .ac-checkbox').append(` <div class="checkbox-layer" ></div>`);


					let airSliderDegree = (airStatusRoomThree * 5.4) + 261;
					$("#RoomThree #air-slider .rs-first").css("transform", `rotate(${airSliderDegree}deg)`);
					$("#RoomThree #air-slider .rs-path-color:first").css("transform", `rotate(${airSliderDegree}deg)`);
					$("#RoomThree #air-slider .rs-range-color:not(:first)").css("transform", `rotate(${airSliderDegree - 180}deg)`);


					$('#RoomThree #air-slider .rs-tooltip').append(airStatusRoomThree);
					$('#RoomThree input[name=air-slider]').val(airStatusRoomThree);
					$("#RoomThree #air-slider .rs-handle").attr("aria-valuenow", airStatusRoomThree);
					$("#RoomThree #air-slider .air-gradient").css("background", `hsl(${-255 + (airStatusRoomThree * 4.25)}, 100%, 57%)`);
				}

				else {
					$('#RoomThree .ac-checkbox').append(`<input type="hidden" class="input-checkbox"   data-id="22" data-value="${airStatusRoomThree}" />`);
					$('#RoomThree .ac-checkbox').append(`<input type="checkbox" class="slider-checkbox"/>`);
					$('#RoomThree .ac-checkbox').append(`<div class="checkbox-btn" ></div>`);
					$('#RoomThree .ac-checkbox').append(`<div class="checkbox-layer" ></div>`);

				}

			}
		}

		//Living Room
		else if (data.deviceId == 23 || data.deviceId == 24 || data.deviceId == 25 || data.deviceId == 26 || data.deviceId == 27) {


			if (data.deviceId == 23) {
				if (data.status == 1) {
					$('#Living .tv-checkbox').append(`<input type="checkbox" class="checkbox send-checkbox" checked  data-id="23"/>`);
					$('#Living .tv-checkbox').append(`<div class="checkbox-btn"></div>`);
					$('#Living .tv-checkbox').append(` <div class="checkbox-layer" ></div>`);
				}
				else {
					$('#Living .tv-checkbox').append(`<input type="checkbox" class="checkbox send-checkbox"  data-id="23"/>`);
					$('#Living .tv-checkbox').append(`<div class="checkbox-btn" ></div>`);
					$('#Living .tv-checkbox').append(`<div class="checkbox-layer" ></div>`);
				}

			}
			else if (data.deviceId == 24) {
				if (data.status == 1) {
					$('#Living .door-checkbox').append(`<input type="checkbox" class="checkbox send-checkbox" checked  data-id="24"/>`);
					$('#Living .door-checkbox').append(`<div class="checkbox-btn-door"></div>`);
					$('#Living .door-checkbox').append(` <div class="checkbox-layer" ></div>`);
				}
				else {
					$('#Living .door-checkbox').append(`<input type="checkbox" class="checkbox send-checkbox"  data-id="24"/>`);
					$('#Living .door-checkbox').append(`<div class="checkbox-btn-door" ></div>`);
					$('#Living .door-checkbox').append(`<div class="checkbox-layer" ></div>`);
				}

			}


			else if (data.deviceId == 25) {
				if (data.status >= 1) {
					soundStatusLiving = data.status;

					$('#Living .sound-checkbox').append(`<input type="hidden" class="input-checkbox"   data-id="25" data-value="0" />`);
					$('#Living .sound-checkbox').append(`<input type="checkbox" class="slider-checkbox" checked  />`);
					$('#Living .sound-checkbox').append(`<div class="checkbox-btn"></div>`);
					$('#Living .sound-checkbox').append(` <div class="checkbox-layer" ></div>`);


					let SoundSliderdegree = (soundStatusLiving * 2.7) + 315;
					$("#Living #sound-slider .rs-first").css("transform", `rotate(${SoundSliderdegree}deg)`);
					$("#Living #sound-slider .rs-path-color:first").css("transform", `rotate(${SoundSliderdegree}deg)`);
					$("#Living #sound-slider .rs-range-color:not(:first)").css("transform", `rotate(${SoundSliderdegree - 180}deg)`);

					$('#Living #sound-slider .rs-tooltip').append(soundStatusLiving);
					$('#Living input[name=sound-slider]').val(soundStatusLiving);
					$("#Living #sound-slider .rs-handle").attr("aria-valuenow", soundStatusLiving);
					$("#Living #sound-slider .sound-gradient").css("background", `hsl(${-255 + (soundStatusLiving * 5.1)}, 100%, 57%)`);

				}
				else {
					$('#Living .sound-checkbox').append(`<input type="hidden" class="input-checkbox"   data-id="25" data-value="${soundStatusLiving}" />`);
					$('#Living .sound-checkbox').append(`<input type="checkbox" class="slider-checkbox" />`);
					$('#Living .sound-checkbox').append(`<div class="checkbox-btn" ></div>`);
					$('#Living .sound-checkbox').append(`<div class="checkbox-layer" ></div>`);

				}

			}

			else if (data.deviceId == 26) {
				if (data.status >= 1) {

					lightStatusLiving = data.status;

					$('#Living .light-checkbox').append(`<input type="hidden" class="input-checkbox"   data-id="26" data-value="0" />`);
					$('#Living .light-checkbox').append(`<input type="checkbox" class="slider-checkbox" checked />`);
					$('#Living .light-checkbox').append(`<div class="checkbox-btn"></div>`);
					$('#Living .light-checkbox').append(` <div class="checkbox-layer" ></div>`);


					let lightSliderDegree = (lightStatusLiving * 2.7) + 315;
					$("#Living #light-slider .rs-first").css("transform", `rotate(${lightSliderDegree}deg)`);
					$("#Living #light-slider .rs-path-color:first").css("transform", `rotate(${lightSliderDegree}deg)`);
					$("#Living #light-slider .rs-range-color:not(:first)").css("transform", `rotate(${lightSliderDegree - 180}deg)`);


					$('#Living #light-slider .rs-tooltip').append(lightStatusLiving);
					$('#Living input[name=light-slider]').val(lightStatusLiving);
					$("#Living #light-slider.rs-handle").attr("aria-valuenow", lightStatusLiving);
					$("#Living #light-slider .light-gradient").css("background", `hsl(${-255 + (lightStatusLiving * 5.1)}, 100%, 57%)`);

				}
				else {
					$('#Living .light-checkbox').append(`<input type="hidden" class="input-checkbox"   data-id="26" data-value="${lightStatusLiving}" />`);
					$('#Living .light-checkbox').append(`<input type="checkbox" class="slider-checkbox" />`);
					$('#Living .light-checkbox').append(`<div class="checkbox-btn" ></div>`);
					$('#Living .light-checkbox').append(`<div class="checkbox-layer" ></div>`);

				}

			}

			else if (data.deviceId == 27) {

				if (data.status > 10) {

					airStatusLiving = data.status;

					$('#Living .ac-checkbox').append(`<input type="hidden" class="input-checkbox"   data-id="27" data-value="0" />`);
					$('#Living .ac-checkbox').append(`<input type="checkbox" class="slider-checkbox"  checked />`);
					$('#Living .ac-checkbox').append(`<div class="checkbox-btn"></div>`);
					$('#Living .ac-checkbox').append(` <div class="checkbox-layer" ></div>`);


					let airSliderDegree = (airStatusLiving * 5.4) + 261;
					$("#Living #air-slider .rs-first").css("transform", `rotate(${airSliderDegree}deg)`);
					$("#Living #air-slider .rs-path-color:first").css("transform", `rotate(${airSliderDegree}deg)`);
					$("#Living #air-slider .rs-range-color:not(:first)").css("transform", `rotate(${airSliderDegree - 180}deg)`);


					$('#Living #air-slider .rs-tooltip').append(airStatusLiving);
					$('#Living input[name=air-slider]').val(airStatusLiving);
					$("#Living #air-slider .rs-handle").attr("aria-valuenow", airStatusLiving);
					$("#Living #air-slider .air-gradient").css("background", `hsl(${-255 + (airStatusLiving * 4.25)}, 100%, 57%)`);
				}

				else {
					$('#Living .ac-checkbox').append(`<input type="hidden" class="input-checkbox"   data-id="27" data-value="${airStatusLiving}" />`);
					$('#Living .ac-checkbox').append(`<input type="checkbox" class="slider-checkbox"/>`);
					$('#Living .ac-checkbox').append(`<div class="checkbox-btn" ></div>`);
					$('#Living .ac-checkbox').append(`<div class="checkbox-layer" ></div>`);

				}

			}
		}

		//Dining Room
		else if (data.deviceId == 28 || data.deviceId == 29 || data.deviceId == 30) {




			if (data.deviceId == 28) {
				if (data.status >= 1) {
					soundStatusDining = data.status;

					$('#Dining .sound-checkbox').append(`<input type="hidden" class="input-checkbox"   data-id="28" data-value="0" />`);
					$('#Dining .sound-checkbox').append(`<input type="checkbox" class="slider-checkbox" checked  />`);
					$('#Dining .sound-checkbox').append(`<div class="checkbox-btn"></div>`);
					$('#Dining .sound-checkbox').append(` <div class="checkbox-layer" ></div>`);


					let SoundSliderdegree = (soundStatusDining * 2.7) + 315;
					$("#Dining #sound-slider .rs-first").css("transform", `rotate(${SoundSliderdegree}deg)`);
					$("#Dining #sound-slider .rs-path-color:first").css("transform", `rotate(${SoundSliderdegree}deg)`);
					$("#Dining #sound-slider .rs-range-color:not(:first)").css("transform", `rotate(${SoundSliderdegree - 180}deg)`);

					$('#Dining #sound-slider .rs-tooltip').append(soundStatusDining);
					$('#Dining input[name=sound-slider]').val(soundStatusDining);
					$("#Dining #sound-slider .rs-handle").attr("aria-valuenow", soundStatusDining);
					$("#Dining #sound-slider .sound-gradient").css("background", `hsl(${-255 + (soundStatusDining * 5.1)}, 100%, 57%)`);

				}
				else {
					$('#Dining .sound-checkbox').append(`<input type="hidden" class="input-checkbox"   data-id="28" data-value="${soundStatusDining}" />`);
					$('#Dining .sound-checkbox').append(`<input type="checkbox" class="slider-checkbox" />`);
					$('#Dining .sound-checkbox').append(`<div class="checkbox-btn" ></div>`);
					$('#Dining .sound-checkbox').append(`<div class="checkbox-layer" ></div>`);

				}

			}

			else if (data.deviceId == 29) {
				if (data.status >= 1) {

					lightStatusDining = data.status;

					$('#Dining .light-checkbox').append(`<input type="hidden" class="input-checkbox"   data-id="29" data-value="0" />`);
					$('#Dining .light-checkbox').append(`<input type="checkbox" class="slider-checkbox" checked />`);
					$('#Dining .light-checkbox').append(`<div class="checkbox-btn"></div>`);
					$('#Dining .light-checkbox').append(` <div class="checkbox-layer" ></div>`);


					let lightSliderDegree = (lightStatusDining * 2.7) + 315;
					$("#Dining #light-slider .rs-first").css("transform", `rotate(${lightSliderDegree}deg)`);
					$("#Dining #light-slider .rs-path-color:first").css("transform", `rotate(${lightSliderDegree}deg)`);
					$("#Dining #light-slider .rs-range-color:not(:first)").css("transform", `rotate(${lightSliderDegree - 180}deg)`);


					$('#Dining #light-slider .rs-tooltip').append(lightStatusDining);
					$('#Dining input[name=light-slider]').val(lightStatusDining);
					$("#Dining #light-slider.rs-handle").attr("aria-valuenow", lightStatusDining);
					$("#Dining #light-slider .light-gradient").css("background", `hsl(${-255 + (lightStatusDining * 5.1)}, 100%, 57%)`);

				}
				else {
					$('#Dining .light-checkbox').append(`<input type="hidden" class="input-checkbox"   data-id="29" data-value="${lightStatusDining}" />`);
					$('#Dining .light-checkbox').append(`<input type="checkbox" class="slider-checkbox" />`);
					$('#Dining .light-checkbox').append(`<div class="checkbox-btn" ></div>`);
					$('#Dining .light-checkbox').append(`<div class="checkbox-layer" ></div>`);

				}

			}

			else if (data.deviceId == 30) {

				if (data.status > 10) {

					airStatusDining = data.status;

					$('#Dining .ac-checkbox').append(`<input type="hidden" class="input-checkbox"   data-id="30" data-value="0" />`);
					$('#Dining .ac-checkbox').append(`<input type="checkbox" class="slider-checkbox"  checked />`);
					$('#Dining .ac-checkbox').append(`<div class="checkbox-btn"></div>`);
					$('#Dining .ac-checkbox').append(` <div class="checkbox-layer" ></div>`);


					let airSliderDegree = (airStatusDining * 5.4) + 261;
					$("#Dining #air-slider .rs-first").css("transform", `rotate(${airSliderDegree}deg)`);
					$("#Dining #air-slider .rs-path-color:first").css("transform", `rotate(${airSliderDegree}deg)`);
					$("#Dining #air-slider .rs-range-color:not(:first)").css("transform", `rotate(${airSliderDegree - 180}deg)`);


					$('#Dining #air-slider .rs-tooltip').append(airStatusDining);
					$('#Dining input[name=air-slider]').val(airStatusDining);
					$("#Dining #air-slider .rs-handle").attr("aria-valuenow", airStatusDining);
					$("#Dining #air-slider .air-gradient").css("background", `hsl(${-255 + (airStatusDining * 4.25)}, 100%, 57%)`);
				}

				else {
					$('#Dining .ac-checkbox').append(`<input type="hidden" class="input-checkbox"   data-id="30" data-value="${airStatusDining}" />`);
					$('#Dining .ac-checkbox').append(`<input type="checkbox" class="slider-checkbox"/>`);
					$('#Dining .ac-checkbox').append(`<div class="checkbox-btn" ></div>`);
					$('#Dining .ac-checkbox').append(`<div class="checkbox-layer" ></div>`);

				}

			}
		}

		//Storage System
		else if (data.deviceId == 31 || data.deviceId == 29 || data.deviceId == 32) {
			if (data.deviceId == 31) {
				if (data.status == 1) {
					$('#storageLight').append(`<input class="form-check-input send-checkbox input-checkbox mb-2" type="checkbox" id="flexSwitchCheckChecked" data-id="31" checked />`);
					$('#storageLight').append(` <label class="form-check-label label-checkbox fw-bold"  for="flexSwitchCheckChecked" data-id="31"> On  </label>`);
				}
				else {
					$('#storageLight').append(`<input class="form-check-input send-checkbox input-checkbox mb-2" type="checkbox" id="flexSwitchCheckChecked" data-id="31"/>`);
					$('#storageLight').append(`<label class="form-check-label label-checkbox fw-bold"  for="flexSwitchCheckChecked" data-id="31"> Off  </label>`);
				}

			}
			else if (data.deviceId == 32) {
				if (data.status == 1) {
					$('#storageDoor').append(`<input class="form-check-input send-checkbox input-checkbox mb-2" type="checkbox"  data-id="32" checked />`);
					$('#storageDoor').append(` <label class="form-check-label label-checkbox fw-bold"   data-id="32" > Open  </label>`);
				}
				else {
					$('#storageDoor').append(`<input class="form-check-input send-checkbox input-checkbox mb-2" type="checkbox" id="flexSwitchCheckChecked" data-id="32"/>`);
					$('#storageDoor').append(` <label class="form-check-label label-checkbox fw-bold"  for="flexSwitchCheckChecked" data-id="32" > Close  </label>`);
				}

			}
		
        }
	
		//Office Room
		else if (data.deviceId == 33 || data.deviceId == 34 || data.deviceId == 35 || data.deviceId == 36 || data.deviceId == 37) {


			if (data.deviceId == 33) {
				if (data.status == 1) {
					$('#Office .tv-checkbox').append(`<input type="checkbox" class="checkbox send-checkbox" checked  data-id="33"/>`);
					$('#Office .tv-checkbox').append(`<div class="checkbox-btn"></div>`);
					$('#Office .tv-checkbox').append(` <div class="checkbox-layer" ></div>`);
				}
				else {
					$('#Office .tv-checkbox').append(`<input type="checkbox" class="checkbox send-checkbox"  data-id="33"/>`);
					$('#Office .tv-checkbox').append(`<div class="checkbox-btn" ></div>`);
					$('#Office .tv-checkbox').append(`<div class="checkbox-layer" ></div>`);
				}

			}
			else if (data.deviceId == 34) {
				if (data.status == 1) {
					$('#Office .door-checkbox').append(`<input type="checkbox" class="checkbox send-checkbox" checked  data-id="34"/>`);
					$('#Office .door-checkbox').append(`<div class="checkbox-btn-door"></div>`);
					$('#Office .door-checkbox').append(` <div class="checkbox-layer" ></div>`);
				}
				else {
					$('#Office .door-checkbox').append(`<input type="checkbox" class="checkbox send-checkbox"  data-id="34"/>`);
					$('#Office .door-checkbox').append(`<div class="checkbox-btn-door" ></div>`);
					$('#Office .door-checkbox').append(`<div class="checkbox-layer" ></div>`);
				}

			}


			else if (data.deviceId == 35) {
				if (data.status >= 1) {
					soundStatusOffice = data.status;

					$('#Office .sound-checkbox').append(`<input type="hidden" class="input-checkbox"   data-id="35" data-value="0" />`);
					$('#Office .sound-checkbox').append(`<input type="checkbox" class="slider-checkbox" checked  />`);
					$('#Office .sound-checkbox').append(`<div class="checkbox-btn"></div>`);
					$('#Office .sound-checkbox').append(` <div class="checkbox-layer" ></div>`);


					let SoundSliderdegree = (soundStatusOffice * 2.7) + 315;
					$("#Office #sound-slider .rs-first").css("transform", `rotate(${SoundSliderdegree}deg)`);
					$("#Office #sound-slider .rs-path-color:first").css("transform", `rotate(${SoundSliderdegree}deg)`);
					$("#Office #sound-slider .rs-range-color:not(:first)").css("transform", `rotate(${SoundSliderdegree - 180}deg)`);

					$('#Office #sound-slider .rs-tooltip').append(soundStatusOffice);
					$('#Office input[name=sound-slider]').val(soundStatusOffice);
					$("#Office #sound-slider .rs-handle").attr("aria-valuenow", soundStatusOffice);
					$("#Office #sound-slider .sound-gradient").css("background", `hsl(${-255 + (soundStatusOffice * 5.1)}, 100%, 57%)`);

				}
				else {
					$('#Office .sound-checkbox').append(`<input type="hidden" class="input-checkbox"   data-id="35" data-value="${soundStatusOffice}" />`);
					$('#Office .sound-checkbox').append(`<input type="checkbox" class="slider-checkbox" />`);
					$('#Office .sound-checkbox').append(`<div class="checkbox-btn" ></div>`);
					$('#Office .sound-checkbox').append(`<div class="checkbox-layer" ></div>`);

				}

			}

			else if (data.deviceId == 36) {
				if (data.status >= 1) {

					lightStatusOffice = data.status;

					$('#Office .light-checkbox').append(`<input type="hidden" class="input-checkbox"   data-id="36" data-value="0" />`);
					$('#Office .light-checkbox').append(`<input type="checkbox" class="slider-checkbox" checked />`);
					$('#Office .light-checkbox').append(`<div class="checkbox-btn"></div>`);
					$('#Office .light-checkbox').append(` <div class="checkbox-layer" ></div>`);


					let lightSliderDegree = (lightStatusOffice * 2.7) + 315;
					$("#Office #light-slider .rs-first").css("transform", `rotate(${lightSliderDegree}deg)`);
					$("#Office #light-slider .rs-path-color:first").css("transform", `rotate(${lightSliderDegree}deg)`);
					$("#Office #light-slider .rs-range-color:not(:first)").css("transform", `rotate(${lightSliderDegree - 180}deg)`);


					$('#Office #light-slider .rs-tooltip').append(lightStatusOffice);
					$('#Office input[name=light-slider]').val(lightStatusOffice);
					$("#Office #light-slider.rs-handle").attr("aria-valuenow", lightStatusOffice);
					$("#Office #light-slider .light-gradient").css("background", `hsl(${-255 + (lightStatusOffice * 5.1)}, 100%, 57%)`);

				}
				else {
					$('#Office .light-checkbox').append(`<input type="hidden" class="input-checkbox"   data-id="36" data-value="${lightStatusOffice}" />`);
					$('#Office .light-checkbox').append(`<input type="checkbox" class="slider-checkbox" />`);
					$('#Office .light-checkbox').append(`<div class="checkbox-btn" ></div>`);
					$('#Office .light-checkbox').append(`<div class="checkbox-layer" ></div>`);

				}

			}

			else if (data.deviceId == 37) {

				if (data.status > 10) {

					airStatusOffice = data.status;

					$('#Office .ac-checkbox').append(`<input type="hidden" class="input-checkbox"   data-id="37" data-value="0" />`);
					$('#Office .ac-checkbox').append(`<input type="checkbox" class="slider-checkbox"  checked />`);
					$('#Office .ac-checkbox').append(`<div class="checkbox-btn"></div>`);
					$('#Office .ac-checkbox').append(` <div class="checkbox-layer" ></div>`);


					let airSliderDegree = (airStatusOffice * 5.4) + 261;
					$("#Office #air-slider .rs-first").css("transform", `rotate(${airSliderDegree}deg)`);
					$("#Office #air-slider .rs-path-color:first").css("transform", `rotate(${airSliderDegree}deg)`);
					$("#Office #air-slider .rs-range-color:not(:first)").css("transform", `rotate(${airSliderDegree - 180}deg)`);


					$('#Office #air-slider .rs-tooltip').append(airStatusOffice);
					$('#Office input[name=air-slider]').val(airStatusOffice);
					$("#Office #air-slider .rs-handle").attr("aria-valuenow", airStatusOffice);
					$("#Office #air-slider .air-gradient").css("background", `hsl(${-255 + (airStatusOffice * 4.25)}, 100%, 57%)`);
				}

				else {
					$('#Office .ac-checkbox').append(`<input type="hidden" class="input-checkbox"   data-id="37" data-value="${airStatusOffice}" />`);
					$('#Office .ac-checkbox').append(`<input type="checkbox" class="slider-checkbox"/>`);
					$('#Office .ac-checkbox').append(`<div class="checkbox-btn" ></div>`);
					$('#Office .ac-checkbox').append(`<div class="checkbox-layer" ></div>`);

				}

			}
		}

		//Garage System
		else if (data.deviceId == 41 || data.deviceId == 42) {
			if (data.deviceId == 41) {
				if (data.status == 1) {
					$('#garageDoor').append(`<input class="form-check-input input-checkbox mb-2" type="checkbox send-checkbox"  data-id="41" checked />`);
					$('#garageDoor').append(` <label class="form-check-label label-checkbox fw-bold"   data-id="41" > Open  </label>`);
				}
				else {
					$('#garageDoor').append(`<input class="form-check-input input-checkbox mb-2" type="checkbox send-checkbox" id="flexSwitchCheckChecked" data-id="41"/>`);
					$('#garageDoor').append(` <label class="form-check-label label-checkbox fw-bold"  for="flexSwitchCheckChecked" data-id="41" > Close  </label>`);
				}

			}
			else if (data.deviceId == 42) {
				if (data.status == 1) {
					$('#garageLight').append(`<input class="form-check-input input-checkbox mb-2" type="checkbox send-checkbox" id="flexSwitchCheckChecked" data-id="42" checked />`);
					$('#garageLight').append(` <label class="form-check-label label-checkbox fw-bold"  for="flexSwitchCheckChecked" data-id="42"> On  </label>`);
				}
				else {
					$('#garageLight').append(`<input class="form-check-input input-checkbox mb-2" type="checkbox send-checkbox" id="flexSwitchCheckChecked" data-id="42"/>`);
					$('#garageLight').append(`<label class="form-check-label label-checkbox fw-bold"  for="flexSwitchCheckChecked" data-id="42"> Off  </label>`);
				}

			}
		}

		//Garden
		else if (data.deviceId == 43 || data.deviceId == 44) {
			if (data.deviceId == 43) {
				$('#WaterTank').append(`<i class="fas fa-tint fs-5 text-primary pe-2"></i>
                                    <span class="flex-grow-1 lh-1">Water Tank</span>
                                    <span class="lh-1">${data.status} %</span>`);
				$('#WaterTankProgress').append(`<div class="progress-bar progress-bar-striped"
                                             role="progressbar"
                                             style="width: ${data.status}%;"
                                             aria-valuenow="${data.status}"
                                             aria-valuemin="0"
                                             aria-valuemax="100">
											 </div>`);
			}
			else if (data.deviceId == 44) {
				$('#garden').append(`<i class="fab fa-pagelines text-success pe-2"></i>
                                    <span class="flex-grow-1 lh-1">Soil</span>
                                    <span class="lh-1">${data.status} %</span>`);
				$('#gardenProgress').append(`<div class="progress-bar progress-bar-striped  bg-success"
                                             role="progressbar"
                                             style="width: ${data.status}%;"
                                             aria-valuenow="${data.status}"
                                             aria-valuemin="0"
                                             aria-valuemax="100">
											 </div>`);
			}
		}


	});
}


function historyLocation(value1) {
	var url = "https://localhost:44303/history/" + value1;
	location.replace(url);
}