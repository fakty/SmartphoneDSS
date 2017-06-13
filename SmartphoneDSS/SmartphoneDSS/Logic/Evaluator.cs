using SmartphoneDSS.Database.Models;
using System.Collections.Generic;
using System.Linq;

namespace SmartphoneDSS.Logic
{
    class Evaluator
    {
        private KnowledgeBase FormBase;
        public Evaluator(KnowledgeBase formBase)
        {
            FormBase = formBase;
        }

        //Metoda liczaca rozwiazania dla zadanego faktu wejsciowego.
        //Zwraca liste znalezionych faktow wyjsciowych (fakt = lista formul).
        public List<List<OutputFormula>> CalculateOutputFormulas(List<InputFormula> factU)
        {
            var S = new List<List<OutputFormula>>();
            
            while (HasNextIteration(FormBase.GetFormulas()))
            {
                if (FormBase.Fact1(FormBase.GetFormulas()))
                {
                    if (FormBase.Fact2(FormBase.GetFormulas()))
                    {
                        if (FormBase.Fact3(FormBase.GetFormulas()))
                        {
                            if (FormBase.Fact4(FormBase.GetFormulas()))
                            {
                                if (FormBase.Fact5(FormBase.GetFormulas()))
                                {
                                    if (FormBase.Fact6(FormBase.GetFormulas()))
                                    {
                                        if (FormBase.Fact7(FormBase.GetFormulas()))
                                        {
                                            //checking Fu = 1
                                            if (CheckFactU(FormBase.GetFormulas(), factU))
                                            {
                                                var result = new List<OutputFormula>(8);
                                                for (var j = 11; j < FormBase.GetFormulas().Count; j++)
                                                {
                                                    result.Add(new OutputFormula((OutputFormula)FormBase.GetFormulas()[j]));
                                                }
                                                if (!ContainsSameItem(S, result))
                                                {
                                                    S.Add(result);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                NextIteration(FormBase.GetFormulas());
            }
            
            return S;
        }

        //Metoda liczaca rozwiazania dla zadanego faktu wyjsciowego.
        //Zwraca liste znalezionych faktow wejsciowych (fakt = lista formul).
        public List<List<InputFormula>> CalculateInputFormulas(List<OutputFormula> factY)
        {
            var S1 = new List<List<InputFormula>>();
            var S2 = new List<List<InputFormula>>();

            while (HasNextIteration(FormBase.GetFormulas()))
            {
                if (FormBase.Fact1(FormBase.GetFormulas()))
                {
                    if (FormBase.Fact2(FormBase.GetFormulas()))
                    {
                        if (FormBase.Fact3(FormBase.GetFormulas()))
                        {
                            if (FormBase.Fact4(FormBase.GetFormulas()))
                            {
                                if (FormBase.Fact5(FormBase.GetFormulas()))
                                {
                                    if (FormBase.Fact6(FormBase.GetFormulas()))
                                    {
                                        if (FormBase.Fact7(FormBase.GetFormulas()))
                                        {
                                            //checking Fy = 1
                                            if (CheckFactY(FormBase.GetFormulas(), factY))
                                            {
                                                var result1 = new List<InputFormula>(11);
                                                for (var j = 0; j < 11; j++)
                                                {
                                                    result1.Add(new InputFormula((InputFormula)FormBase.GetFormulas()[j]));
                                                }
                                                if (!ContainsSameItem(S1, result1))
                                                {
                                                    S1.Add(result1);
                                                }
                                            }
                                            /*else // Fy = 0 - pozniej wytlumacze czemu w komentarzu
                                            {
                                                var result2 = new List<InputFormula>(11);
                                                for (var j = 0; j < 11; j++)
                                                {
                                                    result2.Add(new InputFormula((InputFormula)FormBase.GetFormulas()[j]));
                                                }
                                                if (!ContainsSameItem(S2, result2))
                                                {
                                                    S2.Add(result2);
                                                }
                                            }*/
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                NextIteration(FormBase.GetFormulas());
            }

            if (S1.Count > 0 && S2.Count > 0)
            {
                List<InputFormula> factS1;
                for(var id = S1.Count - 1; id >= 0; id--)
                {
                    factS1 = S1[id];
                    var isSame = true;
                    foreach (var factS2 in S2)
                    {
                        isSame = true;
                        for (var i = 0; i < factS1.Count; i++)
                        {
                            if (!factS1[i].Name.Equals(factS2[i].Name) || factS1[i].Value != factS2[i].Value) isSame = false;
                        }
                        if (isSame)
                        {
                            S1.Remove(factS1);
                            break;
                        }
                    }
                }
            }
            return S1;
        }

        private bool HasNextIteration(List<Formula> list)
        {
            foreach (var l in list)
            {
                if (!l.Value) return true;
            }
            return false;
        }

        private void NextIteration(List<Formula> list)
        {
            var isForward = true;
            var i = list.Count - 1;

            while(i >= 0 && isForward)
            {
                list[i].Value = !list[i].Value;
                if (list[i].Value) isForward = false;
                i--;
            }
        }

        private bool ContainsSameItem(List<List<OutputFormula>> listOfFacts, List<OutputFormula> newFact)
        {
            if (listOfFacts.Count == 0) return false;
            var isSame = true;
            foreach (var fact in listOfFacts)
            {
                isSame = true;
                for(var i = 0; i < fact.Count; i++)
                {
                    if (!fact[i].Name.Equals(newFact[i].Name) || fact[i].Value != newFact[i].Value) isSame = false;
                }
                if (isSame) return true;
            }
            return false;
        }

        private bool ContainsSameItem(List<List<InputFormula>> listOfFacts, List<InputFormula> newFact)
        {
            if (listOfFacts.Count == 0) return false;
            var isSame = true;
            foreach (var fact in listOfFacts)
            {
                isSame = true;
                for (var i = 0; i < fact.Count; i++)
                {
                    if (!fact[i].Name.Equals(newFact[i].Name) || fact[i].Value != newFact[i].Value) isSame = false;
                }
                if (isSame) return true;
            }
            return false;
        }

        private bool CheckFactU(List<Formula> list, List<InputFormula> factU)
        {
            for(var i = 0; i < factU.Count; i++)
            {
                if (factU[i].Value != list[i].Value) return false;
            }
            return true;
        }

        private bool CheckFactY(List<Formula> list, List<OutputFormula> factY)
        {
            for (var i = 0; i < factY.Count; i++)
            {
                if (factY[i].Value && !list[11 + i].Value) return false;
            }
            return true;
        }
    }
}
