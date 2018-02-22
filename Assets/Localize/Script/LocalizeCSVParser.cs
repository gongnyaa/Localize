using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Localize
{
    public class LocalizeCSVParser
    {
        public const int CSV_INDEX_ID = 0;
        public const int CSV_INDEX_NAME = 1;
        public const int CSV_INDEX_JP = 2;
        public const int CSV_INDEX_EN = 3;

        public static Dictionary<int, string> GetTextDictionary (EnumLaungageSetting languagesetting)
        {
            int textIndex = 0;
            switch (languagesetting) {
                case EnumLaungageSetting.EN:
                    textIndex = CSV_INDEX_EN;
                    break;
                case EnumLaungageSetting.JP:
                    textIndex = CSV_INDEX_JP;
                    break;
            }
            return Parse (CSV_INDEX_ID, textIndex);
        }

        public static Dictionary<int, string> GetNameDictionary ()
        {
            return Parse (CSV_INDEX_ID, CSV_INDEX_NAME);
        }

        private static Dictionary<int, string> Parse (int keyIndex, int valueIndex)
        {
            Dictionary<int, string> dic = new Dictionary<int, string> ();
            TextAsset csvFile = Resources.Load ("Localize") as TextAsset;
            StringReader reader = new StringReader (csvFile.text);
            reader.ReadLine ();
            while (reader.Peek () > -1) {
                string line = reader.ReadLine ();
                string[] lineStr = line.Split (',');
                dic.Add (int.Parse (lineStr[keyIndex]), lineStr[valueIndex]);
            }
            return dic;
        }

    }
}