using SmartphoneDSS.Database.Filter;
using SmartphoneDSS.Database.Models;
using SmartphoneDSS.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartphoneDSS.Database
{
    class SmartphoneFilter : Filter<InputFormula, Smartphone>
    {
        internal override List<Smartphone> filterByFormulasSetElement(List<InputFormula> setElement)
        {
            List<Smartphone> allPhones = SmartphoneReader.getSmartphones();
            List<Smartphone> filtered = new List<Smartphone>();
            Smartphone treshold = new Smartphone();
            foreach (InputFormula formula in setElement)
            {
                if (formula.Value == true)
                {
                    if (formula.Name == KnowledgeBase.alfa0)
                        treshold.RAM = 2;
                    else if (formula.Name == KnowledgeBase.alfa1)
                        treshold.BatteryCapacity = 3300;
                    else if (formula.Name == KnowledgeBase.alfa2)
                        treshold.ScreenSize = 5.5f;
                    else if (formula.Name == KnowledgeBase.alfa3)
                        treshold.IsFullHD = true;
                    else if (formula.Name == KnowledgeBase.alfa4)
                        treshold.HasToughenedGlass = true;
                    else if (formula.Name == KnowledgeBase.alfa5)
                        treshold.Camera = 13;
                    else if (formula.Name == KnowledgeBase.alfa6)
                        treshold.HasLTE = true;
                    else if (formula.Name == KnowledgeBase.alfa7)
                        treshold.MaxConversationTime = 20;
                    else if (formula.Name == KnowledgeBase.alfa8)
                        treshold.HasFastCharging = true;
                    else if (formula.Name == KnowledgeBase.alfa9)
                        treshold.InternalMemory = 16;
                    else if (formula.Name == KnowledgeBase.alfa10)
                        treshold.HasExternalSlot = true;
                }
            }

            filtered = allPhones.Where(phone => phone >= treshold).ToList();
            return filtered;
        }
    }
}
