using System;

namespace Localize
{
    public class LanguageSettingStub : ILanguageSetting
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

        public void ChangeLanguage (EnumLaungageSetting laungageSetting)
        {
            this.enumLaungageSetting = laungageSetting;
        }
    }
}