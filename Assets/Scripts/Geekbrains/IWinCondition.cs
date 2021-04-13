
namespace Geekbrains
{
    public interface IWinCondition
    {
        bool IsRequieredToWin { get; set; }
        void CheckCondition();
    }
}
