using System.Collections;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // y : 16.4   z : -.6
    // y : 31   z : -4
    // y : 14.6   z : 3.4
    private readonly Vector3 CamMatchOffsetVec = new Vector3(0, 14.6f, -3.4f);
    private Vector3 MatchPlayVec = Vector3.zero;
    private float _moveSpeed = 20.0f;
    private float distanceThreshold = 0.001f;

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
