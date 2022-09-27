using UnityEngine;
using UnityEngine.SceneManagement;

namespace Steampunk.Code.Extensions
{
    public static class Constants
    {
        public static readonly LayerMask BlockLayer = 1 << 7;
        public static readonly LayerMask CellLayer = 1 << 6;
        
        public static int CurrentScene => SceneManager.GetActiveScene().buildIndex;
        public static int NextLevel => SceneManager.GetActiveScene().buildIndex + 1;
        public static int CorrectIndex => CurrentScene != LastLevelIndex ? NextLevel : FirstLevelIndex;

        private static readonly int FirstLevelIndex = 0;
        private static readonly int LastLevelIndex = 2;
    }
}