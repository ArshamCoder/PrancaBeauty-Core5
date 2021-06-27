using System;

namespace PrancaBeauty.Application.Contracts.Address
{
    public class OutGetAddressByUserIdForManage
    {
        public string Id { get; set; }
        public string Address { get; set; }
        public int CountBills { get; set; }
        public DateTime Date { get; set; }
    }
}
