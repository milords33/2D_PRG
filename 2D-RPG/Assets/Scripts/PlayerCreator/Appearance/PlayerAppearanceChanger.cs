using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Serialization;
using ObjectPooling;

namespace PlayerCreator.Appearance
{ 
    public class PlayerAppearanceChanger : MonoBehaviour
    {
        [SerializeField] private PlayerAppearance _playerAppearance;
        [SerializeField] private PlayerAppearanceView _appearanceView;
        [SerializeField] private AppearanceFeatureSpritesStorage _storage;

        private List<PlayerAppearanceElementController> _elementControllers;
        private string SavePath => Path.Combine(Application.dataPath, "Serialization/Player", "PlayerAppearance.txt");

        public void Start()
        {
            Dictionary<AppearanceFeature, int> appearanceFeatures = Serializator.Deserializate<Dictionary<AppearanceFeature, int>>(SavePath);

            _elementControllers = new List<PlayerAppearanceElementController>();
            foreach (var featureSprite in _storage.AppearanceFeatureSprites)
            {
                appearanceFeatures.TryGetValue(featureSprite.AppearanceFeature, out int index);
                PlayerAppearanceElementView elementView = Instantiate(_appearanceView.PlayerAppearanceElementView, 
                    _appearanceView.ElementsGrid);

                PlayerAppearanceElementController elementController = new PlayerAppearanceElementController(elementView,
                    featureSprite, _playerAppearance.GetFeaturesSprite(featureSprite.AppearanceFeature), index);

                _elementControllers.Add(elementController);
            }
        }
        // private Destroy
        public void SaveData()
        {
            Dictionary<AppearanceFeature, int> appearanceFeatures = new Dictionary<AppearanceFeature, int>();
            foreach (var element in _elementControllers)
            {
                appearanceFeatures.Add(element.AppearanceFeature, element.Index);
                element.Dispose();
            }
            Serializator.Serializate(appearanceFeatures, SavePath);
        }
    }
} 