using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.UI;

public class TestTextMeshLocalizeController
{

    [Test]
    public void TestTextMeshLocalizeControllerSimplePasses ()
    {
        GameObject prefab = Resources.Load<GameObject> ("LocalizeTextMeshForTest");

        LocalizeFacade.ChangeSetting (EnumLaungageSetting.JP);
        GameObject inst = GameObject.Instantiate (prefab);
        TextMesh text = inst.GetComponent<TextMesh> ();
        inst.GetComponent<TextMeshLocalizeController> ().ChangeTextName ("ID_1");
        Assert.AreEqual (text.text, "ID 1 JP");

        LocalizeFacade.ChangeSetting (EnumLaungageSetting.EN);
        Assert.AreEqual (text.text, "ID 1 EN");

        inst.GetComponent<TextMeshLocalizeController> ().ChangeTextName ("ID_2");
        Assert.AreEqual (text.text, "ID 2 EN");

        LocalizeFacade.ChangeSetting (EnumLaungageSetting.JP);
        Assert.AreEqual (text.text, "ID 2 JP");
    }
}
