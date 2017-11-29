using GtfsNet.Visitors;
using System.IO;

namespace GtfsNet.Parsers
{
	public class GtfsFeedParser
	{
		/// <summary>
		/// Facade for parsing GTFS feed
		/// </summary>
		public GtfsFeed Parse(string feedPath)
        {
            return GetFeed(new GtfsFeedParserVisitor(feedPath));
        }

        /// <summary>
        /// Facade for parsing GTFS feed
        /// </summary>
        public GtfsFeed Parse(Stream stream)
        {
            return GetFeed(new GtfsFeedParserVisitor(stream));
        }

        private GtfsFeed GetFeed(GtfsFeedParserVisitor parser)
        {
            GtfsFeed feed = new GtfsFeed();
            feed.Accept(parser);

            return parser.Feed;
        }
    }
}
