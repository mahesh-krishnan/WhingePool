using System;
using System.Collections.Generic;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class WhingeController : ApiController
    {
        private static readonly List<Whinge> Whinges = new List<Whinge>
        {
            new Whinge
            {
                Id = "13192FAC-999F-4C69-9A3F-70A328B860CA",
                WhingePool = "Work",
                Text = "I hate going to work on Mondays!",
                WhingeTime = DateTime.Now
            },
            new Whinge
            {
                Id = "13192FAC-999F-4C69-9A3F-70A328B860CB",
                WhingePool = "Work",
                Text = "I actually hate going to work",
                WhingeTime = DateTime.Now
            },
            new Whinge
            {
                Id = "13192FAC-999F-4C69-9A3F-70A328B860CC",
                WhingePool = "Work",
                Text = "So many imcompetent people around",
                WhingeTime = DateTime.Now
            },
            new Whinge
            {
                Id = "13192FAC-999F-4C69-9A3F-70A328B860CD",
                WhingePool = "Work",
                Text = "Are they really stupid or just acting like one",
                WhingeTime = DateTime.Now
            },
            new Whinge
            {
                Id = "13192FAC-999F-4C69-9A3F-70A328B860CE",
                WhingePool = "Life",
                Text = "Life sux :(",
                WhingeTime = DateTime.Now
            },
            new Whinge
            {
                Id = "13192FAC-999F-4C69-9A3F-70A328B860CF",
                WhingePool = "Life",
                Text = "Why are all good things bad for you?",
                WhingeTime = DateTime.Now
            },
            new Whinge
            {
                Id = "13192FAC-999F-4C69-9A3F-70A328B860D1",
                WhingePool = "Life",
                Text = "I hate twitter",
                WhingeTime = DateTime.Now
            },
            new Whinge
            {
                Id = "13192FAC-999F-4C69-9A3F-70A328B860D2",
                WhingePool = "Life",
                Text = "I hate social media",
                WhingeTime = DateTime.Now
            },
            new Whinge
            {
                Id = "13192FAC-999F-4C69-9A3F-70A328B860D3",
                WhingePool = "Life",
                Text = "I hate everything",
                WhingeTime = DateTime.Now
            },
            new Whinge
            {
                Id = "13192FAC-999F-4C69-9A3F-70A328B860D4",
                WhingePool = "Life",
                Text = "Lorem Ipsem Blah blah blah. This is just too hard. I give up",
                WhingeTime = DateTime.Now
            },
            new Whinge
            {
                Id = "13192FAC-999F-4C69-9A3F-70A328B860D5",
                WhingePool = "Telstra",
                Text = "Nothing to say",
                WhingeTime = DateTime.Now
            },
            new Whinge
            {
                Id = "13192FAC-999F-4C69-9A3F-70A328B860D6",
                WhingePool = "Telstra",
                Text = "Moving right along. We are still living in the dark ages. Blah blah blah...",
                WhingeTime = DateTime.Now
            },
            new Whinge
            {
                Id = "13192FAC-999F-4C69-9A3F-70A328B860D7",
                WhingePool = "Telstra",
                Text =
                    "If you want to join the Telstra hate club, your call is important to us, so please hold hte line",
                WhingeTime = DateTime.Now
            },
            new Whinge
            {
                Id = "13192FAC-999F-4C69-9A3F-70A328B860D8",
                WhingePool = "Others",
                Text = "I am out of ideas!",
                WhingeTime = DateTime.Now
            },
            new Whinge
            {
                Id = "13192FAC-999F-4C69-9A3F-70A328B860D9",
                WhingePool = "",
                Text = "Bleep Bleep Bleep",
                WhingeTime = DateTime.Now
            },
            new Whinge
            {
                Id = "13192FAC-999F-4C69-9A3F-70A328B860DA",
                WhingePool = "",
                Text = "Oh, great!",
                WhingeTime = DateTime.Now
            },
        };

        // GET api/whinge
        public IEnumerable<Whinge> Get()
        {
            return Whinges;
        }

        // GET api/whinge/5
        public IEnumerable<Whinge> Get(string id)
        {
            return Whinges;
        }

        // POST api/whinge
        public void Post(Whinge whinge)
        {
            whinge.Id = Guid.NewGuid().ToString();
            whinge.WhingeTime = DateTime.UtcNow;
            Whinges.Insert(0, whinge);
        }

        // DELETE api/whinge/5
        public void Delete(string id)
        {
        }
    }
}