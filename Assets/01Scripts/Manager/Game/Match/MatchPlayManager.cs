using UnityEngine;
using System.Collections.Generic;

public class MatchPlayManager : MonoBehaviour
{
    private Transform _gunPos1 = null;
    private Transform _gunPos2 = null;
    private Transform _matchPos = null;

    private GameObject[] _matchObj = null;
    private MatchGun[] _matchGun = null;

    public static Vector3 MatchScale = Vector3.one * 2.1f;
    public static Vector3 OriginScale = Vector3.one * 3.0f;

    private List<GameObject> _gunInfoList = new List<GameObject>();
    private Dictionary<Define.eGunType, GameObject> _gunInfoDic = new Dictionary<Define.eGunType, GameObject>();


    public void Init()
    {
        if (_gunPos1 == null) _gunPos1 = Util.FindChild<Transform>(this.gameObject, "GunPos1", true);
        if (_gunPos2 == null) _gunPos2 = Util.FindChild<Transform>(this.gameObject, "GunPos2", true);
        if (_matchPos == null) _matchPos = Util.FindChild<Transform>(this.gameObject, "MatchPos", true);

        _matchObj = new GameObject[2];
        _matchGun = new MatchGun[2];

        Clear();
    }

    public void Selected(GameObject gunObj)
    {
        if (_matchObj[0] == null)
        {
            _matchObj[0] = gunObj;
            _matchGun[0] = _matchObj[0].GetComponent<MatchGun>();
            _matchGun[0].Selected(_gunPos1);
        }
        else if (_matchObj[1] == null)
        {// Judge Match
            _matchObj[1] = gunObj;
            _matchGun[1] = _matchObj[1].GetComponent<MatchGun>();
            _matchGun[1].Selected(_gunPos2);

            Match(_matchObj);
        }
        else
        {
            Debug.Log("Match 판별중");
        }
    }

    private async void Match(GameObject[] matchObj)
    {
        await System.Threading.Tasks.Task.Delay(200);

        Define.eGunType gunType1 = _matchGun[0].GunType;
        Define.eGunType gunType2 = _matchGun[1].GunType;

        if (gunType1 == gunType2)
        {// Match !
            _matchGun[0].Match(_matchPos);
            _matchGun[1].Match(_matchPos);

            CheckDicInfo(gunType1);
        }
        else
        {// MisMatch..
            _matchGun[0].MisMatch(Managers.Game.gunSpawnManager.transform);
            _matchGun[1].MisMatch(Managers.Game.gunSpawnManager.transform);
        }


        for (int i = 0; i < _matchObj.Length; i++)
        {
            if (_matchObj[i] != null)
            {
                _matchObj[i] = null;
                _matchGun[i] = null;
            }
        }
    }

    private void CheckDicInfo(Define.eGunType gunType)
    {
        if (!_gunInfoDic.ContainsKey(gunType))
        {
            GameObject matchInfo = Managers.Resource.Instantiate("UI_MatchInfo", Managers.Game.uiGameScene.MatchInfoRoot.transform);
            matchInfo.GetComponent<MatchInfo>().Init(gunType);

            _gunInfoList.Add(matchInfo);
            _gunInfoDic.Add(gunType, matchInfo);
        }
        else
        {
            _gunInfoDic[gunType].GetComponent<MatchInfo>().Counting();
        }
    }

    private void Clear()
    {
        for (int i = 0; i < _matchObj.Length; i++)
        {
            if (_matchObj[i] != null)
            {
                _matchObj[i] = null;
                _matchGun[i] = null;
            }
        }

        foreach (var list in _gunInfoList)
        {
            if (list != null)
                Managers.Pool.Push(list.GetOrAddComponent<Poolable>());
        }

        _gunInfoList.Clear();
        _gunInfoDic.Clear();
    }
}
