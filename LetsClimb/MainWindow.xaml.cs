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
        public ObservableCollection<Competitor> CompetitorList { get; set; }

        /// <summary>
        /// Main window constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            CompetitorList = new ObservableCollection<Competitor>();
            this.CompatitorSexComboBox.ItemsSource = Enum.GetValues(typeof(Sex));
            this.CompatitorCategoryComboBox.ItemsSource = Enum.GetValues(typeof(Category));
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
    }
}