using System.ComponentModel.DataAnnotations;

namespace FilmProjesi.Models
{
    public class Film
    {
        [Key]
        public int FilmID { get; set; }
        public string FilmAd { get; set; }
        public string FilmAciklama { get; set; }
        public ICollection<Yorum> FilmYorumlar { get; set; }
        public Film()
        {
            FilmYorumlar = new List<Yorum>();
        }
    }
}
