const openBtn = document.querySelectorAll(".ProfileExtra_Btn");
const closeBtn = document.querySelectorAll(".ProfileExtra_closeBtn");
const Menu = document.querySelectorAll(".Profile_Options");
const overlayer = document.getElementById("overlayer");

openBtn.forEach((opbtn, index) => {
    opbtn.addEventListener("click", () => {
        overlayer.classList.add("OpenProfile");
        Menu[index].classList.add("OpenProfile");
    });
});

closeBtn.forEach((opbtn, index) => {
    opbtn.addEventListener("click", () => {
        overlayer.classList.remove("OpenProfile");
        Menu[index].classList.remove("OpenProfile");
    });
});