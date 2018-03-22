using System;
using System.Collections.Generic;

namespace AndcultureCode.ZoomClient.Models
{
    public abstract class BaseCreate
    {
        public virtual List<string> Validate() => throw new NotImplementedException();
    }
}
