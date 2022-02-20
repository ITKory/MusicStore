using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Infrastructure.Interfaces
{
    internal interface ICloseWindow
    {
        Action Close { get; set; }
   
    }
}
