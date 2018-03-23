using System;
using System.Collections.Generic;

namespace AndcultureCode.ZoomClient.Models
{
    public abstract class BaseCreate
    {
        /// <summary>
        /// virtual method for entity validation when creating.
        /// </summary>
        /// <returns></returns>
        public virtual List<string> Validate() => throw new NotImplementedException();
    }
}
