using SmartphoneDSS.Database;
using SmartphoneDSS.Database.Models;
using System.Collections.Generic;
using System.Windows;

namespace SmartphoneDSS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            /*
            Zamiana formuł wejściowych na listę modeli smartfonów

            KnowledgeBase kb = new KnowledgeBase();
            List<InputFormula> formulas = kb.GetInputFormulas();
            formulas[1].Value = true;
            KnowledgeBase kb2 = new KnowledgeBase();
            List<InputFormula> formulas2 = kb2.GetInputFormulas();
            formulas2[0].Value = true;

            SmartphoneFilter filter = new SmartphoneFilter();
            List<List<InputFormula>> list = new List<List<InputFormula>>();
            list.Add(formulas);
            list.Add(formulas2);
            List<Smartphone> phones = filter.filterByFormulas(list);
            */




            //Zamiana smarfonu na Listę formuł wejściowych

            List<Smartphone> smartphones = SmartphoneReader.getSmartphones();
            List<InputFormula> inputFormulas = SmartphoneInterpreter.getInputFormulas(smartphones[1]);


            InitializeComponent();
        }
    }
}
