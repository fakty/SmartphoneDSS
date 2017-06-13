using SmartphoneDSS.Database;
using SmartphoneDSS.Database.Models;
using SmartphoneDSS.Exceptions;
using SmartphoneDSS.Logic;
using System;
using System.Collections.Generic;
using System.Globalization;
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

            //
            List<Smartphone> s = SmartphoneReader.getSmartphones();
            var a = getUserTypeFromChoosedSmartphone(s[5]);
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

        /// <summary>
        /// ZADANIE ANALIZY
        /// </summary>
        /// <param name="smartphone">Smarfon który klika user</param>
        /// <returns>Zbiór faktów reprezentujących userów dla których jest ten smartfon</returns>
        private List<List<OutputFormula>> getUserTypeFromChoosedSmartphone(Smartphone smartphone)
        {
            List<InputFormula> inputFormulas = SmartphoneInterpreter.GetInputFormulas(smartphone);
            List<List<OutputFormula>> userType = new Evaluator(new KnowledgeBase()).CalculateOutputFormulas(inputFormulas);
            return userType;
        }

        /// <summary>
        /// ZADANIE PODEJMOWANIA DECYZJI
        /// </summary>
        /// <param name="outputFormulas">Fakt na podstawie którego wybieramy smartfony</param>
        /// <param name="price">Cena jaką user zadeklarował że może max wydać</param>
        /// <returns>lista smartfonów</returns>
        private List<Smartphone> getSmartphonesFromUserPreferences(List<OutputFormula> outputFormulas, float price)
        {
            var temp = new Evaluator(new KnowledgeBase()).CalculateInputFormulas(outputFormulas);
            SmartphoneFilter sf = new SmartphoneFilter();
            List<Smartphone> preferredSmartphones = sf.FilterByFormulas(temp, price);
            return preferredSmartphones;
        }

        private List<OutputFormula> getOutputFormulasFromInput()
        {
            List<OutputFormula> outputFormulas = new KnowledgeBase().GetOutputFormulas();
            foreach (OutputFormula formula in outputFormulas)
            {
                if (formula.Name == KnowledgeBase.alfa11)
                    formula.Value = (int.Parse(intensiveUsageTextBox.Text) >= OutputFormula.TRESHOLD_WEEKLY_TIME_INTENSIVE ? true : false);
                else if (formula.Name == KnowledgeBase.alfa12)
                    formula.Value = (int.Parse(fallingDownTextBox.Text) >= OutputFormula.TRESHOLD_MONTHLY_COUNT_FALL_DOWN ? true : false);
                else if (formula.Name == KnowledgeBase.alfa13)
                    formula.Value = (int.Parse(photosTextBox.Text) >= OutputFormula.TRESHOLD_MONTHLY_COUNT_PICTURES ? true : false);
                else if (formula.Name == KnowledgeBase.alfa14)
                    formula.Value = (bool)onlineMoviesStreaming.IsChecked;
                else if (formula.Name == KnowledgeBase.alfa15)
                    formula.Value = (bool)onlineMusicStreaming.IsChecked;
                else if (formula.Name == KnowledgeBase.alfa16)
                    formula.Value = (int.Parse(phoneConversationTextBox.Text) >= OutputFormula.TRESHOLD_DAILY_CONVERSATION_TIME ? true : false);
                else if (formula.Name == KnowledgeBase.alfa17)
                    formula.Value = (bool)asMP3PlayerUsing.IsChecked;
                else if (formula.Name == KnowledgeBase.alfa18)
                    formula.Value = (int.Parse(readingTextBox.Text) >= OutputFormula.TRESHOLD_WEEKLY_TIME_READING ? true : false);
            }
            return outputFormulas;
        }

        private void findSmartphonesButton_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(intensiveUsageTextBox.Text) ||
                String.IsNullOrEmpty(readingTextBox.Text) ||
                String.IsNullOrEmpty(fallingDownTextBox.Text) || 
                String.IsNullOrEmpty(photosTextBox.Text) ||
                String.IsNullOrEmpty(phoneConversationTextBox.Text) ||
                String.IsNullOrEmpty(maximumPriceTextBox.Text))
            {
                MessageBox.Show("Wypełnij wszystkie pola!");
            } else
            {
                List<OutputFormula> formulas = getOutputFormulasFromInput();
                try
                {
                    List<Smartphone> smartphones = getSmartphonesFromUserPreferences(formulas, float.Parse(maximumPriceTextBox.Text, CultureInfo.InvariantCulture));
                    List<String> names = smartphones.Select(i => i.Name + " Cena: " + i.Price).ToList();
                    resultsList.ItemsSource = names;
                    MessageBox.Show("Znalezione wyniki: " + smartphones.Count);
                }
                catch (EmptyListException exception)
                {
                    MessageBox.Show(exception.Message);
                }

            } 
        }
    }
}
