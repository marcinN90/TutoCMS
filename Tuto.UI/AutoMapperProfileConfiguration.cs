using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tuto.Data.Models;
using Tuto.UI.Models.DTOModels;

namespace Tuto.UI
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration() : this("MainProfile")
        {
        }
        protected AutoMapperProfileConfiguration (string profileName) : base(profileName)
        {
            CreateMap<Link, LinkDTO>();
            CreateMap<Entry, EntryDTO>();
        }

    }
}
