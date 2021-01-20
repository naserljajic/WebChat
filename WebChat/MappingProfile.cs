using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebChat.Models;

namespace WebChat
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<KorisnikRegistrationModel, Korisnik>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.KorisnickoIme));
        }
    }
}
