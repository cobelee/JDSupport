using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tiyi.JD.SQLServerDAL
{

    public partial class JiadianDataContext
    {
        public JiadianDataContext() :
            base(Tiyi.JD.SQLServerDAL.Connection.GetConnectionString(), mappingSource)
        {
            OnCreated();
        }
    }
}
