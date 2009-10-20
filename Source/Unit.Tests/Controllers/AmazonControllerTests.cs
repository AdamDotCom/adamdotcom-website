using AdamDotCom.Amazon.Service.Proxy;
using AdamDotCom.Common.Website;
using AdamDotCom.Website.App.Controllers;
using AdamDotCom.Website.App.Models;
using NUnit.Framework;
using Rhino.Mocks;

namespace Unit.Tests.Controllers
{
    [TestFixture]
    public class AmazonControllerTests
    {

        [Test]
        public void ShouldVerifyLoadFromServiceAndSaveWhenRepository_IsEmpty_ForReviews()
        {
            var mocks = new MockRepository();

            var repository = mocks.StrictMock<IRepository>();
            var service = mocks.StrictMock<IAmazon>();

            Expect.Call(repository.Find<Reviews>()).IgnoreArguments().Return(null);
            Expect.Call(service.ReviewsByCustomerIdXml(string.Empty)).IgnoreArguments().Return(new Reviews());
            Expect.Call(repository.Save(new Reviews())).IgnoreArguments().Return(true);

            mocks.ReplayAll();

            new AmazonController(repository, service).Reviews(string.Empty);

            mocks.VerifyAll();
        }

        [Test]
        public void ShouldVerifyLoadFromServiceAndSaveWhenRepository_IsStale_ForReviews()
        {
            var mocks = new MockRepository();

            var repository = mocks.StrictMock<IRepository>();
            var service = mocks.StrictMock<IAmazon>();

            Expect.Call(repository.Find<Reviews>()).IgnoreArguments().Return(new Reviews());
            Expect.Call(repository.IsStale<Reviews>()).IgnoreArguments().Return(true);
            Expect.Call(service.ReviewsByCustomerIdXml(string.Empty)).IgnoreArguments().Return(new Reviews());
            Expect.Call(repository.Save(new Reviews())).IgnoreArguments().Return(true);

            mocks.ReplayAll();

            new AmazonController(repository, service).Reviews(string.Empty);

            mocks.VerifyAll();
        }

        [Test]
        public void ShouldVerifyLoadFromServiceAndSaveWhenRepository_IsEmpty_ForToReadList()
        {
            var mocks = new MockRepository();

            var repository = mocks.StrictMock<IRepository>();
            var service = mocks.StrictMock<IAmazon>();

            Expect.Call(repository.Find<ToReadList>()).IgnoreArguments().Return(null);
            Expect.Call(service.WishlistByListIdXml(string.Empty)).IgnoreArguments().Return(new ToReadList());
            Expect.Call(repository.Save(new ToReadList())).IgnoreArguments().Return(true);

            mocks.ReplayAll();

            new AmazonController(repository, service).ToRead(string.Empty);

            mocks.VerifyAll();
        }

        [Test]
        public void ShouldVerifyLoadFromServiceAndSaveWhenRepository_IsStale_ForToReadList()
        {
            var mocks = new MockRepository();

            var repository = mocks.StrictMock<IRepository>();
            var service = mocks.StrictMock<IAmazon>();

            Expect.Call(repository.Find<ToReadList>()).IgnoreArguments().Return(new ToReadList());
            Expect.Call(repository.IsStale<ToReadList>()).IgnoreArguments().Return(true);
            Expect.Call(service.WishlistByListIdXml(string.Empty)).IgnoreArguments().Return(new ToReadList());
            Expect.Call(repository.Save(new ToReadList())).IgnoreArguments().Return(true);

            mocks.ReplayAll();

            new AmazonController(repository, service).ToRead(string.Empty);

            mocks.VerifyAll();
        }
        [Test]
        public void ShouldVerifyLoadFromServiceAndSaveWhenRepository_IsEmpty_ForHaveReadList()
        {
            var mocks = new MockRepository();

            var repository = mocks.StrictMock<IRepository>();
            var service = mocks.StrictMock<IAmazon>();

            Expect.Call(repository.Find<HaveReadList>()).IgnoreArguments().Return(null);
            Expect.Call(service.WishlistByListIdXml(string.Empty)).IgnoreArguments().Return(new HaveReadList());
            Expect.Call(repository.Save(new HaveReadList())).IgnoreArguments().Return(true);

            mocks.ReplayAll();

            new AmazonController(repository, service).HaveRead(string.Empty);

            mocks.VerifyAll();
        }

        [Test]
        public void ShouldVerifyLoadFromServiceAndSaveWhenRepository_IsStale_ForHaveReadList()
        {
            var mocks = new MockRepository();

            var repository = mocks.StrictMock<IRepository>();
            var service = mocks.StrictMock<IAmazon>();

            Expect.Call(repository.Find<HaveReadList>()).IgnoreArguments().Return(new HaveReadList());
            Expect.Call(repository.IsStale<HaveReadList>()).IgnoreArguments().Return(true);
            Expect.Call(service.WishlistByListIdXml(string.Empty)).IgnoreArguments().Return(new HaveReadList());
            Expect.Call(repository.Save(new HaveReadList())).IgnoreArguments().Return(true);

            mocks.ReplayAll();

            new AmazonController(repository, service).HaveRead(string.Empty);

            mocks.VerifyAll();
        }
    }
}