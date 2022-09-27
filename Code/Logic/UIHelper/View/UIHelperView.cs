using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Steampunk.Code.Logic
{
    public class UIHelperView : MonoBehaviour, IUIHelperView
    {
        [SerializeField] private List<TextMeshProUGUI> _texts;
        [SerializeField] private GameObject _screen;

        private void Awake() => 
            DontDestroyOnLoad(this);

        public IEnumerator ShowUI(float timeToHide, float animationSpeed)
        {
            _screen.SetActive(true);
            yield return new WaitForSeconds(timeToHide);
            yield return FadeOutTexts(animationSpeed);
        }
        
        private IEnumerator FadeOutTexts(float timeSpeed)
        {
            Sequence sequence = DOTween.Sequence().SetAutoKill(true);
            foreach (var text in _texts) 
                sequence.Join(text.DOFade(0, timeSpeed));

            sequence.OnKill(UndoFade);
            yield return null;
        }

        private void UndoFade()
        {
            foreach (var text in _texts) 
                text.color = new Color(text.color.r, text.color.g, text.color.b, 1);

            _screen.SetActive(false);
        }
    }
}