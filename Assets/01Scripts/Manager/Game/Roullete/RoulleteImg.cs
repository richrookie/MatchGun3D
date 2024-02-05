using UnityEngine;

public class RoulleteImg : MonoBehaviour
{
    private void Update()
    {
        if (this.transform.localPosition.y > Managers.Game.uiGameScene.RoulleteMgr.EndSpawnTfY)
            this.transform.Translate(Vector3.down * Time.deltaTime * Define.ROULLETE_GUNIMG_SPEED);
        else
            Managers.Resource.Destroy(this.gameObject);
    }
}
