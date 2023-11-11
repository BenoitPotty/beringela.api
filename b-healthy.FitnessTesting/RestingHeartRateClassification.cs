namespace b_healthy.Data;

public class RestingHeartRateClassification
{
    public Gender Gender { get; set; }
    public Range Age { get; set; }
    public Range HeartRate { get; set; }
    public string Label { get; set; }
}