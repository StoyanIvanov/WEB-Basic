
namespace PizzaMore.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Pizza
    {
        [Key]
        public int Id { get; set; }


        public string Title { get; set; }

        public string Recipe { get; set; }

        public string ImageURL { get; set; }

        public int UpVotes { get; set; }

        public int DownVotes { get; set; }

        public int OwnerId { get; set; }
        [ForeignKey("OwnerId")]
        public virtual User User { get; set; }
    }
}
