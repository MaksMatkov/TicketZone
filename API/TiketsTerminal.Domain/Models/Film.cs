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
        public Film(int id, StringValidator name, StringValidator description, StringValidator trailerUrl)
        {
            try
            {
                var url = new Uri(trailerUrl.Value);
                TrailerUrl = url;
            }
            catch(Exception)
            {
                throw new ArgumentException("Trailer URL is Not Valid!");
            }

            ID = id;
            Name = name.Value;
            Description = description.Value;
        }

        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Uri TrailerUrl { get; private set; }

        public List<FilmViewingTime> FilmViewingTimes { get; private set; }
    }
}
