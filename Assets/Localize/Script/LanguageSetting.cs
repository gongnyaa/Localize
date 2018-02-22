using System;
using UnityEngine;

namespace Localize
{
    /// <summary>
    /// note to save language setting, the class is using PlayerPrefs key is LocalizeSetting
    /// 1 is JP
    /// 2 is EN
    /// </summary>
    public class LanguageSetting : ILanguageSetting
    {
        private EnumLaungageSetting enumLaungageSetting;
        public const string PREFS_KEY = "LocalizeSetting";
        public const int NO_SETTING_LANGUAGE = 0;

        public LanguageSetting ()
        {
            int settingLanguageInt = PlayerPrefs.GetInt (PREFS_KEY, NO_SETTING_LANGUAGE);

            if (settingLanguageInt == NO_SETTING_LANGUAGE) {
                SystemLanguage systemLanguage = Application.systemLanguage;
                if (systemLanguage == SystemLanguage.Japanese) {
                    enumLaungageSetting = EnumLaungageSetting.JP;
                } else {
                    enumLaungageSetting = EnumLaungageSetting.EN;
                }
            } else {
                enumLaungageSetting = (EnumLaungageSetting) settingLanguageInt;
            }
        }

        public EnumLaungageSetting GetLanguage ()
        {
            return enumLaungageSetting;
        }

        public void ChangeLanguage (EnumLaungageSetting laungageSetting)
        {
            this.enumLaungageSetting = laungageSetting;
            PlayerPrefs.SetInt (PREFS_KEY, (int) laungageSetting);
        }
    }
}