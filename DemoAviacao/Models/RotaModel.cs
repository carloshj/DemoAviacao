using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoAviacao.Models
{
    public class RotaModel
    {
        [KeyAttribute]
        public Int32 ID { get; private set; }
        public String Origem { get; set; }
        public String Destino { get; set; }
        public Int32 ProbabilidadeComparecer { get; set; }
    }
}