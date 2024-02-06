using UnityEngine;

public class MatchGun : MonoBehaviour
{
    [SerializeField]
    private Define.eGunType _gunType;
    public Define.eGunType GunType => _gunType;

    private Collider _col = null;
    private Rigidbody _rb = null;
    private Poolable poolable = null;


    public void Init(Define.eGunType gunType)
    {
        _gunType = gunType;

        if (_col == null) _col = this.GetComponent<Collider>();
        if (_rb == null) _rb = this.GetComponent<Rigidbody>();
        if (poolable == null) poolable = this.GetComponent<Poolable>();
    }

    public void Selected(Transform selectedTf)
    {
        _col.enabled = false;
        _rb.isKinematic = true;

        StartCoroutine(SelectedCoroutine(selectedTf));
    }

    private System.Collections.IEnumerator SelectedCoroutine(Transform selectedTf)
    {
        this.transform.localScale = MatchPlayManager.MatchScale;
        this.transform.localRotation = selectedTf.localRotation;

        while ((this.transform.position - selectedTf.position).sqrMagnitude > .1f)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, selectedTf.position, Time.deltaTime * 100.0f);

            yield return null;
        }
    }

    public void Match(Transform matchTf)
    {
        StartCoroutine(MatchCoroutine(matchTf));
    }

    private System.Collections.IEnumerator MatchCoroutine(Transform matchTf)
    {
        this.transform.localRotation = matchTf.localRotation;

        while ((this.transform.position - matchTf.position).sqrMagnitude > .1f)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, matchTf.position, Time.deltaTime * 25.0f);

            yield return null;
        }

        Managers.Pool.Push(poolable);
    }

    public void MisMatch(Transform misMatchTf)
    {
        StartCoroutine(MisMatchCoroutine(misMatchTf));
    }

    private System.Collections.IEnumerator MisMatchCoroutine(Transform misMatchTf)
    {
        while ((this.transform.position - misMatchTf.position).sqrMagnitude > .1f)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, misMatchTf.position, Time.deltaTime * 50.0f);

            yield return null;
        }

        Clear();
    }


    private void Clear()
    {
        this.transform.localScale = MatchPlayManager.OriginScale;

        _col.enabled = true;
        _rb.isKinematic = false;
    }
}
