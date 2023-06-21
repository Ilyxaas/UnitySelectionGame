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
        public Level_1()
        {
           int NecessaryXPValue = 100;
        }
        public override int GetLevel()
        {
            return Level;
        }

        public override BaseLevel GetXp(Player player, int value)
        {
            throw new NotImplementedException();
        }

        public override void Start()
        {
            throw new NotImplementedException();
        }
    }
}
