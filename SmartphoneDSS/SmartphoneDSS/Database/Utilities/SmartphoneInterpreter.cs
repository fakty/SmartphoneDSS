using SmartphoneDSS.Database.Models;
using System.Collections.Generic;

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
                    formula.Value = (smartphone.RAM >= InputFormula.TRESHOLD_RAM ? true : false);
                else if (formula.Name == KnowledgeBase.alfa1)
                    formula.Value = (smartphone.BatteryCapacity >= InputFormula.TRESHOLD_BATTERY_CAPACITY ? true : false);
                else if (formula.Name == KnowledgeBase.alfa2)
                    formula.Value = (smartphone.ScreenSize >= InputFormula.TRESHOLD_SCREEN_SIZE ? true : false);
                else if (formula.Name == KnowledgeBase.alfa3)
                    formula.Value = (smartphone.IsFullHD ? true : false);
                else if (formula.Name == KnowledgeBase.alfa4)
                    formula.Value = (smartphone.HasToughenedGlass ? true : false);
                else if (formula.Name == KnowledgeBase.alfa5)
                    formula.Value = (smartphone.Camera >= InputFormula.TRESHOLD_CAMERA ? true : false);
                else if (formula.Name == KnowledgeBase.alfa6)
                    formula.Value = (smartphone.HasLTE ? true : false);
                else if (formula.Name == KnowledgeBase.alfa7)
                    formula.Value = (smartphone.MaxConversationTime >= InputFormula.TRESHOLD_MAX_CONVERSATION_TIME ? true : false);
                else if (formula.Name == KnowledgeBase.alfa8)
                    formula.Value = (smartphone.HasFastCharging ? true : false);
                else if (formula.Name == KnowledgeBase.alfa9)
                    formula.Value = (smartphone.InternalMemory >= InputFormula.TRESHOLD_INTERNAL_MEMORY ? true : false);
                else if (formula.Name == KnowledgeBase.alfa10)
                    formula.Value = (smartphone.HasExternalSlot ? true : false);
            }

            return inputFormulas;
        }
    }
}
