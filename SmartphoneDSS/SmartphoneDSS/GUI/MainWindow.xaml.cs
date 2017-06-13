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
            var Fu = new List<InputFormula>() {
                new InputFormula(KnowledgeBase.alfa0),
                new InputFormula(KnowledgeBase.alfa1),
                new InputFormula(KnowledgeBase.alfa2),
                new InputFormula(KnowledgeBase.alfa3),
                new InputFormula(KnowledgeBase.alfa4),
                new InputFormula(KnowledgeBase.alfa5),
                new InputFormula(KnowledgeBase.alfa6),
                new InputFormula(KnowledgeBase.alfa7),
                new InputFormula(KnowledgeBase.alfa8),
                new InputFormula(KnowledgeBase.alfa9),
                new InputFormula(KnowledgeBase.alfa10),
            };

            Fu[0].Value = true;
            Fu[1].Value = true;
            Fu[2].Value = true;
            Fu[3].Value = true;
            Fu[6].Value = true;
            Fu[7].Value = true;
            Fu[9].Value = true;
            Fu[10].Value = true;

            var temp = new Evaluator(kb).CalculateOutputFormulas(Fu);
            */

            //szukanie formul wejsciowych
            /*
            KnowledgeBase kb = new KnowledgeBase();
            var Fy = new List<OutputFormula>() {
                new OutputFormula(KnowledgeBase.alfa11),
                new OutputFormula(KnowledgeBase.alfa12),
                new OutputFormula(KnowledgeBase.alfa13),
                new OutputFormula(KnowledgeBase.alfa14),
                new OutputFormula(KnowledgeBase.alfa15),
                new OutputFormula(KnowledgeBase.alfa16),
                new OutputFormula(KnowledgeBase.alfa17),
                new OutputFormula(KnowledgeBase.alfa18)
            };

            Fy[0].Value = true;
            Fy[2].Value = true;
            Fy[6].Value = true;
            Fy[7].Value = true;

            var temp = new Evaluator(kb).CalculateInputFormulas(Fy);
            SmartphoneFilter sf = new SmartphoneFilter();
            var smart = sf.FilterByFormulas(temp);
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
