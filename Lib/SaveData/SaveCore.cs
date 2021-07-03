using System;

using SaveData.SaveLogical;
using SaveData.SaveLogical.SaveXML;

namespace SaveData
{
	public static class SaveCore
    {
        public static ISaveData GetSaveDataXml() => new SaveXmlFile();
    }
}
