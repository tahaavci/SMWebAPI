using System.Reflection;

namespace SMWebApi.Dto
{
    public static class DtoTypeConversion
    {

        public static TDst TypeConversion<TSrc, TDst>(TSrc model) where TDst : class, new()
        {

            TDst destination = new TDst();

            typeof(TSrc).GetProperties().ToList().ForEach(p =>
            {
                PropertyInfo property = typeof(TDst).GetProperty(p.Name);

                property.SetValue(destination,p.GetValue(model));


            });
            



            return destination;
        }






    }
}
