namespace Steampunk.Code.Logic
{
    public interface IHealthModel
    {
        void Decrease(int decreaseValue);
        void ResetToDefault();
        bool IsDie();
        int GetValue { get; }
        bool EqualsZero();
    }
}