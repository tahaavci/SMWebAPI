using SMWebApi.Models;

namespace SMWebApi.Repository.Interfaces
{
    public interface IFlatRepository
    {
        bool CreateFLat(Flat flat);
        ICollection<Flat> GetFlats();
        Flat GetFlatById(long flatId);


    }
}
