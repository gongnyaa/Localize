namespace Localize
{
    using System;
    using System.IO;
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;

    public class LocalizeManager
    {
        private LanguageSetting setting;
        //private EnumLaungageSetting nowSetting;
        private Dictionary<int, string> dic;

        public LocalizeManager (LanguageSetting settingStub)
        {
            this.setting = settingStub;
            dic = LocalizeCSVParser.GetTextDictionary (setting.GetLanguage ());
        }

        public EnumLaungageSetting GetNowSetting ()
        {
            return setting.GetLanguage ();
        }

        public void ChangeSetting (EnumLaungageSetting laungageSetting)
        {
            this.setting.ChangeLanguage (laungageSetting);
            dic = LocalizeCSVParser.GetTextDictionary (setting.GetLanguage ());
        }

        public string GetText (int id)
        {
            return dic[id];
        }
    }
}
