using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmProjesi.Models
{
    public class Yorum
    {
        [Key]
        public int YorumID { get; set; }

        public string YorumAciklama { get; set; }

        public DateTime YorumTarihi { get; set; } = DateTime.Now;
        public int FilmID { get; set; }
        public string YorumSahibi { get; set; }

        [ForeignKey("FilmID")]
        public Film Film { get; set; } 
    }
}
