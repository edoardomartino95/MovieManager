using AutoMapper;
using MovieManager.BLL.Models;
using MovieManager.DAL.Entities;

namespace MovieManager.PL.API.Configurations;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // ReverseMap permette il flusso bidirezionale (Entity -> Model e Model -> Entity)
        CreateMap<Actor, ActorModel>().ReverseMap();
        CreateMap<Director, DirectorModel>().ReverseMap();
        CreateMap<Genre, GenreModel>().ReverseMap();
        CreateMap<Movie, MovieModel>().ReverseMap();
        CreateMap<Review, ReviewsModel>().ReverseMap();
        CreateMap<MovieActor, MovieActorModel>().ReverseMap();
    }
}