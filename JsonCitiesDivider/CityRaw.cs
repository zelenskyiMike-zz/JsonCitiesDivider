using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace JsonCitiesDivider
{
    [DataContract]
    public class CityRaw
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public int Id { get; set; }
    }
}
