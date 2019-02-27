using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoAviacao.Models
{
    public class VoosModel
    {
        private const Int32 _Capacidade = 200;
        [KeyAttribute]
        public Int32 ID { get; private set; }
        public DataSaidaModel DataSaidaVoo { get; set; }
        public RotaModel RotaVoo { get; set; }
        public List<PassageiroModel> Passageiros { get; private set; }
        public Int32 CapacidadeNormal { get { return _Capacidade; } }
        public Int32 CapacidadeOver
        {
            get
            {
                Decimal pRiscoOver = RiscoOver / (Decimal)100;
                return _Capacidade + (Int32)(_Capacidade * pRiscoOver);
            }
        }

        public Decimal RiscoOver
        {
            get
            {
                Decimal saidaP = DataSaidaVoo.ProbabilidadeComparecer / (Decimal)100;
                Decimal rotaP = RotaVoo.ProbabilidadeComparecer / (Decimal)100;
                Decimal iRet = 1;


                if (Passageiros != null && Passageiros.Count() > 0)
                {
                    //Caso tenha algum passageiro incluido no voo calcula a probabilidade de comparecimento para cada um
                    var query = (from T in Passageiros
                                 select new
                                 {
                                     p = (T.ProbabilidadeComparecer * saidaP * rotaP)
                                 });
                    //Faz a média das probabilidades de comparecimento dos usuários
                    iRet = query.Average(a => a.p);
                }
                else
                {
                    //Caso não tenha passageiros incluidos calcula a probabilidade somente levando em considerção a rota e data saida
                    iRet = saidaP * rotaP;
                }

                //Subtrai 1 do probabilidade de comparecimento para encontrar a probabilidade de desistencia
                return (1-iRet) * 100;
            }
        }

        public bool Lotado
        {
            get { return Passageiros.Count() >= CapacidadeOver; }
        }

        public bool AddPassageiro(PassageiroModel item)
        {
            if (Lotado)
                return false;
            else
            {
                Passageiros.Add(item);
                return true;
            }
        }

        public VoosModel()
        {
            Passageiros = new List<PassageiroModel>();
        }
    }
}