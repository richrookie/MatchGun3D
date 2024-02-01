using UnityEngine;
using UnityEngine.UI;

public class UI_GameScene : UI_Scene
{
    enum Buttons
    {
        Button_GameStart,
    }

    private void Awake()
    {
        Bind<Button>(typeof(Buttons));

        base.Init();

        ButtonInit();
    }

    private void ButtonInit()
    {
        GetButton(Buttons.Button_GameStart).onClick.AddListener(() =>
        {
            Managers.Game.GameStart(Define.eGameState.Play_Match);

            GetButton(Buttons.Button_GameStart).gameObject.SetActive(false);
        });
    }
}
