using System.Collections.Generic;
using API.Entity;
using API.Interfaces;

namespace API.Services {
    public class SpeakerService : ISpeakerService {
        public IEnumerable<Speaker> Search (string searchString) {
            var hardCodedSpeakers = new List<Speaker> {
                new Speaker { Name = "Josh" },
                new Speaker { Name = "Joshua" },
                new Speaker { Name = "Joseph" },
                new Speaker { Name = "Bill" },
            };

            var speakers = hardCodedSpeakers.Where (x =>
                x.Name.StartsWith (searchString,
                    StringComparison.OrdinalIgnoreCase)).ToList ();

            return speakers;
        }
    }
}