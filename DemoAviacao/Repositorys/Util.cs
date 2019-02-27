using DemoAviacao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoAviacao.Repositorys
{
    public class Util
    {
        public static Repository<RotaModel> RotaRep = new Repository<RotaModel>();
        public static Repository<IdadeModel> IdadeRep = new Repository<IdadeModel>();
        public static Repository<DataSaidaModel> DataSaidaRep = new Repository<DataSaidaModel>();
        public static Repository<VoosModel> VooRep = new Repository<VoosModel>();
    }
}