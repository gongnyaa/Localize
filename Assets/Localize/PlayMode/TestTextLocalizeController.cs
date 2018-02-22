using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.UI;

public class TestTextLocalizeController
{

    [Test]
    public void TestTextLocalizeControllerSimplePasses ()
    {
        GameObject prefab = Resources.Load<GameObject> ("LocalizeTextForTest");

        LocalizeFacade.ChangeSetting (EnumLaungageSetting.JP);
        GameObject inst = GameObject.Instantiate (prefab);
        Text text = inst.GetComponent<Text> ();
        Assert.AreEqual (text.text, "ID 1 JP");

        LocalizeFacade.ChangeSetting (EnumLaungageSetting.EN);
        Assert.AreEqual (text.text, "ID 1 EN");

        inst.GetComponent<TextLocalizeController> ().ChangeTextName ("ID_2");
        Assert.AreEqual (text.text, "ID 2 EN");

        LocalizeFacade.ChangeSetting (EnumLaungageSetting.JP);
        Assert.AreEqual (text.text, "ID 2 JP");
    }
}
