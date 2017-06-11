using SmartphoneDSS.Database.Models;
using System.Collections.Generic;
using SmartphoneDSS.Database;
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
            //TO DO missing correct parameter type!!!
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
                                            //TO DO check Fu in this line
                                            // Fu = 1
                                            var result = new List<OutputFormula>(8);
                                            for (var j = 11; j < FormBase.GetFormulas().Count; j++)
                                            {
                                                result.Add((OutputFormula)FormBase.GetFormulas()[j]);
                                            }
                                            if (!ContainsSameItems(S, result))
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
                NextIteration(FormBase.GetFormulas());
            }
            
            return S;
        }

        //Metoda liczaca rozwiazania dla zadanego faktu wyjsciowego.
        //Zwraca liste znalezionych faktow wejsciowych (fakt = lista formul).
        public List<List<InputFormula>> CalculateInputFormulas(List<OutputFormula> factY)
        {
            //TO DO missing correct parameter type!!!
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
                                            //TO DO check Fy in this line
                                            // Fy = 1
                                            var result1 = new List<InputFormula>(11);
                                            for (var j = 0; j < 11; j++)
                                            {
                                                result1.Add((InputFormula)FormBase.GetFormulas()[j]);
                                            }
                                            if (!ContainsSameItems(S1, result1))
                                            {
                                                S1.Add(result1);
                                            }

                                            // Fy = 0
                                            var result2 = new List<InputFormula>(11);
                                            for (var j = 0; j < 11; j++)
                                            {
                                                result2.Add((InputFormula)FormBase.GetFormulas()[j]);
                                            }
                                            if (!ContainsSameItems(S2, result2))
                                            {
                                                S2.Add(result2);
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

            if (S1.Count > 0 && S2.Count > 0)
            {
                foreach (var list in S2)
                {
                    S1.Remove(list);
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

        private bool ContainsSameItems(List<List<OutputFormula>> list, List<OutputFormula> b)
        {
            if (list.Count == 0) return false;
            foreach (var a in list)
            {
                if (a.Except(b).Any()) return false;
            }
            return true;
        }

        private bool ContainsSameItems(List<List<InputFormula>> list, List<InputFormula> b)
        {
            if (list.Count == 0) return false;
            foreach (var a in list)
            {
                if (a.Except(b).Any()) return false;
            }
            return true;
        }
    }
}
