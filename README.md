# Quandl.NET
Quandl is a marketplace for financial and economic data. All data on Quandl can be accessed via their REST API. This library, as a .NET wrapper, built on Quandl v3 REST API. It is based on .NET standard 1.4, can be run on .NET Core, .NET Framework, Xamarin.iOS, Xamarin.Android & Universal Windows Platform.

### Features
* Allows access to financial and economic data through Quandl v3 API

### Important Notes [26/05/2017]
Quandl has recently reorganized the api & divided the api call into 2 categories, namely timeseries & tables [Reference](https://docs.quandl.com/docs/data-organization). To align with the new schema, the following changes on this library was made:
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
	var data = await client.Timeseries.GetDataAsync("WIKI", "FB");

##### Get filtered time-series data [Reference](https://docs.quandl.com/docs/in-depth-usage#section-get-filtered-time-series-data)
	var data = await client.Timeseries.GetDataAsync("WIKI", "FB", 
		columnIndex: 4, 
		startDate: new DateTime(2014, 1, 1), 
		endDate: new DateTime(2014, 12, 31), 
		collapse: Model.Enum.Collapse.Monthly, 
		transform: Model.Enum.Transform.Rdiff);

##### Get time-series metadata [Reference](https://docs.quandl.com/docs/in-depth-usage#section-get-time-series-metadata)
	var data = await client.Timeseries.GetMetadataAsync("EOD", "FB");

##### Get time-series data and metadata [Reference](https://docs.quandl.com/docs/in-depth-usage#section-get-time-series-data-and-metadata)
	var data = await client.Timeseries.GetDataAndMetadataAsync("WIKI", "FB",
		columnIndex: 4,
		startDate: new DateTime(2014, 1, 1),
		endDate: new DateTime(2014, 12, 31),
		collapse: Model.Enum.Collapse.Monthly,
		transform: Model.Enum.Transform.Rdiff);

##### Get metadata for a time-series database [Reference](https://docs.quandl.com/docs/in-depth-usage#section-get-metadata-for-a-time-series-database)
	var data = await client.Timeseries.GetDatabaseMetadataAsync("WIKI");

##### Get an entire time-series database [Reference](https://docs.quandl.com/docs/in-depth-usage#section-get-an-entire-time-series-database)
	using (var stream = await client.Timeseries.GetEntireDatabaseAsync("SCF", Model.Enum.DownloadType.Full))
	using (var fs = File.Create("someFileName.zip"))
	{
	    stream.CopyTo(fs);
	}

#### Tables Api

##### Get table with filters [Reference](https://docs.quandl.com/docs/in-depth-usage-1#section-filter-rows-and-columns)
	var rowFilter = "ticker=SPY,IWM,GLD&date>2014-01-07";
	var columnFilter = "ticker,date,shares_outstanding";
	var data = await client.Tables.GetAsync("ETFG/FUND", rowFilter, columnFilter);

##### Get table metadata [Reference](https://docs.quandl.com/docs/in-depth-usage-1#section-get-table-metadata)
	var data = await client.Tables.GetMetadataAsync("AR/MWCS");

##### Download an entire table [Reference](https://docs.quandl.com/docs/in-depth-usage-1#section-download-an-entire-table)
	using (var stream = await client.Tables.DownloadAsync("WIKI/PRICES"))
	using (var fs = File.Create("someFileName.zip"))
	{
		stream.CopyTo(fs);
	}

#### Useful Data And Lists

##### Get List Of Index Constituents And The Corresponding Quandl Code
	// Includes S&P500, Dow Jones, NASDAQ Composite, NASDAQ 100, NYSE Composite, FTSE 100
	var result = await UsefulDataAndLists.GetSP500IndexConstituentsAsync();

##### Get List Of Futures And The Corresponding Quandl Code
	var result = await UsefulDataAndLists.GetFuturesMetadataAsync();

##### Get List Of Commodities And The Corresponding Quandl Code
	var result = await UsefulDataAndLists.GetCommoditiesAsync();

##### Get List Of Currencies, Countries and States
	var result = await UsefulDataAndLists.GetISOCurrencyCodesAsync();
	var result2 = await UsefulDataAndLists.GetISO3LetterCountryCodesAsync();
	var result3 = await UsefulDataAndLists.GetCurrencyCrossRatesAsync();

### Powered by
* [Flurl](https://github.com/tmenier/Flurl) ([@tmenier](https://github.com/tmenier)) - A simple & elegant fluent-style REST api library 

### License
This library is under [MIT License](https://github.com/salmonthinlion/Quandl.NET/blob/master/LICENSE)

### Reference
[Quandl API Reference](https://www.quandl.com/docs/api?csv#introduction)
	
	
