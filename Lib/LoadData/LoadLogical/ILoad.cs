using System.Collections.Generic;

namespace LoadData.LoadLogical
{
    public interface ILoad
    {
        public IList<T> LoadFile<T>(string path)
            where T : class, new();
    }
}