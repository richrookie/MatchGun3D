using UnityEngine;

public class RoulleteImgSpawn : MonoBehaviour
{
    private Transform _imgStartSpawnTf = null;
    private Transform _imgEndSpawnTf = null;
    public float EndSpawnTfY => _imgEndSpawnTf.localPosition.y;

    private GameObject _startImgPrefab = null;
    private GameObject _pickImgPrefab = null;

    public void Init()
    {
        if (_imgStartSpawnTf == null) _imgStartSpawnTf = Util.FindChild<Transform>(this.gameObject, "StartSpawnTf");
        if (_imgEndSpawnTf == null) _imgEndSpawnTf = Util.FindChild<Transform>(this.gameObject, "EndSpawnTf");

        Clear();
    }

    public void GameStartMatch(int forCount, int slotNum)
    {
        if (_startImgPrefab != null) Managers.Resource.Destroy(_startImgPrefab.gameObject);

        StartCoroutine(ImgGunSpawnCoroutine(forCount, slotNum));
    }

    private System.Collections.IEnumerator ImgGunSpawnCoroutine(int forCount, int slotNum)
    {
        for (int i = 0; i < forCount; i++)
        {
            GameObject obj = Managers.Resource.Instantiate("Img_Gun", this.transform);
            obj.transform.localPosition = _imgStartSpawnTf.localPosition;
            obj.transform.localRotation = Quaternion.identity;
            obj.SetActive(true);

            yield return Util.WaitGet(.075f);
        }

        PickImg();

        if (slotNum == 2)
        {
            yield return Util.WaitGet(1f);

            Managers.Game.gunSpawnManager.SpawnGun();
            Managers.Game.uiGameScene.RoulleteState(false);
        }
    }

    private void PickImg()
    {
        if (_pickImgPrefab == null) Managers.Resource.Instantiate("PickImg", this.transform);
    }

    public void Clear()
    {
        if (_startImgPrefab == null) _startImgPrefab = Managers.Resource.Instantiate("StartImg", this.transform);
        if (_pickImgPrefab != null) Managers.Resource.Destroy(_pickImgPrefab.gameObject);
    }
}
