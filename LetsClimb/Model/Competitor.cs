namespace LetsClimb.Model
{
    /// <summary>
    /// Choice of sex
    /// </summary>
    public enum Sex { Male, Female };

    /// <summary>
    /// Competitor model class
    /// </summary>
    public class Competitor
    {
        /// <summary>
        /// Competitor's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Competitor's last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Competitor's sex
        /// </summary>
        public Sex Sex { get; set; }

        /// <summary>
        /// Competitor's category
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Competitor's top number
        /// </summary>
        public int Top { get; set; }

        /// <summary>
        /// Competitor's bonus number
        /// </summary>
        public int Bonus { get; set; }

        /// <summary>
        /// Competitor's place
        /// </summary>
        public int Place { get; set; }

        /// <summary>
        /// Competitor model constructor
        /// </summary>
        public Competitor(string name, string lastName, Sex sex, string category, int top, int bonus)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Sex = Sex;
            this.Category = category;
            this.Top = top;
            this.Bonus = bonus;
        }
    }
}