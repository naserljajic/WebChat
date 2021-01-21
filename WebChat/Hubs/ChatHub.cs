using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebChat.Hubs
{
    public class ChatHub : Hub
    {
        public async Task PosaljiPoruku(string poruka)
        {
            string korisnik = Context.User.Identity.Name;
            await Clients.All.SendAsync("PrimljenaPoruka", korisnik, poruka);
        }

    }
}
