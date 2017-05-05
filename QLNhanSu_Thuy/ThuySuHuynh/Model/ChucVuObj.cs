using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhanSu.Model
{
    class ChucVuObj
    {
        public string MaCV;
        public string TenCV;
        public ChucVuObj() { }
        public ChucVuObj(string MaCV, string TenCV)
        {
            this.MaCV = MaCV;
            this.TenCV = TenCV;
        }
    }
}
