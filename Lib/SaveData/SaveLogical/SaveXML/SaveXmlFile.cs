using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace SaveData.SaveLogical.SaveXML
{
	internal sealed class SaveXmlFile : ISaveData
	{
		#region Implemented

		#region Implementation of ISaveData

		/// <inheritdoc />
		public void SaveDataXml<ST, T>(IList<T> dataList, string path,
									   params string[] ignoreProperty)
			where T : class, new()
			where ST : class, new()
		{
			XmlAttributeOverrides overrides = new();
			XmlAttributes attributes = new();
			attributes.XmlIgnore = true;
			foreach (string s in ignoreProperty) overrides.Add(typeof(T), s, attributes);
			XmlSerializer xmlSerializer = new(typeof(ST), overrides);
			using (FileStream fileStream = new(path, FileMode.OpenOrCreate))
				xmlSerializer.Serialize(fileStream, dataList);
		}

		#endregion

		#endregion
	}
}