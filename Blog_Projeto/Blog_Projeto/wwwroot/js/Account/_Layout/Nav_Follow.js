const navbar = document.querySelector(".nav_top");
const space = document.querySelector(".space");
const stickyOffset = navbar.offsetTop;

function NavbarFunc() {
    if (window.pageYOffset >= stickyOffset) {
        navbar.classList.add("nav_top-fixed");
        space.classList.add("space-fixed");
    }
    else {
        navbar.classList.remove("nav_top-fixed");
        space.classList.remove("space-fixed");
    }
}

window.onscroll = NavbarFunc;