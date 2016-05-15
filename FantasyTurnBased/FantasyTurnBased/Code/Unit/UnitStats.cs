using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FantasyTurnBased
{
    class UnitStats
    {
        public int unitMaxHealth;
        public int unitMaxSpeed;
        public int unitMaxAttack;

        public int unitCurrHealth;
        public int unitCurrSpeed;
        public int unitCurrAttack;

        public UnitStats()
        {

        }

        public bool isAlive()
        {
            return (unitCurrHealth > 0);
        }
    }
}
