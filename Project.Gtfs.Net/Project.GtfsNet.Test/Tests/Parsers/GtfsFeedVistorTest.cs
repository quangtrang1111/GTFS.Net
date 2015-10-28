﻿using System.IO;
using System.Linq;
using Project.GtfsNet.Entities;
using Project.GtfsNet.Parsers;
using Xunit;
using Xunit.Abstractions;

namespace Project.GtfsNet.Test.Tests.Parsers
{
	public class GtfsFeedVistorTest
	{
		private readonly ITestOutputHelper _output;
		private readonly GtfsFeedVisitor _sut;
		private const string FEED_PATH = "feeds/subway";

		public GtfsFeedVistorTest(ITestOutputHelper output)
		{
			_output = output;
			_sut = new GtfsFeedVisitor(FEED_PATH);
		}

		[Fact]
		public void ParserDoesntReturnEmptyGtfsFeedProperties()
		{
			GtfsFeed feed = new GtfsFeed();
			feed.Accept(_sut);

			Assert.NotNull(feed.Agencies);
			Assert.NotNull(feed.Calendars);
			Assert.NotNull(feed.CalendarDates);
			Assert.NotNull(feed.FareAttributes);
			Assert.NotNull(feed.FareRules);
			Assert.NotNull(feed.FeedInfos);
			Assert.NotNull(feed.Frequencies);
			Assert.NotNull(feed.Routes);
			Assert.NotNull(feed.Shapes);
			Assert.NotNull(feed.Stops);
			Assert.NotNull(feed.StopTimes);
			Assert.NotNull(feed.Transfers);
			Assert.NotNull(feed.Trips);
		}

		[Fact]
		public void ParserReturnParsedGtfsFeedWithAtLeastOneRecordInEachProperty()
		{
			GtfsFeed feed = new GtfsFeed();
			feed.Accept(_sut);

			_output.WriteLine("_sut.Feed.Count: {0}", _sut.Feed.Agencies.Count);
			Assert.NotEmpty(_sut.Feed.Agencies);

			_output.WriteLine("_sut.Feed.Count: {0}", _sut.Feed.Calendars.Count);
			Assert.NotEmpty(_sut.Feed.Calendars);

			_output.WriteLine("_sut.Feed.CalendarDates.Count: {0}", _sut.Feed.CalendarDates.Count);
			Assert.NotEmpty(_sut.Feed.CalendarDates);

			_output.WriteLine("_sut.Feed.FareAttributes.Count: {0}", _sut.Feed.FareAttributes.Count);
			Assert.NotEmpty(_sut.Feed.FareAttributes);

			_output.WriteLine("_sut.Feed.FareRules.Count: {0}", _sut.Feed.FareRules.Count);
			Assert.NotEmpty(_sut.Feed.FareRules);

			_output.WriteLine("_sut.Feed.FeedInfos.Count: {0}", _sut.Feed.FeedInfos.Count);
			Assert.NotEmpty(_sut.Feed.FeedInfos);

			_output.WriteLine("_sut.Feed.Frequencies.Count: {0}", _sut.Feed.Frequencies.Count);
			Assert.NotEmpty(_sut.Feed.Frequencies);

			_output.WriteLine("_sut.Feed.Routes.Count: {0}", _sut.Feed.Routes.Count);
			Assert.NotEmpty(_sut.Feed.Routes);

			_output.WriteLine("_sut.Feed.Shapes.Count: {0}", _sut.Feed.Shapes.Count);
			Assert.NotEmpty(_sut.Feed.Shapes);

			_output.WriteLine("_sut.Feed.Stops.Count: {0}", _sut.Feed.Stops.Count);
			Assert.NotEmpty(_sut.Feed.Stops);

			_output.WriteLine("_sut.Feed.StopTimes.Count: {0}", _sut.Feed.StopTimes.Count);
			Assert.NotEmpty(_sut.Feed.StopTimes);

			_output.WriteLine("_sut.Feed.Transfers.Count: {0}", _sut.Feed.Transfers.Count);
			Assert.NotEmpty(_sut.Feed.Transfers);

			_output.WriteLine("_sut.Feed.Trips.Count: {0}", _sut.Feed.Trips.Count);
			Assert.NotEmpty(_sut.Feed.Trips);
		}
	}

	public class GtfsFeedVisitor : IFeedVisitor
	{
		private readonly string _feedPath;
		public GtfsFeed Feed { get; }

		public GtfsFeedVisitor(string feedPath)
		{
			_feedPath = feedPath;
			Feed = new GtfsFeed();
		}

		//private void SetParsedList<T>(string feedPath, out parsedList)
		//{
		//	using (var textReader = GetTextReader<T>(feedPath))
		//	{
		//		var entityParser = new EntityParserFactory().Create(
		//			EntityParserFactory.SupportedFileNames.GetFileNameByType<T>());
		//		return new HashSet<T>(entityParser.Parse(textReader).Cast<T>());
		//	}
		//}

		public void Visit(AgencyCollection agencies)
		{
			using (var textReader = GetTextReader<Agency>(_feedPath))
			{
				Feed.Agencies = new AgencyCollection(GetEntityParser<Agency>().Parse(textReader).Cast<Agency>());
			}
		}

		public void Visit(StopCollection stops)
		{
			using (var textReader = GetTextReader<Stop>(_feedPath))
			{
				Feed.Stops = new StopCollection(GetEntityParser<Stop>().Parse(textReader).Cast<Stop>());
			}
		}

		public void Visit(RouteCollection routes)
		{
			using (var textReader = GetTextReader<Route>(_feedPath))
			{
				Feed.Routes = new RouteCollection(GetEntityParser<Route>().Parse(textReader).Cast<Route>());
			}
		}

		public void Visit(TripCollection trips)
		{
			using (var textReader = GetTextReader<Trip>(_feedPath))
			{
				Feed.Trips = new TripCollection(GetEntityParser<Trip>().Parse(textReader).Cast<Trip>());
			}
		}

		public void Visit(StopTimeCollection stopTimes)
		{
			using (var textReader = GetTextReader<StopTime>(_feedPath))
			{
				Feed.StopTimes = new StopTimeCollection(GetEntityParser<StopTime>().Parse(textReader).Cast<StopTime>());
			}
		}

		public void Visit(CalendarCollection calendars)
		{
			using (var textReader = GetTextReader<Calendar>(_feedPath))
			{
				Feed.Calendars = new CalendarCollection(GetEntityParser<Calendar>().Parse(textReader).Cast<Calendar>());
			}
		}

		public void Visit(CalendarDateCollection calendarDates)
		{
			using (var textReader = GetTextReader<CalendarDate>(_feedPath))
			{
				Feed.CalendarDates = new CalendarDateCollection(GetEntityParser<CalendarDate>().Parse(textReader).Cast<CalendarDate>());
			}
		}

		public void Visit(FareAttributeCollection fareAttributes)
		{
			using (var textReader = GetTextReader<FareAttribute>(_feedPath))
			{
				Feed.FareAttributes = new FareAttributeCollection(GetEntityParser<FareAttribute>().Parse(textReader).Cast<FareAttribute>());
			}
		}

		public void Visit(FareRuleCollection fareRules)
		{
			using (var textReader = GetTextReader<FareRule>(_feedPath))
			{
				Feed.FareRules = new FareRuleCollection(GetEntityParser<FareRule>().Parse(textReader).Cast<FareRule>());
			}
		}

		public void Visit(ShapeCollection shapes)
		{
			using (var textReader = GetTextReader<Shape>(_feedPath))
			{
				Feed.Shapes = new ShapeCollection(GetEntityParser<Shape>().Parse(textReader).Cast<Shape>());
			}
		}

		public void Visit(FrequencyCollection frequencies)
		{
			using (var textReader = GetTextReader<Frequency>(_feedPath))
			{
				Feed.Frequencies = new FrequencyCollection(GetEntityParser<Frequency>().Parse(textReader).Cast<Frequency>());
			}
		}

		public void Visit(TransferCollection transfers)
		{
			using (var textReader = GetTextReader<Transfer>(_feedPath))
			{
				Feed.Transfers = new TransferCollection(GetEntityParser<Transfer>().Parse(textReader).Cast<Transfer>());
			}
		}

		public void Visit(FeedInfoCollection feedInfos)
		{
			using (var textReader = GetTextReader<FeedInfo>(_feedPath))
			{
				Feed.FeedInfos = new FeedInfoCollection(GetEntityParser<FeedInfo>().Parse(textReader).Cast<FeedInfo>());
			}

		}

		private TextReader GetTextReader<T>(string feedPath)
		{
			string fileName = EntityParserFactory.SupportedFileNames.GetFileNameByType<T>();
			var testFilePath = Path.Combine(feedPath, fileName);
			return File.OpenText(testFilePath);
		}

		public IEntityParser<IEntity> GetEntityParser<T>()
		{
			return new EntityParserFactory().Create(
				EntityParserFactory.SupportedFileNames.GetFileNameByType<T>());
		}
	}
}