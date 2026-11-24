using System;
using System.Collections.Generic;
using System.Text;

namespace Assets.Scripts.Game_Management_Scripts
{
    public class RNG : Random
    {
        private static RNG instance = new RNG();

        private RNG() { }

        public static RNG Instance { get => instance; set => new RNG(); }
    }
}
