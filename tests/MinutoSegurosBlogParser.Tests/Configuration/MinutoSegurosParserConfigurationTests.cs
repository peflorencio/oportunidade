using System;
using FluentAssertions;
using MinutoSegurosBlogParser.Configuration;
using NUnit.Framework;

namespace MinutoSegurosBlogParser.Tests.Configuration
{
    [TestFixture]
    public class MinutoSegurosParserConfigurationTests
    {
        [Test]
        public void When_The_Limit_Of_Parsed_Posts_Is_Configured_With_A_Positive_Number_Should_Not_Throw_Exception()
        {
            Action a = () =>
            {
                new MinutoSegurosParserConfiguration
                {
                    LimitOfParsedPosts = 2
                };
            };
            a.ShouldNotThrow();
        }

        [Test]
        public void When_The_Limit_Of_Parsed_Posts_Is_Configured_With_A_Negative_Number_Should_Throw_Argument_Out_Of_Range_Exception()
        {
            Action a = () =>
            {
                new MinutoSegurosParserConfiguration
                {
                    LimitOfParsedPosts = -2
                };
            };
            a.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void When_The_Limit_Of_Parsed_Posts_Is_Configured_With_Zero_Should_Throw_Argument_Out_Of_Range_Exception()
        {
            Action a = () =>
            {
                new MinutoSegurosParserConfiguration
                {
                    LimitOfParsedPosts = 0
                };
            };
            a.ShouldThrow<ArgumentOutOfRangeException>();
        }
    }
}