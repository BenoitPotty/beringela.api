using b_healthy.Data;
using Range = b_healthy.Data.Range;

namespace b_healthy.FitnessTesting;

public class RestingHeartRate
{
    private const string Athlete = "Athlète";
    private const string Excellent = "Excellent";
    private const string Good = "Bon";
    private const string AboveAverage = "Au dessus de la moyenne";
    private const string Average = "Moyen";
    private const string BelowAverage = "En dessous de la moyenne";
    private const string Weak = "Faible";

    private Range _ageGroup1 = new() { LowerBound = 18, UpperBound = 25 }; 
    private Range _ageGroup2 = new() { LowerBound = 26, UpperBound = 35 }; 
    private Range _ageGroup3 = new() { LowerBound = 36, UpperBound = 45 }; 
    private Range _ageGroup4 = new() { LowerBound = 46, UpperBound = 55 }; 
    private Range _ageGroup5 = new() { LowerBound = 56, UpperBound = 65 }; 
    private Range _ageGroup6 = new() { LowerBound = 66, UpperBound = 120 }; 
    
    private readonly List<RestingHeartRateClassification> _classifications = new();

    private void addRange(Gender gender, Range ageGroup, string classification, int lower, int upper)
    {
        _classifications.Add(new RestingHeartRateClassification
        {
            Gender = gender, 
            Age = ageGroup, 
            HeartRate = new Range()
            {
                LowerBound = lower,
                UpperBound = upper
            },
            Label = classification
            
        });
    }

    public RestingHeartRate()
    {
        addRange(Gender.Male, _ageGroup1, Athlete, 49, 55);
        addRange(Gender.Male, _ageGroup2, Athlete, 49, 54);
        addRange(Gender.Male, _ageGroup3, Athlete, 50, 56);
        addRange(Gender.Male, _ageGroup4, Athlete, 50, 57);
        addRange(Gender.Male, _ageGroup5, Athlete, 51, 56);
        addRange(Gender.Male, _ageGroup6, Athlete, 50, 55);       
        
        addRange(Gender.Male, _ageGroup1, Excellent, 56, 61);
        addRange(Gender.Male, _ageGroup2, Excellent, 55, 61);
        addRange(Gender.Male, _ageGroup3, Excellent, 57, 62);
        addRange(Gender.Male, _ageGroup4, Excellent, 58, 63);
        addRange(Gender.Male, _ageGroup5, Excellent, 57, 61);
        addRange(Gender.Male, _ageGroup6, Excellent, 56, 61);        
        
        addRange(Gender.Male, _ageGroup1, Good, 62, 65);
        addRange(Gender.Male, _ageGroup2, Good, 62, 65);
        addRange(Gender.Male, _ageGroup3, Good, 63, 66);
        addRange(Gender.Male, _ageGroup4, Good, 64, 67);
        addRange(Gender.Male, _ageGroup5, Good, 62, 67);
        addRange(Gender.Male, _ageGroup6, Good, 62, 65);   
        
        addRange(Gender.Male, _ageGroup1, AboveAverage, 66, 69);
        addRange(Gender.Male, _ageGroup2, AboveAverage, 66, 70);
        addRange(Gender.Male, _ageGroup3, AboveAverage, 67, 70);
        addRange(Gender.Male, _ageGroup4, AboveAverage, 68, 71);
        addRange(Gender.Male, _ageGroup5, AboveAverage, 68, 71);
        addRange(Gender.Male, _ageGroup6, AboveAverage, 66, 69);
        
        addRange(Gender.Male, _ageGroup1, Average, 70, 73);
        addRange(Gender.Male, _ageGroup2, Average, 71, 74);
        addRange(Gender.Male, _ageGroup3, Average, 71, 75);
        addRange(Gender.Male, _ageGroup4, Average, 72, 76);
        addRange(Gender.Male, _ageGroup5, Average, 72, 75);
        addRange(Gender.Male, _ageGroup6, Average, 70, 73);
        
        addRange(Gender.Male, _ageGroup1, BelowAverage, 74, 81);
        addRange(Gender.Male, _ageGroup2, BelowAverage, 75, 81);
        addRange(Gender.Male, _ageGroup3, BelowAverage, 76, 82);
        addRange(Gender.Male, _ageGroup4, BelowAverage, 77, 83);
        addRange(Gender.Male, _ageGroup5, BelowAverage, 76, 81);
        addRange(Gender.Male, _ageGroup6, BelowAverage, 74, 79);
        
        addRange(Gender.Male, _ageGroup1, Weak, 82, 200);
        addRange(Gender.Male, _ageGroup2, Weak, 82, 200);
        addRange(Gender.Male, _ageGroup3, Weak, 83, 200);
        addRange(Gender.Male, _ageGroup4, Weak, 84, 200);
        addRange(Gender.Male, _ageGroup5, Weak, 82, 200);
        addRange(Gender.Male, _ageGroup6, Weak, 80, 200);
        
        addRange(Gender.Female, _ageGroup1, Athlete, 54, 60);
        addRange(Gender.Female, _ageGroup2, Athlete, 54, 59);
        addRange(Gender.Female, _ageGroup3, Athlete, 54, 59);
        addRange(Gender.Female, _ageGroup4, Athlete, 54, 60);
        addRange(Gender.Female, _ageGroup5, Athlete, 54, 59);
        addRange(Gender.Female, _ageGroup6, Athlete, 54, 59);       
        
        addRange(Gender.Female, _ageGroup1, Excellent, 61, 65);
        addRange(Gender.Female, _ageGroup2, Excellent, 60, 64);
        addRange(Gender.Female, _ageGroup3, Excellent, 60, 64);
        addRange(Gender.Female, _ageGroup4, Excellent, 61, 65);
        addRange(Gender.Female, _ageGroup5, Excellent, 60, 64);
        addRange(Gender.Female, _ageGroup6, Excellent, 60, 64);        
        
        addRange(Gender.Female, _ageGroup1, Good, 66, 69);
        addRange(Gender.Female, _ageGroup2, Good, 65, 68);
        addRange(Gender.Female, _ageGroup3, Good, 65, 69);
        addRange(Gender.Female, _ageGroup4, Good, 66, 69);
        addRange(Gender.Female, _ageGroup5, Good, 65, 68);
        addRange(Gender.Female, _ageGroup6, Good, 65, 68);   
        
        addRange(Gender.Female, _ageGroup1, AboveAverage, 70, 73);
        addRange(Gender.Female, _ageGroup2, AboveAverage, 69, 72);
        addRange(Gender.Female, _ageGroup3, AboveAverage, 70, 73);
        addRange(Gender.Female, _ageGroup4, AboveAverage, 70, 73);
        addRange(Gender.Female, _ageGroup5, AboveAverage, 69, 73);
        addRange(Gender.Female, _ageGroup6, AboveAverage, 69, 72);
        
        addRange(Gender.Female, _ageGroup1, Average, 74, 78);
        addRange(Gender.Female, _ageGroup2, Average, 73, 76);
        addRange(Gender.Female, _ageGroup3, Average, 74, 78);
        addRange(Gender.Female, _ageGroup4, Average, 74, 77);
        addRange(Gender.Female, _ageGroup5, Average, 74, 77);
        addRange(Gender.Female, _ageGroup6, Average, 73, 76);
        
        addRange(Gender.Female, _ageGroup1, BelowAverage, 79, 84);
        addRange(Gender.Female, _ageGroup2, BelowAverage, 77, 82);
        addRange(Gender.Female, _ageGroup3, BelowAverage, 79, 84);
        addRange(Gender.Female, _ageGroup4, BelowAverage, 78, 83);
        addRange(Gender.Female, _ageGroup5, BelowAverage, 78, 83);
        addRange(Gender.Female, _ageGroup6, BelowAverage, 77, 84);
        
        addRange(Gender.Female, _ageGroup1, Weak, 85, 200);
        addRange(Gender.Female, _ageGroup2, Weak, 83, 200);
        addRange(Gender.Female, _ageGroup3, Weak, 85, 200);
        addRange(Gender.Female, _ageGroup4, Weak, 84, 200);
        addRange(Gender.Female, _ageGroup5, Weak, 84, 200);
        addRange(Gender.Female, _ageGroup6, Weak, 84, 200);
    }
        
    public string Compute(Gender gender, int age, int heartRate)
    {
        return _classifications
            .Where(c => c.Gender == gender)
            .Where(c => c.Age.IsInBound(age))
            .Where(c => c.HeartRate.IsInBound(heartRate))
            .Select(c => c.Label)
            .FirstOrDefault() ?? string.Empty;
    }
}