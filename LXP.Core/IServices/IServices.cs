using LXP.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LXP.Core.IServices
{
    public  interface IServices
    {

        public List<MoviedetailModel> GetMoviedetails();

        public MoviedetailModel GetMoviedetailbyid(int id);

        public void CreateMovie(MoviedetailModel moviedetail);
    }
}
