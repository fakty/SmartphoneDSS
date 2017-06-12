using SmartphoneDSS.Database;
using SmartphoneDSS.Database.Models;
using SmartphoneDSS.Logic;
using System.Collections.Generic;
using System.Linq;
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

            //szukanie formul wyjsciowych
            /*
            KnowledgeBase kb = new KnowledgeBase();
            var temp = new Evaluator(kb).CalculateOutputFormulas(null);
            */

            //szukanie formul wejsciowych
            /*
            KnowledgeBase kb = new KnowledgeBase();
            var temp = new Evaluator(kb).CalculateInputFormulas(null);
            */

            //Zamiana smarfonu na Listę formuł wejściowych
            /*
            List<Smartphone> smartphones = SmartphoneReader.getSmartphones();
            List<InputFormula> inputFormulas = SmartphoneInterpreter.getInputFormulas(smartphones[4]);
            */

            InitializeComponent();
        }
    }
}
