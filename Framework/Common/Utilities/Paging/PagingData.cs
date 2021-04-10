using System;

namespace Framework.Common.Utilities.Paging
{
    public class PagingData
    {
        public static OutPagingData Calc(long countAllItem, int page, int take)
        {
            try
            {
                int _Skip = 0;

                page = page <= 0 ? 1 : page;

                // زمانی که هیچ دیتایی به جهت نمایش وجود ندارد
                if (countAllItem == 0)
                {
                    return new OutPagingData
                    {
                        CountAllItem = 0,
                        CountAllPage = 1,
                        Page = 1,
                        Take = take,
                        Skip = 0
                    };
                }

                // محاسبه تعداد صفحات
                int _CountAllPage = (int)(Math.Ceiling((decimal)countAllItem / take));

                if (countAllItem < take)
                    take = (int)countAllItem;

                if (page > _CountAllPage)
                    page = _CountAllPage;

                // _Skip محاسبه 
                _Skip = (int)((take * page) - take);
                if (_Skip < 0)
                    _Skip = 0;

                return new OutPagingData()
                {
                    CountAllItem = countAllItem,
                    CountAllPage = _CountAllPage,
                    Page = page,
                    Skip = _Skip,
                    Take = take
                };
            }
            catch
            {
                return new OutPagingData
                {
                    CountAllItem = 0,
                    CountAllPage = 1,
                    Page = 1,
                    Take = take,
                    Skip = 0
                };
            }
        }
    }
}
