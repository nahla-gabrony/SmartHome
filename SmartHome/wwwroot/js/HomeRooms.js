/* ------------------------------------------------------------sidebar----------------------------------------*/
const sidebar = document.querySelector("#sidebar");
const sidebarBtn = document.querySelector("#sidebar-button");

sidebarBtn.addEventListener("click", () => {
    sidebar.classList.toggle("active");
});
/*------------------------------------ change the dropdown List Value--------------------------*/
const links = document.querySelectorAll(".dropdown-menu li a");
const element = document.querySelector(".dropdown-toggle");
links.forEach(link => {
    link.addEventListener("click", () => {
        selectText = link.querySelector("span").innerHTML;
        selectIcon = link.querySelector('i').classList;
        element.innerHTML = `<i class="${selectIcon}"> </i> <span class="d-none d-md-flex">${selectText}</span>`;
    });
});
/*------------------------------------ change the page content after select from menu--------------------------*/
const selectMenu = document.getElementById("house-menu");
const buttonsMenu = document.querySelectorAll(".house-icons a");
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
//var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
//var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
//    return new bootstrap.Tooltip(tooltipTriggerEl)
//})

//// Slider
//airVal = 0;
//soundVal = 0;
//lightVal = 0;

//function createAirSlider() {
//  $('<div class="air-gradient" />').insertBefore($("#air-slider .rs-tooltip"));
//}

//function updateAirSlider() {
//  // val = -230 + parseInt($(".rs-tooltip-text").html() * 7.5);
//   airVal = -255 + parseInt($("#air-slider .rs-tooltip-text").html() * 4.25);
//  $(".air-gradient").css({
//    background: "hsl(" + airVal + ", 100%, 57%)"
//  });
  
//}

//$("#air-slider").roundSlider({
//  radius: 40,
//  width: 10,
//  min: 10,
//  max: 60,
//  circleShape: "pie",
//  handleSize: "+16",
//  handleShape: "dot",
//  sliderType: "min-range",
//  startAngle: 315,
//  value: airVal,
//  editableTooltip: false,
//  mouseScrollAction: true,
//  change: updateAirSlider,
//  drag: updateAirSlider,
//  create: function () {
//   createAirSlider();
//    updateAirSlider();
//  }
//});


//function createSoundSlider() {
//  $('<div class="sound-gradient" />').insertBefore($("#sound-slider .rs-tooltip"));
//}
//function updateSoundSlider() {
//   soundVal = -255 + parseInt($("#sound-slider .rs-tooltip-text").html() * 5.1);
//  $(".sound-gradient").css({
//    background: "hsl(" + soundVal + ", 100%, 57%)"
//  });
 
//}

//$("#sound-slider").roundSlider({
//  radius: 40,
//  width: 10,
//  min: 0,
//  max: 50,
//  circleShape: "pie",
//  handleSize: "+16",
//  handleShape: "dot",
//  sliderType: "min-range",
//  startAngle: 315,
//  value: soundVal,
//  editableTooltip: false,
//  mouseScrollAction: true,
//  change: updateSoundSlider,
//  drag: updateSoundSlider,
//  create: function () {
//    createSoundSlider();
//    updateSoundSlider();
//  }
//});

//function createLightSlider() {
//  $('<div class="light-gradient" />').insertBefore($("#light-slider .rs-tooltip"));
//}
//function updateLightSlider() {
//  lightVal = -255 + parseInt($("#light-slider .rs-tooltip-text").html() * 5.1);
//  $(".light-gradient").css({
//    background: "hsl(" + lightVal + ", 100%, 57%)"
//  });
//}
//$("#light-slider").roundSlider({
//  radius: 40,
//  width: 10,
//  min: 1,
//  max: 50,
//  circleShape: "pie",
//  handleSize: "+16",
//  handleShape: "dot",
//  sliderType: "min-range",
//  startAngle: 315,
//  value: lightVal,
//  editableTooltip: false,
//  mouseScrollAction: true,
//  change: updateLightSlider,
//  drag: updateLightSlider,
//  create: function () {
//    createLightSlider();
//    updateLightSlider();
//  }
});
