using LXP.Common.Entities;
using LXP.Common.ViewModels;
using LXP.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LXP.Common.ViewModels;
using LXP.Core.IServices;
using Microsoft.AspNetCore.Mvc;
using LXP.Data.IRepository;

namespace LXP.Core.Services
{
    public class Services: IServices.IServices
    {
        private  readonly IRepository _repository;

        private Mapper _moviemapper;

        public Services(IRepository repository) {
          _repository=repository;
           var _configMovie = new MapperConfiguration(cfg => cfg.CreateMap<Moviedetail, MoviedetailModel>().ReverseMap());
            _moviemapper = new Mapper(_configMovie);
        }
        public List<MoviedetailModel> GetMoviedetails()
        {
            List<Moviedetail> fromDb = _repository.GetMoviedetails();
            List<MoviedetailModel> model = new List<MoviedetailModel>();

            foreach (var item in fromDb)
            {
                var movieModel = new MoviedetailModel
                {
                    Movie = item.MovieName // Assign the movie name from the entity to the DTO property
                };

                model.Add(movieModel);
            }

            return model;
        }

        public MoviedetailModel GetMoviedetailbyid(int id)
        {

           var moviedetail = _repository.GetMoviedetailbyid(id);

            if (moviedetail == null)
            {

                throw new Exception("Not Found");

            }

            MoviedetailModel moviedetailmodel = _moviemapper.Map<Moviedetail, MoviedetailModel>(moviedetail);

            moviedetailmodel =new MoviedetailModel()
            {
                Movie = moviedetail.MovieName
            };

              
            

           
            return moviedetailmodel;

        }
        public void CreateMovie(MoviedetailModel moviedetail)
        {

            Moviedetail moviedetail1=_moviemapper.Map<MoviedetailModel, Moviedetail>(moviedetail);

            moviedetail1 = new Moviedetail()
            {
                 MovieName=moviedetail.Movie
            };

            _repository.CreateMovie(moviedetail1);

        }
    }
}
