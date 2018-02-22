namespace Localize
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEditor;
    using System.IO;
    using System.Text;
    using System;

    public class EnumLocalizeNameGenerator
    {

        [MenuItem ("Assets/Generate EnumLocalizeName")]
        public static void Test ()
        {
            StringBuilder fileContent = new StringBuilder ();
            fileContent.Append ("public enum EnumLocalizeName");
            fileContent.AppendLine ("");
            fileContent.Append ("{");

            TextAsset csvFile = Resources.Load ("Localize") as TextAsset; /* Resouces/CSV下のCSV読み込み */
            StringReader reader = new StringReader (csvFile.text);
            Dictionary<int, string> dic = LocalizeCSVParser.GetNameDictionary ();

            foreach (int id in dic.Keys) {
                fileContent.AppendLine ();
                string name = dic[id];
                fileContent.Append (string.Format ("    {0} = {1},", name, id));
            }

            fileContent.AppendLine ();
            fileContent.Append ("}");
            System.IO.File.WriteAllText (Application.dataPath + "/Localize/Public/EnumLocalizeName.cs", fileContent.ToString ());


            AssetDatabase.Refresh ();
        }
    }
}
