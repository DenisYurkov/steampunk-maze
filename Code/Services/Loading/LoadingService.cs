using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Steampunk.Code.Services
{
    public class LoadingService : MonoBehaviour, ILoadingService
    {
        [SerializeField] private GameObject _screen;

        private IEnumerator LoadSingleAsync(int sceneName)
        {
            _screen.SetActive(true);
            var first = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
            
            yield return first.isDone;
            _screen.SetActive(false);
        }
        
        private IEnumerator LoadAdditiveAsync(int sceneName)
        {
            _screen.SetActive(true);
            SceneManager.UnloadSceneAsync(sceneName, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
            
            var first = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            yield return first.isDone;

            _screen.SetActive(false);
        }

        private IEnumerator LoadMultipleAsync(int firstScene, int secondScene)
        {
            _screen.SetActive(true);
            
            var first = SceneManager.LoadSceneAsync(firstScene, LoadSceneMode.Single);
            var second = SceneManager.LoadSceneAsync(secondScene, LoadSceneMode.Additive);

            yield return new WaitUntil(() => second.isDone);
            _screen.SetActive(false);
        }
        
        public void LoadSingle(int sceneName) =>
            StartCoroutine(LoadSingleAsync(sceneName));
        public void LoadAdditive(int sceneName) =>
            StartCoroutine(LoadAdditiveAsync(sceneName));
        public void LoadMultiple(int firstScene, int secondScene) =>
            StartCoroutine(LoadMultipleAsync(firstScene, secondScene));
    }
}