using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PlayerCreator.Appearance
{
    public class PlayerAppearanceView : MonoBehaviour
    {
        [SerializeField] private PlayerAppearanceElementView _appearanceElementView;
        [SerializeField] private Transform _elementsGrid;

        public PlayerAppearanceElementView PlayerAppearanceElementView => _appearanceElementView;
        public Transform ElementsGrid => _elementsGrid;
    }
}
