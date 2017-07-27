using Microsoft.Analytics.Interfaces;
using Parquet.Adla;
using Parquet.Adla.Outputter;

/*
 * This file contains a syntax to create exposed primitives somewhat simpler
 */

public static class ApacheParquet
{
    /// <summary>
    /// Creates Apache Parquet outputter
    /// </summary>
    /// <returns></returns>
    public static IOutputter Outputter()
    {
        return new ParquetOutputter();
    }
}
