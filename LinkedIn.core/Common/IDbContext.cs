using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace LinkedIn.core
{

    public interface IDbContext
    {
        DbConnection Connection { get; }
    }
}