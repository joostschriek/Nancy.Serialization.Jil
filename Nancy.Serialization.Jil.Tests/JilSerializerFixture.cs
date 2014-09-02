﻿using System;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nancy.Serialization.Jil.Tests
{
    [TestClass]
    public class JilSerializerFixture
    {
        [TestMethod]
        public void when_serializing()
        {
            // Given
            var guid = Guid.NewGuid();
            var data = new { SomeString = "some string value", SomeGuid = guid, NullValue = default(Uri) };
            string expected
                = string.Format("{{\"SomeGuid\":\"{0}\",\"NullValue\":null,\"SomeString\":\"some string value\"}}", guid);

            // When
            string actual;
            using (var stream = new MemoryStream())
            {
                ISerializer sut = new JilSerializer();
                sut.Serialize("application/json", data, stream);
                actual = Encoding.UTF8.GetString(stream.ToArray());
            }

            // Then
            Assert.AreEqual(expected, actual);
        }
    }
}
