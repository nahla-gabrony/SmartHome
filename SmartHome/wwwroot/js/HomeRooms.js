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
const selectMenu = document.getElementById("house-menu");
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
        if (housePart.dataset.target !== "garden" && housePart.dataset.target !== "main-systems" ) {
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
var airVal = 0;
var soundVal = 0;
var lightVal = 0;

function createAirSlider() {
    $('<div class="air-gradient" />').insertBefore($("#air-slider-room1 .rs-tooltip"));
    $('#air-slider-room1').append(`<input type="hidden" data-id="9" class="input-slider" id="air-inputSlider-room1">`);
}

function updateAirSlider() {
    $('#air-inputSlider-room1').val($("input[name=air-slider-room1]").val()).trigger('change');

    airVal = -255 + parseInt($("#air-slider-room1 .rs-tooltip-text").html() * 4.25);
    $(".air-gradient").css({
        background: "hsl(" + airVal + ", 100%, 57%)"
    });
   
}

$("#air-slider-room1").roundSlider({
    radius: 40,
    width: 10,
    min: 10,
    max: 60,
    circleShape: "pie",
    handleSize: "+16",
    handleShape: "dot",
    sliderType: "min-range",
    startAngle: 315,
    value: airVal,
    editableTooltip: false,
    mouseScrollAction: true,
    change: updateAirSlider,
    drag: updateAirSlider,
    create: function () {
        createAirSlider();
        updateAirSlider();
    }
});

function createLightSlider() {
    $('<div class="light-gradient" />').insertBefore($("#light-slider-room1 .rs-tooltip"));
    $('#light-slider-room1').append(`<input type="hidden" data-id="11" class="input-slider" id="light-inputSlider-room1">`);
}
function updateLightSlider() {
    $('#light-inputSlider-room1').val($("input[name=light-slider-room1]").val()).trigger('change');

    lightVal = -255 + parseInt($("#light-slider-room1 .rs-tooltip-text").html() * 5.1);
    $(".light-gradient").css({
        background: "hsl(" + lightVal + ", 100%, 57%)"
    });
}
$("#light-slider-room1").roundSlider({
    radius: 40,
    width: 10,
    min: 1,
    max: 100,
    circleShape: "pie",
    handleSize: "+16",
    handleShape: "dot",
    sliderType: "min-range",
    startAngle: 315,
    value: lightVal,
    editableTooltip: false,
    mouseScrollAction: true,
    change: updateLightSlider,
    drag: updateLightSlider,
    create: function () {
        createLightSlider();
        updateLightSlider();
    }
});
function createSoundSlider() {
    $('<div class="sound-gradient" />').insertBefore($("#sound-slider-room1 .rs-tooltip"));
    $('#sound-slider-room1').append(`<input type="hidden" data-id="10" class="input-slider" id="sound-inputSlider-room1">`);
}
function updateSoundSlider() {
    $('#sound-inputSlider-room1').val($("input[name=sound-slider-room1]").val()).trigger('change');

    soundVal = -255 + parseInt($("#sound-slider-room1 .rs-tooltip-text").html() * 5.1);
    $(".sound-gradient").css({
        background: "hsl(" + soundVal + ", 100%, 57%)"
    });

}

$("#sound-slider-room1").roundSlider({
    radius: 40,
    width: 10,
    min: 0,
    max: 100,
    circleShape: "pie",
    handleSize: "+16",
    handleShape: "dot",
    sliderType: "min-range",
    startAngle: 315,
    value: soundVal,
    editableTooltip: false,
    mouseScrollAction: true,
    change: updateSoundSlider,
    drag: updateSoundSlider,
    create: function () {
        createSoundSlider();
        updateSoundSlider();
    }
});

