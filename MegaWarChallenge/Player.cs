using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaWarChallenge
{
    public class Player
    {
        public string Name { get; set; }
        public Queue<Card> MyCards = new Queue<Card>();
    }
}