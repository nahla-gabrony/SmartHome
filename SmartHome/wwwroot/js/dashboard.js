"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/dashboardHub").build();

connection.start().then(function () {
	InvokeHomeSystems();
	InvokeUserSystems()

}).catch(function (err) {
	return console.error(err.toString());
});

// Home system
function InvokeHomeSystems() {
	connection.invoke("SendSystemsData").catch(function (err) {
		return console.error(err.toString());
	});
}

connection.on("ReceivedSystemsData", function (data) {
	BindHomeSystemToGrid(data);
});

// Users
function InvokeUserSystems() {
	connection.invoke("SendUserData").catch(function (err) {
		return console.error(err.toString());
	});
}
connection.on("ReceivedUserData", function (data) {
	BindUserToGrid(data);
});

function BindHomeSystemToGrid(data) {
	$('#tblHomeSystems tbody').empty();
	$('#temperature').empty();
	$('#humidity').empty();
	$('#WaterTank').empty();
	$('#WaterTankProgress').empty();
	$('#garden').empty();
	$('#gardenProgress').empty();
	// Home System
	var tr;
	$.each(data, function (index, data) {
		tr = $('<tr/>');
		var style = data.status == 1 ? "bg-danger" : "bg-success";
		if (data.systemId == 1) {
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
		else if (data.systemId == 2) {
			var text = data.status == 1 ? "Unsafe" : "Safe";
			tr.append(`<td><i class="fas fa-warehouse fs-4 p-2"></i></td>`);
			tr.append(`<td><span>Garage Security</span></td>`);
			tr.append(`<td class="status">
                        <span class="badge fs-6 ${style}">${text}</span>
                        </td>`);
			tr.append(`<td>
						   <a href="#">
							  <i class="history-icon fas fa-cog fs-3"></i>
						   </a>
                       </td>`);
		}
		else if (data.systemId == 3) {
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
		else if (data.systemId == 4) {
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
		else if (data.systemId == 5) {
			var text = data.status == 1 ? "Busy" : "Empty";
			tr.append(`<td><i class="fas fa-parking fs-3 p-2"></i></td>`);
			tr.append(`<td><span>Left Parking</span></td>`);
			tr.append(`<td class="status">
                        <span class="badge fs-6 ${style}">${text}</span>
                        </td>`);
			tr.append(`<td>
						   <a href="#">
							  <i class="history-icon fas fa-cog fs-3"></i>
						   </a>
                       </td>`);
		}
		else if (data.systemId == 6) {
			var text = data.status == 1 ? "Busy" : "Empty";
			tr.append(`<td><i class="fas fa-parking fs-3 p-2"></i></td>`);
			tr.append(`<td><span>Right Parking</span></td>`);
			tr.append(`<td class="status">
                        <span class="badge fs-6 ${style}">${text}</span>
                        </td>`);
			tr.append(`<td>
						   <a href="#">
							  <i class="history-icon fas fa-cog fs-3"></i>
						   </a>
                       </td>`);
        }
		else if (data.systemId == 7) {
			var text = data.status == 1 ? "Off" : "On";
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
		// Temperature and Humidity
		else if (data.systemId == 8) {
			$('#temperature').append(`<span>${data.status}</span><i class="far fa-temperature-high"></i>`);
		}	
		else if (data.systemId == 9) {
			$('#humidity').append(`<span>${data.status}</span><i class="far fa-humidity"></i>`);
		}
		//Water Tank and Garden
		else if (data.systemId == 10) {
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
		else if (data.systemId == 11) {
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
		$('#tblHomeSystems').append(tr);


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

