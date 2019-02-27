using DemoAviacao.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoAviacao.Controllers
{
    public class ParametrosController : Controller
    {
        // GET: Parametros
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult _PartialRotas()
        {
            return PartialView(Util.RotaRep.ToList());
        }

        [HttpPost]
        public ActionResult _PartialRotas(FormCollection formCollection, string action)
        {
            if (action.Equals("add"))
            {
                string[] strOrigem = formCollection["origem"].Split(new char[] { ',' });
                string[] strDestino = formCollection["destino"].Split(new char[] { ',' });
                string[] strProbrabilidade = formCollection["probabilidade"].Split(new char[] { ',' });

                Models.RotaModel item = new Models.RotaModel()
                {
                    Origem = strOrigem[0],
                    Destino = strDestino[0],
                    ProbabilidadeComparecer = Convert.ToInt32(strProbrabilidade[0])
                };

                Util.RotaRep.Add(item);
            }
            else if (action.Equals("excluir"))
            {
                string[] strItemID = formCollection["itemid"].Split(new char[] { ',' });
                var item = Util.RotaRep.Where(a => a.ID == Convert.ToInt32(strItemID[0]));
                if (item != null && item.Count() > 0)
                    Util.RotaRep.Remove(item.First());

            }
            return RedirectToAction("", "Parametros");
        }

        [ChildActionOnly]
        public ActionResult _PartialDataSaida()
        {
            return PartialView(Util.DataSaidaRep.ToList());
        }

        [HttpPost]
        public ActionResult _PartialDataSaida(FormCollection formCollection, string action)
        {
            if (action.Equals("add"))
            {
                string[] strData = formCollection["datasaida"].Split(new char[] { ',' });
                string[] strProbrabilidade = formCollection["probabilidade"].Split(new char[] { ',' });
                string[] strTime = formCollection["time"].Split(new char[] { ',' });

                Models.DataSaidaModel item = new Models.DataSaidaModel()
                {
                    DataSaida= DateTime.Parse(strData[0] + " " + strTime[0]),
                    ProbabilidadeComparecer = Convert.ToInt32(strProbrabilidade[0])
                };

                Util.DataSaidaRep.Add(item);
            }
            else if (action.Equals("excluir"))
            {
                string[] strItemID = formCollection["itemid"].Split(new char[] { ',' });
                var item = Util.DataSaidaRep.Where(a => a.ID == Convert.ToInt32(strItemID[0]));
                if (item != null && item.Count() > 0)
                    Util.DataSaidaRep.Remove(item.First());
            }
            return RedirectToAction("", "Parametros");
        }

        [ChildActionOnly]
        public ActionResult _PartialIdade()
        {
            return PartialView(Util.IdadeRep.ToList());
        }

        [HttpPost]
        public ActionResult _PartialIdade(FormCollection formCollection, string action)
        {
            if (action.Equals("add"))
            {
                string[] strIdade = formCollection["idade"].Split(new char[] { ',' });
                string[] strProbabilidade = formCollection["probabilidade"].Split(new char[] { ',' });

                Models.IdadeModel item = new Models.IdadeModel()
                {
                    Idade = Convert.ToInt32(strIdade[0]),
                    ProbabilidadeComparecer = Convert.ToInt32(strProbabilidade[0])
                };

                Util.IdadeRep.Add(item);
            }
            else if (action.Equals("excluir"))
            {
                string[] strItemID = formCollection["itemid"].Split(new char[] { ',' });
                var item = Util.IdadeRep.Where(a => a.ID == Convert.ToInt32(strItemID[0]));
                if (item != null && item.Count() > 0)
                    Util.IdadeRep.Remove(item.First());
            }
            return RedirectToAction("","Parametros");
        }

        
    }
}