using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoAviacao.Models
{
    public class DataSaidaModel
    {
        [KeyAttribute]
        public Int32 ID { get; private set; }
        public DateTime DataSaida { get; set; }
        public Int32 ProbabilidadeComparecer { get; set; }
    }
}