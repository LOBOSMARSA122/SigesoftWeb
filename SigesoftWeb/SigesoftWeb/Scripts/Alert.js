(function () {

    $.notificacion = function (opciones) {
        opciones = $.extend({

            icono: "icon-help",
            contenido: "Contenido para agregar",
            btnAceptar: "",
            btnCancelar: "",
            btnOk: "OK",
            mostrarBtnAceptar: "",
            mostrarBtnCancelar: "",
            mostrarBtnOk: "",
        }, opciones);

        controlBotones();
        var contenido = "";
        contenido = `    <div class="container pluginContenedor">
								<div class="bigBox-Fondo"></div>
								<div class="row justify-content-center bigBox-contenedor" align="center">
									<div class="col-12">
										<div class="row">
											<div class="bigBox-Contenido   pr-0 d-flex justify-content-end align-items-center flex-wrap col-8">
												<span class="bigBox-Texto m-0 p-0">`+ opciones.contenido + `</span>
											</div>
											<div class="col-2 ml-0 pl-0 d-flex justify-content-start">
												<i class=" m-0 icon `+ opciones.icono + `"></i>	
											</div>
										</div>
										<div class="row justify-content-center m-0 p-0">
											<div class="`+ opciones.mostrarBtnOk + ` col-6">
												<button class="btn  btn-success bigBox-Ok"><i class="icon-ok"></i>`+ opciones.btnOk + `</button>
											</div>
											<div class="`+ opciones.mostrarBtnAceptar + ` col-6">
												<button class="btn  btn-primary bigBox-Aceptar"><i class=" m-0 p-0 icon-pencil"></i>`+ opciones.btnAceptar + `</button>
											</div>	
											<div class="`+ opciones.mostrarBtnCancelar + ` col-6">
												<button class="btn btn-danger bigBox-Cancelar"><i class="fa fa-times"></i>`+ opciones.btnCancelar + `</button>	
											</div>										
										</div>
									</div>															
								</div>
							</div>	`
        $("body").append(contenido);
        animar_entrada();
        centrarContenedor();

        //Funcion de cancelar
        $("body").on("click", ".bigBox-Cancelar", function () {
            animar_salida();
        });
        $("body").on("click", ".bigBox-Ok", function () {
            animar_salida();
        });


        //Controlar los botones
        function controlBotones() {

            if (opciones.mostrarBtnAceptar === "si") {
                opciones.mostrarBtnAceptar = ""
            } else if (opciones.mostrarBtnAceptar === "no") {
                opciones.mostrarBtnAceptar = "d-none"
            }

            if (opciones.mostrarBtnCancelar === "si") {
                opciones.mostrarBtnCancelar = ""
            } else if (opciones.mostrarBtnCancelar === "no") {
                opciones.mostrarBtnCancelar = "d-none"
            }

            if (opciones.mostrarBtnOk === "si") {
                opciones.mostrarBtnOk = ""
            } else if (opciones.mostrarBtnOk === "no") {
                opciones.mostrarBtnOk = "d-none"
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
            //$(document).ready(function () {
            //    $('.pluginContenedor').css({
            //        'left': ($(window).width() / 2) - ($('.pluginContenedor').width() / 2),
            //        'top': ($(window).width() / 2) - ($('.pluginContenedor').height() / 2)
            //    });
            //});
            $(document).ready(function () {
                 //aquí le pasamos la clase o id de nuestro div a centrar (en este caso "bigBox-contenedor")
                $('.bigBox-contenedor').css({
                    position: 'absolute',
                    left: ($(window).width() - $('.bigBox-contenedor').width()) / 2,
                    top: ($(window).height() - $('.bigBox-contenedor').height()) / 2
                });

            });
            $(window).resize(function () {
                //aquí le pasamos la clase o id de nuestro div a centrar (en este caso "bigBox-contenedor")
                $('.bigBox-contenedor').css({
                    position: 'absolute',
                    left: ($(window).width() - $('.bigBox-contenedor').width()) / 2,
                    top: ($(window).height() - $('.bigBox-contenedor').height()) / 2
                });

            });
        }
    };


    $(document).ready(function () {
        $(window).resize();
    });

})();