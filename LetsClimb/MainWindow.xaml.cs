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
        /// <summary>
        /// Competitors observable collection
        /// </summary>
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
            this.CompetitorSexComboBox.ItemsSource = Enum.GetValues(typeof(Sex));
            CompetitionCollection = new ObservableCollection<Competition>();
            CompetitorList = new ObservableCollection<Competitor>();
        }

        #region Competitor Controls
        /// <summary>
        /// Add button click in Competitor tab item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompetitorAddButton_Click(object sender, RoutedEventArgs e)
        {
            var name = this.CompetitorNameTextBox.Text;
            var lastName = this.CompetitorLastNameTextBox.Text;
            var sex = (Sex)Enum.Parse(typeof(Sex), this.CompetitorSexComboBox.Text);
            var category = (string)this.CompetitorCategoryComboBox.SelectedItem;
            var top = Int32.Parse(this.CompetitorTopTextBox.Text);
            var bonus = Int32.Parse(this.CompetitorBonusTextBox.Text);
            var competitor = new Competitor(name, lastName, sex, category, top, bonus);

            CompetitorList.Add(competitor);
            ClearTextBoxes();
        }

        /// <summary>
        /// Delete button click in Competitor tab item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompetitorDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.CompetitorList.RemoveAt(this.CompetitorListView.SelectedIndex);
            }
            catch(ArgumentException)
            {
                MessageBox.Show("First you have to select character you want to delete.", "Delete Competitor");
            }
        }

        /// <summary>
        /// Clear text boxes context in Competitor tab item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearCompetitorTextBoxes()
        {
            this.CompetitorNameTextBox.Clear();
            this.CompetitorLastNameTextBox.Clear();
            this.CompetitorSexComboBox.SelectedIndex = -1;
            this.CompetitorCategoryComboBox.SelectedIndex = -1;
            this.CompetitorTopTextBox.Clear();
            this.CompetitorBonusTextBox.Clear();
        }
        #endregion

        #region Competition Controls
        /// <summary>
        /// Add button click on Competition tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <returns>List of text boxes from Competition tab item</returns>
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// On selected item changed in Competition list view
        /// </summary>
        private void CompetitionListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var competition = (Competition)this.CompetitionListView.SelectedItem;
                var categories = competition.Categories;
                this.CompetitorTabItem.IsEnabled = true;
                this.CompetitorCategoryComboBox.ItemsSource = categories;
            }
            catch(NullReferenceException)
            {
                this.CompetitorTabItem.IsEnabled = false;
            }
        }
        #endregion
    }
}