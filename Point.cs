namespace SweepTriangulation
{
    /// <summary>
    ///     The point.
    /// </summary>
    public class Point
    {
        /// <summary>
        ///     The vertical point value.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        ///     The horizontal point value.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        ///     The point segment type.
        /// </summary>
        public SegmentType SegmentType { get; set; }

        /// <summary>
        ///     The segment ID.
        /// </summary>
        public int SegmentId { get; set; }

        /// <summary>
        ///     The flag - is point start point.
        /// </summary>
        public bool IsStart { get; set; }

        /// <summary>
        ///     Initializes a new instance of the point class.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="segType"></param>
        /// <param name="segmentId"></param>
        /// <param name="isStart"></param>
        public Point(int x, int y, SegmentType segType, int segmentId, bool isStart)
        {
            X = x;
            Y = y;
            SegmentType = segType;
            SegmentId = segmentId;
            IsStart = isStart;
        }

        /// <summary>
        ///     The override default to string method to display coords.
        /// </summary>
        /// <returns>
        ///     The overridden to string message.
        /// </returns>
        public override string ToString()
        {
            return $"X:{X} Y:{Y} #Segment_ID={SegmentId}";
        }
    }
}
