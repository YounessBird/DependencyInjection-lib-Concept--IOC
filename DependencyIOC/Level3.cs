using System;
namespace DependencyIOC
{
    public interface ILevel3
    {
        public string GetGuidFromLevel2();
    }
    public class Level3 : ILevel3
    {
        private ILevel2 _Level2;

        public Level3(ILevel2 level2)
        {
            _Level2 = level2;
        }

        public string GetGuidFromLevel2()
        {
            return _Level2.GetGuidFromSomeSerivce().ToString() + "L3-";
        }
    }
}




