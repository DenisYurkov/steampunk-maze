namespace Steampunk.Code.Services
{
    public interface ILoadingService
    {
        void LoadSingle(int sceneName);
        void LoadAdditive(int sceneName);
        void LoadMultiple(int firstScene, int secondScene);
    }
}