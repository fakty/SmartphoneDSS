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
        private static readonly String alfa0 = "smartfon ma więcej niż 2GB RAMu";
        private static readonly String alfa1 = "bateria powyżej 3300 mAh";
        private static readonly String alfa2 = "matryca ma przekątną większą lub równą 5,5 cala";
        private static readonly String alfa3 = "rozdzielczość nie mniejszą niż Full HD";
        private static readonly String alfa4 = "smartfon posiada ekran z hartowanego szkła";
        private static readonly String alfa5 = "telefon powinien mieć aparat >13 Mpx";
        private static readonly String alfa6 = "smartfon powinien obsługiwać LTE";
        private static readonly String alfa7 = "maksymalny czas rozmów co najmniej 20h";
        private static readonly String alfa8 = "smartfon powinien mieć funkcję szybkiego ładowania";
        private static readonly String alfa9 = "smartfon ma pamięć wewnętrzną większą niż 16GB";
        private static readonly String alfa10 = "smartfon ma slot na kartę SD";

        //Formuły wyjściowe
        private static readonly String alfa11 = "osoba intensywnie używa telefonu więcej niż 15h tygodniowo";
        private static readonly String alfa12 = "urządzenie upada częściej niż 4 razy w miesiącu";
        private static readonly String alfa13 = "osoba robi zdjęcia więcej niż 100 razy w miesiącu";
        private static readonly String alfa14 = "osoba chce oglądać filmy online";
        private static readonly String alfa15 = "osoba chce słuchać muzyki online";
        private static readonly String alfa16 = "osoba rozmawia co najmniej 5 godzin dziennie";
        private static readonly String alfa17 = "osoba używa telefonu jako odtwarzacza MP3";
        private static readonly String alfa18 = "osoba czyta na telefonie więcej niż 15h tygodniowo";


        private static List<Formula> Formulas = new List<Formula>(FORMULAS_COUNT){
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

        public List<Formula> GetFormulas()
        {
            return Formulas;
        }

        private bool Implication(bool A, bool B)
        {
            if (A)
                return B;
            else
                return true;
        }

        //Jeżeli osoba używa intensywnie telefonu więcej niż 15h tygodniowo to smartfon ma mieć >2GB RAMu i baterię powyżej 3300 mAh
        public bool Fact1(List<Formula> formulas)
        {
            return Implication(formulas[11].Value, formulas[0].Value && formulas[1].Value);
        }

        //Jeżeli osoba spędza na czytaniu na urządzeniu mobilnym więcej niż 15h tygodniowo
        //to matryca powinna mieć przekątną większą lub równą 5,5 cala i rozdzielczość nie mniejszą niż Full HD i baterię powyżej 3300 mAh
        public bool Fact2(List<Formula> formulas)
        {
            return Implication(formulas[18].Value, formulas[2].Value && formulas[3].Value && formulas[1].Value);
        }

        //Jeżeli urządzenie upada częściej niż 4 razy w miesiącu to powinno mieć ekran z hartowanego szkła
        public bool Fact3(List<Formula> formulas)
        {
            return Implication(formulas[12].Value, formulas[4].Value);
        }

        //Jeżeli osoba robi zdjęcia więcej niż 100 razy w miesiącu, to telefon powinien mieć aparat >13 Mpx
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

        //Jeżeli osoba używa telefonu jako odtwarzacza MP3 to powinna mieć pamięć wewnętrzną większą niż 16GB lub slot na kartę SD
        public bool Fact7(List<Formula> formulas)
        {
            return Implication(formulas[17].Value, formulas[9].Value && formulas[10].Value);
        }
    }
}
