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
        private static HashSet<ILocalizeObserver> observerList = new HashSet<ILocalizeObserver> ();


        public LocalizeManager (LanguageSetting settingStub)
        {
            this.setting = settingStub;
            dic = LocalizeCSVParser.GetTextDictionary (setting.GetLanguage ());
        }

        public EnumLaungageSetting GetNowSetting ()
        {
            return setting.GetLanguage ();
        }

        public static void AddObserver (ILocalizeObserver observer)
        {
            observerList.Add (observer);
        }
        public static void RemoveObserver (ILocalizeObserver observer)
        {
            observerList.Remove (observer);
        }

        public void ChangeSetting (EnumLaungageSetting laungageSetting)
        {
            this.setting.ChangeLanguage (laungageSetting);
            dic = LocalizeCSVParser.GetTextDictionary (setting.GetLanguage ());
            foreach (ILocalizeObserver observer in observerList) {
                observer.OnUpdateLanguageSetting ();
            }
        }

        public string GetText (int id)
        {
            return dic[id];
        }
    }
}
