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
                // [{FtpHost:'ftp://127.0.0.3',FtpPort:'21',FtpPath:'/',FtpUserName:'Arsham',FtpPassword:'1'}]
                _repFileServer.AddAsync(new TblFileServer()
                {
                    Id = new Guid().SequentialGuid(),
                    Name = "Public",
                    FtpData = "UU+c1H9R7gmsOZQZ5IpuIdRoPdIqrUqK03h5SiHc9mk7skgie5bdQlb6hfRj0C6UM16ja7e0voUyovKBl79ht7jhPJHukx3JRZVmpCctL2kNI26YVrnJn8O4esS9o7E5ViGo/MjJVEcieQyIbRXGNQ==",
                    Capacity = 0,
                    Description = "",
                    HttpDomin = "http://127.0.0.111",
                    HttpPath = "/",
                    IsActive = true,
                }, default, false).Wait();
            }

            _repFileServer.SaveChangeAsync().Wait();
        }
    }
}
