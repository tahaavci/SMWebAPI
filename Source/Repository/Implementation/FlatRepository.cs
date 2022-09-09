using SMWebApi.Context;
using SMWebApi.Models;
using SMWebApi.Repository.Interfaces;

namespace SMWebApi.Repository.Implementation
{
    public class FlatRepository : IFlatRepository
    {
        private readonly DataContext _dataContext;


        public FlatRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool CreateFLat(Flat flat)
        {

            _dataContext.Add(flat);

            if (_dataContext.SaveChanges() > 0)
                return true;



            return false;
        }

        public Flat GetFlatById(long flatId)
        {
            var flat = _dataContext.Flats.Where(f => f.flat_id == flatId).FirstOrDefault();

            return flat;
        }

        public ICollection<Flat> GetFlats()
        {
            return _dataContext.Flats.OrderBy(f => f.flat_number).ToList();
        }
    }
}
