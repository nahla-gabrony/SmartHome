"use strict";
var connection = new signalR.HubConnectionBuilder().withUrl("/dashboardHub").build();
connection.start().then(function () {
	InvokeDevicesSystems();

}).catch(function (err) {
	return console.error(err.toString());
});

// Devices 
function InvokeDevicesSystems() {
	connection.invoke("SendDevicesData").catch(function (err) {
		return console.error(err.toString());
	});
}
connection.on("ReceivedDevicesData", function (data) {
	BindDeviceToGrid(data);
	BindHomeSystemToGrid(data);
});

function BindHomeSystemToGrid(data) {
	$('#tblHomeSystems tbody').empty();
	// Home System
	var tr;
	$.each(data, function (index, data) {
		if (data.deviceId == 1 || data.deviceId == 28 || data.deviceId == 3 || data.deviceId == 4 || data.deviceId == 5 || data.deviceId == 30 || data.deviceId == 31) {
			tr = $('<tr class="alert-secondary"/>');
			var style = data.status == 1 ? "bg-danger" : "bg-success";
			if (data.deviceId == 1) {
				var text = data.status == 1 ? "Unsafe" : "Safe";
				tr.append(`<td><i class="fas fa-hotel fs-4 p-2"></i></td>`);
				tr.append(`<td><span>Home Security</span></td>`);
				tr.append(`<td class="status">
                        <span class="badge fs-6 ${style}">${text}</span>
                        </td>`);
				tr.append(`<td>
						   <a href="#">
							  <i class="history-icon fas fa-cog fs-3"></i>
						   </a>
                       </td>`);
			}
			else if (data.deviceId == 3) {
				var text = data.status == 1 ? "Fire" : "Safe";
				tr.append(`<td><i class="fas fa-fire-extinguisher fs-3 p-2"></i></td>`);
				tr.append(`<td><span>Fire System</span></td>`);
				tr.append(`<td class="status">
                        <span class="badge fs-6 ${style}">${text}</span>
                        </td>`);
				tr.append(`<td>
						   <a href="#">
							  <i class="history-icon fas fa-cog fs-3"></i>
						   </a>
                       </td>`);
			}
			else if (data.deviceId == 4) {
				var text = data.status == 1 ? "Smoke" : "Safe";
				tr.append(`<td><i class="fab fa-gripfire fs-2 p-2"></i></td>`);
				tr.append(`<td><span>Smoke System</span></td>`);
				tr.append(`<td class="status">
                        <span class="badge fs-6 ${style}">${text}</span>
                        </td>`);
				tr.append(`<td>
						   <a href="#">
							  <i class="history-icon fas fa-cog fs-3"></i>
						   </a>
                       </td>`);
			}
			else if (data.deviceId == 5) {
				style = data.status == 1 ? "bg-success" : "bg-danger";
				var text = data.status == 1 ? "On" : "Off";
				tr.append(`<td><i class="far fa-lightbulb fs-3 p-2"></i></td>`);
				tr.append(`<td><span>Outdoor Light</span></td>`);
				tr.append(`<td class="status">
                        <span class="badge fs-6 ${style}">${text}</span>
                        </td>`);
				tr.append(`<td>
						   <a href="#">
							  <i class="history-icon fas fa-cog fs-3"></i>
						   </a>
                       </td>`);
			}

			$('#tblHomeSystems').append(tr);

		}
	});
}
let airStatus_roomOne = "";
let soundStatus_roomOne = "";
let lightStatus_roomOne = "";
function BindDeviceToGrid(data) {
	//Main System
	$('#homeDoor').empty();
	$('#outdoorLight').empty();
	//Bedroom 1
	$('#BedroomOneTV').empty();
	$('#BedroomOneDoor').empty();

	$('#BedroomOneAC').empty();
	$('#air-slider-room1 .rs-tooltip').empty();

	$('#BedroomOneLight').empty();
	$('#sound-slider-room1 .rs-tooltip').empty();

	$('#BedroomOneSound').empty();
	$('#light-slider-room1 .rs-tooltip').empty();


	$.each(data, function (index, data) {
		//Main System
		if (data.deviceId == 2) {
			if (data.status == 1) {
				$('#homeDoor').append(`<input class="form-check-input input-checkbox mb-2" type="checkbox"  data-id="2" checked />`);
				$('#homeDoor').append(` <label class="form-check-label label-checkbox fw-bold"   data-id="2" > Open  </label>`);
			}
			else {
				$('#homeDoor').append(`<input class="form-check-input input-checkbox mb-2" type="checkbox" id="flexSwitchCheckChecked" data-id="2"/>`);
				$('#homeDoor').append(` <label class="form-check-label label-checkbox fw-bold"  for="flexSwitchCheckChecked" data-id="2" > Close  </label>`);
            }
		
		}
		else if (data.deviceId == 5) {
			if (data.status == 1) {
				$('#outdoorLight').append(`<input class="form-check-input input-checkbox mb-2" type="checkbox" id="flexSwitchCheckChecked" data-id="5" checked />`);
				$('#outdoorLight').append(` <label class="form-check-label label-checkbox fw-bold"  for="flexSwitchCheckChecked" data-id="5"> On  </label>`);
			}
			else {
				$('#outdoorLight').append(`<input class="form-check-input input-checkbox mb-2" type="checkbox" id="flexSwitchCheckChecked" data-id="5"/>`);
				$('#outdoorLight').append(`<label class="form-check-label label-checkbox fw-bold"  for="flexSwitchCheckChecked" data-id="5"> Off  </label>`);
			}

		}
		//Bedroom 1
		if (data.deviceId == 8 || data.deviceId == 9 || data.deviceId == 10 || data.deviceId == 11 || data.deviceId == 12) {


			if (data.deviceId == 8) {
				if (data.status == 1) {
					$('#BedroomOneTV').append(`<input type="checkbox" class="checkbox" checked  data-id="8"/>`);
					$('#BedroomOneTV').append(`<div class="checkbox-btn"></div>`);
					$('#BedroomOneTV').append(` <div class="checkbox-layer" ></div>`);
				}
				else {
					$('#BedroomOneTV').append(`<input type="checkbox" class="checkbox"  data-id="8"/>`);
					$('#BedroomOneTV').append(`<div class="checkbox-btn" ></div>`);
					$('#BedroomOneTV').append(`<div class="checkbox-layer" ></div>`);
				}

			}
			else if (data.deviceId == 12) {
				if (data.status == 1) {
					$('#BedroomOneDoor').append(`<input type="checkbox" class="checkbox" checked  data-id="12"/>`);
					$('#BedroomOneDoor').append(`<div class="checkbox-btn-door"></div>`);
					$('#BedroomOneDoor').append(` <div class="checkbox-layer" ></div>`);
				}
				else {
					$('#BedroomOneDoor').append(`<input type="checkbox" class="checkbox"  data-id="12"/>`);
					$('#BedroomOneDoor').append(`<div class="checkbox-btn-door" ></div>`);
					$('#BedroomOneDoor').append(`<div class="checkbox-layer" ></div>`);
				}

			}

			else if (data.deviceId == 9) {
				
				if (data.status > 10) {
					
					airStatus_roomOne = data.status;

					$('#BedroomOneAC').append(`<input type="hidden" class="input-checkbox"   data-id="9" data-value="0" />`);
					$('#BedroomOneAC').append(`<input type="checkbox" class="slider-checkbox" checked />`);
					$('#BedroomOneAC').append(`<div class="checkbox-btn"></div>`);
					$('#BedroomOneAC').append(` <div class="checkbox-layer" ></div>`);
				
					
					let airSliderDegree = (airStatus_roomOne * 5.4) + 261;
					$("#air-slider-room1 .rs-first").css("transform", `rotate(${airSliderDegree}deg)`);
					$("#air-slider-room1 .rs-path-color:first").css("transform", `rotate(${airSliderDegree}deg)`);
					$("#air-slider-room1 .rs-range-color:not(:first)").css("transform", `rotate(${airSliderDegree - 180}deg)`);


					$('#air-slider-room1 .rs-tooltip').append(airStatus_roomOne);
					$('input[name=air-slider-room1]').val(airStatus_roomOne);
					$("#air-slider-room1 .rs-handle").attr("aria-valuenow", airStatus_roomOne);
					$("#air-slider-room1 .air-gradient").css("background", `hsl(${-255 + (airStatus_roomOne * 4.25)}, 100%, 57%)`);
				}

				else {
					$('#BedroomOneAC').append(`<input type="hidden" class="input-checkbox"   data-id="9" data-value="${airStatus_roomOne}" />`);
					$('#BedroomOneAC').append(`<input type="checkbox" class="slider-checkbox"/>`);
					$('#BedroomOneAC').append(`<div class="checkbox-btn" ></div>`);
					$('#BedroomOneAC').append(`<div class="checkbox-layer" ></div>`);

				}

			}

			else if (data.deviceId == 10) {
				if (data.status >= 1) {
					soundStatus_roomOne = data.status;

					$('#BedroomOneSound').append(`<input type="hidden" class="input-checkbox"   data-id="10" data-value="0" />`);
					$('#BedroomOneSound').append(`<input type="checkbox" class="slider-checkbox" checked  data-id="10"/>`);
					$('#BedroomOneSound').append(`<div class="checkbox-btn"></div>`);
					$('#BedroomOneSound').append(` <div class="checkbox-layer" ></div>`);

			
					let SoundSliderdegree = (soundStatus_roomOne * 2.7) + 315;
					$("#sound-slider-room1 .rs-first").css("transform", `rotate(${SoundSliderdegree}deg)`);
					$("#sound-slider-room1 .rs-path-color:first").css("transform", `rotate(${SoundSliderdegree}deg)`);
					$("#sound-slider-room1 .rs-range-color:not(:first)").css("transform", `rotate(${SoundSliderdegree - 180}deg)`);

					$('#sound-slider-room1 .rs-tooltip').append(soundStatus_roomOne);
					$('input[name=sound-slider-room1]').val(soundStatus_roomOne);
					$("#sound-slider-room1 .rs-handle").attr("aria-valuenow", soundStatus_roomOne);
					$("#sound-slider-room1 .sound-gradient").css("background", `hsl(${-255 + (soundStatus_roomOne * 5.1)}, 100%, 57%)`);

				}
				else {
					$('#BedroomOneSound').append(`<input type="hidden" class="input-checkbox"   data-id="10" data-value="${soundStatus_roomOne}" />`);
					$('#BedroomOneSound').append(`<input type="checkbox" class="slider-checkbox" />`);
					$('#BedroomOneSound').append(`<div class="checkbox-btn" ></div>`);
					$('#BedroomOneSound').append(`<div class="checkbox-layer" ></div>`);

				}

			}

			else if (data.deviceId == 11) {
				if (data.status >= 1) {

					lightStatus_roomOne = data.status;

					$('#BedroomOneLight').append(`<input type="hidden" class="input-checkbox"   data-id="11" data-value="0" />`);
					$('#BedroomOneLight').append(`<input type="checkbox" class="slider-checkbox" checked />`);
					$('#BedroomOneLight').append(`<div class="checkbox-btn"></div>`);
					$('#BedroomOneLight').append(` <div class="checkbox-layer" ></div>`);

				
					let lightSliderDegree = (lightStatus_roomOne * 2.7) + 315;
					$("#light-slider-room1 .rs-first").css("transform", `rotate(${lightSliderDegree}deg)`);
					$("#light-slider-room1 .rs-path-color:first").css("transform", `rotate(${lightSliderDegree}deg)`);
					$("#light-slider-room1 .rs-range-color:not(:first)").css("transform", `rotate(${lightSliderDegree - 180}deg)`);


					$('#light-slider-room1 .rs-tooltip').append(lightStatus_roomOne);
					$('input[name=light-slider-room1]').val(lightStatus_roomOne);
					$("#light-slider-room1 .rs-handle").attr("aria-valuenow", lightStatus_roomOne);
					$("#light-slider-room1 .light-gradient").css("background", `hsl(${-255 + (lightStatus_roomOne * 5.1)}, 100%, 57%)`);

				}
				else {
					$('#BedroomOneLight').append(`<input type="hidden" class="input-checkbox"   data-id="11" data-value="${lightStatus_roomOne}" />`);
					$('#BedroomOneLight').append(`<input type="checkbox" class="slider-checkbox" />`);
					$('#BedroomOneLight').append(`<div class="checkbox-btn" ></div>`);
					$('#BedroomOneLight').append(`<div class="checkbox-layer" ></div>`);

				}

			}
		}
	
	
	});
}


