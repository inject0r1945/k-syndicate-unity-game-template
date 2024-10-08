using Cysharp.Threading.Tasks;
using GameTemplate.Infrastructure.Signals;
using GameTemplate.Infrastructure.StateMachineComponents;
using GameTemplate.Infrastructure.StateMachineComponents.States;
using GameTemplate.Services.Log;
using GameTemplate.Services.MusicPlay;
using GameTemplate.UI.GameHub.Signals;
using GameTemplate.UI.LoadingCurtain;

namespace GameTemplate.GameLifeCycle.GameHub
{
    public class MainSceneState : SceneState
    {
        private readonly ILoadingCurtain _loadingCurtain;
        private readonly IMusicPlayService _musicPlayService;

        public MainSceneState(SceneStateMachine stateMachine, IEventBus eventBus, ILogService logService, 
            ILoadingCurtain loadingCurtain, IMusicPlayService musicPlayService)
            : base(stateMachine, eventBus, logService)
        {
            _loadingCurtain = loadingCurtain;
            _musicPlayService = musicPlayService;
        }

        public async override UniTask Enter()
        {
            await base.Enter();

            StateEventBus.Subscribe<LoginSignal>(OnLoginSignal);

            if (_musicPlayService.IsPlaying == false)
                _musicPlayService.PlayOrUnpause();

            _loadingCurtain.Hide();
        }

        public async override UniTask Exit()
        {
            await base.Exit();

            StateEventBus.Unsubscribe<LoginSignal>(OnLoginSignal);
        }

        private async void OnLoginSignal() =>
            await StateMachine.SwitchState<AuthorizationSceneState>();
    }
}
