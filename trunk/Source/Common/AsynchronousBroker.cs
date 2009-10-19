namespace AdamDotCom.Common.Website
{
    public class AsynchronousBroker
    {
        public delegate T FireAndForgetDelegate<T>(string id);

        public void FireAndForget<T>(FireAndForgetDelegate<T> param0, string param1)
        {
            FireAndForgetDelegate<T> fireAndForgetDelegate = param0;
            fireAndForgetDelegate.BeginInvoke(param1, null, null);
        }
    }
}
