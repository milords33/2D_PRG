using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GamePlay
{
    [Serializable]
    public class SkillDescriptor
    {
        [SerializeField] private SkillType _skillType;
        [SerializeField] private string _skillName;
        [TextArea]
        [SerializeField] private string _skillDescription;
        [SerializeField] private Sprite _skillSprite;

        public SkillType SkillType => _skillType;
        public string SkillName => _skillName;
        public string SkillDescription => _skillDescription;
        public Sprite SkillSprite => _skillSprite;

    }
}
