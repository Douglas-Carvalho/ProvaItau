class Chamado {
    constructor(numero) {
        this.Numero = numero;
    }

    
}

var chamado = new Chamado(1);



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

    async registraAtendimento(event) {

     event.preventDefault();

     var start = new Date();
     var motivoId;
    
        debugger;
        
     var atendimento = {
        Data: start.toUTCString(),
        Chamado: {Numero: this._inputChamado.val()}
     }

     if($(".radio:checked").val() == "2") {
         motivoId = parseInt(this._selectMotivo.val());
     } else {
         motivoId = 0;
     }

     var equipamento = {
        equipamento: {Id: parseInt(this._selectModelo.val())},
        atendimento: atendimento,
        motivo: {Id: motivoId}
     } 

     var param = {
        atendimento: atendimento,
        equipamento: equipamento
     }


     $.ajax({
        type: 'POST',
        url: 'http://localhost:5000/Home/RegistraAtendimento',
        dataType: 'json',
        contentType: 'application/json',
        data: JSON.stringify(param),
        success: function(result) {

            alert("Atendimento reportado com sucesso");
            
            if(motivoId == 1) {
                self._selectModelo.addClass("disabled");
                self._selectModelo.prop("disabled", true);

                self._inputRadio.addClass("disabled");
                self._inputRadio.prop("disabled", true);

                self._selectMotivo.addClass("disabled");
                self._selectMotivo.prop("disabled", true);

                self._buttonReportar.addClass("disabled");
                self._buttonReportar.prop("disabled", true);
            }
        }
     });
 
 }

    async pesquisaChamado() {

        var self = this;
    
        await $.ajax({
          url: 'http://localhost:5000/Home/ValidaAtendimentoChamado',
          type: 'GET',
          data: {numeroChamado: self._inputChamado.val()}
        }).then(
            function fulfillHandler(data) {

                if (data == 0) {
               
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

        if($(elm).val() == 2) {
            this._selectMotivo.removeClass("disabled");
            this._selectMotivo.prop("disabled", false);

            return;
        } 

            this._selectMotivo.addClass("disabled");
            this._selectMotivo.prop("disabled", true);
    }   
    
}

let site = new Site();