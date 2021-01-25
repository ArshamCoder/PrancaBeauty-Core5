﻿namespace PrancaBeauty.WebApp.Localization
{
    public interface ILocalizer
    {
        public string this[string name] { get; }
        public string this[string name, params object[] arguments] { get; }

    }
}
