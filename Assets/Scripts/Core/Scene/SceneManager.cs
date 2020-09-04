using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Scene
{
    public class SceneManager : MonoBehaviour, ISceneManager
    {
        public void ChangeScene( Scene scene )
        {
            
            if ( _sceneMappings.TryGetValue( scene, out var sceneName ) )
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene( sceneName );
            }
        }

        #region private

        [SerializeField]
        private List<SceneMap> _sceneMaps;
        
        private readonly Dictionary<Scene, string> _sceneMappings = new Dictionary<Scene, string>();

        private void Awake()
        {
            foreach ( var map in _sceneMaps )
            {
                _sceneMappings[map.Scene] = map.Name;
            }
        }
        
        #endregion
    }
}
