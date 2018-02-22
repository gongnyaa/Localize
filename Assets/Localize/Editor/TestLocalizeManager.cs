namespace Localize
{
    using UnityEngine;
    using UnityEditor;
    using UnityEngine.TestTools;
    using NUnit.Framework;
    using System.Collections;

    public class TestLocalizeManager
    {
        private static LanguageSettingStub defaultJPStub = new LanguageSettingStub (EnumLaungageSetting.JP);
        private static LanguageSettingStub defaultENStub = new LanguageSettingStub (EnumLaungageSetting.EN);


        [Test]
        public void TestDefSetting ()
        {

            LocalizeManager localizeFacade = new LocalizeManager (defaultJPStub);
            Assert.AreEqual (EnumLaungageSetting.JP, localizeFacade.GetNowSetting ());

            LocalizeManager localizeFacade2 = new LocalizeManager (defaultENStub);
            Assert.AreEqual (EnumLaungageSetting.EN, localizeFacade2.GetNowSetting ());


        }
        [Test]
        public void TestChangeSetting ()
        {
            LocalizeManager localizeFacade = new LocalizeManager (defaultJPStub);
            localizeFacade.ChangeSetting (EnumLaungageSetting.EN);
            Assert.AreEqual (EnumLaungageSetting.EN, localizeFacade.GetNowSetting ());
            localizeFacade.ChangeSetting (EnumLaungageSetting.JP);
            Assert.AreEqual (EnumLaungageSetting.JP, localizeFacade.GetNowSetting ());
        }

        //// A UnityTest behaves like a coroutine in PlayMode
        //// and allows you to yield null to skip a frame in EditMode
        [Test]
        public void TestGetText ()
        {
            LocalizeManager localizeFacade = new LocalizeManager (defaultJPStub);
            Assert.AreEqual (localizeFacade.GetText ((int) EnumLocalizeName.ID_1), "ID 1 JP");
            Assert.AreEqual (localizeFacade.GetText ((int) EnumLocalizeName.ID_2), "ID 2 JP");
            localizeFacade.ChangeSetting (EnumLaungageSetting.EN);
            Assert.AreEqual (localizeFacade.GetText ((int) EnumLocalizeName.ID_1), "ID 1 EN");
            Assert.AreEqual (localizeFacade.GetText ((int) EnumLocalizeName.ID_2), "ID 2 EN");

        }
    }
}