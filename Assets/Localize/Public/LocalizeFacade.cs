using System;
using System.IO;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Localize;

public class LocalizeFacade
{
    private static LocalizeManager localizeManager;

    public static string GetText (EnumLocalizeName id)
    {
        if (localizeManager == null) {
            localizeManager = new LocalizeManager (new LanguageSetting ());
        }
        return localizeManager.GetText ((int) id);
    }
    public static void ChangeSetting (EnumLaungageSetting settingLanguage)
    {
        if (localizeManager == null) {
            localizeManager = new LocalizeManager (new LanguageSetting ());
        }
        localizeManager.ChangeSetting (settingLanguage);
    }
}
