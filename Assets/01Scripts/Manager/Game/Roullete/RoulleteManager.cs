using System.Collections.Generic;
using UnityEngine;

public class RoulleteManager : MonoBehaviour
{
    private RoulleteImgSpawn[] roulleteImgSpawn = null;

    private readonly int MaxRoulleteSlotCount = 3;
    public float EndSpawnTfY => roulleteImgSpawn[0].EndSpawnTfY;

    private List<Define.eGunType> _gunTypeList = new List<Define.eGunType>();
    public List<Define.eGunType> GunTypeList => _gunTypeList;

    public void Init()
    {
        roulleteImgSpawn = new RoulleteImgSpawn[MaxRoulleteSlotCount];

        for (int i = 0; i < MaxRoulleteSlotCount; i++)
        {
            roulleteImgSpawn[i] = this.transform.GetChild(i).GetComponent<RoulleteImgSpawn>();
            roulleteImgSpawn[i].Init();
        }

        _gunTypeList.Clear();
    }


    public void GameStartMatch()
    {
        for (int i = 0; i < MaxRoulleteSlotCount; i++)
            roulleteImgSpawn[i].GameStartMatch(15 + i * 6, i);
    }

    public void PickImg(Define.eGunType gunType)
    {
        _gunTypeList.Add(gunType);
    }

    public void Clear()
    {
        _gunTypeList.Clear();

        for (int i = 0; i < MaxRoulleteSlotCount; i++)
            roulleteImgSpawn[i].Clear();
    }
}
