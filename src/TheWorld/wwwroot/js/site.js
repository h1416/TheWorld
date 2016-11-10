/*site.js*/

// self exec. function
(function () {

    //var $ele = $("#username");
    //$ele.text("Hieu Vo");

    ////// change the background color of the form when hover over
    //var $main = $("#main");
    //$main.on("mouseenter",  function () {
    //    $main.style.background = "#888";
    //});

    //// restore the background color of the form 
    //$main.on("mouseleave", function () {
    //    $main.style.background = "";
    //})

    //var $menuItems = $("ul.menu li a");
    //menuItems.on("click", function () {
    //    var me = $(this);
    //    alert(me.text());
    //});

    // Assign my name next to the image
    var $myName = $("#username");
    $myName.text("Hieu Vo");


    $sidebarAndWrapper = $("#sidebar, #wrapper");
    var $icon = $("#sidebarToggle i.fa");

    $("#sidebarToggle").on("click", function () {
        // toggleClass is adding the class if it doesn't exist and remove the class if it exists
        $sidebarAndWrapper.toggleClass("hide-sidebar");

        if ($sidebarAndWrapper.hasClass("hide-sidebar")) {
            $icon.removeClass("fa-angle-left");
            $icon.addClass("fa-angle-right")
        } else {
            $icon.removeClass("fa-angle-right");
            $icon.addClass("fa-angle-left")
        }
    })

})();
