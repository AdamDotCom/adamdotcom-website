namespace AdamDotCom.Common.Website
{
    public interface IService<T> where T : class
    {
        T Find(string id);
    }
}