using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using API.Controllers;
using API.Entity;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Test.TestDoubles;
using Xunit;

namespace Test {
    public class SpeakerControllerSearchTests {

        private readonly SpeakerController _controller;
        private static Mock<ISpeakerService> _speakerServiceMock;
        private readonly List<Speaker> _speakers;
        public SpeakerControllerSearchTests () {
            var speaker = new Speaker {
                Name = "test"
            };

            // define the mock
            _speakerServiceMock = new Mock<ISpeakerService> ();

            // when search is called, return list of speakers containing speaker
            _speakerServiceMock.Setup (x => x.Search (It.IsAny<string> ()))
                .Returns (() => new List<Speaker> { speaker });

            // pass mock object as ISpeakerService
            _controller = new SpeakerController (_speakerServiceMock.Object);
        }

        [Fact]
        public void GivenSearchStringThenSpeakerServiceSearchCalledWithString () {
            // Arrange
            var searchString = "jos";

            // Act
            _controller.Search (searchString);

            // Assert
            // Verifify if the method "Search" in the mock service has been calling once 
            _speakerServiceMock.Verify (mock => mock.Search (searchString),
                Times.Once ());
        }

        [Fact]
        public void GivenSpeakerServiceThenResultsReturned () {
            // Arrange
            var searchString = "jos";

            // Act 
            var result = _controller.Search (searchString) as OkObjectResult;

            // Assert
            Assert.NotNull (result);
            var speakers = ((IEnumerable<Speaker>) result.Value).ToList ();
            Assert.Equal (_speakers, speakers);
        }

        [Fact]
        public void ItAcceptsInterface () {
            // Arrange 
            // Act
            // Assert
            Assert.NotNull (_controller);
        }

        [Fact]
        public void ItCallsSearchServiceOnce () {
            // Arrange
            // Act
            _controller.Search ("jos");

            // Assert
            _speakerServiceMock.Verify (mock => mock.Search (It.IsAny<string> ()),
                Times.Once ());
        }

        [Fact]
        public void ItReturnsOkObjectResult () {
            // Arrange
            // Act 
            var result = _controller.Search ("Jos");

            // Assert
            Assert.NotNull (result);
            Assert.IsType<OkObjectResult> (result);
        }

        [Fact]
        public void ItReturnsCollectionOfSpeakers () {
            // Arrange
            // Act
            var result = _controller.Search ("Jos") as OkObjectResult;

            // Assert
            Assert.NotNull (result);
            Assert.NotNull (result.Value);
            Assert.IsType<List<Speaker>> (result.Value);
        }

        [Fact]
        public void GivenExactMatchThenOneSpeakerInCollection () {
            // Arrange
            // Act
            var result = _controller.Search ("Joshua") as OkObjectResult;

            // Assert  
            var speakers = ((IEnumerable<Speaker>) result.Value).ToList ();
            Assert.Equal (1, speakers.Count);
            Assert.Equal ("Joshua", speakers[0].Name);
        }

        [Fact]
        public void GivenNoMatchThenEmptyCollection () {
            // Arrange
            // Act
            var result = _controller.Search ("ZZZ") as OkObjectResult;

            // Assert
            var speakers = ((IEnumerable<Speaker>) result.Value).ToList ();
            Assert.Equal (0, speakers.Count);
        }

        [Fact]
        public void Given3MatchThenCollectionWith3Speakers () {
            // Arrange
            // Act 
            var result = _controller.Search ("jos") as OkObjectResult;

            // Assert  
            var speakers = ((IEnumerable<Speaker>) result.Value).ToList ();
            Assert.Equal (3, speakers.Count);
            Assert.True (speakers.Any (s => s.Name == "Josh"));
            Assert.True (speakers.Any (s => s.Name == "Joshua"));
            Assert.True (speakers.Any (s => s.Name == "Joseph"));
        }
    }
}