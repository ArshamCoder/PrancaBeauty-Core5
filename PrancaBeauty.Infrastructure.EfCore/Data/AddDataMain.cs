using System;

namespace PrancaBeauty.Infrastructure.EfCore.Data
{
    public class AddDataMain
    {
        public void Run()
        {
            try
            {
                new AddDataAccessLevel().Run();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
