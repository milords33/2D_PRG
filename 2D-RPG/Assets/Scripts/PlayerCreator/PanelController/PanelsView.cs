using PlayerCreator.Appearance;
using PlayerCreator.Specialization;
using PlayerCreator.Stats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerCreator.PanelController
{
    public class PanelsView : MonoBehaviour
    {
        [SerializeField] private Button _nextPanelButton;
        [SerializeField] private Button _previousPanelButton;
        [SerializeField] private Button _saveAll;
        [SerializeField] List<GameObject> _panels;

        [SerializeField] private PlayerAppearanceChanger _appearance;
        [SerializeField] private SpecializationChanger _specialization;
        [SerializeField] private StatsView _characteristics;

        private int _index;

        private void Start()
        {
            _index = 0;
            _nextPanelButton.onClick.AddListener(NextMenu);
            _previousPanelButton.onClick.AddListener(PreviousMenu);
            _saveAll.onClick.AddListener(SaveAll);
        }

        private void OnButtonClicked(Panels _panels)
        {
            switch(_panels)
            {
                case Panels.Appearance:
                    _appearance.SaveData();
                    Debug.Log("Appearance");
                    break;

                case Panels.Specialization:
                    _specialization.SaveData();
                    Debug.Log("Specialization");
                    break;

                case Panels.Characteristics:
                    Debug.Log("Characteristics");
                    _characteristics.ChangeData();
                    break;
            }
        }

        private void NextMenu()
        {
            if (_index < _panels.Count - 1)
            {
                OnButtonClicked((Panels)_index + 1);
                _panels[_index++].gameObject.SetActive(false);
                _panels[_index].gameObject.SetActive(true);
            }
        }

        private void PreviousMenu()
        {
            if (_index > 0)
            {
                OnButtonClicked((Panels)_index - 1);
                _panels[_index--].gameObject.SetActive(false);
                _panels[_index].gameObject.SetActive(true);
            }
        }

        private void SaveAll()
        {
            _appearance.SaveData();
            _specialization.SaveData();
            _characteristics.ChangeData();
        }
    }
}
