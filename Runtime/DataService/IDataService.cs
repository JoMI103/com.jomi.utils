public interface IDataService
{
    bool SaveData<T>(string RelativePath, T Data, bool Encrypted = false);

    T LoadData<T>(string RelativePath, bool Encrypted = false);
}
