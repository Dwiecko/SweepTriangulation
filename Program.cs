namespace SweepTriangulation
{
    #region Usings

    using System;
    using System.Linq;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    ///     The main execution program.
    /// </summary>
    class Program
    {
        #region Fields

        /// <summary>
        ///     The check that horizontal line X coord is crossing with vertical X coords of start and end points.
        /// </summary>
        private static readonly Func<int, int, int, bool> isCrossingVertically = (hLineX, stX, endX) => stX <= hLineX && endX >= hLineX;

        /// <summary>
        ///     The check that vertical line Y coord is within area limited by horizontal line Y coords of start and end points.
        /// </summary>
        private static readonly Func<int, int, int, bool> isCrossingHorizontally = (hStartY, hEndY, segY) => hStartY >= segY && hEndY <= segY;

        /// <summary>
        ///     The tested set against crossings.
        /// </summary>
        private static List<Point> set = new List<Point>()
            {
                new Point(-2, 1, SegmentType.HORIZONTAL, 1, true),
                new Point(2, 1, SegmentType.HORIZONTAL, 1, false),
                new Point(-2, -1, SegmentType.HORIZONTAL, 2, true),
                new Point(2, -1, SegmentType.HORIZONTAL, 2, false),

                new Point(-1, 2, SegmentType.VERTICAL, 3, true),
                new Point(-1, -2, SegmentType.VERTICAL, 3, false),
                new Point(1, 2, SegmentType.VERTICAL, 4, true),
                new Point(1, -2, SegmentType.VERTICAL, 4, false),
            };

        #endregion

        #region Methods

        /// <summary>
        ///     The main execution method.
        /// </summary>
        static void Main()
        {
            FindCrossingsInSet(ref set);
        }

        /// <summary>
        ///     The main algorithm - compute crossings across set.
        /// </summary>
        /// <param name="set">
        ///     The horizontal and vertical segments,
        /// </param>
        private static void FindCrossingsInSet(ref List<Point> set)
        {
            List<Segment> tree = new List<Segment>();
            var segments = set.OrderBy(segment => segment.X).ToList();

            while (segments.Any())
            {
                var currentPoint = segments.FirstOrDefault();
                segments.Remove(currentPoint);

                if (currentPoint.SegmentType == SegmentType.HORIZONTAL)
                {
                    if (currentPoint.IsStart)
                    {
                        tree.Add(new Segment(currentPoint, set.Last(el => el.SegmentId == currentPoint.SegmentId), currentPoint.SegmentId));
                    }
                    else
                    {
                        var segmentToRemove = tree.First(segment => segment.SegmentId == currentPoint.SegmentId);
                        tree.Remove(segmentToRemove);
                    }
                }
                else
                {
                    var horizontalEndPoint = segments.Last(point => point.SegmentId == currentPoint.SegmentId);
                    segments.Remove(horizontalEndPoint);

                    var crossings = tree.Where(segment => isCrossingVertically(currentPoint.X, segment.Start.X, segment.End.X) && 
                                                          isCrossingHorizontally(currentPoint.Y, horizontalEndPoint.Y, segment.Start.Y));

                    if (crossings != null && crossings.Any())
                    {
                        Console.WriteLine("There is a crossing.\nHorizontal - start: {0} end: {1}", currentPoint, horizontalEndPoint);

                        foreach (var crossing in crossings)
                        {
                            Console.WriteLine("Vertical - start: {0} end: {1}", crossing.Start, crossing.End);
                        }
                    }
                }
            }
        }

        #endregion
    }
}
