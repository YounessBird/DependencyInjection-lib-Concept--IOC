using System;
namespace DependencyIOC
{
    public class Level2 :ILevel2
    {
        private ISomeService _someserivce;

        public Level2(ISomeService someservice)
        {
            _someserivce = someservice;
        }

        public string GetGuidFromSomeSerivce()
        {
            return _someserivce.ReturnGuid();

        }
    }
}
