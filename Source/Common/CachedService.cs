namespace AdamDotCom.Common.Website
{
    public abstract class CachedService<T> where T : class
    {
        private readonly IRepository repository;
        private readonly AsynchronousBroker asynchronousBroker;

        protected CachedService():this(new Repository())
        {
        }

        protected CachedService(IRepository repository)
        {
            asynchronousBroker = new AsynchronousBroker();
            this.repository = repository;
        }

        public T Find(string id)
        {
            var result = repository.Find<T>();

            if (result == null)
            {
                result = GetAndSaveFromService(id);
            }
            else if (repository.IsStale<T>())
            {
                asynchronousBroker.FireAndForget<T>(GetAndSaveFromService, id);
            }
            return result;
        }
        
        private T GetAndSaveFromService(string id)
        {
            var result = GetFromService(id);
            repository.Save(result);
            return result;
        }

        protected abstract T GetFromService(string id);
    }
}
