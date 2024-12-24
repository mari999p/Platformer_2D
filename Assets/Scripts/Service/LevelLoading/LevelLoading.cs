using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Service.LevelLoading
{
    [CreateAssetMenu(fileName = nameof(LevelLoadingConfig), menuName = "Game/LevelLoading/Level Loading Config")]
    public class LevelLoadingConfig : ScriptableObject
    {
        #region Variables

        [SerializeField] private string[] _levelSceneNames;

        #endregion

        #region Properties

        public IReadOnlyList<string> LevelSceneNames => _levelSceneNames;

        #endregion
    }
}