using System.Collections.Generic;

namespace SaveData.SaveLogical
{
	public interface ISaveData
	{
		public void SaveDataXml<ST, T>(IList<T> dataList, string path,
									   params string[] ignoreProperty)
			where T : class, new()
			where ST : class, new();
	}
}