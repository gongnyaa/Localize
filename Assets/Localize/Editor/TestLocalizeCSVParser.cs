using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using Localize;

public class TestLocalizeCSVParser
{

    [Test]
    public void TestLocalizeCSVParserSimplePasses ()
    {
        Dictionary<int, string> resultJp = LocalizeCSVParser.GetTextDictionary (EnumLaungageSetting.JP);

        Assert.AreEqual (resultJp[(int) EnumLocalizeName.ID_1], "ID 1 JP");
        Assert.AreEqual (resultJp[(int) EnumLocalizeName.ID_2], "ID 2 JP");

        Dictionary<int, string> resultEn = LocalizeCSVParser.GetTextDictionary (EnumLaungageSetting.EN);

        Assert.AreEqual (resultEn[(int) EnumLocalizeName.ID_1], "ID 1 EN");
        Assert.AreEqual (resultEn[(int) EnumLocalizeName.ID_2], "ID 2 EN");
    }

}
