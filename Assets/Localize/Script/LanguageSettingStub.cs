using System;

namespace Localize
{
    public class LanguageSettingStub : LanguageSetting
    {
        private EnumLaungageSetting enumLaungageSetting;

        public LanguageSettingStub (EnumLaungageSetting laungageSetting)
        {
            this.enumLaungageSetting = laungageSetting;
        }

        public EnumLaungageSetting GetLanguage ()
        {
            return enumLaungageSetting;
        }

        internal void ChangeLanguage (EnumLaungageSetting laungageSetting)
        {
            this.enumLaungageSetting = laungageSetting;
        }
    }
}