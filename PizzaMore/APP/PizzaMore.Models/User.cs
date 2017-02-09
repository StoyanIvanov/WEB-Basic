
namespace PizzaMore.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User
    {
        private ICollection<Pizza> suggestions;

        public User()
        {
            this.Suggestions=new HashSet<Pizza>();
        }

        [Key]
        public int Id { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public ICollection<Pizza> Suggestions {
            get { return this.suggestions; }
            set { this.suggestions = value; }
        }

    }
}
