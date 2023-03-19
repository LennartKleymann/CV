using Core.Common.Contracts;

namespace Core.Domain;

public class Company : BaseEntity<Guid>
{
    public string Name { get; set; } = default!;
    public string ContactPerson { get; set; } = default!;
    public string HashedPinCode { get; set; } = default!;
    public string PersonalizedBriefing { get; set; } = default!;
}