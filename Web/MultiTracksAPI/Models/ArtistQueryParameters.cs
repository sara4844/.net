using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTracksAPI.Models
{
    public class ArtistQueryParameters : QueryParameters
    {
        public string Name { get; set; } = String.Empty;
    }
}
