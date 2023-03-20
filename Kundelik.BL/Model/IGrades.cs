using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kundelik.BL.Model
{
    interface IGrades
    {

        int ID { get; set; }
        List<int> Math { get; set; }
        List<int> Physics { get; set; }
        List<int> Geometry { get; set; }
        List<int> Chemistry { get; set; }
        List<int> English { get; set; }
        int AverageGrade(List<int> item);

    }
}
