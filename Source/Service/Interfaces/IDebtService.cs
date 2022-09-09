using SMWebApi.Dto;

namespace SMWebApi.Service.Interfaces
{
    public interface IDebtService
    {

        bool CreateDept(DeptDto deptDto);

        bool PayDebt(long dept_id);



    }
}
