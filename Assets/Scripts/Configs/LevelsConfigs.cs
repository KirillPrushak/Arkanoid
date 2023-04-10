

using UnityEngine;

namespace DefaultNamespace.Ui
{
    [CreateAssetMenu(menuName = nameof(LevelsConfigs))]
    public class LevelsConfigs : ScriptableObject
    {
        public LevelConfig[] Levels => _levels;
        [SerializeField] public LevelConfig[] _levels;
    }
}