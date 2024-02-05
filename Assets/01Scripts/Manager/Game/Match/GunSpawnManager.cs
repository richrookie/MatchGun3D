using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSpawnManager : MonoBehaviour
{
    private List<GameObject> _gunList = new List<GameObject>();

    private readonly int SpawnCount = 16;

    public void SpawnGun()
    {
        List<Define.eGunType> gunTypeList = Managers.Game.uiGameScene.GunTypeList;

        for (int i = 0; i < SpawnCount / 2; i++)
        {
            Define.eGunType gunType = gunTypeList[Random.Range(0, 3)];

            GameObject gun1 = Managers.Resource.Instantiate(gunType.ToString(), this.transform);
            gun1.transform.position += SpwanBoundary();
            GameObject gun2 = Managers.Resource.Instantiate(gunType.ToString(), this.transform);
            gun2.transform.position += SpwanBoundary();

            _gunList.Add(gun1);
            _gunList.Add(gun2);
        }
    }

    private Vector3 SpwanBoundary()
    {
        float x = Random.Range(-4, 4);
        float z = Random.Range(-5, 5);

        return new Vector3(x, 0, z);
    }
}
