using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using GamePlay;

using PlayerCreator.PanelController;
using Serialization;
using System.IO;

namespace PlayerCreator.Stats
{
    public class StatsView : MonoBehaviour
    {
        [SerializeField] private List<StatView> _statViews;
        [SerializeField] private TMP_Text _freeStatsText;

        private int _freeStats;
        private List<StatViewData> _statViewsData;
        private List<Stat> _stats;

        private string SavePath => Path.Combine(Application.dataPath, "Serialization/Player", "PlayerClassValue.txt");

        private void Start()
        {
             LoadData();
            _statViewsData = new List<StatViewData>();
            _freeStats = 5;
            _freeStatsText.text = $"Stats left: {_freeStats}";
            for (int i = 0; i < _stats.Count; i++)
            {
                if(i> _statViews.Count)
                {
                    break;
                }
                _statViews[i].Initialize(_stats[i].StatType.ToString());
                _statViews[i].OnStatViewDecreaseClicked += DecreaseStatValue;
                _statViews[i].OnStatViewIncreaseClicked += IncreaseStatValue;
                _statViews[i].OnStatViewValueClicked += ChangeStatValue;
                _statViewsData.Add(new StatViewData(_statViews[i], _stats[i], _stats[i].Value));
            }
            UpdateStatViews();
        }
        private void Update()
        {
            Debug.Log(_statViews.Count);
        }
        public void ChangeFreeStats(int value)
        {
            _freeStats += value;
            _freeStatsText.text = $"Stats left: {_freeStats}";
        }

        private void IncreaseStatValue(StatView statView)
        {
            StatViewData statViewData = _statViewsData.Find(data => data.StatView == statView);
            ChangeStat(statViewData, statViewData.Stat.Value + 1);
        }

        private void DecreaseStatValue(StatView statView)
        {
            StatViewData statViewData = _statViewsData.Find(data => data.StatView == statView);
            ChangeStat(statViewData, statViewData.Stat.Value - 1);
        }

        private void ChangeStatValue(StatView statView, int value)
        {
            StatViewData statViewData = _statViewsData.Find(data => data.StatView == statView);
            ChangeStat(statViewData, value);
        }

        private void ChangeStat(StatViewData statViewData, int value)
        {
            int oldValue = statViewData.Stat.Value;
            if (_freeStats < 0 && value > oldValue)
                return;

            if (value < statViewData.MinValue)
                return;

            value = Mathf.Clamp(value, statViewData.MinValue, oldValue + _freeStats);

            _freeStats += oldValue - value;
            _freeStatsText.text = $"Stats left: {_freeStats}";
            statViewData.Stat.SetValue(value);
            UpdateStatViews();
        }

        private void UpdateStatViews()
        {
            foreach(var statViewData in _statViewsData)
            {
                int value = statViewData.Stat.Value;
                statViewData.StatView.UpdateView(_freeStats > 0 && value < statViewData.StatView.MaxValue,
                    value > statViewData.MinValue, value);
            }
        }

        private void LoadData()
        {
            Dictionary<StatType, int> StatsData = Serializator.Deserializate<Dictionary<StatType, int>>(SavePath);
            _stats = new List<Stat>();
            foreach (var stat in StatsData)
            {
                _stats.Add(new Stat(stat.Key, stat.Value));
            }
        }

        public void ChangeData()
        {
            LoadData();
            Debug.Log("Why it`s doesn`t work " + _statViews.Count); // 0
            for (int i = 0; i < _statViews.Count; i++)
            {
                Debug.Log(i);
                _statViews[i].ChangeStat(Convert.ToInt32(_stats[i].Value));
            }
        }
    }
}