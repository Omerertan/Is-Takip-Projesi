using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.Business.Interfaces
{
    public interface IGorevService : IGenericService<Gorev>
    {
        List<Gorev> GetirAciliyetileTamamlanmayan();
        List<Gorev> GetirTumTablolarla();
        List<Gorev> GetirTumTablolarla(Expression<Func<Gorev, bool>> filter);
        Gorev GetirAciliyetileId(int id);
        List<Gorev> GetirileAppUserId(int appUserId);
        Gorev GetirRaporlarileId(int id);
        List<Gorev> GetirTumTablolarlaTamamlanmayan(out int toplamSayfa, int userId, int aktifSayfa = 1);
        int GetirGorevSayisiTamamlananileAppUserId(int id);
        int GetirGorevSayisiileTamamlanmayanileAppUserId(int id);
        int GetirAtanmayiBekleyenGorevSayisi();
        int GetirGorevTamamlanmis();
    }
}
