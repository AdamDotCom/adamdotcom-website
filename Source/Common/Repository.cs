using AdamDotCom.Common.Website;

namespace AdamDotCom.Common.Website
{
    public class Repository: IRepository
    {
        public override T Find<T>()
        {
            return default(T).FindLocal();
        }

        public override bool Save<T>(T value)
        {
            return value.SaveLocal();
        }

        public override bool IsStale<T>()
        {
            return default(T).IsLocalStale();
        }
    }
}