using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Threading.Tasks;

namespace Assets.Scripts.Player.Level
{
    internal class Level_1 : BaseLevel
    {
        public const int Level = 1;
        private const int NecessaryXPValue = 100;
        public Level_1(int CurentXp = 0)
        {
            CurentXpValue = CurentXp;
        }
        public override int GetLevel()
        {
            return Level;
        }

        public override BaseLevel AddXp(int value)
        {
            return BaseAddXp(value, NecessaryXPValue, out int superfluous) ? new Level_1(superfluous) : (BaseLevel)this;
        }

        public override void Start()
        {
            throw new NotImplementedException();
        }
    }
}
