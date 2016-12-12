namespace ViewCSVFiles.Adapters
{
    public interface IEnvironment
    {
        string FileName { get; set; }
        int PageLength { get; }
    }
}
