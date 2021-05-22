using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //first bubble
    public ParticleSystem particleObject;

    public GameObject clownfish;

    public Vector3 positionToMoveTo;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


       // clownfish.transform.Translate(0, 0, Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("pressed");
            particleObject.Stop();
            particleObject.Clear();
            StartCoroutine(LerpPosition(positionToMoveTo, 5));

        }

       }

    IEnumerator LerpPosition(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = clownfish.transform.position;

        while (time < duration)
        {
            clownfish.transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }
}
