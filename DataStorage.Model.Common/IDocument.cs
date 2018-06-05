using System;
using System.Collections.Generic;
using System.Text;

namespace DataStorage.Model.Common
{
    public interface IDocument
    {
        
        Guid Id { get; set; }
        
        int Version { get; set; }
    }
}
