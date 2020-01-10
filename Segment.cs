namespace SweepTriangulation
{
    /// <summary>
    ///     The segment.
    /// </summary>
    public class Segment
    {
        #region Properties

        /// <summary>
        ///     The segment unique ID.
        /// </summary>
        public int SegmentId { get; set; }

        /// <summary>
        ///     The segment type.
        /// </summary>
        public SegmentType SegmentType { get; set; }

        /// <summary>
        ///     The segment start point.
        /// </summary>
        public Point Start { get; set; }

        /// <summary>
        ///     The segment end point.
        /// </summary>
        public Point End { get; set; }

        #endregion

        #region Methods

        /// <summary>
        ///     Initializes a new class instance.
        ///     Segment is limited by end points: start and end.
        /// </summary>
        /// <param name="start">
        ///     The segment start point.
        /// </param>
        /// <param name="end">
        ///     The segment end point.
        /// </param>
        /// <param name="segmentId">
        ///     The unique segment ID.
        /// </param>
        public Segment(Point start, Point end, int segmentId)
        {
            Start = start;
            End = end;
            SegmentId = segmentId;
        }

        #endregion
    }
}
