namespace StoreManager.Services
{
    public class NumberGeneratorService : INumberGenerator
    {
        public int GetNumber()
        {
            return Random.Shared.Next(10);
        }
    }

    public class BigNumberGeneratorService : INumberGenerator
    {
        public int GetNumber()
        {
            return Random.Shared.Next(100, 1000);
        }
    }

    public interface INumberGenerator
    {
        int GetNumber();
    }
}