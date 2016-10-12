namespace WordCount
{
    public class ResultOfCounts
    {
        public ResultOfCounts(int count, int unique)
        {
            Count = count;
            UniqueCount = unique;
        }
        public int Count { get; }
        public int UniqueCount { get; }
    }
}