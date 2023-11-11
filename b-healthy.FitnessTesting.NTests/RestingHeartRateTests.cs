using b_healthy.Data;

namespace b_healthy.FitnessTesting.NTests;

public class RestingHeartRateTests
{
    private RestingHeartRate _restingHeartRate = null!;
    
    [SetUp]
    public void Setup()
    {
        _restingHeartRate = new RestingHeartRate();
    }

    [Test]
    public void GivenAMaleValue_WhenCompute_ThenCorrectClassificationIsReturned()
    {
        var classification = _restingHeartRate.Compute(Gender.Male, 40, 65);
        Assert.That(classification, Is.EqualTo("Bon"));
    }    
    
    [Test]
    public void GivenAFemaleValue_WhenCompute_ThenCorrectClassificationIsReturned()
    {
        var classification = _restingHeartRate.Compute(Gender.Female, 40, 64);
        Assert.That(classification, Is.EqualTo("Excellent"));
    }
    
    [Test]
    public void GivenAMaleLowValue_WhenCompute_ThenCorrectClassificationIsReturned()
    {
        var classification = _restingHeartRate.Compute(Gender.Male, 40, 12);
        Assert.That(classification, Is.EqualTo(string.Empty));
    }    
    
    [Test]
    public void GivenAFemaleLowValue_WhenCompute_ThenCorrectClassificationIsReturned()
    {
        var classification = _restingHeartRate.Compute(Gender.Female, 40, 12);
        Assert.That(classification, Is.EqualTo(string.Empty));
    }
    
    [Test]
    public void GivenAMaleHighValue_WhenCompute_ThenCorrectClassificationIsReturned()
    {
        var classification = _restingHeartRate.Compute(Gender.Male, 40, 99);
        Assert.That(classification, Is.EqualTo("Faible"));
    }    
    
    [Test]
    public void GivenAFemaleHighValue_WhenCompute_ThenCorrectClassificationIsReturned()
    {
        var classification = _restingHeartRate.Compute(Gender.Female, 40, 99);
        Assert.That(classification, Is.EqualTo("Faible"));
    }
    
    [Test]
    public void GivenAnOldMaleValue_WhenCompute_ThenCorrectClassificationIsReturned()
    {
        var classification = _restingHeartRate.Compute(Gender.Male, 70, 60);
        Assert.That(classification, Is.EqualTo("Excellent"));
    }    
    
    [Test]
    public void GivenAnOldFemaleValue_WhenCompute_ThenCorrectClassificationIsReturned()
    {
        var classification = _restingHeartRate.Compute(Gender.Female, 70, 60);
        Assert.That(classification, Is.EqualTo("Excellent"));
    }
}