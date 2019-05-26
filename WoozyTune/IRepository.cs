
namespace WoozyTune
{
    interface IRepository
    {
        int FindUser(string login, string password);
        int CreateUser(string login, string password, int age, string gender, string username);
        string GetUsername();
        void UploadTrack(int playlistId, string artist, string title, string path, string imagePath, string genre);
    }
}
