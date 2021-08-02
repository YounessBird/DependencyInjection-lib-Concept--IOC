using System;
namespace DependencyIOC
{
    public interface ISomeService
    {
        void PrintGuid();
        string ReturnGuid();
    }
    public class SomeService:ISomeService
    {
        private readonly IRandomGuidGenerator _randomGuidGenerator;
       
        public SomeService(IRandomGuidGenerator randomGuidGenerator)
        {
            _randomGuidGenerator = randomGuidGenerator;
        }
        public void PrintGuid()
        {
            Console.WriteLine(_randomGuidGenerator.RandomGuid);
        }
        public string ReturnGuid()
        {
            return _randomGuidGenerator.ToString();
        }
    }

}
