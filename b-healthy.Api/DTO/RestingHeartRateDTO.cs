using System.Runtime.CompilerServices;
using b_healthy.Data;

namespace Beringela.Api.DTO;

public class RestingHeartRateDto
{
    public int Age { get; set; }
    public Gender Gender { get; set; }
    public int Rate { get; set; }

    public bool Validate()
    {
        return Age > 18 && Rate > 49;
    }
}