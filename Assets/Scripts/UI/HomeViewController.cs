using Core.Scene;
using UnityEngine;
using Zenject;

namespace UI
{
    [RequireComponent( typeof( Animator ) )]
    public class HomeViewController : MonoBehaviour
    {
        public void OnOutroAnimationEnded()
        {
            if ( _isInitialized )
            {
                StartGame();
            }
            else
            {
                _isInitialized = !_isInitialized;
            }
        }

        public void OnStartButtonClicked()
        {
            _animator.SetTrigger( _outroTriggerName );
        }

        public void OnExitButtonClicked()
        {
            Application.Quit();
        }

        [SerializeField]
        private Scene _startScene = Scene.Map1;

        [Header( "Animation" )]
        [SerializeField]
        private string _outroTriggerName = "Outro";

        [Inject]
        private ISceneManager _sceneManager;

        private Animator _animator;
        private bool _isInitialized;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void StartGame()
        {
            _sceneManager.ChangeScene( _startScene );
        }
    }
}