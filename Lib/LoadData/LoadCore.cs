using LoadData.LoadLogical;
using LoadData.LoadLogical.XML;

namespace LoadData
{
    public static class LoadCore
    {
        public static ILoad GetLoadXML() => new LoaderXML();
    }
}