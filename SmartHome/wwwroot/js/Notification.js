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
	BindAlertSystem(data);
});
// Notification 
function InvokeNotificationsSystems() {
	connectionAlert.invoke("SendNotificationsData").catch(function (err) {
		return console.error(err.toString());
	});
}
connectionAlert.on("ReceivedNotificationsData", function (data) {
	BindNotifcationSystem(data);
});
function BindNotifcationSystem(data) {
	// Notifcation System
	$('#notifcation-container').empty();
	$('#notifcation-container').removeClass("d-flex");
	$('#notifcation-container').addClass("d-none");
	var count = 0;

	$.each(data, function (index, data) {
		$('#notifcation-container').removeClass("d-none");
		$('#notifcation-container').addClass("d-flex");
		var icon = "";
		count = count + 1;
		if (data.deviceId == 1) {
			icon = "fas fa-hotel";
		}
		else if (data.deviceId == 3) {
			icon = "fas fa-fire-extinguisher";
		}
		else if (data.deviceId == 4) {
			icon = "fab fa-gripfire";
		}
		else if(data.deviceId == 38)   {
			icon = "fas fa-warehouse";
			
		}

		$('#notifcation-container').append(`<button class="btn-notification notifcation-item d-flex justify-content-left" onclick ="deviceLocation(${data.deviceId}, ${data.id})">
												<div class="fa-stack  me-2 mb-3 d-inline-block">
													<i class="fa fa-circle fa-stack-2x main-color"></i>
													<i class="fa-stack-1x fa-inverse ${icon}"></i>
												</div>
												<div class="d-inline-block">
													<div class="notifcation-text fw-bold text-left">${data.notificationHeader}</div>
													<div class="notifcation-time text-black-50">
														<span>${data.notificationBody}</span>
													</div>
												</div>
												</button>`);

		$('#alert-toast').append(`<div class="toast show position-fixed bottom-0 end-0 m-3" role="alert" aria-live="assertive" aria-atomic="true">
										<div  class="toast-header ${data.status == 1 ? "bg-danger" :"bg-success"}  ">
										<button onclick ="deviceLocation(${data.deviceId}, ${data.id})" class="me-auto text-white btn-notification">${data.notificationHeader}</button>
											<small class="text-white">Just Now</small>
											 <div type="button" class="btn" data-bs-dismiss="toast" aria-label="Close"><i class="fas fa-times"></i></div>
										</div>
										<div class="toast-body bg-light text-black">
											<strong>${data.notificationBody}</strong>
										</div>
										</div>`);
		

		$('#notif-count').attr("data-count", count);


	});
}


// Alert 
var homeNotif = -1;
var smokeNotif = -1;
var fireNotif = -1;
var garageNotif = -1;
function BindAlertSystem(data) {
	// Alert System

	$.each(data, function (index, data) {
		if (data.deviceId == 1) {
			if (data.status == 1 && homeNotif != data.status) {
				$('#homealert').prop('checked', true).trigger('change');
				homeNotif = 1;
			}
			else if (data.status == 0 && homeNotif != data.status) {
				$('#homealert').prop('checked', false).trigger('change');
				homeNotif = 0;
			}
		}

		else if (data.deviceId == 4) {
			if (data.status == 1 && smokeNotif != data.status) {
				$('#smokealert').prop('checked', true).trigger('change');
				smokeNotif = 1;
			}
			else if (data.status == 0 && smokeNotif != data.status) {
				$('#smokealert').prop('checked', false).trigger('change');
				smokeNotif = 0;
			}
		}

		else if (data.deviceId == 3) {
			if (data.status == 1 && fireNotif != data.status) {
				$('#firealert').prop('checked', true).trigger('change');
				fireNotif = 1;
			}
			else if (data.status == 0 && fireNotif != data.status) {
				$('#firealert').prop('checked', false).trigger('change');
				fireNotif = 0;
			}
		}

		else if (data.deviceId == 38) {
			if (data.status == 1 && garageNotif != data.status) {
				$('#garagealert').prop('checked', true).trigger('change');
				garageNotif = 1;
			}
			else if (data.status == 0 && garageNotif != data.status) {
				$('#garagealert').prop('checked', false).trigger('change');
				garageNotif = 0;
			}
		}

	});
}

function deviceLocation(value1, value2) {
	var url = "https://localhost:44303/notification/update?deviceid=" + value1 + "&id=" + value2 ;
	location.replace(url);
}
