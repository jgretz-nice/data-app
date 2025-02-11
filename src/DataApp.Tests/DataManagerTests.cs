namespace DataApp.Tests;

public class DataManager_Consolidation
{
    private readonly DataManager _dataManager;

    public DataManager_Consolidation()
    {
        // Initialize a new DataManager for each test
        // See https://xunit.net/docs/shared-context for more information
        _dataManager = new();
    }

    [Fact(DisplayName = "Invalid Data ID Request")]
    public async void ConsolidateDataFromSources_InvalidDataId()
    {
        // Expect result to be InvalidDataID (-1) since we're inputting an invalid data ID
        Assert.Equal(
            (int)DataManagerResult.InvalidDataID,
            await _dataManager.ConsolidateDataFromSourcesAsync(-1)
        );
    }

    [Fact(DisplayName = "Empty Data Request")]
    public async void ConsolidateDataFromSources_EmptyDataId()
    {
        // Expect result to be EmptyDataID (-2) since we're inputting a valid data ID that 
        // corresponds to an empty data source
        Assert.Equal(
            (int)DataManagerResult.EmptyDataID,
            await _dataManager.ConsolidateDataFromSourcesAsync(1)
        );
    }

    [Fact(DisplayName = "Valid Data Request")]
    public async void ConsolidateDataFromSources_Success()
    {
        // Expect result to be Success (0) since we're inputting a valid, non-empty data ID
        Assert.Equal(
            (int)DataManagerResult.Success,
            await _dataManager.ConsolidateDataFromSourcesAsync(2)
        );
    }
}
