using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiketsTerminal.Domain.Models.ValueModels;

namespace TiketsTerminal.Domain.Models
{
    public class Film
    {

        public Film() { }
        public Film(int id, StringValidator name, StringValidator description, StringValidator trailerUrl, StringValidator posterUrl)
        {
            try
            {
                var url = new Uri(trailerUrl.Value);
                TrailerUrl = trailerUrl.Value;
            }
            catch(Exception)
            {
                throw new ArgumentException("Trailer URL is Not Valid!");
            }

            try
            {
                var url = new Uri(posterUrl.Value);
                PosterUrl = posterUrl.Value;
            }
            catch (Exception)
            {
                throw new ArgumentException("Poster URL is Not Valid!");
            }

            ID = id;
            Name = name.Value;
            Description = description.Value;
        }

        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string TrailerUrl { get; private set; }
        public string PosterUrl { get; private set; }

        public List<FilmViewingTime> FilmViewingTimes { get; private set; }
    }
}
