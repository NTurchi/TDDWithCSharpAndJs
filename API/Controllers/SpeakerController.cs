using System;
using System.Collections.Generic;
using System.Linq;
using API.Entity;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    [Route ("api/[controller]")]
    public class SpeakerController : Controller {
        private readonly ISpeakerService _speakerService;

        public SpeakerController (ISpeakerService speakerService) {
            _speakerService = speakerService;
        }

        [Route ("search")]
        public IActionResult Search (string searchString) {

            var speakers = _speakerService.Search (searchString);

            return Ok (speakers);
        }
    }
}