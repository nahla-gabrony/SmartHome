/*------------------------------------ change the dropdown List Value--------------------------*/
const links = document.querySelectorAll(".dropdown-menu li a");
const dropdown_toggle = document.querySelector(".dropdown-toggle");
links.forEach(link => {
    link.addEventListener("click", () => {
        selectText = link.querySelector("span").innerHTML;
        selectIcon = link.querySelector('i').classList;
        dropdown_toggle.innerHTML = `<i class="${selectIcon}"> </i> <span class="d-none d-md-flex">${selectText}</span>`;
    });
});
/*------------------------------------ change the page content after select from menu--------------------------*/
const buttonsMenu = document.querySelectorAll(".house-icons-btn");
const houseSections = document.querySelectorAll(".house-section");
const houseParts = document.querySelectorAll(".house-part");
// Click on house Icons
buttonsMenu.forEach(btn => {
    btn.addEventListener("click",()=>{

        //Remove/Add active of icons menu 
        buttonsMenu.forEach(element => {
           element.classList.remove("active");
        });
        btn.classList.add("active");

        //Remove-Add active to Content section
        houseSections.forEach(houseSection => {
           houseSection.classList.remove("active");
        });
        var section = document.getElementById(btn.dataset.target);
        section.classList.add("active");

        //Remove-Add active from house draw
         houseParts.forEach(housePart => {
         housePart.classList.remove("active");
         if (housePart.dataset.target == btn.dataset.target) {
            housePart.classList.add("active");
         }
     });
    })
});
//-- click on part of house
houseParts.forEach(housePart => {
    housePart.addEventListener("click", () => {
        if (housePart.dataset.target !== "Garden" && housePart.dataset.target !== "main-systems" ) {
            dropdown_toggle.innerHTML = `<i class= "fas fs-4 pe-2 ${housePart.dataset.icon}"> </i> <span class="d-none d-md-flex">${housePart.dataset.target}</span>`;
        }
        

        // Add/Remove active of icons menu 
        buttonsMenu.forEach(btn => {
             btn.classList.remove("active");
            if (btn.dataset.target == housePart.dataset.target) {
                 btn.classList.add("active");
             }
        });
    
        //Remove-Add active to Content section
        houseSections.forEach(houseSection => {
            houseSection.classList.remove("active");
        });
        var section = document.getElementById(housePart.dataset.target);
        section.classList.add("active");
        //Remove-Add active from house draw
        houseParts.forEach(element => {
            element.classList.remove("active");
        });
        housePart.classList.add("active");
    });
});
/*------------------------------------------ Tooltip ---------------------------*/
var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
    return new bootstrap.Tooltip(tooltipTriggerEl)
})
/*------------------------------------------ Slider ---------------------------*/
/*Bedroom One */
var airValRoomOne = 0;
var lightValRoomOne = 0;
var soundValRoomOne = 0;

function createAirRoomOne() {
    $('<div class="air-gradient" />').insertBefore($("#RoomOne #air-slider .rs-tooltip"));
    $('#RoomOne #air-slider').append(`<input type="hidden" data-id="12" class="input-slider" id="air-inputSlider">`);
}

function updateAirRoomOne() {
    $('#RoomOne #air-inputSlider').val($("#RoomOne input[name=air-slider]").val()).trigger('change');

    airVal = -255 + parseInt($("#RoomOne #air-slider .rs-tooltip-text").html() * 4.25);
    $("#RoomOne .air-gradient").css({
        background: "hsl(" + airValRoomOne + ", 100%, 57%)"
    });
   
}

$("#RoomOne #air-slider").roundSlider({
    radius: 40,
    width: 10,
    min: 10,
    max: 60,
    circleShape: "pie",
    handleSize: "+16",
    handleShape: "dot",
    sliderType: "min-range",
    startAngle: 315,
    value: airValRoomOne,
    editableTooltip: false,
    mouseScrollAction: true,
    change: updateAirRoomOne,
    drag: updateAirRoomOne,
    create: function () {
        createAirRoomOne();
        updateAirRoomOne();
    }
});

function createLightRoomOne() {
    $('<div class="light-gradient" />').insertBefore($("#RoomOne #light-slider .rs-tooltip"));
    $('#RoomOne #light-slider').append(`<input type="hidden" data-id="11" class="input-slider" id="light-inputSlider">`);
}
function updateLightRoomOne() {
    $('#RoomOne #light-inputSlider').val($("#RoomOne input[name=light-slider]").val()).trigger('change');

    lightVal = -255 + parseInt($("#RoomOne #light-slider .rs-tooltip-text").html() * 5.1);
    $("#RoomOne .light-gradient").css({
        background: "hsl(" + lightValRoomOne + ", 100%, 57%)"
    });
}
$("#RoomOne #light-slider").roundSlider({
    radius: 40,
    width: 10,
    min: 1,
    max: 100,
    circleShape: "pie",
    handleSize: "+16",
    handleShape: "dot",
    sliderType: "min-range",
    startAngle: 315,
    value: lightValRoomOne,
    editableTooltip: false,
    mouseScrollAction: true,
    change: updateLightRoomOne,
    drag: updateLightRoomOne,
    create: function () {
        createLightRoomOne();
        updateLightRoomOne();
    }
});
function createSoundRoomOne() {
    $('<div class="sound-gradient" />').insertBefore($("#RoomOne #sound-slider .rs-tooltip"));
    $('#RoomOne #sound-slider').append(`<input type="hidden" data-id="10" class="input-slider" id="sound-inputSlider">`);
}
function updateSoundRoomOne() {
    $('#RoomOne #sound-inputSlider').val($("#RoomOne input[name=sound-slider]").val()).trigger('change');

    soundVal = -255 + parseInt($("#RoomOne #sound-slider .rs-tooltip-text").html() * 5.1);
    $("#RoomOne .sound-gradient").css({
        background: "hsl(" + soundValRoomOne + ", 100%, 57%)"
    });

}

$("#RoomOne #sound-slider").roundSlider({
    radius: 40,
    width: 10,
    min: 0,
    max: 100,
    circleShape: "pie",
    handleSize: "+16",
    handleShape: "dot",
    sliderType: "min-range",
    startAngle: 315,
    value: soundValRoomOne,
    editableTooltip: false,
    mouseScrollAction: true,
    change: updateSoundRoomOne,
    drag: updateSoundRoomOne,
    create: function () {
        createSoundRoomOne();
        updateSoundRoomOne();
    }
});
/*Bedroom Two */
var airValRoomTwo = 0;
var soundValRoomTwo = 0;
var lightValRoomTwo = 0;

function createAirRoomTwo() {
    $('<div class="air-gradient" />').insertBefore($("#RoomTwo #air-slider .rs-tooltip"));
    $('#RoomTwo #air-slider').append(`<input type="hidden" data-id="17" class="input-slider" id="air-inputSlider">`);
}

function updateAirRoomTwo() {
    $('#RoomTwo #air-inputSlider').val($("#RoomTwo input[name=air-slider]").val()).trigger('change');

    airVal = -255 + parseInt($("#RoomTwo #air-slider .rs-tooltip-text").html() * 4.25);
    $("#RoomTwo .air-gradient").css({
        background: "hsl(" + airValRoomTwo + ", 100%, 57%)"
    });

}

$("#RoomTwo #air-slider").roundSlider({
    radius: 40,
    width: 10,
    min: 10,
    max: 60,
    circleShape: "pie",
    handleSize: "+16",
    handleShape: "dot",
    sliderType: "min-range",
    startAngle: 315,
    value: airValRoomTwo,
    editableTooltip: false,
    mouseScrollAction: true,
    change: updateAirRoomTwo,
    drag: updateAirRoomTwo,
    create: function () {
        createAirRoomTwo();
        updateAirRoomTwo();
    }
});

function createLightRoomTwo() {
    $('<div class="light-gradient" />').insertBefore($("#RoomTwo #light-slider .rs-tooltip"));
    $('#RoomTwo #light-slider').append(`<input type="hidden" data-id="16" class="input-slider" id="light-inputSlider">`);
}
function updateLightRoomTwo() {
    $('#RoomTwo #light-inputSlider').val($("#RoomTwo input[name=light-slider]").val()).trigger('change');

    lightVal = -255 + parseInt($("#RoomTwo #light-slider .rs-tooltip-text").html() * 5.1);
    $("#RoomTwo .light-gradient").css({
        background: "hsl(" + lightValRoomTwo + ", 100%, 57%)"
    });
}
$("#RoomTwo #light-slider").roundSlider({
    radius: 40,
    width: 10,
    min: 1,
    max: 100,
    circleShape: "pie",
    handleSize: "+16",
    handleShape: "dot",
    sliderType: "min-range",
    startAngle: 315,
    value: lightValRoomTwo,
    editableTooltip: false,
    mouseScrollAction: true,
    change: updateLightRoomTwo,
    drag: updateLightRoomTwo,
    create: function () {
        createLightRoomTwo();
        updateLightRoomTwo();
    }
});
function createSoundRoomTwo() {
    $('<div class="sound-gradient" />').insertBefore($("#RoomTwo #sound-slider .rs-tooltip"));
    $('#RoomTwo #sound-slider').append(`<input type="hidden" data-id="15" class="input-slider" id="sound-inputSlider">`);
}
function updateSoundRoomTwo() {
    $('#RoomTwo #sound-inputSlider').val($("#RoomTwo input[name=sound-slider]").val()).trigger('change');

    soundVal = -255 + parseInt($("#RoomTwo #sound-slider .rs-tooltip-text").html() * 5.1);
    $("#RoomTwo .sound-gradient").css({
        background: "hsl(" + soundValRoomTwo + ", 100%, 57%)"
    });

}

$("#RoomTwo #sound-slider").roundSlider({
    radius: 40,
    width: 10,
    min: 0,
    max: 100,
    circleShape: "pie",
    handleSize: "+16",
    handleShape: "dot",
    sliderType: "min-range",
    startAngle: 315,
    value: soundValRoomTwo,
    editableTooltip: false,
    mouseScrollAction: true,
    change: updateSoundRoomTwo,
    drag: updateSoundRoomTwo,
    create: function () {
        createSoundRoomTwo();
        updateSoundRoomTwo();
    }
});

/*Bedroom Three */
var airValRoomThree = 0;
var soundValRoomThree = 0;
var lightValRoomThree = 0;

function createAirRoomThree() {
    $('<div class="air-gradient" />').insertBefore($("#RoomThree #air-slider .rs-tooltip"));
    $('#RoomThree #air-slider').append(`<input type="hidden" data-id="22" class="input-slider" id="air-inputSlider">`);
}

function updateAirRoomThree() {
    $('#RoomThree #air-inputSlider').val($("#RoomThree input[name=air-slider]").val()).trigger('change');

    airVal = -255 + parseInt($("#RoomThree #air-slider .rs-tooltip-text").html() * 4.25);
    $("#RoomThree .air-gradient").css({
        background: "hsl(" + airValRoomThree + ", 100%, 57%)"
    });

}

$("#RoomThree #air-slider").roundSlider({
    radius: 40,
    width: 10,
    min: 10,
    max: 60,
    circleShape: "pie",
    handleSize: "+16",
    handleShape: "dot",
    sliderType: "min-range",
    startAngle: 315,
    value: airValRoomThree,
    editableTooltip: false,
    mouseScrollAction: true,
    change: updateAirRoomThree,
    drag: updateAirRoomThree,
    create: function () {
        createAirRoomThree();
        updateAirRoomThree();
    }
});

function createLightRoomThree() {
    $('<div class="light-gradient" />').insertBefore($("#RoomThree #light-slider .rs-tooltip"));
    $('#RoomThree #light-slider').append(`<input type="hidden" data-id="21" class="input-slider" id="light-inputSlider">`);
}
function updateLightRoomThree() {
    $('#RoomThree #light-inputSlider').val($("#RoomThree input[name=light-slider]").val()).trigger('change');

    lightVal = -255 + parseInt($("#RoomThree #light-slider .rs-tooltip-text").html() * 5.1);
    $("#RoomThree .light-gradient").css({
        background: "hsl(" + lightValRoomThree + ", 100%, 57%)"
    });
}
$("#RoomThree #light-slider").roundSlider({
    radius: 40,
    width: 10,
    min: 1,
    max: 100,
    circleShape: "pie",
    handleSize: "+16",
    handleShape: "dot",
    sliderType: "min-range",
    startAngle: 315,
    value: lightValRoomThree,
    editableTooltip: false,
    mouseScrollAction: true,
    change: updateLightRoomThree,
    drag: updateLightRoomThree,
    create: function () {
        createLightRoomThree();
        updateLightRoomThree();
    }
});
function createSoundRoomThree() {
    $('<div class="sound-gradient" />').insertBefore($("#RoomThree #sound-slider .rs-tooltip"));
    $('#RoomThree #sound-slider').append(`<input type="hidden" data-id="20" class="input-slider" id="sound-inputSlider">`);
}
function updateSoundRoomThree() {
    $('#RoomThree #sound-inputSlider').val($("#RoomThree input[name=sound-slider]").val()).trigger('change');

    soundVal = -255 + parseInt($("#RoomThree #sound-slider .rs-tooltip-text").html() * 5.1);
    $("#RoomThree .sound-gradient").css({
        background: "hsl(" + soundValRoomThree + ", 100%, 57%)"
    });

}

$("#RoomThree #sound-slider").roundSlider({
    radius: 40,
    width: 10,
    min: 0,
    max: 100,
    circleShape: "pie",
    handleSize: "+16",
    handleShape: "dot",
    sliderType: "min-range",
    startAngle: 315,
    value: soundValRoomThree,
    editableTooltip: false,
    mouseScrollAction: true,
    change: updateSoundRoomThree,
    drag: updateSoundRoomThree,
    create: function () {
        createSoundRoomThree();
        updateSoundRoomThree();
    }
});

/*Living Room */
var airValLiving = 0;
var soundValLiving = 0;
var lightValLiving = 0;

function createAirLiving() {
    $('<div class="air-gradient" />').insertBefore($("#Living #air-slider .rs-tooltip"));
    $('#Living #air-slider').append(`<input type="hidden" data-id="27" class="input-slider" id="air-inputSlider">`);
}

function updateAirLiving() {
    $('#Living #air-inputSlider').val($("#Living input[name=air-slider]").val()).trigger('change');

    airVal = -255 + parseInt($("#Living #air-slider .rs-tooltip-text").html() * 4.25);
    $("#Living .air-gradient").css({
        background: "hsl(" + airValLiving + ", 100%, 57%)"
    });

}

$("#Living #air-slider").roundSlider({
    radius: 40,
    width: 10,
    min: 10,
    max: 60,
    circleShape: "pie",
    handleSize: "+16",
    handleShape: "dot",
    sliderType: "min-range",
    startAngle: 315,
    value: airValLiving,
    editableTooltip: false,
    mouseScrollAction: true,
    change: updateAirLiving,
    drag: updateAirLiving,
    create: function () {
        createAirLiving();
        updateAirLiving();
    }
});

function createLightLiving() {
    $('<div class="light-gradient" />').insertBefore($("#Living #light-slider .rs-tooltip"));
    $('#Living #light-slider').append(`<input type="hidden" data-id="26" class="input-slider" id="light-inputSlider">`);
}
function updateLightLiving() {
    $('#Living #light-inputSlider').val($("#Living input[name=light-slider]").val()).trigger('change');

    lightVal = -255 + parseInt($("#Living #light-slider .rs-tooltip-text").html() * 5.1);
    $("#Living .light-gradient").css({
        background: "hsl(" + lightValLiving + ", 100%, 57%)"
    });
}
$("#Living #light-slider").roundSlider({
    radius: 40,
    width: 10,
    min: 1,
    max: 100,
    circleShape: "pie",
    handleSize: "+16",
    handleShape: "dot",
    sliderType: "min-range",
    startAngle: 315,
    value: lightValLiving,
    editableTooltip: false,
    mouseScrollAction: true,
    change: updateLightLiving,
    drag: updateLightLiving,
    create: function () {
        createLightLiving();
        updateLightLiving();
    }
});
function createSoundLiving() {
    $('<div class="sound-gradient" />').insertBefore($("#Living #sound-slider .rs-tooltip"));
    $('#Living #sound-slider').append(`<input type="hidden" data-id="25" class="input-slider" id="sound-inputSlider">`);
}
function updateSoundLiving() {
    $('#Living #sound-inputSlider').val($("#Living input[name=sound-slider]").val()).trigger('change');

    soundVal = -255 + parseInt($("#Living #sound-slider .rs-tooltip-text").html() * 5.1);
    $("#Living .sound-gradient").css({
        background: "hsl(" + soundValLiving + ", 100%, 57%)"
    });

}

$("#Living #sound-slider").roundSlider({
    radius: 40,
    width: 10,
    min: 0,
    max: 100,
    circleShape: "pie",
    handleSize: "+16",
    handleShape: "dot",
    sliderType: "min-range",
    startAngle: 315,
    value: soundValLiving,
    editableTooltip: false,
    mouseScrollAction: true,
    change: updateSoundLiving,
    drag: updateSoundLiving,
    create: function () {
        createSoundLiving();
        updateSoundLiving();
    }
});
/*Dining Room */
var airValDining = 0;
var soundValDining = 0;
var lightValDining = 0;

function createAirDining() {
    $('<div class="air-gradient" />').insertBefore($("#Dining #air-slider .rs-tooltip"));
    $('#Dining #air-slider').append(`<input type="hidden" data-id="30" class="input-slider" id="air-inputSlider">`);
}

function updateAirDining() {
    $('#Dining #air-inputSlider').val($("#Dining input[name=air-slider]").val()).trigger('change');

    airVal = -255 + parseInt($("#Dining #air-slider .rs-tooltip-text").html() * 4.25);
    $("#Dining .air-gradient").css({
        background: "hsl(" + airValDining + ", 100%, 57%)"
    });

}

$("#Dining #air-slider").roundSlider({
    radius: 40,
    width: 10,
    min: 10,
    max: 60,
    circleShape: "pie",
    handleSize: "+16",
    handleShape: "dot",
    sliderType: "min-range",
    startAngle: 315,
    value: airValDining,
    editableTooltip: false,
    mouseScrollAction: true,
    change: updateAirDining,
    drag: updateAirDining,
    create: function () {
        createAirDining();
        updateAirDining();
    }
});

function createLightDining() {
    $('<div class="light-gradient" />').insertBefore($("#Dining #light-slider .rs-tooltip"));
    $('#Dining #light-slider').append(`<input type="hidden" data-id="29" class="input-slider" id="light-inputSlider">`);
}
function updateLightDining() {
    $('#Dining #light-inputSlider').val($("#Dining input[name=light-slider]").val()).trigger('change');

    lightVal = -255 + parseInt($("#Dining #light-slider .rs-tooltip-text").html() * 5.1);
    $("#Dining .light-gradient").css({
        background: "hsl(" + lightValDining + ", 100%, 57%)"
    });
}
$("#Dining #light-slider").roundSlider({
    radius: 40,
    width: 10,
    min: 1,
    max: 100,
    circleShape: "pie",
    handleSize: "+16",
    handleShape: "dot",
    sliderType: "min-range",
    startAngle: 315,
    value: lightValDining,
    editableTooltip: false,
    mouseScrollAction: true,
    change: updateLightDining,
    drag: updateLightDining,
    create: function () {
        createLightDining();
        updateLightDining();
    }
});
function createSoundDining() {
    $('<div class="sound-gradient" />').insertBefore($("#Dining #sound-slider .rs-tooltip"));
    $('#Dining #sound-slider').append(`<input type="hidden" data-id="28" class="input-slider" id="sound-inputSlider">`);
}
function updateSoundDining() {
    $('#Dining #sound-inputSlider').val($("#Dining input[name=sound-slider]").val()).trigger('change');

    soundVal = -255 + parseInt($("#Dining #sound-slider .rs-tooltip-text").html() * 5.1);
    $("#Dining .sound-gradient").css({
        background: "hsl(" + soundValDining + ", 100%, 57%)"
    });

}

$("#Dining #sound-slider").roundSlider({
    radius: 40,
    width: 10,
    min: 0,
    max: 100,
    circleShape: "pie",
    handleSize: "+16",
    handleShape: "dot",
    sliderType: "min-range",
    startAngle: 315,
    value: soundValDining,
    editableTooltip: false,
    mouseScrollAction: true,
    change: updateSoundDining,
    drag: updateSoundDining,
    create: function () {
        createSoundDining();
        updateSoundDining();
    }
});

/*Office Room */
var airValOffice = 0;
var soundValOffice = 0;
var lightValOffice = 0;

function createAirOffice() {
    $('<div class="air-gradient" />').insertBefore($("#Office #air-slider .rs-tooltip"));
    $('#Office #air-slider').append(`<input type="hidden" data-id="37" class="input-slider" id="air-inputSlider">`);
}

function updateAirOffice() {
    $('#Office #air-inputSlider').val($("#Office input[name=air-slider]").val()).trigger('change');

    airVal = -255 + parseInt($("#Office #air-slider .rs-tooltip-text").html() * 4.25);
    $("#Office .air-gradient").css({
        background: "hsl(" + airValOffice + ", 100%, 57%)"
    });

}

$("#Office #air-slider").roundSlider({
    radius: 40,
    width: 10,
    min: 10,
    max: 60,
    circleShape: "pie",
    handleSize: "+16",
    handleShape: "dot",
    sliderType: "min-range",
    startAngle: 315,
    value: airValOffice,
    editableTooltip: false,
    mouseScrollAction: true,
    change: updateAirOffice,
    drag: updateAirOffice,
    create: function () {
        createAirOffice();
        updateAirOffice();
    }
});

function createLightOffice() {
    $('<div class="light-gradient" />').insertBefore($("#Office #light-slider .rs-tooltip"));
    $('#Office #light-slider').append(`<input type="hidden" data-id="36" class="input-slider" id="light-inputSlider">`);
}
function updateLightOffice() {
    $('#Office #light-inputSlider').val($("#Office input[name=light-slider]").val()).trigger('change');

    lightVal = -255 + parseInt($("#Office #light-slider .rs-tooltip-text").html() * 5.1);
    $("#Office .light-gradient").css({
        background: "hsl(" + lightValOffice + ", 100%, 57%)"
    });
}
$("#Office #light-slider").roundSlider({
    radius: 40,
    width: 10,
    min: 1,
    max: 100,
    circleShape: "pie",
    handleSize: "+16",
    handleShape: "dot",
    sliderType: "min-range",
    startAngle: 315,
    value: lightValOffice,
    editableTooltip: false,
    mouseScrollAction: true,
    change: updateLightOffice,
    drag: updateLightOffice,
    create: function () {
        createLightOffice();
        updateLightOffice();
    }
});
function createSoundOffice() {
    $('<div class="sound-gradient" />').insertBefore($("#Office #sound-slider .rs-tooltip"));
    $('#Office #sound-slider').append(`<input type="hidden" data-id="35" class="input-slider" id="sound-inputSlider">`);
}
function updateSoundOffice() {
    $('#Office #sound-inputSlider').val($("#Office input[name=sound-slider]").val()).trigger('change');

    soundVal = -255 + parseInt($("#Office #sound-slider .rs-tooltip-text").html() * 5.1);
    $("#Office .sound-gradient").css({
        background: "hsl(" + soundValOffice + ", 100%, 57%)"
    });

}

$("#Office #sound-slider").roundSlider({
    radius: 40,
    width: 10,
    min: 0,
    max: 100,
    circleShape: "pie",
    handleSize: "+16",
    handleShape: "dot",
    sliderType: "min-range",
    startAngle: 315,
    value: soundValOffice,
    editableTooltip: false,
    mouseScrollAction: true,
    change: updateSoundOffice,
    drag: updateSoundOffice,
    create: function () {
        createSoundOffice();
        updateSoundOffice();
    }
});