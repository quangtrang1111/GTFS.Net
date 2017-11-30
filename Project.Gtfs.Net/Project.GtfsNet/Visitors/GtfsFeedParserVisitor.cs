using System;
using System.IO;
using System.Linq;
using GtfsNet.Collections;
using GtfsNet.Entities;
using GtfsNet.Parsers;
using System.IO.Compression;

namespace GtfsNet.Visitors
{
	public class GtfsFeedParserVisitor : IFeedVisitor
	{
		private readonly string _feedPath;
        private readonly ZipArchive _zipData;

        public GtfsFeed Feed { get; }

		public GtfsFeedParserVisitor(string feedPath)
		{
			_feedPath = feedPath;
			Feed = new GtfsFeed();
        }

        public GtfsFeedParserVisitor(Stream dataStream)
        {
            _zipData = new ZipArchive(dataStream);
            Feed = new GtfsFeed();
        }

        public void Visit(AgencyCollection agencies)
		{
			using (var textReader = GetTextReader<Agency>())
			{
				Feed.Agencies = new AgencyCollection(GetEntityParser<Agency>().Parse(textReader).Cast<Agency>());
			}
		}

		public void Visit(StopCollection stops)
		{
			using (var textReader = GetTextReader<Stop>())
			{
				Feed.Stops = new StopCollection(GetEntityParser<Stop>().Parse(textReader).Cast<Stop>());
			}
		}

		public void Visit(RouteCollection routes)
		{
			using (var textReader = GetTextReader<Route>())
			{
				Feed.Routes = new RouteCollection(GetEntityParser<Route>().Parse(textReader).Cast<Route>());
			}
		}

		public void Visit(TripCollection trips)
		{
			using (var textReader = GetTextReader<Trip>())
			{
				Feed.Trips = new TripCollection(GetEntityParser<Trip>().Parse(textReader).Cast<Trip>());
			}
		}

		public void Visit(StopTimeCollection stopTimes)
		{
			using (var textReader = GetTextReader<StopTime>())
			{
				Feed.StopTimes = new StopTimeCollection(GetEntityParser<StopTime>().Parse(textReader).Cast<StopTime>());
			}
		}

		public void Visit(CalendarCollection calendars)
		{
			using (var textReader = GetTextReader<Calendar>())
			{
				Feed.Calendars = new CalendarCollection(GetEntityParser<Calendar>().Parse(textReader).Cast<Calendar>());
			}
		}

		public void Visit(CalendarDateCollection calendarDates)
		{
			using (var textReader = GetTextReader<CalendarDate>())
			{
				Feed.CalendarDates = new CalendarDateCollection(GetEntityParser<CalendarDate>().Parse(textReader).Cast<CalendarDate>());
			}
		}

		public void Visit(FareAttributeCollection fareAttributes)
		{
			using (var textReader = GetTextReader<FareAttribute>())
			{
				Feed.FareAttributes = new FareAttributeCollection(GetEntityParser<FareAttribute>().Parse(textReader).Cast<FareAttribute>());
			}
		}

		public void Visit(FareRuleCollection fareRules)
		{
			using (var textReader = GetTextReader<FareRule>())
			{
				Feed.FareRules = new FareRuleCollection(GetEntityParser<FareRule>().Parse(textReader).Cast<FareRule>());
			}
		}

		public void Visit(ShapeCollection shapes)
		{
			using (var textReader = GetTextReader<Shape>())
			{
				Feed.Shapes = new ShapeCollection(GetEntityParser<Shape>().Parse(textReader).Cast<Shape>());
			}
		}

		public void Visit(FrequencyCollection frequencies)
		{
			using (var textReader = GetTextReader<Frequency>())
			{
				Feed.Frequencies = new FrequencyCollection(GetEntityParser<Frequency>().Parse(textReader).Cast<Frequency>());
			}
		}

		public void Visit(TransferCollection transfers)
		{
			using (var textReader = GetTextReader<Transfer>())
			{
				Feed.Transfers = new TransferCollection(GetEntityParser<Transfer>().Parse(textReader).Cast<Transfer>());
			}
		}

		public void Visit(FeedInfoCollection feedInfos)
		{
			using (var textReader = GetTextReader<FeedInfo>())
			{
				Feed.FeedInfos = new FeedInfoCollection(GetEntityParser<FeedInfo>().Parse(textReader).Cast<FeedInfo>());
			}
		}

		private TextReader GetTextReader<T>()
        {
            string fileName = SupportedFileNames.GetFileNameByType<T>();

            if (_zipData == null)
            {
                var testFilePath = Path.Combine(_feedPath, fileName);
                if (!File.Exists(testFilePath))
                    return new StringReader(String.Empty);
                return File.OpenText(testFilePath);
            }
            
            var zipFile = _zipData.Entries.FirstOrDefault(f => f.Name == fileName);
            if (zipFile == null)
            {
                return new StringReader(String.Empty);
            }

            return new StreamReader(zipFile.Open());
		}

		private IEntityParser<IEntity> GetEntityParser<T>()
		{
			return new EntityParserFactory().Create(
				SupportedFileNames.GetFileNameByType<T>());
		}
	}
}