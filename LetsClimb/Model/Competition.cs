namespace LetsClimb.Model
{
    using System.Collections.Generic;

    /// <summary>
    /// Competition model class
    /// </summary>
    public class Competition
    {
        /// <summary>
        /// Competition's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Competition's categories
        /// </summary>
        public List<string> Categories { get; set; }

        /// <summary>
        /// Competition's result
        /// </summary>
        public List<Competitor> Result { get; set; }

        /// <summary>
        /// Competition model constructor
        /// </summary>
        /// <param name="name">Competition's name</param>
        /// <param name="categories">Competition's categories</param>
        public Competition(string name, List<string> categories)
        {
            this.Name = name;
            this.Categories = categories;
            this.Result = new List<Competitor>();
        }
    }
}