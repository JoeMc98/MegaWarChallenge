using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MegaWarChallenge
{
    public partial class index : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        

        protected void dealButton_Click(object sender, EventArgs e)
        {
            Battle battle = new Battle();
            Player player1 = new Player();
            Player player2 = new Player();
            resultLabel.Text = "";
            Random random = new Random();
            
            Deck deck = new Deck();
            

            player1.Name = "Player 1";
            player2.Name = "Player 2";

            deck.Shuffle(random);

            deck.Deal(player1, player2);

            for (int i = 0; i < 20; i++)
            {
                resultLabel.Text += String.Format("<h2>Round {0}</h2>", i + 1);
                resultLabel.Text += battle.PerformBattle(player1, player2);
                resultLabel.Text += String.Format("Player 1 : {0}<br>Player 2 : {1}<br>",
                    player1.MyCards.Count, player2.MyCards.Count);
            }
        }

        protected void battleButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}