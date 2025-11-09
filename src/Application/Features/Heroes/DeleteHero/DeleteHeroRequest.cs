using Ardalis.Result;
using Domain.Entities.Common;
using MediatR;

namespace Application.Features.Heroes.DeleteHero;

public record DeleteHeroRequest(HeroId Id) : IRequest<Result>;