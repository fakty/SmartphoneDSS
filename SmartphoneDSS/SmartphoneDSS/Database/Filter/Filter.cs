using SmartphoneDSS.Database.Models;
using SmartphoneDSS.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SmartphoneDSS.Database.Filter
{
    abstract class Filter<T1, T2> where T1 : Formula
    {
        public List<T2> FilterByFormulas(List<List<T1>> formulas, float price)
        {
            List<T2> filtered = new List<T2>();

            foreach (List<T1> setElement in formulas)
            {
                List<T2> filteredPart = FilterByFormulasSetElement(setElement, price);
                filtered.AddRange(filteredPart);
                filtered = filtered.Distinct().ToList();
            }

            if (filtered.Count == 0)
            {
                throw new EmptyListException("Brak urządzeń dla podanych formuł!");
            }

            return filtered;
        }

        internal abstract List<T2> FilterByFormulasSetElement(List<T1> setElement, float price);
    }
}
