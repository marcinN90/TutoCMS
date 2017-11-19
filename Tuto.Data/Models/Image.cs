using System;
using System.Collections.Generic;
using System.Text;

namespace Tuto.Data.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public byte[] Content { get; set; }
    }
}
