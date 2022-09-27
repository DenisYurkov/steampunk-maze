using System.Collections;

namespace Steampunk.Code.Logic
{
    public interface IUIHelperView
    {
        IEnumerator ShowUI(float timeToHide, float animationSpeed);
    }
}