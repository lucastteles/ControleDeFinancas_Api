using ControleDeFinancas.Application.Dto;
using ControleDeFinancas.Application.Interface;
using ControleDeFinancas.Application.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeFinancas.MVC.Controllers
{
    public class DespesaController : Controller
    {
        private readonly IDespesaApplication _despesaApplication;

        public DespesaController(IDespesaApplication despesaApplication)
        {
            _despesaApplication = despesaApplication;
        }
        // GET: DespesaController
        public async Task<IActionResult> Index(DespesaDto despesa, DateTime data)
        {
            if (data == null )
                return View(new List<ControleDeFinancas.Application.Dto.DespesaDto>());

            ViewData["dataInicial"] = data.ToString("yyyy-MM-dd");
            

            var venda = await _despesaApplication.DespesaPorData(data);

            return View(venda);


            //if (despesa.DepesaId != Guid.Empty)
            //{
            //    var despesaData = await _despesaApplication.DespesaPorData(despesa.Vencimento);

            //    return View(despesaData);
            //}
            //if (data == null)
            //    return View(new DespesaDto());
            //ViewData["data"] = data.ToString("yyyy-MM-dd");

            //return View();
            //////////////

            //var de
            //if (data == null)
            //    return View(new List<Application.Dto.DespesaDto>());

            //ViewData["data"] = data.ToString("yyyy-MM-dd");

            //var despesa = await _despesaApplication.DespesaPorData(data);

            //return View(despesa);
        }

        // GET: DespesaController/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var despesa = await _despesaApplication.ObterDespesaPorId(id);

            return View(despesa);
        }

        // GET: DespesaController/Create
        public async Task<IActionResult> Create()
        {

            return View();
        }

        // POST: DespesaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DespesaViewModel despesaVM)
        {
            await _despesaApplication.AdicionarDespesa(despesaVM);

            return View();
        }

        // GET: DespesaController/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var despesa = await _despesaApplication.ObterDespesaPorId(id);

            return View(despesa);
        }

        // POST: DespesaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DespesaViewModel despesaVM)
        {
            await _despesaApplication.AtualizarDespesa(despesaVM);

            return RedirectToAction(nameof(Index));
        }

        // GET: DespesaController/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var despesa = await _despesaApplication.ObterDespesaPorId(id);

            return View(despesa);
        }

        // POST: DespesaController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _despesaApplication.DeletarDespesa(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
