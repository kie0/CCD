namespace KataLoc
{
    public class LocResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public LocResult(int totalLines, int linesOfCode)
        {
            TotalLines = totalLines;
            LinesOfCode = linesOfCode;
        }

        public int TotalLines { get; }
        public int LinesOfCode { get; }
    }
}