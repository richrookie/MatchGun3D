using UnityEngine;
using UnityEngine.UI;

public class RoulleteStartImg : MonoBehaviour
{
    private Image _img = null;

    private void OnEnable()
    {
        _img = this.GetComponent<Image>();

        int gunImgNum = Random.Range(0, (int)Define.eGunType.MaxCount);

        _img.sprite = Managers.Resource.Load<Sprite>($"Img_Gun{gunImgNum}");
    }
}
