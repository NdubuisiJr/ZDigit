namespace NdubuisiJr.Z_Digit.Data.IO.TextInputRules
{
    public interface IReadLineRule {
        bool IsMatched(string line);
        void GetChartValue(string line);
    }
}
