using LXP.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LXP.Data.IRepository
{
    public interface IRepository
    {
        public List<Moviedetail> GetMoviedetails();

        public Moviedetail GetMoviedetailbyid(int id);

        public void CreateMovie(Moviedetail moviedetail);
    }
}
