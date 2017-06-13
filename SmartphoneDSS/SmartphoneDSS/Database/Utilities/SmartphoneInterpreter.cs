using SmartphoneDSS.Database.Filter;
using SmartphoneDSS.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartphoneDSS.Database
{
    class SmartphoneInterpreter
    {
        public static List<InputFormula> GetInputFormulas(Smartphone smartphone)
        {
            List<InputFormula> inputFormulas = new KnowledgeBase().GetInputFormulas();
            
            foreach (InputFormula formula in inputFormulas)
            {
                if (formula.Name == KnowledgeBase.alfa0)
                    formula.Value = (smartphone.RAM >= Smartphone.TRESHOLD_RAM ? true : false);
                else if (formula.Name == KnowledgeBase.alfa1)
                    formula.Value = (smartphone.BatteryCapacity >= Smartphone.TRESHOLD_BATTERY_CAPACITY ? true : false);
                else if (formula.Name == KnowledgeBase.alfa2)
                    formula.Value = (smartphone.ScreenSize >= Smartphone.TRESHOLD_SCREEN_SIZE ? true : false);
                else if (formula.Name == KnowledgeBase.alfa3)
                    formula.Value = (smartphone.IsFullHD ? true : false);
                else if (formula.Name == KnowledgeBase.alfa4)
                    formula.Value = (smartphone.HasToughenedGlass ? true : false);
                else if (formula.Name == KnowledgeBase.alfa5)
                    formula.Value = (smartphone.Camera >= Smartphone.TRESHOLD_CAMERA ? true : false);
                else if (formula.Name == KnowledgeBase.alfa6)
                    formula.Value = (smartphone.HasLTE ? true : false);
                else if (formula.Name == KnowledgeBase.alfa7)
                    formula.Value = (smartphone.MaxConversationTime >= Smartphone.TRESHOLD_MAX_CONVERSATION_TIME ? true : false);
                else if (formula.Name == KnowledgeBase.alfa8)
                    formula.Value = (smartphone.HasFastCharging ? true : false);
                else if (formula.Name == KnowledgeBase.alfa9)
                    formula.Value = (smartphone.InternalMemory >= Smartphone.TRESHOLD_INTERNAL_MEMORY ? true : false);
                else if (formula.Name == KnowledgeBase.alfa10)
                    formula.Value = (smartphone.HasExternalSlot ? true : false);
            }

            return inputFormulas;
        }
    }
}
