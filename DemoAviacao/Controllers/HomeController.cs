using DemoAviacao.Models;
using DemoAviacao.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoAviacao.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            
            //RotaModel rotaModel = new RotaModel()
            //{
            //    Destino = "DDK",
            //    Origem = "ODL",
            //    ProbabilidadeComparecer = 90
            //};
            //Util.RotaRep.Add(rotaModel);


            //IdadeModel idadeModel = new IdadeModel()
            //{
            //    Idade=20,
            //    ProbabilidadeComparecer = 90
            //};
            //Util.IdadeRep .Add(idadeModel);


            //DataSaidaModel dataSaidaModel = new DataSaidaModel()
            //{
            //    DataSaida= DateTime.Now,
            //    ProbabilidadeComparecer = 90
            //};
            //Util.DataSaidaRep.Add(dataSaidaModel);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}