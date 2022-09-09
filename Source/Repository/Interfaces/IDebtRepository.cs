using SMWebApi.Models;

namespace SMWebApi.Repository.Interfaces
{
    public interface IDebtRepository
    {
        bool CreateDebt(Debt model);

        bool PayDebt(Debt model);

        Debt GetDebt(long id);

        ICollection<Debt> GetAllDepts();
        ICollection<Debt> GetDeptsByFlatId(long flatId);

    }
}
