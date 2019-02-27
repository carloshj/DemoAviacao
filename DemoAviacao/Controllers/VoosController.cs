using DemoAviacao.Models;
using DemoAviacao.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoAviacao.Controllers
{
    public class VoosController : Controller
    {
        // GET: Voos
        public ActionResult Index()
        {
            ViewBag.DataSaidaList = Util.DataSaidaRep.ToList();
            ViewBag.RotaList = Util.RotaRep.ToList();
            return View(Util.VooRep.ToList());
        }

        public ActionResult RiscoOverbooking()
        {
            return View(Util.VooRep.ToList());
        }

        [HttpPost]
        public ActionResult Index(FormCollection formCollection, string action)
        {
            if (action.Equals("add"))
            {
                string[] strIdData = formCollection["datasaida"].Split(new char[] { ',' });
                string[] strIdRota = formCollection["rota"].Split(new char[] { ',' });

                VoosModel item = new VoosModel()
                {
                    RotaVoo = Util.RotaRep.Where(a => a.ID == Convert.ToInt32(strIdData[0])).First(),
                    DataSaidaVoo = Util.DataSaidaRep.Where(a => a.ID == Convert.ToInt32(strIdData[0])).First()
                };

                Util.VooRep.Add(item);
            }
            return RedirectToAction("", "Voos");
        }


        public ActionResult AddPassageiro(Int32 vooID)
        {
            ViewBag.Msg = null;
            ViewBag.MsgSuccess = null;
            ViewBag.VooID = vooID;
            return View(Util.VooRep.Where(a=> a.ID==vooID).First());
        }


        [HttpPost]
        public ActionResult AddPassageiro(FormCollection formCollection, string action)
        {
            ViewBag.Msg = null;
            ViewBag.MsgSuccess = null;
            Int32 ivooID = 0;
            if (action.Equals("add"))
            {
                
                string[] strNome = formCollection["nomepassageiro"].Split(new char[] { ',' });
                string[] strIdade = formCollection["idadepassageiro"].Split(new char[] { ',' });
                string[] strVooID = formCollection["vooid"].Split(new char[] { ',' });
                ivooID=Int32.Parse(strVooID[0]);

                Models.PassageiroModel item = new Models.PassageiroModel()
                {
                    Nome = strNome[0],
                    Idade = Convert.ToInt32(strIdade[0])
                };

                VoosModel voo = Util.VooRep.Where(a => a.ID == ivooID).First();

                if (!voo.AddPassageiro(item))
                    ViewBag.Msg = "Voo lotado";
                else
                    ViewBag.MsgSuccess = "Passageiro incluido com sucesso";
            }
            return View(Util.VooRep.Where(a => a.ID == ivooID).First());
        }

        

        
    }
}