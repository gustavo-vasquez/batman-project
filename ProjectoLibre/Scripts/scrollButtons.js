$(document).ready(function () {
    if ($(document).height() > $(window).height()) {
        $('#scrollButtonDown').removeAttr("display");
    }
    else {
        $('#scrollButtonDown').css("display", "none");
    }
});

$(window).scroll(function () {   
    if ($(this).scrollTop()) { // 300px from top
        $('#scrollButtonUp').slideDown();
    } else {
        $('#scrollButtonUp').slideUp();        
    }

    if ($(window).scrollTop() + $(window).height() == $(document).height()) {
        $('#scrollButtonDown').slideUp();
    }
    else {
        $('#scrollButtonDown').css("display", "block");
    }
});

function scrollToTop() {
    $("html, body").animate({ scrollTop: 0 }, "slow");
    return false;
};

function scrollToDown() {
    $("html, body").animate({ scrollTop: $(document).height() }, "slow");
    return false;
};