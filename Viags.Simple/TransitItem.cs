using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viags.Simple
{
    public class TransitItem : BaseSimple
    {

    }
    public class KhuVucItem : BaseSimple
    {
        public bool? SuDung { get; set; }

    }
    public class PhuongXaItem : BaseSimple
    {
       public bool? SuDung { get; set; }
    }
    public class DuongApItem : BaseSimple
    {
        public bool? SuDung { get; set; }
    }

}
