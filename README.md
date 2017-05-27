# Quandl.NET
Quandl is a marketplace for financial and economic data. All data on Quandl can be accessed via their REST API. This library, as a .NET wrapper, built on Quandl v3 REST API. It is based on .NET standard 1.4, can be run on .NET Core, .NET Framework, Xamarin.iOS, Xamarin.Android & Universal Windows Platform.

### Features
* Allows access to financial and economic data through Quandl v3 API

### Release Notes
[27/05/2017] 
* All enums have been moved to Quandl.NET namespace from Quandl.NET.Model.Enum namespace, inputting "Model.Enum." prefix is no longer needed.
* UsefulDataAndLists has been renamed as Quandl for easier access.
* Bug fix on invalid conversion for GetFuturesMetadataAsync() method.

[26/05/2017] Quandl has recently reorganized the api & divided the api call into 2 categories, namely timeseries & tables [Reference](https://docs.quandl.com/docs/data-organization). To align with the new schema, the following changes on this library was made:
* DatabaseApi, DatatableApi, DatasetApi under "QuandlClient" has been marked obsoleted and will be removed in the future
* Timeseries, Tables have been added under "QuandlClient" as a replacement of the original DatabaseApi, DatatableApi & DatasetApi
You can easily migrate your code following the message given by intellisense, some of the api call such as GetListAsync() will not be supported as there is no equivalent api written in the Quandl's api doc.

### Supported Platforms
* .NET Core 1.0
* .NET Framework 4.6.1 or above
* Xamarin.iOS
* Xamarin.Android
* Universal Windows Platform

### How To Install
You can find the package through Nuget

	PM> Install-Package Quandl.NET

### How To Use

#### Add using reference
	using Quandl.NET;

#### Initialize Quandl Client
	var client = new QuandlClient(apiKey);
	
#### Time-series Api

##### Get time-series data [Reference](https://docs.quandl.com/docs/in-depth-usage#section-get-time-series-data)
	// The call
	var data = await client.Timeseries.GetDataAsync("WIKI", "FB");

	// Output: "Date; Open; High; Low; Close; Volume; Ex-Dividend; Split Ratio; Adj. Open; Adj. High; Adj. Low; Adj. Close; Adj. Volume"
	Console.WriteLine(string.Join("; ", result.DatasetData.ColumnNames));

	// Output: "2017-05-26; 152.23; 152.25; 151.15; 152.13; 14907827; 0; 1; 152.23; 152.25; 151.15; 152.13; 14907827"
	Console.WriteLine(string.Join("; ", result.DatasetData.Data.First()));

##### Get filtered time-series data [Reference](https://docs.quandl.com/docs/in-depth-usage#section-get-filtered-time-series-data)
	// The call
	var result = await client.Timeseries.GetDataAsync("WIKI", "FB", 
													columnIndex: 4, 
													startDate: new DateTime(2014, 1, 1), 
													endDate: new DateTime(2014, 12, 31), 
													collapse: Collapse.Monthly, 
													transform: Transform.Rdiff);

	// Output should be similar to Get time-series data api

##### Get time-series metadata [Reference](https://docs.quandl.com/docs/in-depth-usage#section-get-time-series-metadata)
	// The call
	var result = await client.Timeseries.GetMetadataAsync("WIKI", "FB");

	// Output: "DatabaseCode: WIKI; DatasetCode: FB; Name: Facebook Inc. (FB) Prices, Dividends, Splits and Trading Volume; Premium: False"
	Console.WriteLine($"DatabaseCode: {result.Dataset.DatabaseCode}; DatasetCode: {result.Dataset.DatasetCode}; Name: {result.Dataset.Name}; Premium: {result.Dataset.Premium}");

##### Get time-series data and metadata [Reference](https://docs.quandl.com/docs/in-depth-usage#section-get-time-series-data-and-metadata)
	// The call
	var result = await client.Timeseries.GetDataAndMetadataAsync("WIKI", "FB",
											columnIndex: 4,
											startDate: new DateTime(2014, 1, 1),
											endDate: new DateTime(2014, 12, 31),
											collapse: Collapse.Monthly,
											transform: Transform.Rdiff);

	// Output should be similar to Get time-series data api

##### Get metadata for a time-series database [Reference](https://docs.quandl.com/docs/in-depth-usage#section-get-metadata-for-a-time-series-database)
	// The call
	var result = await client.Timeseries.GetDatabaseMetadataAsync("WIKI");

	// Output: "Name: Wiki EOD Stock Prices; Premium: False; DatasetsCount: 3187"
	Console.WriteLine($"Name: {result.Database.Name}; Premium: {result.Database.Premium}; DatasetsCount: {result.Database.DatasetsCount}");

##### Get an entire time-series database [Reference](https://docs.quandl.com/docs/in-depth-usage#section-get-an-entire-time-series-database)
	// The call returns a zip stream with csv inside, you should use the csv after the zip is decompressed
	using (var stream = await client.Timeseries.GetEntireDatabaseAsync("SCF", Model.Enum.DownloadType.Full))
	using (var fs = File.Create("someFileName.zip"))
	{
	    stream.CopyTo(fs);
	}

##### Download raw data instead of .NET objects
	// The call returns a stream based on the returnFormat (i.e. json stream if returnFormat = ReturnFormat.Json, xml stream if returnFormat = ReturnFormat.Xml, csv stream if returnFormat = ReturnFormat.Csv)
	// Let use Get time-series data api as an example
	using (var csvStream = await client.Timeseries.GetDataAsync("WIKI", "FB", ReturnFormat.Csv))
	using (var fs = File.Create("someFileName.csv"))
	{
		csvStream.CopyTo(fs);
	}

#### Tables Api

##### Get table with filters [Reference](https://docs.quandl.com/docs/in-depth-usage-1#section-filter-rows-and-columns)
	// Create row filter & column filter for the call, use ampersand(&) to separate each criteria for row Filter
	var rowFilter = "ticker=SPY,IWM,GLD&date>2014-01-07";
	var columnFilter = "ticker,date,shares_outstanding";

	// The call
	var result = await client.Tables.GetAsync("ETFG/FUND", rowFilter, columnFilter);

	// Output: "ticker; date; shares_outstanding"
	Console.WriteLine(string.Join("; ", result.Datatable.Columns.Select(c => c.Name)));

	// Output: "GLD; 2014-01-02; 264800000"
	Console.WriteLine(string.Join("; ", result.Datatable.Data.First()));

##### Get table metadata [Reference](https://docs.quandl.com/docs/in-depth-usage-1#section-get-table-metadata)
	// The call
	var result = await client.Tables.GetMetadataAsync("AR/MWCS");

	// Output: "Name: MarketWorks Futures Settlement CME; Filters: code, date; Premium: True"
	Console.WriteLine($"Name: {result.Datatable.Name}; Filters: {string.Join(", ", result.Datatable.Filters)}; Premium: {result.Datatable.Premium}");

##### Download an entire table [Reference](https://docs.quandl.com/docs/in-depth-usage-1#section-download-an-entire-table)
	// The call returns a zip stream with csv inside, you should use the csv after the zip is decompressed
	using (var stream = await client.Tables.DownloadAsync("WIKI/PRICES"))
	using (var fs = File.Create("someFileName.zip"))
	{
		stream.CopyTo(fs);
	}

#### Useful Data And Lists for Quandl

##### Get List Of Index Constituents And The Corresponding Quandl Code
	// The call returns a list of S&P500 index constituents.
	// There are also calls for other indexes, including Dow Jones, NASDAQ Composite, NASDAQ 100, NYSE Composite, FTSE 100
	var result = await Quandl.GetSP500IndexConstituentsAsync();

	// Output: "MMM; ABT; ABBV; ACN; ACE; ATVI; ADBE; ADT; AAP; AES"
	Console.WriteLine(string.Join("; ", result.Take(10).Select((c => c.Ticker))));

##### Get List Of Futures And The Corresponding Quandl Code
	// The call
	var result = await Quandl.GetFuturesMetadataAsync();

	// Output: "0D; 6T; 6Z; 7Q; 8I; 8Z; AD; AD; AFR; AG"
	Console.WriteLine(string.Join("; ", result.Take(10).Select(md => md.Symbol)));

##### Get List Of Commodities And The Corresponding Quandl Code
	// The call
	var result = await Quandl.GetCommoditiesAsync();

	// Output: "Name: Milk, Non-Fat Dry, Chicago, Sector: Farms and Fisheries; Name: CME Milk Futures, Sector: Farms and Fisheries; Name: Cheddar Cheese, Barrels, Chicago, Sector: Farms and Fisheries"
	Console.WriteLine(string.Join("; ", result.Select(r => $"Name: {r.Name}, Sector: {r.Sector}").Take(10)));

##### Get List Of Currencies, Countries and States
	// The call
	var result = await Quandl.GetISOCurrencyCodesAsync();

	// Output: "Code: AFN, Country: AFGHANISTAN, Currency: Afghani; Code: ALL, Country: ALBANIA, Currency: Lek; Code: DZD, Country: ALGERIA, Currency: Algerian Dinar"
	Console.WriteLine(string.Join("; ", result.Select(c => $"Code: {c.AlphabeticCode}, Country: {c.Country}, Currency: {c.Currency}").Take(3)));

### Powered by
* [Flurl](https://github.com/tmenier/Flurl) ([@tmenier](https://github.com/tmenier)) - A simple & elegant fluent-style REST api library 

### License
This library is under [MIT License](https://github.com/salmonthinlion/Quandl.NET/blob/master/LICENSE)

### Reference
[Quandl API Reference](https://www.quandl.com/docs/api?csv#introduction)
	
	
