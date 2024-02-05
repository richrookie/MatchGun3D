using UnityEngine;
using UnityEngine.UI;

public class UI_GameScene : UI_Scene
{
    enum Buttons
    {
        Button_GameStart,
    }

    enum GameObjects
    {
        RoulleteBG,
    }

    private RoulleteManager roulleteMgr = null;
    public RoulleteManager RoulleteMgr => roulleteMgr;
    public System.Collections.Generic.List<Define.eGunType> GunTypeList => RoulleteMgr.GunTypeList;

    private void Awake()
    {
        Bind<Button>(typeof(Buttons));
        Bind<GameObject>(typeof(GameObjects));

        base.Init();

        LoadData();
        ButtonInit();
    }

    private void LoadData()
    {
        if (roulleteMgr == null) roulleteMgr = Util.FindChild<RoulleteManager>(this.gameObject, "Roullete", true);

        roulleteMgr.Init();
    }

    private void ButtonInit()
    {
        GetButton(Buttons.Button_GameStart).onClick.AddListener(() =>
        {
            Managers.Game.GameStart(Define.eGameState.Play_Match);

            GetButton(Buttons.Button_GameStart).gameObject.SetActive(false);
        });
    }

    public void GameStartMatch()
    {
        RoulleteMgr.GameStartMatch();
    }

    public void RoulleteState(bool state)
    {
        GetObject(GameObjects.RoulleteBG).SetActive(state);
    }

    public void Clear()
    {
        RoulleteMgr.Clear();

        RoulleteState(true);
    }
}
