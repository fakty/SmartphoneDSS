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
                        treshold.RAM = Smartphone.TRESHOLD_RAM;
                    else if (formula.Name == KnowledgeBase.alfa1)
                        treshold.BatteryCapacity = Smartphone.TRESHOLD_BATTERY_CAPACITY;
                    else if (formula.Name == KnowledgeBase.alfa2)
                        treshold.ScreenSize = Smartphone.TRESHOLD_SCREEN_SIZE;
                    else if (formula.Name == KnowledgeBase.alfa3)
                        treshold.IsFullHD = true;
                    else if (formula.Name == KnowledgeBase.alfa4)
                        treshold.HasToughenedGlass = true;
                    else if (formula.Name == KnowledgeBase.alfa5)
                        treshold.Camera = Smartphone.TRESHOLD_CAMERA;
                    else if (formula.Name == KnowledgeBase.alfa6)
                        treshold.HasLTE = true;
                    else if (formula.Name == KnowledgeBase.alfa7)
                        treshold.MaxConversationTime = Smartphone.TRESHOLD_MAX_CONVERSATION_TIME;
                    else if (formula.Name == KnowledgeBase.alfa8)
                        treshold.HasFastCharging = true;
                    else if (formula.Name == KnowledgeBase.alfa9)
                        treshold.InternalMemory = Smartphone.TRESHOLD_INTERNAL_MEMORY;
                    else if (formula.Name == KnowledgeBase.alfa10)
                        treshold.HasExternalSlot = true;
                }
            }

            filtered = allPhones.Where(phone => phone >= treshold).ToList();
            return filtered;
        }
    }
}
