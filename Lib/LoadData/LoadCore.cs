using LoadData.LoadLogical;
using LoadData.LoadLogical.XML;

namespace LoadData
{
    public static class LoadCore
    {
        private static LoaderXML _loaderXml;
        public static ILoadData GetLoadXML() => _loaderXml ??= new();
    }
}