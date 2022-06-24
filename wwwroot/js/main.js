// /* ScrollReveal: Mostrar elementos quando der scroll na página */
const scrollReveal = ScrollReveal({
  origin: 'top',
  distance: '30px',
  duration: 600,
  reset: true
})
// /*é a sequencia para aparecer na pagina*/
scrollReveal.reveal(
  `
#sliderHome .maindiv,
#imgHome img, 
#dolls .dolls,
#textAbout img,
#contactNow,
.backgroundGhost,
.imgGost,
.imgGhost,
.wolf,
.imgWitch,
.imgWitch2,
.imgCauldron,
.imgCauldron2,
.imgJack,
.imgJack2,
.imgZombie,
.imgZumbie2,
.imgTerror,
#imgBox img,
.img-list img,
.lo1,
.lo2,
.lo3,
.flex img,
#login-container,
.table.table-dark.table-houer,
footer,
.box-container,
table,
article,
iframe 
 `,
  { interval: 100 }
)

/* Botão voltar para o topo */
/*para quando eu for rolar o botão aparecer em determinado ponto da tela*/
const backToTopButton = document.querySelector('.back-to-top')

function backToTop() {
  if (window.scrollY >= 5) {
    backToTopButton.classList.add('show')
  } else {
    backToTopButton.classList.remove('show')
  }
}

/*When Scroll */
window.addEventListener('scroll', function () {
  backToTop()
})

// Função ver mais e ver menos -Sobre nós / trabalhando com o style
var stitches = document.getElementById('stitches')
var More = document.getElementById('More')
var see = document.getElementById('see')

function moreRedC() {
  if (stitches.style.display === 'none') {
    stitches.style.display = 'initial'
    More.style.opacity = '0'
    see.innerHTML = ''
  } else {
    stitches.style.display = 'none'
    More.style.opacity = '1'
    inserts.style.height = ''
    see.innerHTML = ''
  }
}

// Para a div ir para baixo -Sobre nós / trabalhando com o style
var textAbout = document.querySelector('.textAbout')
var grid3 = document.querySelector('.grid3')
var dolls = document.querySelector('.dolls')
var gridImg = document.querySelector('.u')
var shop = document.querySelector('.imgHerry.shop')
var textShop = document.querySelector('.textShop')
var Book = document.querySelector('.imgHerry.Book')
var textBook = document.querySelector('.textBook')
var maindiv = document.querySelector('.maindiv')
var contactNow = document.getElementById('contactNow')
var contact = document.getElementById('contact')

function moreRedA() {
  if (More.style.opacity === '1') {
    contactNow.style.top = 46.3 + 'rem'
    contact.style.top = 55.9 + 'rem'
    textAbout.classList.add('out')
    grid3.classList.add('out')
    dolls.classList.add('out')
    gridImg.classList.add('out')
    shop.classList.add('out')
    textShop.classList.add('out')
    Book.classList.add('out')
    textBook.classList.add('out')
    maindiv.classList.add('out')
    see.innerHTML = ''
  } else {
    contactNow.style.top = ''
    contact.style.top = ''
    textAbout.classList.remove('out')
    grid3.classList.remove('out')
    dolls.classList.remove('out')
    gridImg.classList.remove('out')
    shop.classList.remove('out')
    textShop.classList.remove('out')
    Book.classList.remove('out')
    textBook.classList.remove('out')
    maindiv.classList.remove('out')
    see.innerHTML = ''
  }
}
