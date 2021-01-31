using NETCore.Encrypt;
using System;

namespace Framework.Common.ExMethod
{
    public static class StringEx
    {
        /// <summary>
        /// عملیات رمز گذاری
        /// </summary>
        public static string AesEncrypt(this string text, string key)
        {
            if (!string.IsNullOrEmpty(key) || !string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException("لطفا مقدار کلید را وارد نمایید.");

            string encrypt = EncryptProvider.AESEncrypt(text, key);

            return encrypt;


        }

        /// <summary>
        /// عملیات رمز گشایی
        /// </summary>
        public static string AesDecrypt(this string text, string key)
        {
            if (!string.IsNullOrEmpty(key) || !string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException("لطفا مقدار کلید را وارد نمایید.");

            string decrypt = EncryptProvider.AESDecrypt(text, key);

            return decrypt;


        }
    }
}
