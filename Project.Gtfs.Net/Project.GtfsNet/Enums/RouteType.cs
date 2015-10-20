﻿namespace Project.GtfsNet.Enums
{
	public enum RouteType
	{
		AnyLightRailOrStreetLevelSystem = 0,
		Subway = 1,
		Rail = 2,
		Bus = 3,
		Ferry = 4,
		CableCar = 5,
		GondolaOrSuspendedCableCar = 6,
		Fnicular = 7,

		// Rest from https://github.com/OsmSharp/GTFS/blob/226a247861cf90badde49655095193ac829cf227/GTFS/Entities/Enumerations/RouteTypeExtended.cs
		// And also https://support.google.com/transitpartners/answer/3520902?hl=en&ref_topic=1095593&vid=1-635809781607093517-612977364
		RailwayService = 100,
		HighSpeedRailService = 101,
		LongDistanceTrains = 102,
		InterRegionalRailService = 103,
		CarTransportRailService = 104,
		SleeperRailService = 105,
		RegionalRailService = 106,
		TouristRailwayService = 107,
		RailShuttleWithinComplex = 108,
		SuburbanRailway = 109,
		ReplacementRailService = 110,
		SpecialRailService = 111,
		LorryTransportRailService = 112,
		AllRailServices = 113,
		CrossCountryRailService = 114,
		VehicleTransportRailService = 115,
		RackandPinionRailway = 116,
		AdditionalRailService = 117,
		CoachService = 200,
		InternationalCoachService = 201,
		NationalCoachService = 202,
		ShuttleCoachService = 203,
		RegionalCoachService = 204,
		SpecialCoachService = 205,
		SightseeingCoachService = 206,
		TouristCoachService = 207,
		CommuterCoachService = 208,
		AllCoachServices = 209,
		SuburbanRailwayService = 300,
		UrbanRailwayService = 400,
		MetroCoachService = 401,
		UndergroundService = 402,
		UrbanRailwayServiceDefault = 403,
		AllUrbanRailwayServices = 404,
		Monorail = 405,
		MetroService = 500,
		UndergroundMetroService = 600,
		BusService = 700,
		RegionalBusService = 701,
		ExpressBusService = 702,
		StoppingBusService = 703,
		LocalBusService = 704,
		NightBusService = 705,
		PostBusService = 706,
		SpecialNeedsBus = 707,
		MobilityBusService = 708,
		MobilityBusforRegisteredDisabled = 709,
		SightseeingBus = 710,
		ShuttleBus = 711,
		SchoolBus = 712,
		SchoolandPublicServiceBus = 713,
		RailReplacementBusService = 714,
		DemandandResponseBusService = 715,
		AllBusServices = 716,
		TrolleybusService = 800,
		TramService = 900,
		CityTramService = 901,
		LocalTramService = 902,
		RegionalTramService = 903,
		SightseeingTramService = 904,
		ShuttleTramService = 905,
		AllTramServices = 906,
		WaterTransportService = 1000,
		InternationalCarFerryService = 1001,
		NationalCarFerryService = 1002,
		RegionalCarFerryService = 1003,
		LocalCarFerryService = 1004,
		InternationalPassengerFerryService = 1005,
		NationalPassengerFerryService = 1006,
		RegionalPassengerFerryService = 1007,
		LocalPassengerFerryService = 1008,
		PostBoatService = 1009,
		TrainFerryService = 1010,
		RoadLinkFerryService = 1011,
		AirportLinkFerryService = 1012,
		CarHighSpeedFerryService = 1013,
		PassengerHighSpeedFerryService = 1014,
		SightseeingBoatService = 1015,
		SchoolBoat = 1016,
		CableDrawnBoatService = 1017,
		RiverBusService = 1018,
		ScheduledFerryService = 1019,
		ShuttleFerryService = 1020,
		AllWaterTransportServices = 1021,
		AirService = 1100,
		InternationalAirService = 1101,
		DomesticAirService = 1102,
		IntercontinentalAirService = 1103,
		DomesticScheduledAirService = 1104,
		ShuttleAirService = 1105,
		IntercontinentalCharterAirService = 1106,
		InternationalCharterAirService = 1107,
		RoundTripCharterAirService = 1108,
		SightseeingAirService = 1109,
		HelicopterAirService = 1110,
		DomesticCharterAirService = 1111,
		SchengenAreaAirService = 1112,
		AirshipService = 1113,
		AllAirServices = 1114,
		FerryService = 1200,
		TelecabinService = 1300,
		TelecabinServiceDefault = 1301,
		CableCarService = 1302,
		ElevatorService = 1303,
		ChairLiftService = 1304,
		DragLiftService = 1305,
		SmallTelecabinService = 1306,
		AllTelecabinServices = 1307,
		FunicularService = 1400,
		FunicularServiceDefault = 1401,
		AllFunicularService = 1402,
		TaxiService = 1500,
		CommunalTaxiService = 1501,
		WaterTaxiService = 1502,
		RailTaxiService = 1503,
		BikeTaxiService = 1504,
		LicensedTaxiService = 1505,
		PrivateHireServiceVehicle = 1506,
		AllTaxiServices = 1507,
		SelfDrive = 1600,
		HireCar = 1601,
		HireVan = 1602,
		HireMotorbike = 1603,
		HireCycle = 1604,
		MiscellaneousService = 1700,
		CableCar2 = 1701,
		HorsedrawnCarriage = 1702
	}
}