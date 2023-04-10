using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace.Ui
{
    public class SelectLevelWindow : MonoBehaviour
    {
        [SerializeField] private LevelButton _levelButtonPrefab;
        [SerializeField] private RectTransform _content;

        [SerializeField] private LevelsConfigs _levelsConfigs;

        private void Awake()
        {
            for (int i = 0; i < _levelsConfigs.Levels.Length; i++)
            {
                var buttonInstance = Instantiate(_levelButtonPrefab, _content);

                var levelConfig = _levelsConfigs.Levels[i];
                
                // bool active = levelConfig.Completed ||
                //               (i - 1 >= 0 && 
                //                _levelsConfigs.Levels[i - 1].Completed) ||
                //               i == 0;

                bool active = levelConfig.Completed ||
                              (i - 1 >= 0 && _levelsConfigs.Levels[i - 1].Completed) ||
                              i == 0;

                var levelConfug = _levelsConfigs.Levels[i];
                buttonInstance.DrawLevel(
                    (i + 1).ToString(), levelConfig.SceneName, active);
            }
        }
    }
}