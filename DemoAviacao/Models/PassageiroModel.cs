using DemoAviacao.Repositorys;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoAviacao.Models
{
    public class PassageiroModel
    {
        [KeyAttribute]
        public Int32 ID { get; private set; }
        public String Nome { get; set;}    
        public Int32 Idade { get; set; }
        public Decimal ProbabilidadeComparecer
        {
            get
            {
                var result = Util.IdadeRep.Where(a => a.Idade == this.Idade);
                if (result == null || result.Count()==0)
                    return 1;
                else
                    return result.First().ProbabilidadeComparecer/(Decimal)100;
            }
        }
    }
}