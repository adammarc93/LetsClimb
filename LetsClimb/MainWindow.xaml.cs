namespace LetsClimb
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows;

    using Model;

    /// <summary>
    /// Interaction logic for MainWindow.xaml 
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Competition's result
        /// </summary>
        public ObservableCollection<Competitor> CompetitorList { get; set; }

        /// <summary>
        /// Main window constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            this.CompetitorSexComboBox.ItemsSource = Enum.GetValues(typeof(Sex));
            this.CompetitorCategoryComboBox.ItemsSource = Enum.GetValues(typeof(Category));
            CompetitorList = new ObservableCollection<Competitor>();
        }

        /// <summary>
        /// Add button click in Competitor tab item
        /// </summary>
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var name = this.CompetitorNameTextBox.Text;
            var lastName = this.CompetitorLastNameTextBox.Text;
            var sex = (Sex)Enum.Parse(typeof(Sex), this.CompetitorSexComboBox.Text);
            var category = (Category)Enum.Parse(typeof(Category), this.CompetitorCategoryComboBox.Text);
            var top = Int32.Parse(this.CompetitorTopTextBox.Text);
            var bonus = Int32.Parse(this.CompetitorBonusTextBox.Text);
            var competitor = new Competitor(name, lastName, sex, category, top, bonus);

            CompetitorList.Add(competitor);
            ClearTextBoxes();
        }

        /// <summary>
        /// Delete button click in Competitor tab item
        /// </summary>
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
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
        private void ClearTextBoxes()
        {
            this.CompetitorNameTextBox.Clear();
            this.CompetitorLastNameTextBox.Clear();
            this.CompetitorSexComboBox.SelectedIndex = -1;
            this.CompetitorCategoryComboBox.SelectedIndex = -1;
            this.CompetitorTopTextBox.Clear();
            this.CompetitorBonusTextBox.Clear();
        }
    }
}