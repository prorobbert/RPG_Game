using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Binding_of_ROB
{
    class Game
    {
        public void Start()
        {
            RenderWindow window = new RenderWindow(new VideoMode(800, 600), "RPG Binding of Isaac,Robbert,Odin & Barry");
            window.SetFramerateLimit(60);

            Map newworld = new Map(100, 100);
            newworld.Draw(window);
            window.Closed += new EventHandler(OnClosed);

            while (window.IsOpen)
            {
                window.DispatchEvents();
                window.Display();
            }

        }

        void OnClosed(object sender, EventArgs e)
        {
            window window = (window)sender;
            
        }
    }
}
