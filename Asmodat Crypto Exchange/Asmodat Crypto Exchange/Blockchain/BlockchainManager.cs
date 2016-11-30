using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Asmodat.Blockchain
{
    public partial class BlockchainManager
    {


        public BlockchainManager(string GUID, string PasswordMain, string PasswordSecond)
        {
            this.GUID = GUID;
            this.PasswordMain = PasswordMain;
            this.PasswordSecond = PasswordSecond;

            ServicePointManager.DefaultConnectionLimit = 1000;
        }
    }
}
