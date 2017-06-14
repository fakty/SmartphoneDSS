using System;

namespace SmartphoneDSS.Database.Models
{
    class OutputFormula : Formula
    {
        public static int TRESHOLD_WEEKLY_TIME_INTENSIVE = 15;
        public static int TRESHOLD_WEEKLY_TIME_READING = 15;
        public static int TRESHOLD_MONTHLY_COUNT_FALL_DOWN = 4;
        public static int TRESHOLD_MONTHLY_COUNT_PICTURES = 100;
        public static int TRESHOLD_DAILY_CONVERSATION_TIME = 5;

        public OutputFormula(String name) : base(name)
        {
        }

        public OutputFormula(OutputFormula outF) : base(outF)
        {
        }
    }
}
