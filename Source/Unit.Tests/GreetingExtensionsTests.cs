using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AdamDotCom.Website.App;
using AdamDotCom.Website.App.Extensions;
using AdamDotCom.Website.App.Models;
using AdamDotCom.Whois.Service.Proxy;
using NUnit.Framework;

namespace Unit.Tests
{
    [TestFixture]
    public class GreetingExtensionsTests
    {
        [Test]
        public void ShouldVerifyFriendlyMessages()
        {
            var msg = new Greeting().Translate(new WhoisEnhancedRecord
                                                   {
                                                       IsFriendly = true,
                                                       FriendlyMatches = new List<string> {"google"}
                                                   }).Message;
            Assert.IsNotNull(msg);

            Console.WriteLine(msg);

            Assert.IsTrue(msg.Contains("Google"));
            Assert.IsTrue(msg.Contains(MyWebPresence.EmailLink));
            Assert.IsTrue(msg.Contains("callto"));
        }

        [Test]
        public void ShouldVerifyReferrerMessages()
        {
            var msg = new Greeting().Translate(new WhoisEnhancedRecord
                                                   {
                                                       IsReferrerMatch = true,
                                                       ReferrerMatches = new List<string> {"asp.net"}
                                                   }).Message;
            Assert.IsNotNull(msg);

            Console.WriteLine(msg);

            Assert.IsTrue(msg.Contains(MyWebPresence.TwitterLink));
        }

        [Test]
        public void ShouldVerifyFilterMessages()
        {
            var msg = new Greeting().Translate(new WhoisEnhancedRecord
                                                   {
                                                       IsFilterMatch = true,
                                                       FilterMatches = new List<string> {"calgary"}
                                                   }).Message;
            Assert.IsNotNull(msg);

            Console.WriteLine(msg);

            Assert.IsTrue(msg.Contains("Alberta"));
        }

        [Test]
        public void ShouldVerifyRandomizer()
        {
            int result = GreetingExtensions.RandomNumber(new Collection<string> {"one"});

            Assert.IsTrue(result == 0);

            result = GreetingExtensions.RandomNumber(new Collection<string> {"one", "two"});

            Assert.IsTrue(result == 0 || result ==1);
        }

        [Test]
        public void ShouldVerifyCapitalizer()
        {
            Assert.IsTrue("i like cake".Capitalize().Contains("I Like Cake"));
            Assert.IsTrue("I like cake".Capitalize().Contains("I Like Cake"));
        }

        [Test]
        public void ShouldDisplayAllMessagesSoICanLookForMistakesInGrammer()
        {
            Assert.Fail();
        }
    }
}