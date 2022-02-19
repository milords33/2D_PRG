using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace PlayerCreator.Specialization
{
    public class PlayerSpecializationView : MonoBehaviour
    {
        [Header("Header")]
        [SerializeField] private Image _specializationIcon;
        [SerializeField] private TMP_Text _specializationName;
        [SerializeField] private Button _leftArrow;
        [SerializeField] private Button _rightArrow;

        [Header("Body")]
        [SerializeField] private TMP_Text _description;
        [SerializeField] private SkillView _skillView;
        [SerializeField] private Transform _skillContainer;
        [SerializeField] private StatView _statView;
        [SerializeField] private Transform _statContainer;

        public Image SpecializationIcon => _specializationIcon;
        public TMP_Text SpecializationName => _specializationName;
        public Button LeftArrow => _leftArrow;
        public Button RightArrow => _rightArrow;
        public TMP_Text Description => _description;
        public SkillView SkillView => _skillView;
        public Transform SkillContainer => _skillContainer;
        public StatView StatView => _statView;
        public Transform StatContainer => _statContainer;
    }
}