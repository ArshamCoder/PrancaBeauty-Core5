using PrancaBeauty.WebApp.Localization;

namespace PrancaBeauty.WebApp.Common.Utilities.MessageBox
{
    public class MsgBox : IMsgBox
    {
        private readonly ILocalizer _localizer;
        public MsgBox(ILocalizer localizer)
        {
            _localizer = localizer;
        }
        private string Show(string title, string message, MsgBoxType type, string okBtnText = "OK", string callBackFunction = null)
        {

            callBackFunction ??= "return '';";
            string js = $@"swal.fire({{
                                        title: '{title.Replace("'", "`")}',
                                        html: '{message.Replace("'", "`")}',
                                        icon: '{type.ToString()}',
        `                               confirmButtonText: '{okBtnText}'
                                     }}).then((result)=> {{
                                                            if(result.isConfirmed){{
                                                                {callBackFunction}
                                                            }}
                                                         }});";

            return js;
        }

        public string ModelStateMsg(string modelErrors, string callBackFuncs = null)
        {
            return Show("", modelErrors, MsgBoxType.error, _localizer["OK"], callBackFuncs);
        }
    }

    public enum MsgBoxType
    {
        success,
        error,
        warning,
        info,
        //question
    }

}
