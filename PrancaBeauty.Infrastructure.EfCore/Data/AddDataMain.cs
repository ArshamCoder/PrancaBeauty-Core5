using System;

namespace PrancaBeauty.Infrastructure.EfCore.Data
{
    public class AddDataMain
    {
        public void Run()
        {
            try
            {
                new AddDataFileServer().Run();
                new AddDataRole().Run();
                new AddDataAccessLevel().Run();
                new AddDataUser().Run();
                new AddDataLanguage().Run();
                new AddDataSetting().Run();
                new AddDataTemplate().Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
