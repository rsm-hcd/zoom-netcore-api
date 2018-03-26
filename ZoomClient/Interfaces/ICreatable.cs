using System.Collections.Generic;

namespace AndcultureCode.ZoomClient.Interfaces
{
    public interface ICreatable
    {
        /// <summary>
        /// method for entity validation when creating.
        /// </summary>
        /// <returns></returns>
        List<string> Validate();
    }
}
