# Apache Parquet for Azure Data Lake [![Build status](https://ci.appveyor.com/api/projects/status/e8inekwpv0femv8b/branch/master?svg=true)](https://ci.appveyor.com/project/aloneguid/parquet-usql/branch/master)

## Azure Data Lake Analytics custom extractor and outputter for parquet

This custom extractor consumes parquet-dotnet to enable reads of parquet files in Azure Data Lake Analytics. 
The extractor supports both the native Apache Parquet format and the type representation using Apache Spark, 
HIVE and Impala so that the outputs are interchangable as there are several discrepencies in representation for annotated types.

## Deployment

The Parquet.Adla project compiles with all dependent assemblies into a single assembly created through ILMerge. The deploy.ps1 Powershell script can be run locally 
to:

-	Merge all dependent assemblies into Parquet.Adla.dll
-	Copy the assembly to your chosen blob storage container
-	Copy and register the assembly to the catalog of your chosen ADLS database 

To install for use with ADLA open a command script at the solution root and enter the following:

	powershell -File .\deploy.ps1 -BlobStorageAccountName xx
		-BlobStorageAccountKey xx
		-BlobStorageContainer xx
		-BlobStoragePath xx
		-AzureDataLakeStoreName xx
		-AzureDataLakeAnalyticsName xx
		-SubscriptionId xx

If the Blob storage parameters are omitted then the script will not deploy to storage and if the ADLS and ADLA names are omitted then the dll will not be deployed to ADLS and regsitered with the catalog.

##Usage
###Outputter
To use the outputter reference Parquet.Adla as follows.

	REFERENCE ASSEMBLY [Parquet.Adla];

	@a  = 
    SELECT * FROM 
        (VALUES
            ("Contoso", 1500.0),
            ("Woodgrove", 2700.0)
        ) AS 
              D( customer, amount );
	OUTPUT @a
		TO "/pqnet/test1.parquet"
		USING new Parquet.Adla.Outputter.ParquetOutputter();

###Extractor

##Limitations