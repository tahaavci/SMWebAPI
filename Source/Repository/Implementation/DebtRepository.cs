using SMWebApi.Context;
using SMWebApi.Models;
using SMWebApi.Repository.Interfaces;

namespace SMWebApi.Repository.Implementation
{
    public class DebtRepository : IDebtRepository
    {

        private readonly DataContext _dataContext;

        private readonly IFlatRepository flatRepository;

        public DebtRepository(DataContext dataContext, IFlatRepository flatRepository)
        {
            _dataContext = dataContext;
            this.flatRepository = flatRepository;
        }

        public bool CreateDebt(Debt model)
        {

            _dataContext.Add(model);

            if (_dataContext.SaveChanges() > 0)
                return true;


            return false;
        }

        public ICollection<Debt> GetAllDepts()
        {
            return _dataContext.Debts.OrderBy(d => d.debt_duedate).ToList();
        }

        public Debt GetDebt(long id)
        {
            return _dataContext.Debts.Where(d => d.debt_id == id).FirstOrDefault();
        }

        public ICollection<Debt> GetDeptsByFlatId(long flatId)
        {
            var flat = flatRepository.GetFlatById(flatId);

            if (flat == null)
                return null;


            return _dataContext.Debts.Where(d => d.debtFlatId == flat).ToList();
        }

        public bool PayDebt(Debt model)
        {

            _dataContext.Debts.Update(model);
            if (_dataContext.SaveChanges() > 0)
                return true;


            return false;
        }
    }
}
