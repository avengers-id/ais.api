using Application.Features.Heroes.CreateHero;
using Domain.Entities;
using Riok.Mapperly.Abstractions;
using System.Linq;

namespace Application.Features.Heroes;

[Mapper]
public static partial class Mapper
{
    public static partial Hero ToHeroEntity(CreateHeroRequest dto);
    public static partial GetHeroResponse ToHeroDto(Hero entity);
    
    public static partial IQueryable<GetHeroResponse> ProjectToResponse(this IQueryable<Hero> source);

}