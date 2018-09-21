using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Projeto.Application.Models
{
    public class HomeViewModel
    {
        public IEnumerable<SelectListItem> listaEquipamentos;
        public IEnumerable<SelectListItem> listaMotivos;
    }
}
