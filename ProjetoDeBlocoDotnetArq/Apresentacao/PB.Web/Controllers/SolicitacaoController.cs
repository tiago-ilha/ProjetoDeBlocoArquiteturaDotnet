using PB.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PB.Web.Controllers
{
	public class SolicitacaoController : Controller
	{
		// GET: Solicitacao
		public ActionResult Index()
		{
			return View();
		}

		//[HttpGet]
		//public ActionResult ListarSolicitacoes()
		//{
		//	var client = new HttpClient();

		//	client.BaseAddress = new Uri("http://localhost:64189/api/");
		//	//HTTP GET
		//	var responseTask = client.GetAsync("solicitacao/listar");
		//	//responseTask.Wait();

		//	var result = responseTask.Result;
		//	if (result.IsSuccessStatusCode)
		//	{
		//		return Json(new{});
		//	}
		//	else
		//	{
		//		return Json(new { });
		//	}
		//}

		// GET: Solicitacao/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: Solicitacao/Create
		public ActionResult Cadastrar()
		{
			return PartialView("CadastrarSolicitacao");
		}

		// POST: Solicitacao/Create
		[HttpPost]
		public async Task<ActionResult> Cadastrar(SolicitacaoDeClientePessoaFisicaViewModel modelo)
		{
			var client = new HttpClient();
			HttpResponseMessage resposta = await client.PostAsJsonAsync("http://localhost:53708/api/solicitacao/pessoa-fisica", modelo);

			return Json(new{resultadoDaOperacao = resposta});

			//var client = new HttpClient();
			//client.BaseAddress = new Uri("http://localhost:64189/api/");
			//client.DefaultRequestHeaders.Accept.Clear();
			//client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			//var resposta = client.PostAsJsonAsync("solicitacao/pessoa-fisica", modelo).Result;

			//if (resposta.IsSuccessStatusCode)
			//{
			//	string responseString = resposta.Content.ReadAsStringAsync().Result;
			//	return Json(new{resultadoDaOperacao = rep})
			//	//return await Json(new { resultadoDaOperacao = resultado });
			//}
			//else
			//{
			//	return await Json(new { resultadoDaOperacao = resultado });
			//}
		}

		// GET: Solicitacao/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: Solicitacao/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, FormCollection collection)
		{
			try
			{
				// TODO: Add update logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: Solicitacao/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: Solicitacao/Delete/5
		[HttpPost]
		public ActionResult Delete(int id, FormCollection collection)
		{
			try
			{
				// TODO: Add delete logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}
	}
}
