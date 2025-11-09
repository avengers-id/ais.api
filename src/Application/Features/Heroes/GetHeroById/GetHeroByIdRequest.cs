using Ardalis.Result;
using Domain.Entities.Common;
using MediatR;

namespace Application.Features.Heroes.GetHeroById;

public record GetHeroByIdRequest(HeroId Id) : IRequest<Result<GetHeroResponse>>;