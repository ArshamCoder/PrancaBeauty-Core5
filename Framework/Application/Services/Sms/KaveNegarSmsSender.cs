using Framework.Infrastructure;
using Kavenegar;
using Kavenegar.Models;
using System;

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


        public bool SendOtp(string phoneNumber, string templateName, string[] tokens)
        {
            if (phoneNumber == null)
                throw new ArgumentNullException("PhoneNumber cant be null");

            if (templateName == null)
                throw new ArgumentNullException("TemplateName cant be null");

            if (tokens == null)
                throw new ArgumentNullException("Tokens cant be null");

            KavenegarApi Api = new KavenegarApi(_apiKey);
            SendResult Result = null;




            return true;
        }
    }
}
