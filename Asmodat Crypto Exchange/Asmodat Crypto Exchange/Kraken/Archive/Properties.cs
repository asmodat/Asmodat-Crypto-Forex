using Asmodat.Kraken;
using Asmodat.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Asmodat.IO;
using Asmodat.Abbreviate;using Asmodat.Extensions.Objects;
using Asmodat.Extensions.Collections.Generic;
using Asmodat.Extensions;

namespace Asmodat.Kraken
{


    public partial class Archive
    {
        public string Path
        {
            get
            {
                return Directories.GetFullPath(@"\DataBase\Archive");
            }
        }

        public KrakenManager Manager { get; private set; }


        public JsonDataBase<ArchiveEntriesJson> Entries { get; private set; } = null;

        
        public JsonStorage<ArchiveOrders> Orders { get; private set; } = null;
        //public JsonDataBase<> ClosedOrders { get; private set; } = null;

    }
}

