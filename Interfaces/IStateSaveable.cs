public interface IStateSaveable
{
    string saveFilePath { get; set; }
    void SaveState();
    void ReloadState();
}