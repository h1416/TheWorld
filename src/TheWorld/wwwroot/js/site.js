/*site.js*/

// self exec. function
(function () {
    var ele = document.getElementById("username");
    ele.innerHTML = "Hieu Vo";

    // change the background color of the form when hover over
    var main = document.getElementById("main");
    main.onmouseenter = function () {
        main.style.background = "#888";
    }

    // restore the background color of the form 
    main.onmouseleave = function () {
        main.style.background = "";
    }
})();
