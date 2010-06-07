using AdamDotCom.Common.Website;
using NUnit.Framework;
using Rhino.Mocks;

namespace Unit.Tests
{
    [TestFixture]
    public class CachedServiceTests
    {
        public class TestObject
        {
        }

        public class TestService : CachedService<TestObject>
        {
            public TestService()
            {
                
            }
            public TestService(IRepository repository) : base(repository)
            {
            }

            protected override TestObject GetFromService(string id)
            {
                return new TestObject();
            }
        }

        [Test]
        public void ShouldVerify_LoadFromServiceAndSaveWhenRepository_IsEmpty()
        {
            var mocks = new MockRepository();

            var repository = mocks.StrictMock<IRepository>();

            Expect.Call(repository.Find<TestObject>()).IgnoreArguments().Return(null);
            Expect.Call(repository.Save(new TestObject())).IgnoreArguments().Return(true);

            mocks.ReplayAll();

            new TestService(repository).Find(string.Empty);

            mocks.VerifyAll();
        }

        [Test,Ignore]
        //ToDo: revisit testing staleness
        public void ShouldVerify_LoadFromServiceAndSaveWhenRepository_IsStale()
        {
            var mocks = new MockRepository();

            var repository = mocks.StrictMock<IRepository>();

            Expect.Call(repository.Find<TestObject>()).IgnoreArguments().Return(new TestObject());
            Expect.Call(repository.IsStale<TestObject>()).IgnoreArguments().Return(true);
            Expect.Call(repository.Save(new TestObject())).IgnoreArguments().Return(true);

            mocks.ReplayAll();

            new TestService(repository).Find(string.Empty);

            mocks.VerifyAll();
        }
    }
}