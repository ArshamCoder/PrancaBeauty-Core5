namespace PrancaBeauty.Application.Contracts.Result
{
    public class OperationResult
    {
        public OperationResult()
        {
            IsSucceed = false;
        }
        public bool IsSucceed { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }

        public OperationResult Succeed(string message)
        {
            IsSucceed = true;
            Message = message;
            return this;

        }

        public OperationResult Succeed(int code, string message)
        {
            IsSucceed = true;
            Message = message;
            Code = code;
            return this;

        }
        public OperationResult Failed(string message)
        {
            IsSucceed = false;
            Message = message;
            return this;

        }
        public OperationResult Failed(int code, string message)
        {
            IsSucceed = false;
            Message = message;
            Code = code;
            return this;

        }
    }
}
