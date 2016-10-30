# Quandl.NET (Beta)
A .NET wrapper built on Quandl.NET REST API, based on .NET standard 1.1, can be run on .NET Core, .NET Framework, Xamarin.iOS, Xamarin.Android & Universal Windows Platform.

### Features
* Allows access to financial and economic data through Quandl API

### Supported Platforms
* .NET Core 1.0
* .NET framework 4.5 or above
* Xamarin.iOS
* Xamarin.Android
* Universal Windows Platform

<!--### How To Install
You can find the package through Nuget

	PM> Install-Package GoogleCloudPrintApi-->

### How To Use

#### Initialize Quandl Client
	var client = new QuandlClient(apiKey);
	
#### Database API Access

##### Save entire database as zip file to target location
	// Be careful to the download size of the zip file, may take a while to complete
	using (var ds = await client.Database.GetStreamAsync(databaseCode))
	using (var fs = File.Create(zipFileName))
	{
		ds.CopyTo(fs);
	}
	
##### Save dataset list as zip file to target location
	using (var ds = await client.Database.GetDatasetListStreamAsync(databaseCode))
	using (var fs = File.Create(zipFileName))
	{
		ds.CopyTo(fs);
	}
	
##### Get database list
Under construction

##### Get database metadata
Unde construction

#### Datatable API Access
Under construction

#### Dataset API Access
Under construction

### Powered by
* [Refit](https://github.com/paulcbetts/refit) ([@paulcbetts](https://github.com/paulcbetts)) - A robust REST api library 

### License
This library is under [MIT License](https://github.com/salmonthinlion/Quandl.NET/blob/master/LICENSE)

### Reference
[Quandl API Reference](https://www.quandl.com/docs/api?csv#introduction)
	
	
