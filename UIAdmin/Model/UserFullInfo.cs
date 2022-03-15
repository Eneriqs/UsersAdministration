using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIAdmin.Model
{
    public class UserFullInfo
    {
        public UserInfo UserInfo { get; set; }
        public List<string> PotentialSites { get; set; }
        public List<string> AllSites { get; set; }
    }
}
