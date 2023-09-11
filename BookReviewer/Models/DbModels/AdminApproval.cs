using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookReviewer.Models.DbModels
{
    public class AdminApproval
    {
        [Key, ForeignKey("ApplicationUser")]
        public string Id { get; set; }

        [DefaultValue(false)]
        public bool IsApproved { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}