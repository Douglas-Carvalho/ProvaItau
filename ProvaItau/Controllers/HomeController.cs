using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projeto.Application.Models;
using Projeto.Service.DTO;
using Projeto.Service.Services.Contracts;

namespace Projeto.Controllers
{
	public class HomeController : Controller
	{
		private readonly IServiceChamadoInstalacao _serviceChamadoInstalacao;
        private readonly IServiceCadastroEquipamento _serviceCadastroEquipamento;
        private readonly IServiceMotivoAvariaEquipamento _serviceMotivoAvariaEquipamento;
        private readonly IServiceAtendimentoChamadoInstalacao _serviceAtendimentoChamadoInstalacao;
        private readonly IServiceEquipamentoUtilizadoAtendimentoChamadoInstalacao _serviceEquipamentoUtilizadoAtendimentoChamadoInstalacao;

        public HomeController(IServiceChamadoInstalacao serviceChamadoInstalacao_, 
                              IServiceCadastroEquipamento serviceCadastroEquipamento_,
                              IServiceMotivoAvariaEquipamento serviceMotivoAvariaEquipamento_,
                              IServiceAtendimentoChamadoInstalacao serviceAtendimentoChamadoInstalacao_,
                              IServiceEquipamentoUtilizadoAtendimentoChamadoInstalacao serviceEquipamentoUtilizadoAtendimentoChamadoInstalacao_)
		{
			_serviceChamadoInstalacao = serviceChamadoInstalacao_;
            _serviceCadastroEquipamento = serviceCadastroEquipamento_;
            _serviceMotivoAvariaEquipamento = serviceMotivoAvariaEquipamento_;
            _serviceAtendimentoChamadoInstalacao = serviceAtendimentoChamadoInstalacao_;
            _serviceEquipamentoUtilizadoAtendimentoChamadoInstalacao = serviceEquipamentoUtilizadoAtendimentoChamadoInstalacao_;
        }

		public IActionResult Index()
		{
            var homeViewModel = new HomeViewModel();

            var listaEquipamentos = _serviceCadastroEquipamento.FindAll().Select(x => new SelectListItem
                {
                    Text = x.Nome,
                    Value = x.Id.ToString()
                }
            );

            var listaMotivos = _serviceMotivoAvariaEquipamento.GetMotivos().Select(x => new SelectListItem
            {
                Text = x.MotivoAvaria,
                Value = x.Id.ToString()
            }
            );

            homeViewModel.listaEquipamentos = listaEquipamentos;
            homeViewModel.listaMotivos = listaMotivos;

            return View(homeViewModel);
		}

		[HttpGet]
        public JsonResult ValidaAtendimentoChamado([FromQuery]int numeroChamado)
		{
            var result = _serviceAtendimentoChamadoInstalacao.VerificaAtendimentoChamado(numeroChamado);
			return Json(result);
		}

        [HttpPost]
        public IActionResult RegistraAtendimento([FromBody]ParametroViewModel param)
        {
            var atendimentoId = _serviceAtendimentoChamadoInstalacao.RegistraAtendimentoChamado(param.atendimento);
            param.equipamento.Atendimento.Id = atendimentoId;

            _serviceEquipamentoUtilizadoAtendimentoChamadoInstalacao.RegistraEquipamentoUtilizado(param.equipamento);
            return Json("sucesso");
        }
    }
}
