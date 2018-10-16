$(document).ready(function () {
    var $iconPin = $(".iconoPin");
    var icon = `<i class="fa-thumb-tack"></i>`;
  
    $iconPin.on("click", function () {
        $iconPin.addClass("iconPinRotate")
        if ($iconPin.val() == "onPin") {
            LoadTopDiagnostic();
            MonthlyControls();
        $(".colAside").removeClass("col-md-4");
        $(".colMain").removeClass("col-md-8");
        $(".colAside").prependTo(".contenedor-main");
        $(this).val("offPin");
        } else if ($iconPin.val() == "offPin") {
            $iconPin.removeClass("iconPinRotate")
            LoadTopDiagnostic();
            MonthlyControls();
            $(".colAside").addClass("col-md-4");
            $(".colMain").addClass("col-md-8");
            $(".colAside").appendTo(".contenedor-main");
            $(this).val("onPin");
        }
    });

    
})