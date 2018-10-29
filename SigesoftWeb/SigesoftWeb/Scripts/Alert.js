(function () {

    $.notificacion = function (opciones) {
        opciones = $.extend({
            title: "Advertencia",
            icono: "",
            contenido: "Contenido para agregar",
            btnAceptar: "",
            btnCancelar: "",
            btnOk: "OK",
            mostrarBtnAceptarAndCancelar: "",
            mostrarBtnOk: "no",
            mostrarIcono: "",
            classTitleAndButtons: "dangerTitleAndButtons",
            classMessage: "dangerMessage",
        }, opciones);

        controlBotones();
        var contenido = "";
        contenido = `    <div class="container pluginContenedor w-50">
								<div class="bigBox-Fondo"></div>
								<div class="row justify-content-center bigBox-contenedor `+ opciones.classTitleAndButtons +`" align="center">
									<div class="col-12 m-0 p-0 ">
                                        <div class="row rowTitleAndButton">
											<div class="  col-12 mt-2 mb-2 d-flex align-items-center justify-content-start"><h2 class="tileNotification">` + opciones.title + `</h2>
											</div>
										</div>
										<div class="row rowText `+ opciones.classMessage +`">
											<div class="bigBox-Contenido   pr-0 d-flex justify-content-strat align-items-center flex-wrap col-8">
												<span class="bigBox-Texto m-0 p-0">`+ opciones.contenido + `</span>
											</div>
											<div class="contentIcon col-2 ml-0 p-0 d-flex justify-content-start">
												<i class=" m-0 icon `+ opciones.icono + `"></i>	
											</div>
										</div>
										<div class="row rowTitleAndButton `+ opciones.mostrarBtnAceptarAndCancelar +  ` justify-content-between m-0 p-0">									
                                            <div class=" m-0  p-0 col-auto">
												<button class="pt-0 pb-0 mt-3 btn  bigBox-Cancelar">`+ opciones.btnCancelar + `</button>	
											</div>			
											<div class=" m-0 p-0 col-auto">
												<button class="pt-0 pb-0 mt-3 btn e bigBox-Aceptar">`+ opciones.btnAceptar + `</button>
											</div>	
                                        </div>
                                        <div class="row rowTitleAndButton justify-content-end m-0 p-0">
											<div class="`+ opciones.mostrarBtnOk + ` col-auto m-0 p-0">
												<button class="pt-0 pb-0 mt-3 btn  bigBox-Ok"><i class="icon-ok"></i>`+ opciones.btnOk + `</button>
											</div>							
										</div>
									</div>															
								</div>
							</div>	`
        $("body").append(contenido);
        animar_entrada();
        centrarContenedor();
        controlTeclas();
        controlBotones();
        controlIcono();
        //Funcion de cancelar
        $("body").on("click", ".bigBox-Cancelar", function () {
            animar_salida();
        });
        $("body").on("click", ".bigBox-Ok", function () {
            animar_salida();
        });


        //Controlar los botones
        function controlBotones() {

            if (opciones.mostrarBtnAceptarAndCancelar === "si") {   
                
                opciones.mostrarBtnAceptarAndCancelar = ""

            } else if (opciones.mostrarBtnAceptarAndCancelar === "no") {
                opciones.mostrarBtnAceptarAndCancelar = "d-none"
            }

            if (opciones.mostrarBtnOk === "si") {
                opciones.mostrarBtnOk = ""
            } else if (opciones.mostrarBtnOk === "no") {
                opciones.mostrarBtnOk = "d-none"
            }
        }
        function controlIcono() {
            if (opciones.icono === "") {
                $(".contentIcon").remove();
            }
        }

        //Animar la entrada
        function animar_entrada() {
            var $fondo = $(".bigBox-Fondo");

            var $contenedor = $(".bigBox-contenedor");

            $fondo.show();
            $contenedor.show();

            var tl = new TimelineMax();
            tl.to($fondo, 0.5, { opacity: 0.5 })
                .to($contenedor, 0.5, { opacity: 1 }, "-=0.5")
                .from($contenedor, 0.8, { ease: Bounce.easeOut, y: "-=20" }, "-=0.5");
        }

        function animar_salida() {
            var $fondo = $(".bigBox-Fondo");

            var $contenedor = $(".bigBox-contenedor");
            var tl = new TimelineMax();
            tl.to($fondo, 0.3, { opacity: 0 })
                .to($contenedor, 0.3, { opacity: 0, onComplete: remover_contenedor }, "-=0.5");
        }

        function remover_contenedor() {

            var $fondo = $(".bigBox-Fondo");
            var $contenedor = $(".pluginContenedor");

            $fondo.remove();
            $contenedor.remove();
        }

        function centrarContenedor() {

            $(document).ready(function () {
                $('.bigBox-contenedor').css({
                    position: 'absolute',
                    left: ($(window).width() - $('.bigBox-contenedor').width()) / 2,
                    top: ($(window).height() - $('.bigBox-contenedor').height()) / 4
                });

            });
            $(window).resize(function () {
                $('.bigBox-contenedor').css({
                    position: 'absolute',
                    left: ($(window).width() - $('.bigBox-contenedor').width()) / 2,
                    top: ($(window).height() - $('.bigBox-contenedor').height()) / 4
                });

            });
        }
        function controlTeclas() {
            $(document).keypress(function (e) {
                if (e.keyCode === 13) {
                    $(".bigBox-Aceptar").click();
                }
            });
            $(document).keyup(function (e) {
                if (e.which === 27) {
                    $(".bigBox-Cancelar").click();
                }
            });
            $(document).keypress(function (e) {
                if (e.keyCode === 13) {
                    $(".bigBox-Ok").click();
                }
            });
        }
    };


    $(document).ready(function () {
        $(window).resize();
    });

})();