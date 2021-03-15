using Framework.Infrastructure;
using Kavenegar;
using Kavenegar.Models;
using System;
using System.Linq;

namespace Framework.Application.Services.Sms
{
    public class KaveNegarSmsSender : ISmsSender
    {
        private ILogger _logger;
        private readonly string _apiKey;
        private readonly string _sender;

        public KaveNegarSmsSender(ILogger logger)
        {
            _logger = logger;
            _apiKey = "";
            _sender = "";
        }

        public bool Send(string phoneNumber, string message)
        {
            throw new System.NotImplementedException();
        }




        private bool SendOtp(string phoneNumber, string templateName, string[] tokens)
        {
            try
            {
                if (phoneNumber == null)
                    throw new ArgumentNullException("PhoneNumber cant be null");

                if (templateName == null)
                    throw new ArgumentNullException("TemplateName cant be null");

                if (tokens == null)
                    throw new ArgumentNullException("Tokens cant be null");

                KavenegarApi Api = new KavenegarApi(_apiKey);
                SendResult Result = null;

                if (tokens.Length == 0)
                {
                    throw new ArgumentNullException("Tokens cant be null");
                }
                else if (tokens.Length == 1)
                {
                    Result = Api.VerifyLookup(phoneNumber, tokens[0], templateName);
                }
                else if (tokens.Length == 2)
                {
                    tokens.Append("");
                    Result = Api.VerifyLookup(phoneNumber, tokens[0], tokens[1], tokens[2], templateName);
                }
                else if (tokens.Length == 3)
                {
                    Result = Api.VerifyLookup(phoneNumber, tokens[0], tokens[1], tokens[2], templateName);
                }

                var IsSent = CheckStatus(Result);

                return IsSent;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return false;
            }
        }

        private bool CheckStatus(SendResult Result)
        {
            try
            {
                if (Result.Status == 5)
                {
                    return true;
                }
                else
                {
                    if (Result.Status == 401)
                    {
                        throw new Exception("حساب کاربری غیرفعال شده است");
                    }
                    else if (Result.Status == 402)
                    {
                        throw new Exception("عملیات ناموفق بود");
                    }
                    else if (Result.Status == 403)
                    {
                        throw new Exception("کد شناسائی API-Key معتبر نمی‌باشد");
                    }
                    else if (Result.Status == 406)
                    {
                        throw new Exception("پارامترهای اجباری خالی ارسال شده اند");
                    }
                    else if (Result.Status == 407)
                    {
                        throw new Exception("دسترسی به اطلاعات مورد نظر برای شما امکان پذیر نیست. برای استفاده از متدهای Select، SelectOutbox و LatestOutBox و یا ارسال با خط بین المللی نیاز به تنظیم IP در بخش تنظیمات امنیتی می باشد");
                    }
                    else if (Result.Status == 409)
                    {
                        throw new Exception("سرور قادر به پاسخگوئی نیست بعدا تلاش کنید");
                    }
                    else if (Result.Status == 411)
                    {
                        throw new Exception($"دریافت کننده نامعتبر است, [{Result.Receptor}]");
                    }
                    else if (Result.Status == 412)
                    {
                        throw new Exception($"ارسال کننده نامعتبر است, [{_sender}]");
                    }
                    else if (Result.Status == 414)
                    {
                        throw new Exception("حجم درخواست بیشتر از حد مجاز است ،ارسال پیامک :هر فراخوانی حداکثر 200 رکوردو کنترل وضعیت :هر فراخوانی 500 رکورد");
                    }
                    else if (Result.Status == 415)
                    {
                        throw new Exception("اندیس شروع بزرگ تر از کل تعداد شماره های مورد نظر است");
                    }
                    else if (Result.Status == 416)
                    {
                        throw new Exception("IP سرویس مبدا با تنظیمات مطابقت ندارد");
                    }
                    else if (Result.Status == 417)
                    {
                        throw new Exception("تاریخ ارسال اشتباه است و فرمت آن صحیح نمی باشد.");
                    }
                    else if (Result.Status == 418)
                    {
                        throw new Exception("اعتبار شما کافی نمی‌باشد");
                    }
                    else if (Result.Status == 420)
                    {
                        throw new Exception("استفاده از لینک در متن پیام برای شما محدود شده است");
                    }
                    else if (Result.Status == 422)
                    {
                        throw new Exception("داده ها به دلیل وجود کاراکتر نامناسب قابل پردازش نیست");
                    }
                    else if (Result.Status == 424)
                    {
                        throw new Exception("الگوی مورد نظر پیدا نشد");
                    }
                    else if (Result.Status == 426)
                    {
                        throw new Exception("استفاده از این متد نیازمند سرویس پیشرفته می‌باشد");
                    }
                    else if (Result.Status == 427)
                    {
                        throw new Exception("استفاده از این خط نیازمند ایجاد سطح دسترسی می باشد");
                    }
                    else if (Result.Status == 428)
                    {
                        throw new Exception("ارسال کد از طریق تماس تلفنی امکان پذیر نیست");
                    }
                    else if (Result.Status == 429)
                    {
                        throw new Exception("IP محدود شده است");
                    }
                    else if (Result.Status == 432)
                    {
                        throw new Exception("پارامتر کد در متن پیام پیدا نشد");
                    }
                    else if (Result.Status == 451)
                    {
                        throw new Exception("فراخوانی بیش از حد در بازه زمانی مشخص IP محدود شده");
                    }
                    else if (Result.Status == 501)
                    {
                        throw new Exception("فقط امکان ارسال پیام تست به شماره صاحب حساب کاربری وجود دارد");
                    }
                    else
                    {
                        throw new Exception("Unknown error");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return false;
            }
        }

        public bool SendLoginCode(string phoneNumber, string code)
        {
            return SendOtp(phoneNumber, "pr-SendLoginCode", new string[] { code });
        }
    }
}
