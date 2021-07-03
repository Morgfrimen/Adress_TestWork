namespace LoadData.LoadLogical
{
    public interface ILoadData
    {
        public ST LoadFile<ST, T>(string path)
            where T : class, new()
            where ST : class, new();

        public void SetIgnoreProperty(params string[] ignoreProperty);
    }
}