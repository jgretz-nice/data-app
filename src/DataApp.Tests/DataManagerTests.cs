namespace DataApp.Tests;

public class DataManager_Consolidation
{
    [Fact(DisplayName = "Invalid Data ID Request")]
    public void ConsolidateDataFromSources_InvalidDataIdRequest_Fails()
    {
        // Prepares Data Manager object for testing
        DataManager dataManager = new();

        // Expect result to be InvalidDataID (-1) since we're inputting an invalid data ID
        var result = dataManager.ConsolidateDataFromSources(-1);
        Assert.Equal((int)DataManagerResult.InvalidDataID, result);
    }

    [Fact(DisplayName = "Empty Data Request")]
    public void ConsolidateDataFromSources_EmptyDataId_Fails()
    {
        // Prepares Data Manager object for testing
        DataManager dataManager = new();

        // Expect result to be EmptyDataID (-2) since we're inputting a valid data ID that 
        // corresponds to an empty data source
        var result = dataManager.ConsolidateDataFromSources(1);
        Assert.Equal((int)DataManagerResult.EmptyDataID, result);
    }

    [Fact(DisplayName = "Valid Data Request")]
    public void ConsolidateDataFromSources_Success()
    {
        // Prepares Data Manager object for testing
        DataManager dataManager = new();

        // Expect result to be Success (0) since we're inputting a valid, non-empty data ID
        var result = dataManager.ConsolidateDataFromSources(2);
        Assert.Equal((int)DataManagerResult.Success, result);
    }
}
