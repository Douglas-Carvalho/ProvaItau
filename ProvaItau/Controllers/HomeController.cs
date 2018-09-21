using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projeto.Application.Models;
using Projeto.Service.Services.Contracts;

namespace Projeto.Controllers
{
	public class HomeController : Controller
	{
		private readonly IServiceChamadoInstalacao _serviceChamadoInstalacao;
        private readonly IServiceCadastroEquipamento _serviceCadastroEquipamento;
        private readonly IServiceMotivoAvariaEquipamento _serviceMotivoAvariaEquipamento;

        public HomeController(IServiceChamadoInstalacao serviceChamadoInstalacao_, 
                              IServiceCadastroEquipamento serviceCadastroEquipamento_,
                              IServiceMotivoAvariaEquipamento serviceMotivoAvariaEquipamento_)
		{
			_serviceChamadoInstalacao = serviceChamadoInstalacao_;
            _serviceCadastroEquipamento = serviceCadastroEquipamento_;
            _serviceMotivoAvariaEquipamento = serviceMotivoAvariaEquipamento_;
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

            var listaMotivos = _serviceMotivoAvariaEquipamento.FindAll().Select(x => new SelectListItem
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
        public JsonResult GetChamado([FromQuery]int number)
		{
            var returnDTO = _serviceChamadoInstalacao.FindByNumber(number);
			return Json(returnDTO);
		}
	}
}
