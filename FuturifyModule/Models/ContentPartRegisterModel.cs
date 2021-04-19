using System;
using System.Collections.Generic;
using System.Text;

namespace FuturifyModule.Models
{
    public class ContentPartRegisterModel
    {
        public ContentPartRegisterModel(string contentType, string contentPart)
        {
            ContentType = contentType;
            ContentPart = contentPart;
        }

        public string ContentType { get; set; }
        public string ContentPart { get; set; }
    }
}
