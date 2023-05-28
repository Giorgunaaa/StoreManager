namespace StoreManager.Services
{
    public class MyClass : IMyClass
    {
        public void Test()
        {
            throw new NotImplementedException();
        }
    }

    public interface IMyClass
    {
        void Test();
    }
}