using SmartphoneDSS.Database;
using SmartphoneDSS.Database.Models;
using SmartphoneDSS.Database.Utilities;
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
            InitializeComponent();
            if (AccountManager.loginStatus == AccountManager.LoginStatus.LoggedAsAnon)
            {
                tresholdValuesTab.IsEnabled = false;
                addingSmartphoneTab.IsEnabled = false;
            }
            else
            {
                InitializeConfigurationPanel();
            }
        }

        private void InitializeConfigurationPanel()
        {
            RAM_Box.Text = InputFormula.TRESHOLD_RAM.ToString();
            Capacity_Box.Text = InputFormula.TRESHOLD_BATTERY_CAPACITY.ToString();
            Screen_Box.Text = InputFormula.TRESHOLD_SCREEN_SIZE.ToString();
            Camera_Box.Text = InputFormula.TRESHOLD_CAMERA.ToString();
            Conversation_Box.Text = InputFormula.TRESHOLD_MAX_CONVERSATION_TIME.ToString();
            Memory_Box.Text = InputFormula.TRESHOLD_INTERNAL_MEMORY.ToString();

            Usage_Box.Text = OutputFormula.TRESHOLD_WEEKLY_TIME_INTENSIVE.ToString();
            Reading_Box.Text = OutputFormula.TRESHOLD_WEEKLY_TIME_READING.ToString();
            Falling_Box.Text = OutputFormula.TRESHOLD_MONTHLY_COUNT_FALL_DOWN.ToString();
            Foto_Box.Text = OutputFormula.TRESHOLD_MONTHLY_COUNT_PICTURES.ToString();
            Avg_Conversation_Box.Text = OutputFormula.TRESHOLD_DAILY_CONVERSATION_TIME.ToString();
        }

        /// <summary>
        /// ZADANIE ANALIZY
        /// </summary>
        /// <param name="smartphone">Smarfon który klika user</param>
        /// <returns>Zbiór faktów reprezentujących userów dla których jest ten smartfon</returns>
        private List<List<OutputFormula>> GetUserTypeFromChoosedSmartphone(Smartphone smartphone)
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
        private List<Smartphone> GetSmartphonesFromUserPreferences(List<OutputFormula> outputFormulas, float price)
        {
            var temp = new Evaluator(new KnowledgeBase()).CalculateInputFormulas(outputFormulas);
            SmartphoneFilter sf = new SmartphoneFilter();
            List<Smartphone> preferredSmartphones = sf.FilterByFormulas(temp, price);
            return preferredSmartphones;
        }

        private List<OutputFormula> GetOutputFormulasFromInput()
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

        private void FindSmartphonesButton_Click(object sender, RoutedEventArgs e)
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
                List<OutputFormula> formulas = GetOutputFormulasFromInput();
                try
                {
                    List<Smartphone> smartphones = GetSmartphonesFromUserPreferences(formulas, float.Parse(maximumPriceTextBox.Text, CultureInfo.InvariantCulture));
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

        private Smartphone GetSmartphoneFromInput()
        {
            Smartphone smartphone = new Smartphone();

            if (String.IsNullOrEmpty(nameTextBox.Text) ||
                String.IsNullOrEmpty(RAMTextBox.Text) ||
                String.IsNullOrEmpty(batteryTextBox.Text) ||
                String.IsNullOrEmpty(cameraTextBox.Text) ||
                String.IsNullOrEmpty(maxConversationTimeTextBox.Text) ||
                String.IsNullOrEmpty(screenSizeTextBox.Text) ||
                String.IsNullOrEmpty(internalMemoryTextBox.Text) ||
                String.IsNullOrEmpty(priceTextBox.Text))
            {
                MessageBox.Show("Wypełnij wszystkie pola!");
                return null;
            }
            else
            {
                smartphone.Name = nameTextBox.Text;
                smartphone.RAM = float.Parse(RAMTextBox.Text, CultureInfo.InvariantCulture);
                smartphone.BatteryCapacity = int.Parse(batteryTextBox.Text);
                smartphone.ScreenSize = float.Parse(screenSizeTextBox.Text, CultureInfo.InvariantCulture);
                smartphone.InternalMemory = int.Parse(internalMemoryTextBox.Text);
                smartphone.Camera = float.Parse(cameraTextBox.Text, CultureInfo.InvariantCulture);
                smartphone.MaxConversationTime = int.Parse(maxConversationTimeTextBox.Text);
                smartphone.HasToughenedGlass = (bool)hasToughenedGlass.IsChecked;
                smartphone.HasLTE = (bool)hasLTE.IsChecked;
                smartphone.HasFastCharging = (bool)hasFastCharging.IsChecked;
                smartphone.HasExternalSlot = (bool)hasExternalSlot.IsChecked;
                smartphone.IsFullHD = (bool)isFullHD.IsChecked;
                smartphone.Price = float.Parse(priceTextBox.Text, CultureInfo.InvariantCulture);
                return smartphone;
            }
        }

        private void AddSmartphonesButton_Click(object sender, RoutedEventArgs e)
        {
            Smartphone s = GetSmartphoneFromInput();
            if (s != null)
            {
                SmartphoneFileHandler.SaveSmartphone(s);
                MessageBox.Show("Dodano smartfona do bazy!");
            }
        }

        private void SaveSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            InputFormula.TRESHOLD_RAM = float.Parse(RAM_Box.Text);
            InputFormula.TRESHOLD_BATTERY_CAPACITY = int.Parse(Capacity_Box.Text);
            InputFormula.TRESHOLD_SCREEN_SIZE = float.Parse(Screen_Box.Text);
            InputFormula.TRESHOLD_CAMERA = float.Parse(Camera_Box.Text);
            InputFormula.TRESHOLD_MAX_CONVERSATION_TIME = int.Parse(Conversation_Box.Text);
            InputFormula.TRESHOLD_INTERNAL_MEMORY = int.Parse(Memory_Box.Text);

            OutputFormula.TRESHOLD_WEEKLY_TIME_INTENSIVE = int.Parse(Usage_Box.Text);
            OutputFormula.TRESHOLD_WEEKLY_TIME_READING = int.Parse(Reading_Box.Text);
            OutputFormula.TRESHOLD_MONTHLY_COUNT_FALL_DOWN = int.Parse(Falling_Box.Text);
            OutputFormula.TRESHOLD_MONTHLY_COUNT_PICTURES = int.Parse(Foto_Box.Text);
            OutputFormula.TRESHOLD_DAILY_CONVERSATION_TIME = int.Parse(Avg_Conversation_Box.Text);
        }
        /*
        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            InitializeConfigurationPanel();
        }
        */
    }
}
