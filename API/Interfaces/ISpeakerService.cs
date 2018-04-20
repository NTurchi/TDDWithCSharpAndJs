using System.Collections.Generic;
using API.Entity;

namespace API.Interfaces {
    public interface ISpeakerService {
        IEnumerable<Speaker> Search (string searchString);
    }

}