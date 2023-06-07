using FilmProjesi.Models;

namespace FilmProjesi.Repos
{
    public interface IYorumRepository
    {
        List<Yorum> getAll();
        void add(Yorum yorum);
        List<Yorum> getByUsername(string username);
        Yorum getById(int id);
        void sil(Yorum yorum);
        void guncelle(int id,string newYorumAciklama);
    }
}
