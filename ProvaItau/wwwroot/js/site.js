class Site {
    constructor() {

        this._inputChamado = $("#inputChamado");
        this._selectModelo = $("#selectModelo");
        this._inputRadio = $(".radio");
        this._selectMotivo = $("#selectMotivo");
        this._buttonReportar = $("#buttonReportar");

    }
    
    _init() {
    }

    async pesquisaChamado() {

        var self = this;
    
        await $.ajax({
          url: 'http://localhost:5000/Home/GetChamado',
          type: 'GET',
          data: {number: self._inputChamado.val()}
        }).then(
            function fulfillHandler(data) {

                if (data == null) {
               
                    alert("Este chamado não está aberto!");

                    self._selectModelo.addClass("disabled");
                    self._selectModelo.prop("disabled", true);

                    self._inputRadio.addClass("disabled");
                    self._inputRadio.prop("disabled", true);

                    self._selectMotivo.addClass("disabled");
                    self._selectMotivo.prop("disabled", true);

                    self._buttonReportar.addClass("disabled");
                    self._buttonReportar.prop("disabled", true);
                   
                } else {

                    self._selectModelo.removeClass("disabled");
                    self._selectModelo.prop("disabled", false);

                    self._inputRadio.removeClass("disabled");
                    self._inputRadio.prop("disabled", false);

                    self._buttonReportar.removeClass("disabled");
                    self._buttonReportar.prop("disabled", false);
                }
            },  
            function rejectHandler(jqXHR, textStatus, errorThrown) {

            }
        ).catch(function errorHandler(error) {

        });
    }

    validaInstalacaoStatus(elm) {

        debugger;
    
        if($(elm).val() == 1) {
            this._selectMotivo.removeClass("disabled");
            this._selectMotivo.prop("disabled", false);

            return;
        } 

            this._selectMotivo.addClass("disabled");
            this._selectMotivo.prop("disabled", true);
    }   
    
}

let site = new Site();