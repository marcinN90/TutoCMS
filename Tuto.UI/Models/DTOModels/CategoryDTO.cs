﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Tuto.UI.Models.DTOModels
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<EntryDTO> Entires { get; set; }
    }
}
