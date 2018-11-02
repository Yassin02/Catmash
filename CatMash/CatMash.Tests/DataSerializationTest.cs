using System;
using System.Net;
using CatMash.Business.Model;
using CatMash.Core.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CatMash.Tests
{
    [TestClass]
    public class DataSerializationTest
    {
        [TestMethod]
        public void Should_Pass_When_URLValid()
        {
            var data = JsonSerializer.DeserializeJson<CatsData>("https://latelier.co/data/cats.json");
            Assert.IsNotNull(data);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Should_ThrowException_When_URLEmpty()
        {
            JsonSerializer.DeserializeJson<CatsData>("");
        }

        [TestMethod]
        [ExpectedException(typeof(WebException))]
        public void Should_ThrowException_When_URLInvalid()
        {
            JsonSerializer.DeserializeJson<CatsData>("invalidUrl");
        }
    }
}
