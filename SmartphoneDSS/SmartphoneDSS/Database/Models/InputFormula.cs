namespace SmartphoneDSS.Database.Models
{
    class InputFormula : Formula
    {
        public static float TRESHOLD_RAM = 2f;
        public static int TRESHOLD_BATTERY_CAPACITY = 3300;
        public static float TRESHOLD_SCREEN_SIZE = 5.5f;
        public static float TRESHOLD_CAMERA = 13f;
        public static int TRESHOLD_MAX_CONVERSATION_TIME = 20;
        public static int TRESHOLD_INTERNAL_MEMORY = 16;

        public InputFormula(string name) : base(name)
        {
        }

        public InputFormula(InputFormula inF) : base(inF)
        {
        }
    }
}
