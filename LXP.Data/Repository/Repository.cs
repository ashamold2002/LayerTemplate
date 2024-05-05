using LXP.Common.Entities;

using LXP.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LXP.Common.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LXP.Data.Repository
{
    public class Repository :IRepository.IRepository
    {
        public List<Moviedetail> GetMoviedetails()
        {
            var db = new LXPDbContext();
            return db.Moviedetails.ToList();
        }
        public Moviedetail GetMoviedetailbyid(int id)
        {

            var db = new LXPDbContext();
            Moviedetail moviedetail = new Moviedetail();
            moviedetail = db.Moviedetails.FirstOrDefault(x => x.MovieId == id);
            
            return moviedetail;

        }
        public void CreateMovie(Moviedetail moviedetail)
        {

            var db=new LXPDbContext();
            db.Moviedetails.Add(moviedetail);
            db.SaveChanges();

        }
    }
}
