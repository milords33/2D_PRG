using UnityEngine;

namespace PlayerCreator.Appearance
{
    public class PlayerAppearance : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _hair;
        [SerializeField] private SpriteRenderer _beard;
        [SerializeField] private SpriteRenderer _ears;
        [SerializeField] private SpriteRenderer _eyeBrows;
        [SerializeField] private SpriteRenderer _eyes;
        [SerializeField] private SpriteRenderer _mouth;

        public SpriteRenderer Hair => _hair;
        public SpriteRenderer Beard => _beard;
        public SpriteRenderer Eard => _ears;
        public SpriteRenderer EyeBrows => _eyeBrows;
        public SpriteRenderer Eyes => _eyes;
        public SpriteRenderer Mouth => _mouth;
        public SpriteRenderer GetFeaturesSprite(AppearanceFeature feature)
        {
            switch (feature)
            {
                case AppearanceFeature.Beard:    return _beard;
                case AppearanceFeature.Hair:     return _hair;
                case AppearanceFeature.Ears:     return _ears;
                case AppearanceFeature.EyeBrows: return _eyeBrows;
                case AppearanceFeature.Eyes:     return _eyes;
                case AppearanceFeature.Mouth:    return _mouth;
                default:
                    throw new System.NullReferenceException($"There is no spriteRenderer for features{feature.ToString()} ");
            }
        }
    }
}