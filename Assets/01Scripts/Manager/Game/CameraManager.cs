using System.Collections;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private readonly Vector3 CamStartVec = new Vector3(0, 16.5f, -.6f);
    private readonly Vector3 CamMatchOffsetVec = new Vector3(0, 14.6f, -3.4f);
    private Vector3 MatchPlayVec = Vector3.zero;
    private float _moveSpeed = 20.0f;
    private float distanceThreshold = 0.001f;

    private Camera Cam = null;
    private Ray ray;
    private RaycastHit hit;

    private void Update()
    {
        if (Managers.Game.GameStateMatchPlay)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ray = Cam.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, 100.0f, 1 << 6))
                {
                    print(hit.transform.gameObject.name);
                    GameObject hitObj = hit.transform.gameObject;

                    Managers.Game.matchPlayManager.Selected(hitObj);
                }
            }
        }
    }


    public void Init()
    {
        Cam = Camera.main;

        this.transform.localPosition = CamStartVec;
    }

    public void GameStartMatch()
    {
        MatchPlayVec = transform.position + CamMatchOffsetVec;

        StartCoroutine(GameStartMatchCoroutine());
    }

    private IEnumerator GameStartMatchCoroutine()
    {
        float distanceThresholdSquared = distanceThreshold * distanceThreshold;
        float step = Time.deltaTime * _moveSpeed;

        while (Vector3.SqrMagnitude(this.transform.position - MatchPlayVec) > distanceThresholdSquared)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, MatchPlayVec, step);

            yield return null;
        }
    }
}
