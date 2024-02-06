using UnityEngine;
using UnityEngine.UI;

public class MatchInfo : MonoBehaviour
{
    private Image _gunImg = null;
    private Text _gunCountText = null;

    private int _count = 1;

    public void Init(Define.eGunType gunType)
    {
        if (_gunImg == null) _gunImg = Util.FindChild<Image>(this.gameObject, "Img_Gun");
        if (_gunCountText == null) _gunCountText = Util.FindChild<Text>(this.gameObject, "Text_GunCount");

        _count = 1;
        _gunCountText.text = _count.ToString();

        switch (gunType)
        {
            case Define.eGunType.HandGun:
                _gunImg.sprite = Managers.Resource.Load<Sprite>("Img_Gun0");
                break;

            case Define.eGunType.Shotgun:
                _gunImg.sprite = Managers.Resource.Load<Sprite>("Img_Gun1");
                break;

            case Define.eGunType.AutoRifle:
                _gunImg.sprite = Managers.Resource.Load<Sprite>("Img_Gun2");
                break;
        }
    }

    public void Counting()
    {
        _count += 1;
        _gunCountText.text = _count.ToString();
    }
}
