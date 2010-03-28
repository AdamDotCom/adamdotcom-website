using System;
using AdamDotCom.Common.Website;
using NUnit.Framework;

namespace Unit.Tests
{
    [TestFixture]
    public class MailerMessageTests
    {
        [Test]
        public void ShouldVerify_InvalidEmailAddress()
        {
            var message = new MailerMessage {FromAddress = "invalidemailaddress", Body = "valid-body"};
            Assert.IsFalse(message.IsValid());
        }

        [Test]
        public void ShouldVerify_ValidMessage()
        {
            var message = new MailerMessage { FromAddress = "dude@test.com", Body = "valid-body" };
            Assert.IsTrue(message.IsValid());
        }

        [Test]
        public void ShouldVerify_HtmlStripperWithLinks()
        {
            var messageBody =
                new MailerMessage
                    {
                        Body = @"<blink>bling-bling</blink><br></p><hr><a href='http://www.google.com'>visit this link</a>&nbsp;<a href=""http://www.yahoo.com"">Or check out this link</a>"
                    }.Body;
            
            Console.WriteLine(messageBody);

            Assert.IsFalse(messageBody.Contains("blink"));
            Assert.IsFalse(messageBody.Contains("<br>"));
            Assert.IsTrue(messageBody.Contains("http://www.google.com"));
            Assert.IsTrue(messageBody.Contains("http://www.yahoo.com"));
        }

        [Test]
        public void ShouldVerify_HtmlStripperMoreComplexLinks()
        {
            string messageBody =
                new MailerMessage
                    {
                        Body =
                            @"<a href=""http://www.yahoo.com"">yahoo</a>, visit <a href=""http://www.bing.com"">bing</a>, visit <a href=""http://www.google.com"">google</a>, or check out <a href=""http://www.veer.com"">veer. also look into</a>"
                    }.Body;

            Console.WriteLine(messageBody);

            Assert.IsTrue(messageBody.Contains("http://www.yahoo.com"));
            Assert.IsTrue(messageBody.Contains("http://www.bing.com"));
            Assert.IsTrue(messageBody.Contains("http://www.google.com"));
            Assert.IsTrue(messageBody.Contains("http://www.veer.com"));
        }

        [Test]
        public void ShouldVerify_HtmlStripperOnHappyDays()
        {
            var messageBody = new MailerMessage { Body = @"hello" }.Body;

            Assert.IsTrue(messageBody.Contains("hello"));
        }

        [Test]
        public void ShouldVerify_HtmlStripperOnWeirdInput()
        {
            var messageBody = new MailerMessage { Body = @"-url- -url- <a href='dude'>hi</a> <a href='"" -url-</a> -url-" }.Body;

            Console.WriteLine(messageBody);
        }
    }
}