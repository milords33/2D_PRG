using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelsView : MonoBehaviour
{
    [SerializeField] private Button _nextPanelButton;
    [SerializeField] private Button _previousPanelButton;
    [SerializeField] List<GameObject> _gameObjects;

    private int _index;

    private void Start()
    {
        _index = 0;
        _nextPanelButton.onClick.AddListener(NextMenu);
        _previousPanelButton.onClick.AddListener(PreviousMenu);
    }

    private void NextMenu()
    {
        if (_index < _gameObjects.Count - 1)
        {
            _gameObjects[_index++].SetActive(false);
            _gameObjects[_index].SetActive(true);
        }
    }

    private void PreviousMenu()
    {
        if(_index > 0)
        {
            _gameObjects[_index--].SetActive(false);
            _gameObjects[_index].SetActive(true);
        }
    }

}
