function openLogin(){
    $('.modal-Login-dialog').addClass('open');
}
function openCreate(){
    $('.modal-Create-dialog').addClass('open');
}
function removeLogin(){
    $('.modal-Login-dialog').removeClass('open');
}function removeCreate(){
    $('.modal-Create-dialog').removeClass('open');
}
function addType(){
    $('.modal-Type-dialog').addClass('open');
}
function removeType(){
    $('.modal-Type-dialog').removeClass('open');
}
function addBook(){
    $('.modal-Book-dialog').addClass('open');
}
function removeBook(){
    $('.modal-Book-dialog').removeClass('open');
}
$(document).ready(function () {
    $(".main-contain").html($(".main-contain").html().replaceAll(/[“”"]/g, '<br>'))
    $(".main-story").html($(".main-story").html().replaceAll(/[“”"]/g, '<br>'))
})
function scrollDown(valuse){
    let height = $('.main-contain').height()
    $('.read-More').click(function(){
            $('.content-Synopsis').css('max-height',height)
            $('.read-More').css({'top': height-20,'opacity':'0'}) 
    })
}

function scrollChange() {
    if (document.body.scrollTop > 400 || document.documentElement.scrollTop > 400) {
        $('#myBtn').css('display', 'block');
        $('#main-header').css('background-color', '#f6f7f8');
        $('#nav-header>li>a').css('color', "#000");
        $('.header-login a').css('color', "#000");
        $('.header-login').css('border-color', 'black')
        $('#nav-header li').hover(function () {
            $(this).css('background-color', 'rgba(199, 203, 209, 0.889)')
        }, function () {
            $(this).css('background-color', 'transparent')
        })
    }
    else {
        $('#nav-header>li>a').css('color', "#fff");
        $('#myBtn').css('display', 'none');
        $('.header-login').css('border-color', '#fff')
        $('.header-login a').css('color', "#fff");
        $('header').css('background-color', 'transparent');
        $('#nav-header>li').hover(function () {
            $(this).css('background-color', 'transparent')
        }, function () {
            $(this).css('border-bottom', 'none')
        })
    }
}
function moveSlide(){
    let total = $('.content-Finished .col-5').length;
    let drive = (total/4).toFixed(2)
    var slideTime = 0;
        $(document).on('click','.move-next',function(){
            slideTime+=Math.round(((drive)*100)/(total/2))
            if(slideTime >=100){ 
                slideTime = 100;            
            }
            $('.content-Finished .row').css('transform',`translate3d(-${slideTime}%,0px,0px)`)
               $('.move-next').css('opacity',1) 
               $('.move-prev').css('opacity',0.5) 
            })
            $(document).on('click','.move-prev',function(){
                slideTime = 0
                $('.content-Finished .row').css('transform',`translate3d(0px,0px,0px)`)
                $('.move-next').css('opacity','0.5') 
                $('.move-prev').css('opacity','1') 
            })
}
function showBtnSlide(){
    var number = $('.content-Finished .col-5').length;
    if(number>=8){
        $('.next-slide-nav').css('display','block')
    }
    
}
$(document).ready(function(){
    $('.header-login').click(openLogin)
})
$(document).ready(function(){
    $('.Create-book').click(openCreate)
})
$(document).ready(function(){
    $('.type_Book').click(addType)
    $('.name_Book').click(addBook)
})
$(document).ready(function(){
    $('.modal-container').click(function(event){
        event.stopPropagation();
    })
})
$(document).ready(function(){
    $('.modal-close').click(removeCreate)
    $('.modal-Create-dialog').click(removeCreate)
    $('.modal-Type-dialog').click(removeType) 
    $('.modal-Book-dialog').click(removeBook)
})
$(document).ready(function(){
    $('.modal-close').click(removeLogin)
    $('.modal-Login-dialog').click(removeLogin)
})
$(document).ready(function(){
    $('#myBtn').click(function(){
       window.scrollTo({
           top: 0,
           behavior: 'smooth'
       })
    })
})

$(document).ready(showBtnSlide)
window.onscroll = function() {scrollChange()};
$(document).ready(moveSlide) 
$(document).ready(scrollDown)


function deepBlue() {
    $('body').css('background', 'rgb(0,59,102)')
    $('.main-story').css('color', 'white')
    $('.story_ep').css('color', 'white')
    $('.sub_side').css('color', 'white')

}
function slime() {
    $('body').css('background', '#e6f0e6')
    $('.main-story').css('color', 'black')
    $('.story_ep').css('color', 'black')
    $('.sub_side').css('color', 'black')
}
function lightGray() {
    $('body').css('background', '#a7b1b4')
    $('.main-story').css('color', 'black')
    $('.story_ep').css('color', 'black')
    $('.sub_side').css('color', 'black')

}
function wheat() {
    $('body').css('background', '#f6f4ec')
    $('.main-story').css('color', 'black')
    $('.story_ep').css('color', 'black')
    $('.sub_side').css('color', 'black')
}
function black() {
    $('body').css('background', '#000')
    $('.main-story').css('color', 'white')
    $('.story_ep').css('color', 'white')
    $('.sub_side').css('color', 'white')
}
$(document).ready(function () {
    $('.deep-blue').click(deepBlue)
    $('.slime').click(slime)
    $('.light-gray').click(lightGray)
    $('.wheat').click(wheat)
    $('.black').click(black)
})
function textStyle(value) {
    if (value == 1)
        $('.main-story').css('font-family', 'Time New Roman')
    if (value == 2)
        $('.main-story').css('font-family', 'Roboto')
    if (value == 3)
        $('.main-story').css('font-family', 'Nunito')
}
$(document).ready(function () {
    $('.modal_opption').click(function () {
        $('.modal-Opption-dialog').css('display', 'flex')
    })
    $('.modal-Opption-dialog').click(function () {
        $('.modal-Opption-dialog').css('display', 'none')
    })
})
$(document).ready(function () {
    var size = 1.5
    var height = 2.4
    $('.toUpFont').click(function () {
        size += 0.5
        height += 0.2
        $('#font-size').attr('placeholder', `${size}rem`)
        $('.main-story').css({
            'font-size': `${size}rem`,
            'line-height': `${height}`
        })
    })
    $('.toDownFont').click(function () {
        size -= 0.5
        height -= 0.2
        $('#font-size').attr('placeholder', `${size}rem`)
        $('.main-story').css({
            'font-size': `${size}rem`,
            'line-height': `${height}`
        })
    })
})