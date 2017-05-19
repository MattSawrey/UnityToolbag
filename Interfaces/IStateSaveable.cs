public interface IStateSaveable<T>
{
    void SaveState(string filePath);
    T GetState(string filePath);
}