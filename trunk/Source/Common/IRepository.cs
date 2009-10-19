namespace AdamDotCom.Common.Website
{
    public abstract class IRepository
    {
        public abstract T Find<T>();
        public abstract bool Save<T>(T value);
        public abstract bool IsStale<T>();
    }
}