"use strict";

var connectionAlert = new signalR.HubConnectionBuilder().withUrl("/dashboardHub").build();

connectionAlert.start().then(function () {
	InvokeUserSystems();
	InvokeDevicesSystems();

}).catch(function (err) {
	return console.error(err.toString());
});

// Users
function InvokeUserSystems() {
	connectionAlert.invoke("SendUserData").catch(function (err) {
		return console.error(err.toString());
	});
}
connectionAlert.on("ReceivedUserData", function (data) {
	BindUserToGrid(data);
});

// Devices 
function InvokeDevicesSystems() {
	connectionAlert.invoke("SendDevicesData").catch(function (err) {
		return console.error(err.toString());
	});
}
connectionAlert.on("ReceivedDevicesData", function (data) {
	BindHomeSystemToGrid(data);
	BindDevice(data);
	BindWeatherSystem(data);
	BindGardenSystem(data);
	BindAlertSystem(data);
});

function BindHomeSystemToGrid(data) {
	$('#tblHomeSystems tbody').empty();
	// Home System
	var tr;
	$.each(data, function (index, data) {
		if (data.deviceId == 1 || data.deviceId == 3 || data.deviceId == 4 || data.deviceId == 5 || data.deviceId == 38 || data.deviceId == 39 || data.deviceId == 40) {
			var text = "";
			var icon = "";
			var system = "";
			var style = data.status == 1 ? "bg-danger" : "bg-success";
			tr = $('<tr class="alert-secondary"/>');

			if (data.deviceId == 1) {
				 text = data.status == 1 ? "Unsafe" : "Safe";
				 icon = "fas fa-hotel";
				 system = "Home Security";
			}
			else if (data.deviceId == 3) {
				text = data.status == 1 ? "Fire" : "Safe";
				icon = "fas fa-fire-extinguisher";
				system = "Fire System";
			}
			else if (data.deviceId == 4) {
				text = data.status == 1 ? "Smoke" : "Safe";
				icon = "fab fa-gripfire";
				system = "Smoke System";
			}
			else if (data.deviceId == 5) {
				style = data.status == 1 ? "bg-success" : "bg-danger";
				text = data.status == 1 ? "On" : "Off";
				icon = "far fa-lightbulb";
				system = "Outdoor Light";
			}
			else if (data.deviceId == 38) {
				text = data.status == 1 ? "Unsafe" : "Safe";
				icon = "fas fa-warehouse";
				system = "Garage Security";
			}
			else if (data.deviceId == 39) {
				text = data.status == 1 ? "Busy" : "Empty";
				icon = "fas fa-parking ";
				system = "Left Parking";
			}
			else if (data.deviceId == 40) {
				text = data.status == 1 ? "Busy" : "Empty";
				icon = "fas fa-parking ";
				system = "Right Parking";
			}
			tr.append(`<td><i class="${icon} fs-4 p-2"></i></td>`);
			tr.append(`<td><span>${system}</span></td>`);
			tr.append(`<td class="status">
                        <span class="badge fs-6 ${style}">${text}</span>
                        </td>`);
			tr.append(`<td>
						<button class="btn-notification" onclick ="historyLocation(${data.deviceId})">
							<i class="history-icon fas fa-history fs-3"></i>  </a>
						</button>   
						</td>`);

			$('#tblHomeSystems').append(tr);

		}
	});
}
function BindWeatherSystem(data) {
	$('#temperature').empty();
	$('#humidity').empty();
	$.each(data, function (index, data) {
		if (data.deviceId == 6 || data.deviceId == 7) {
			if (data.deviceId == 6) {
				$('#temperature').append(`<span> ${data.status} </span><i class="far fa-temperature-high"></i>`);
			}
			else if (data.deviceId == 7) {
				$('#humidity').append(`<span> ${data.status} </span><i class="far fa-humidity"></i>`);
			}
		}
	});
}
function BindGardenSystem(data) {
	$('#WaterTank').empty();
	$('#WaterTankProgress').empty();
	$('#garden').empty();
	$('#gardenProgress').empty();
	$.each(data, function (index, data) {
		if (data.deviceId == 43 || data.deviceId == 44) {
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

function BindUserToGrid(data) {
	$('#users').empty();
	var user;
	$.each(data, function (index, data) {
		user = $('<div class="col-6 col-sm-3 col-md-6 col-xl-3 d-flex flex-column align-items-center">');
		user.append(`<img src="${data.userImageURL}" class="member-img rounded-circle" alt="${data.firstName}" />`);
		user.append(`<span  class="fw-bold">${data.firstName}</span>`);
		$('#users').append(user);
	});
}

function BindDevice(data) {
	$('#homeDoor').empty();
	$('#outdoorLight').empty();
	$('#leavingTV').empty();
	$('#leavingSound').empty();
	$.each(data, function (index, data) {
		if (data.deviceId == 2) {
			if (data.status == 1) {
				$('#homeDoor').append(`<input class="form-check-input input-checkbox mb-2" type="checkbox" data-id="2" checked />`);
				$('#homeDoor').append(` <label class="form-check-label label-checkbox fw-bold"  data-id="2" > Open  </label>`);
			}
			else {
				$('#homeDoor').append(`<input class="form-check-input input-checkbox mb-2" type="checkbox" data-id="2"/>`);
				$('#homeDoor').append(` <label class="form-check-label label-checkbox fw-bold"   data-id="2" > Close  </label>`);
            }
		
		}
		else if (data.deviceId == 5) {
			if (data.status == 1) {
				$('#outdoorLight').append(`<input class="form-check-input input-checkbox mb-2" type="checkbox"  data-id="5" checked />`);
				$('#outdoorLight').append(` <label class="form-check-label label-checkbox fw-bold"   data-id="5"> On  </label>`);
			}
			else {
				$('#outdoorLight').append(`<input class="form-check-input input-checkbox mb-2" type="checkbox"  data-id="5"/>`);
				$('#outdoorLight').append(` <label class="form-check-label label-checkbox fw-bold"   data-id="5"> Off  </label>`);
			}

		}
		else if (data.deviceId == 23) {
			if (data.status == 1) {
				$('#leavingTV').append(`<input class="form-check-input input-checkbox mb-2" type="checkbox"  data-id="23" checked />`);
				$('#leavingTV').append(` <label class="form-check-label label-checkbox fw-bold"  data-id="23"> On  </label>`);
			}
			else {
				$('#leavingTV').append(`<input class="form-check-input input-checkbox mb-2" type="checkbox"  data-id="23"/>`);
				$('#leavingTV').append(` <label class="form-check-label label-checkbox fw-bold"   data-id="23"> Off  </label>`);
			}

		}
		else if (data.deviceId == 25) {
			if (data.status == 1) {
				$('#leavingSound').append(`<input class="form-check-input input-checkbox mb-2" type="checkbox"  data-id="25" checked />`);
				$('#leavingSound').append(` <label class="form-check-label label-checkbox fw-bold"  data-id="25"> On  </label>`);
			}
			else {
				$('#leavingSound').append(`<input class="form-check-input input-checkbox mb-2" type="checkbox"  data-id="25"/>`);
				$('#leavingSound').append(` <label class="form-check-label label-checkbox fw-bold"  data-id="25"> Off  </label>`);
			}

		}
	});
}  
function historyLocation(value1) {
	var url = "https://localhost:44303/history/" + value1;
	location.replace(url);
}