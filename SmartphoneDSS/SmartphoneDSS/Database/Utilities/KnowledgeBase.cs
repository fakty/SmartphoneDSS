using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartphoneDSS.Database.Models
{
    class KnowledgeBase
    {
        private static readonly int FORMULAS_COUNT = 19;

        //Formuły wejściowe
        public static readonly String alfa0 = "smartfon musi mieć 2GB RAMu lub więcej";
        public static readonly String alfa1 = "bateria musi mieć pojemnośc 3300 mAh lub większą";
        public static readonly String alfa2 = "matryca musi mieć przekątną większą lub równą 5,5 cala";
        public static readonly String alfa3 = "rozdzielczość musi być nie mniejsza niż Full HD";
        public static readonly String alfa4 = "smartfon musi posiadać ekran z hartowanego szkła";
        public static readonly String alfa5 = "telefon musi mieć aparat większy lub równy 13 Mpx";
        public static readonly String alfa6 = "smartfon musi obsługiwać LTE";
        public static readonly String alfa7 = "smartfon musi posiadać maksymalny czas rozmów co najmniej 20h";
        public static readonly String alfa8 = "smartfon musi mieć funkcję szybkiego ładowania";
        public static readonly String alfa9 = "smartfon musi mieć pamięć wewnętrzną większą lub równą niż 16GB";
        public static readonly String alfa10 = "smartfon musi mieć slot na kartę SD";

        //Formuły wyjściowe
        public static readonly String alfa11 = "osoba intensywnie używa telefonu więcej niż 15h tygodniowo";
        public static readonly String alfa12 = "urządzenie upada częściej niż 4 razy w miesiącu";
        public static readonly String alfa13 = "osoba robi zdjęcia więcej niż 100 razy w miesiącu";
        public static readonly String alfa14 = "osoba chce oglądać filmy online";
        public static readonly String alfa15 = "osoba chce słuchać muzyki online";
        public static readonly String alfa16 = "osoba rozmawia co najmniej 5 godzin dziennie";
        public static readonly String alfa17 = "osoba używa telefonu jako odtwarzacza MP3";
        public static readonly String alfa18 = "osoba czyta na telefonie więcej niż 15h tygodniowo";


        private readonly List<Formula> Formulas = new List<Formula>(FORMULAS_COUNT){
            new InputFormula(alfa0),
            new InputFormula(alfa1),
            new InputFormula(alfa2),
            new InputFormula(alfa3),
            new InputFormula(alfa4),
            new InputFormula(alfa5),
            new InputFormula(alfa6),
            new InputFormula(alfa7),
            new InputFormula(alfa8),
            new InputFormula(alfa9),
            new InputFormula(alfa10),
            new OutputFormula(alfa11),
            new OutputFormula(alfa12),
            new OutputFormula(alfa13),
            new OutputFormula(alfa14),
            new OutputFormula(alfa15),
            new OutputFormula(alfa16),
            new OutputFormula(alfa17),
            new OutputFormula(alfa18)
        };

        public List<InputFormula> GetInputFormulas()
        {
            return Formulas.OfType<InputFormula>().ToList();
        }

        public List<OutputFormula> GetOutputFormulas()
        {
            return Formulas.OfType<OutputFormula>().ToList();
        }

        public List<Formula> GetFormulas()
        {
            return Formulas;
        }

        private static bool Implication(bool A, bool B)
        {
            if (A)
                return B;
            else
                return true;
        }

        //Jeżeli osoba używa intensywnie telefonu więcej niż 15h tygodniowo to smartfon ma mieć >= 2GB RAMu i baterię powyżej 3300 mAh
        public bool Fact1(List<Formula> formulas)
        {
            return Implication(formulas[11].Value, formulas[0].Value && formulas[1].Value);
        }

        //Jeżeli osoba spędza na czytaniu na urządzeniu mobilnym więcej niż 15h tygodniowo
        //to matryca powinna mieć przekątną większą lub równą 5,5 cala i rozdzielczość nie mniejszą niż Full HD i baterię >= 3300 mAh
        public bool Fact2(List<Formula> formulas)
        {
            return Implication(formulas[18].Value, formulas[2].Value && formulas[3].Value && formulas[1].Value);
        }

        //Jeżeli urządzenie upada częściej niż 4 razy w miesiącu to powinno mieć ekran z hartowanego szkła
        public bool Fact3(List<Formula> formulas)
        {
            return Implication(formulas[12].Value, formulas[4].Value);
        }

        //Jeżeli osoba robi zdjęcia więcej niż 100 razy w miesiącu, to telefon powinien mieć aparat >= 13 Mpx
        public bool Fact4(List<Formula> formulas)
        {
            return Implication(formulas[13].Value, formulas[5].Value);
        }

        //Jeśli osoba chce oglądać filmy online lub słuchać muzyki online to smartfon powinien obsługiwać LTE
        public bool Fact5(List<Formula> formulas)
        {
            return Implication(formulas[14].Value || formulas[15].Value, formulas[6].Value);
        }

        //Jeżeli osoba rozmawia co najmniej 5 godzin dziennie smartfon powinien mieć maksymalny czas rozmów co najmniej 20h i funkcję szybkiego ładowania
        public bool Fact6(List<Formula> formulas)
        {
            return Implication(formulas[16].Value, formulas[7].Value && formulas[8].Value);
        }

        //Jeżeli osoba używa telefonu jako odtwarzacza MP3 to powinna mieć pamięć wewnętrzną co najmniej 16GB lub slot na kartę SD
        public bool Fact7(List<Formula> formulas)
        {
            return Implication(formulas[17].Value, formulas[9].Value && formulas[10].Value);
        }
    }
}
