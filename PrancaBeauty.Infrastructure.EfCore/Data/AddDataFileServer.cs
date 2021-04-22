using Framework.Common.ExMethod;
using Framework.Infrastructure;
using PrancaBeauty.Domain.FileServer.ServerAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Context;
using System;
using System.Linq;

namespace PrancaBeauty.Infrastructure.EfCore.Data
{
    public class AddDataFileServer
    {
        readonly BaseRepository<TblFileServer> _repFileServer;
        public AddDataFileServer()
        {
            _repFileServer = new BaseRepository<TblFileServer>(new MainContext());
        }

        public void Run()
        {
            if (!_repFileServer.Get.Any(a => a.Name == "Public"))
            {
                _repFileServer.AddAsync(new TblFileServer()
                {
                    Id = new Guid().SequentialGuid(),
                    Name = "Public",
                    FtpData = "",
                    Capacity = 0,
                    Description = "",
                    HttpDomin = "http://127.0.0.111",
                    HttpPath = "/Main",
                    IsActive = true,
                }, default, false).Wait();
            }

            _repFileServer.SaveChangeAsync().Wait();
        }
    }
}
