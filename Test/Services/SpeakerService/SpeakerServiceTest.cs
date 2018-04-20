using System;
using System.Collections.Generic;
using SpeakerServices = API.Services.SpeakerService;
using System.Linq;
using API.Interfaces;
using API.Services;
using Xunit;

namespace Test.Services.SpeakerService {

    public class SpeakerServiceTest {
        private readonly SpeakerServices _speakerService;

        public SpeakerServiceTest () {
            _speakerService = new SpeakerServices ();
        }

        [Fact]
        public void ItExists () {
            var speakerService = new SpeakerServices ();
        }

        [Fact]
        public void ItHasSearchMethod () {

            _speakerService.Search ("test");
        }

        [Fact]
        public void ItImplementsISpeakerService () {

            Assert.True (_speakerService is ISpeakerService);
        }

        [Fact]
        public void GivenExactMatchThenOneSpeakerInCollection () {
            // Arrange
            // Act
            var result = _speakerService.Search ("Joshua");

            // Assert
            var speakers = result.ToList ();
            Assert.Equal (1, speakers.Count);
            Assert.Equal ("Joshua", speakers[0].Name);
        }

        [Theory]
        [InlineData ("Joshua")]
        [InlineData ("joshua")]
        [InlineData ("JoShUa")]
        public void GivenCaseInsensitveMatchThenSpeakerInCollection (string searchString) {
            // Arrange
            // Act
            var result = _speakerService.Search (searchString);

            // Assert
            var speakers = result.ToList ();
            Assert.Equal (1, speakers.Count);
            Assert.Equal ("Joshua", speakers[0].Name);
        }

        [Fact]
        public void GivenNoMatchThenEmptyCollection () {
            // Arrange
            // Act
            var result = _speakerService.Search ("ZZZ");

            // Assert
            var speakers = result.ToList ();
            Assert.Equal (0, speakers.Count);
        }

        [Fact]
        public void Given3MatchThenCollectionWith3Speakers () {
            // Arrange
            // Act
            var result = _speakerService.Search ("jos");

            // Assert
            var speakers = result.ToList ();
            Assert.Equal (3, speakers.Count);
            Assert.True (speakers.Any (s => s.Name == "Josh"));
            Assert.True (speakers.Any (s => s.Name == "Joshua"));
            Assert.True (speakers.Any (s => s.Name == "Joseph"));
        }

    }
}