using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.DataProvider
{
    //[JsonObject(MemberSerialization.OptIn)]
    public class FilterProvider
    {
        //[JsonProperty(PropertyName = "acceptTime")]
        public string Date { get; } = "27.08.2019 00:00:00";
    }
}