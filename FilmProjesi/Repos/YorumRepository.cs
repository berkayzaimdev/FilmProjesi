using FilmProjesi.Data;
using FilmProjesi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmProjesi.Repos
{
    public class YorumRepository : IYorumRepository
    {
        private Context _context;
        public YorumRepository(Context context)
        {
            _context = context;
        }
        public List<Yorum> getAll() => _context.Yorumlar.ToList();
        public void add(Yorum yorum)
        {
            _context.Yorumlar.Add(yorum);
            _context.SaveChanges();
        }
        public List<Yorum> getByUsername(string username) => _context.Yorumlar.Where(y => y.YorumSahibi == username).ToList();

        public Yorum getById(int id) => _context.Yorumlar.FirstOrDefault(y => y.YorumID == id);
        public void sil(Yorum yorum) 
        {
            _context.Yorumlar.Remove(yorum);
            _context.SaveChanges();
        }
        public void guncelle(int id,string newYorumAciklama)
        {
            var yorum = _context.Yorumlar.FirstOrDefault(y => y.YorumID == id);
            yorum.YorumAciklama = newYorumAciklama;
            _context.SaveChanges();
        }
    }
}
