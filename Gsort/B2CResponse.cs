using System;
using RestSharp.Deserializers;
namespace Gsort
{
    /// <summary>
    /// B2B Response.
    /// </summary>
    public class B2BResponse : GenericResponse
    {
        /// <summary>
        /// Gets or sets the response code.
        /// </summary>
        /// <value>The response code.</value>
        [DeserializeAs(Name = "ResponseCode")]
        public int ResponseCode { get; set; }
    }
}
