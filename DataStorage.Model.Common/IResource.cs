using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStorage.Model.Common
{
    public interface IResource : IDocument
    {
       JObject Data { get; set; }

    }
}
