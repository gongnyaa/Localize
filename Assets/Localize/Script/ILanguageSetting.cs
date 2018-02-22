using System;

namespace Localize
{
    public interface ILanguageSetting
    {
        EnumLaungageSetting GetLanguage ();
        void ChangeLanguage (EnumLaungageSetting laungageSetting);
    }
}