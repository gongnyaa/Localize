using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using Localize;

public class TestLocalizeFacede
{

    [Test]
    public void TestGetText ()
    {
        LocalizeFacade.ChangeSetting (EnumLaungageSetting.JP);
        Assert.AreEqual (LocalizeFacade.GetText (EnumLocalizeName.ID_1), "ID 1 JP"); ;
        Assert.AreEqual (LocalizeFacade.GetText (EnumLocalizeName.ID_2), "ID 2 JP"); ;
        LocalizeFacade.ChangeSetting (EnumLaungageSetting.EN);
        Assert.AreEqual (LocalizeFacade.GetText (EnumLocalizeName.ID_1), "ID 1 EN"); ;
        Assert.AreEqual (LocalizeFacade.GetText (EnumLocalizeName.ID_2), "ID 2 EN"); ;
    }


}
