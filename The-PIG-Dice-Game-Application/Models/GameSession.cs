using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace The_PIG_Dice_Game_Application.Models
{
    public class GameSession
    {
        private const string GameKey = "pigGame";

        private ISession session;

        public GameSession(ISession sess) => session = sess; // inject ISession

        public Game GetGame() => session.GetObject<Game>(GameKey) ?? new Game();
        // The null-coalescing operator ?? returns the value of its left-hand operand
        // if it isn't null; otherwise, it evaluates the right-hand operand and returns its result. 

        public void SetGame(Game game) => session.SetObject(GameKey, game); // save game inside session


    }
}
