﻿namespace ContactManager.AzGet.Data.Domain.Models;

public abstract class BaseDomainEntity()
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public DateTime CreatedAt { get; set; }
    public Guid CreatedBy { get; init; }
    public DateTime ModifiedAt { get; set; }
    public Guid ModifiedBy { get; set; }
}
