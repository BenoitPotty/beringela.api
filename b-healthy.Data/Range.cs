namespace b_healthy.Data;

public class Range
{
    public int LowerBound { get; set; }
    public int UpperBound { get; set; }

    public bool IsInBound(int value)
    {
        return LowerBound <= value && value <= UpperBound;
    }
}