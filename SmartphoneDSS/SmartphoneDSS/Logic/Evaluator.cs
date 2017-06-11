using SmartphoneDSS.Database.Models;
using System.Collections.Generic;

namespace SmartphoneDSS.Logic
{
    class Evaluator
    {
        private KnowledgeBase FormBase;
        public Evaluator(KnowledgeBase formBase)
        {
            FormBase = formBase;
        }

        public List<List<OutputFormula>> CalculateOutputFormulas(InputFormula inFormula)
        {
            List<List<OutputFormula>> S;
            //TO DO create iterational version of it
            FormBase.GetFormulas()[0].Value = true;


            //TO DO returning calculated output formulas
            return null;
        }

        public List<List<InputFormula>> CalculateInputFormulas(OutputFormula outFormula)
        {
            List<List<InputFormula>> S1;
            List<List<InputFormula>> S2;
            //TO DO returning calculated input formulas
            return null;
        }
    }
}
