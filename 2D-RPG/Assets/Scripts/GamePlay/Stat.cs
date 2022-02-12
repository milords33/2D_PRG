using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GamePlay
{
    [Serializable]
    public class Stat
    {
        [SerializeField] private StatType _statType;
        [SerializeField] private int _amount;

        public StatType StatType => _statType;
        public int Amount => _amount;

    }
}
