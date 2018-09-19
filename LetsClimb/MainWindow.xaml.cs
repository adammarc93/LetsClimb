namespace LetsClimb
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Controls;

    using Model;

    /// <summary>
    /// Interaction logic for MainWindow.xaml 
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Competitor> CompetitorList { get; set; }

        /// <summary>
        /// Competitions observable collection
        /// </summary>
        public ObservableCollection<Competition> CompetitionCollection { get; set; }

        /// <summary>
        /// Main window constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            this.CompatitorSexComboBox.ItemsSource = Enum.GetValues(typeof(Sex));
            this.CompatitorCategoryComboBox.ItemsSource = Enum.GetValues(typeof(Category));
            CompetitionCollection = new ObservableCollection<Competition>();
            CompetitorList = new ObservableCollection<Competitor>();
        }

        /// <summary>
        /// Add button click
        /// </summary>
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var name = this.CompatitorNameTextBox.Text;
                var lastName = this.CompatitorLastNameTextBox.Text;
                var sex = (Sex)Enum.Parse(typeof(Sex), this.CompatitorSexComboBox.Text);
                var category = (Category)Enum.Parse(typeof(Category), this.CompatitorCategoryComboBox.Text);
                var top = Int32.Parse(this.CompatitorTopTextBox.Text);
                var bonus = Int32.Parse(this.CompatitorBonusTextBox.Text);
                var competitor = new Competitor(name, lastName, sex, category, top, bonus);
                CompetitorList.Add(competitor);
            }
            catch(Exception)
            {
                MessageBox.Show("First you have to fill all fields.", "Add competitor");
            }

            ClearTextBoxes();
        }

        /// <summary>
        /// Delete button clik
        /// </summary>
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.CompetitorList.RemoveAt(this.CompetitorListView.SelectedIndex);
            }
            catch(Exception)
            {
                MessageBox.Show("First you have to select character you want to delete.", "Delete Competitor");
            }
        }

        /// <summary>
        /// Clear text boxes context
        /// </summary>
        private void ClearTextBoxes()
        {
            this.CompatitorNameTextBox.Clear();
            this.CompatitorLastNameTextBox.Clear();
            this.CompatitorSexComboBox.SelectedIndex = -1;
            this.CompatitorCategoryComboBox.SelectedIndex = -1;
            this.CompatitorTopTextBox.Clear();
            this.CompatitorBonusTextBox.Clear();
        }

        /// <summary>
        /// Add button click on Competition tab
        /// </summary>
        private void CompetitionAddButton_Click(object sender, RoutedEventArgs e)
        {
            var name = this.CompetitionNameTextBox.Text;
            var categories = new List<string>();
            var textBoxCollection = FillTextBoxCollection();

            foreach(var textBox in textBoxCollection)
            {
                if(!String.IsNullOrEmpty(textBox.Text))
                {
                    categories.Add(textBox.Text);
                }
            }

            var competition = new Competition(name, categories);
            CompetitionCollection.Add(competition);
            ClearCompetitionTextBoxes();
        }

        /// <summary>
        /// Delete button click on Competition tab
        /// </summary>
        private void CompetitionDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.CompetitionCollection.RemoveAt(this.CompetitionListView.SelectedIndex);
            }
            catch(ArgumentException)
            {
                MessageBox.Show("First you have to select character you want to delete.", "Delete Competition");
            }
        }

        /// <summary>
        /// Clear text boxes context in Competition tab item
        /// </summary>
        private void ClearCompetitionTextBoxes()
        {
            this.CompetitionNameTextBox.Clear();
            this.CompetitionCategoryOneTextBox.Clear();
            this.CompetitionCategoryTwoTextBox.Clear();
            this.CompetitionCategoryThreeTextBox.Clear();
            this.CompetitionCategoryFourTextBox.Clear();
            this.CompetitionCategoryFiveTextBox.Clear();
            this.CompetitionCategorySixTextBox.Clear();
        }

        /// <summary>
        /// Fill text box collection from text boxes in Competition tab item
        /// </summary>
        private List<TextBox> FillTextBoxCollection()
        {
            var textBoxCollection = new List<TextBox>();
            textBoxCollection.Add(this.CompetitionCategoryOneTextBox);
            textBoxCollection.Add(this.CompetitionCategoryTwoTextBox);
            textBoxCollection.Add(this.CompetitionCategoryThreeTextBox);
            textBoxCollection.Add(this.CompetitionCategoryFourTextBox);
            textBoxCollection.Add(this.CompetitionCategoryFiveTextBox);
            textBoxCollection.Add(this.CompetitionCategorySixTextBox);

            return textBoxCollection;
        }

        /// <summary>
        /// Text changed text box in Competition tab item
        /// </summary>
        private void CompetitionCategoryOneTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(!String.IsNullOrEmpty(this.CompetitionCategoryOneTextBox.Text))
            {
                this.CompetitionCategoryTwoTextBox.IsEnabled = true;
            }
            else
            {
                this.CompetitionCategoryTwoTextBox.IsEnabled = false;
            }
        }

        /// <summary>
        /// Text changed text box in Competition tab item
        /// </summary>
        private void CompetitionCategoryTwoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(!String.IsNullOrEmpty(this.CompetitionCategoryTwoTextBox.Text))
            {
                this.CompetitionCategoryThreeTextBox.IsEnabled = true;
            }
            else
            {
                this.CompetitionCategoryThreeTextBox.IsEnabled = false;
            }
        }

        /// <summary>
        /// Text changed text box in Competition tab item
        /// </summary>
        private void CompetitionCategoryThreeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(!String.IsNullOrEmpty(this.CompetitionCategoryThreeTextBox.Text))
            {
                this.CompetitionCategoryFourTextBox.IsEnabled = true;
            }
            else
            {
                this.CompetitionCategoryFourTextBox.IsEnabled = false;
            }
        }

        /// <summary>
        /// Text changed text box in Competition tab item
        /// </summary>
        private void CompetitionCategoryFourTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(!String.IsNullOrEmpty(this.CompetitionCategoryFourTextBox.Text))
            {
                this.CompetitionCategoryFiveTextBox.IsEnabled = true;
            }
            else
            {
                this.CompetitionCategoryFiveTextBox.IsEnabled = false;
            }
        }

        /// <summary>
        /// Text changed text box in Competition tab item
        /// </summary>
        private void CompetitionCategoryFiveTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(!String.IsNullOrEmpty(this.CompetitionCategoryFiveTextBox.Text))
            {
                this.CompetitionCategorySixTextBox.IsEnabled = true;
            }
            else
            {
                this.CompetitionCategorySixTextBox.IsEnabled = false;
            }
        }
    }
}