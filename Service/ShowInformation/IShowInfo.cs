using System.Collections.Generic;
using Models;

namespace Service.ShowInformation
{
    public interface IShowInfo
    {

        public List<Value> ValueOfTable(int id);
        public List<string> AllType(int id);



    }
}
