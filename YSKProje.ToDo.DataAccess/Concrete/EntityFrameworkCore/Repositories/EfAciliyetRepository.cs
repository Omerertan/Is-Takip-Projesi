using YSKProje.ToDo.DataAccess.Interfaces;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAciliyetRepository : EfGenericRepository<Aciliyet>, IAciliyetDal
    {
    }
}
