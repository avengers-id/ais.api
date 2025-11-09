using Domain.Entities.Common;
using System;

namespace Domain.Auth.Interfaces;

public interface ISession
{
    public UserId UserId { get; }

    public DateTime Now { get; }
}