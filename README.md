# Quandl.NET (Beta)
Quandl is a marketplace for financial and economic data. All data on Quandl can be accessed via their REST API. This library, as a .NET wrapper, built on Quandl v3 REST API. It is based on .NET standard 1.3, can be run on .NET Core, .NET Framework, Xamarin.iOS, Xamarin.Android & Universal Windows Platform.

### Features
* Allows access to financial and economic data through Quandl v3 API

### Supported Platforms
* .NET Core 1.0
* .NET Framework 4.6 or above
* Xamarin.iOS
* Xamarin.Android
* Universal Windows Platform

### How To Install
You can find the package through Nuget

	PM> Install-Package Quandl.NET

### How To Use

#### Initialize Quandl Client
	var client = new QuandlClient(apiKey);
	
#### Database API Access

##### Get Entire Database (Zip ONLY): [Reference](https://www.quandl.com/docs/api?csv#get-entire-database)

	// Be careful of the size of the zip file if using complete mode
	using (var dbs = await client.Database.GetZipAsync("WIKI"))
	using (var fs = File.Create(/* zipFileName */))
	{
		dbs.CopyTo(fs);
	}
	
##### Get Database Metadata (.NET Object / CSV): [Reference](https://www.quandl.com/docs/api?json#get-database-metadata)
	var result = await client.Database.GetMetadataAsync("WIKI");
	
##### Get Database List (.NET Object / CSV): [Reference](https://www.quandl.com/docs/api?json#search-for-databases)
	var result = await client.Database.GetListAsync();

##### Get Available Dataset List for a Database (Zip ONLY): [Reference](https://www.quandl.com/docs/api?csv#get-list-of-database-contents)
	using (var dss = await client.Database.GetDatasetListZipAsync("YC"))
	using (var fs = File.Create(/* zipFileName */))
	{
		dss.CopyTo(fs);
	}

#### Datatable API Access

##### Get Entire Datatable (.NET Object / CSV): [Reference](https://www.quandl.com/docs/api?json#get-entire-datatable)
	var result = await client.Datatable.GetAsync("INQ", "EE");
	
##### Query for Datatable (.NET Object / CSV): [Reference](https://www.quandl.com/docs/api?json#filter-rows-and-columns)
	var rowFilter = new Dictionary<string, List<string>>();
	rowFilter.Add("isin", new List<string> { "FI0009000681", "DE0007236101" });
	
	var columnFilter = new List<string> { "isin", "company" };
	
	var result = await client.Datatable.GetAsync("INQ", "EE", rowFilter, columnFilter);
	
##### Get Datatable Metadata (.NET Object / CSV)
	var result = await client.Datatable.GetMetadataAsync("INQ", "EE");

#### Dataset API Access

##### Get a Dataset (.NET Object / CSV): [Reference](https://www.quandl.com/docs/api?json#get-data)
	var result = await client.Dataset.GetAsync("WIKI", "FB");
	
##### Get Dataset Metadata (.NET Object / CSV): [Reference](https://www.quandl.com/docs/api?json#get-metadata)
	var result = await client.Dataset.GetMetadataAsync("WIKI", "FB");
	
##### Query For Dataset (.NET Object / CSV): [Reference](https://www.quandl.com/docs/api?json#get-data-and-metadata)
	var result = await client.Dataset.GetDataAndMetadataAsync("WIKI", "FB", columnIndex: 4, startDate: new DateTime(2014, 1, 1), endDate: new DateTime(2014, 12, 31), collapse: Model.Enum.Collapse.Monthly, transform: Model.Enum.Transform.Rdiff);
	
##### Get Dataset by Query (.NET Object / CSV): [Reference](https://www.quandl.com/docs/api?json#dataset-search)
	var query = new List<string> { "crude", "oil" };
	var result = await client.Dataset.GetListAsync(query, "ODA", 1, 1);

### Powered by
* [Refit](https://github.com/paulcbetts/refit) ([@paulcbetts](https://github.com/paulcbetts)) - A robust REST api library 

### License
This library is under [MIT License](https://github.com/salmonthinlion/Quandl.NET/blob/master/LICENSE)

### Reference
[Quandl API Reference](https://www.quandl.com/docs/api?csv#introduction)
	
	
