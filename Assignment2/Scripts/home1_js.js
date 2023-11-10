const imgBox = document.querySelector('.imgBox');
const sliders = document.querySelectorAll('.slider');

let counter = 0;
const slideWidth = sliders[0].clientWidth;
const totalSlides = sliders.length;

function nextSlide() {
    counter++;
    if (counter === totalSlides) {
        imgBox.style.transition = "none";
        counter = 0;
        imgBox.style.transform = `translateX(${-counter * slideWidth}px`; 
        setTimeout(() => {
            imgBox.style.transition = "transform 0.5s ease-in-out";
        }, 0);
    } else {
        imgBox.style.transform = `translateX(${-counter * slideWidth}px)`;
    }

    sliders.forEach((slider, index) => {
        if (index === counter) {
            slider.classList.add('active');
        } else {
            slider.classList.remove('active');
        }
    });
}
setInterval(nextSlide, 3000); 


//Picture scroller
let ul = document.querySelector('.scroller-ul');
ul.innerHTML = ul.innerHTML + ul.innerHTML;
let lis = document.querySelectorAll('.scroller-li');

let btns = document.querySelectorAll('.btn');
let spa = -2;
ul.style.width = lis[0].offsetWidth * lis.length + 'px';

function move() {
    if (ul.offsetLeft < -ul.offsetWidth / 2) {
        ul.style.left = '0';
    }
    if (ul.offsetLeft > 0) {
        ul.style.left = -ul.offsetWidth / 2 + 'px';
    }
    ul.style.left = ul.offsetLeft + spa + 'px';
}

let timer = setInterval(move, 30);

ul.addEventListener('mousemove', function () {
    clearInterval(timer);
})
ul.addEventListener('mouseout', function () {
    timer = setInterval(move, 30);
})


/*anchor point*/
document.addEventListener('DOMContentLoaded', function () {
    var links = document.getElementsByClassName('action-link');
    for (var i = 0; i < links.length; i++) {
        links[i].addEventListener('click', scrollToSection);
    }
});
function scrollToSection(event) {
    event.preventDefault();

    var targetId = this.getAttribute('href');
    var targetSection = document.querySelector(targetId);
    if (targetSection) {
        var targetOffsetTop = targetSection.offsetTop;
        window.scrollTo({
            top: targetOffsetTop,
            behavior: 'smooth'
        });
    }
}
var banner = document.querySelector('.banner');
var anchorLinks = document.querySelector('.anchor-links');
var bannerHeight = banner.offsetHeight;
var anchorLinksVisible = false;

function checkAnchorLinks() {
    var scrollY = window.scrollY || window.pageYOffset;

    if (scrollY >= bannerHeight) {
        if (!anchorLinksVisible) {
            anchorLinks.style.top = '50%';
            anchorLinks.style.opacity = 1;
            anchorLinksVisible = true;
        }
    } else {
        anchorLinks.style.opacity = 0;
        anchorLinksVisible = false;
    }
}
window.addEventListener('DOMContentLoaded', checkAnchorLinks);
window.addEventListener('scroll', checkAnchorLinks);



