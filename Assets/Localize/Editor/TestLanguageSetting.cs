using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System;
using Localize;

public class TestLanguageSetting
{

    [Test]
    public void TestDefault ()
    {
        PlayerPrefs.SetInt (LanguageSetting.PREFS_KEY, LanguageSetting.NO_SETTING_LANGUAGE);

        LanguageSetting languageSetting = new LanguageSetting ();
        SystemLanguage systemLanguage = Application.systemLanguage;
        if (systemLanguage == SystemLanguage.Japanese) {
            Assert.AreEqual (EnumLaungageSetting.JP, languageSetting.GetLanguage ());
        } else {
            Assert.AreEqual (EnumLaungageSetting.EN, languageSetting.GetLanguage ());
        }
    }

    [Test]
    public void TestChange ()
    {
        LanguageSetting languageSetting = new LanguageSetting ();
        SystemLanguage systemLanguage = Application.systemLanguage;

        languageSetting.ChangeLanguage (EnumLaungageSetting.EN);
        Assert.AreEqual (EnumLaungageSetting.EN, languageSetting.GetLanguage ());
        languageSetting.ChangeLanguage (EnumLaungageSetting.JP);
        Assert.AreEqual (EnumLaungageSetting.JP, languageSetting.GetLanguage ());
    }
}
