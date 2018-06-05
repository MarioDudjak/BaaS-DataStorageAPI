using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStorage.Model.Common
{
    public interface ISchema: IDocument
    {
        string Name { get; set; }
        string Description { get; set; }
        JObject Options { get; set; }
    }
}
