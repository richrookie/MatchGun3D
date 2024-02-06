using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Define.eGameState _curGameState = Define.eGameState.Ready;

    public bool GameStateReady => _curGameState == Define.eGameState.Ready;
    public bool GameStateMatchPlay => _curGameState == Define.eGameState.Play_Match;
    public bool GameStateTimeOver => _curGameState == Define.eGameState.End_Match;
    public bool GameStateRunPlay => _curGameState == Define.eGameState.Play_Run;
    public bool GameStateEnd => _curGameState == Define.eGameState.End;

    [HideInInspector]
    public JoystickController JoyStickController;
    public void SetDownAction(System.Action action)
    {
        JoyStickController?.AddDownEvent(action);
    }
    public void SetUpAction(System.Action action)
    {
        JoyStickController?.AddUpEvent(action);
    }
    public void SetMoveAction(System.Action<Vector2> action)
    {
        JoyStickController?.AddMoveEvent(action);
    }

    private UI_GameScene _uiGameScene = null;
    private CameraManager _camManager = null;
    private GunSpawnManager _gunSpawnManager = null;
    private MatchPlayManager _matchPlayManager = null;

    public UI_GameScene uiGameScene { get { CheckNull(); return _uiGameScene; } }
    public CameraManager camManager { get { CheckNull(); return _camManager; } }
    public GunSpawnManager gunSpawnManager { get { CheckNull(); return _gunSpawnManager; } }
    public MatchPlayManager matchPlayManager { get { CheckNull(); return _matchPlayManager; } }

    public string _iapName = "";
    private bool _stageClear = false;
    public bool StageClear
    {
        get => _stageClear;
    }


    public void Init()
    {
        GameReady();
    }

    private void CheckNull()
    {
        if (_uiGameScene == null) _uiGameScene = FindObjectOfType<UI_GameScene>() as UI_GameScene;
        if (_camManager == null) _camManager = FindObjectOfType<CameraManager>() as CameraManager;
        if (_gunSpawnManager == null) _gunSpawnManager = FindObjectOfType<GunSpawnManager>() as GunSpawnManager;
        if (_matchPlayManager == null) _matchPlayManager = FindObjectOfType<MatchPlayManager>() as MatchPlayManager;
    }

    public void GameReady()
    {
        CheckNull();

        _camManager.Init();
        _matchPlayManager.Init();

        _curGameState = Define.eGameState.Ready;
    }

    private System.Action PlayMatchAction;
    public void GameStartMatch(Define.eGameState state)
    {
        _curGameState = state;

        PlayMatchAction -= camManager.GameStartMatch;
        PlayMatchAction += camManager.GameStartMatch;
        PlayMatchAction -= uiGameScene.GameStartMatch;
        PlayMatchAction += uiGameScene.GameStartMatch;

        PlayMatchAction?.Invoke();
    }


    public void Clear()
    {
        if (JoyStickController != null)
        {
            JoyStickController.DownAction = null;
            JoyStickController.UpAction = null;
            JoyStickController.JoystickMoveAction = null;
        }
    }
}
