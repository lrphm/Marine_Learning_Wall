using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //first bubble
    public ParticleSystem bubble_One;
    //second bubble
    public ParticleSystem bubble_Two;
    //third bubble
    public ParticleSystem bubble_Three;
    //fourth bubble
    public ParticleSystem bubble_Four;

    //death bubble one
    public ParticleSystem SubEmitterDeath_One;

    //death bubble two
    public ParticleSystem SubEmitterDeath_Two;

    //death bubble three
    public ParticleSystem SubEmitterDeath_Three;

    //death bubble four
    public ParticleSystem SubEmitterDeath_Four;

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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            bubble_One.TriggerSubEmitter(0);
            bubble_One.Stop();
            bubble_One.Clear();
            SubEmitterDeath_One.Play();
            StartCoroutine(LerpPosition(positionToMoveTo, 10, clownfish));
            StartCoroutine(RefreshBubble(bubble_One));

        } else if (Input.GetKeyDown(KeyCode.W))
        {
            bubble_Two.TriggerSubEmitter(0);
            bubble_Two.Stop();
            bubble_Two.Clear();
            SubEmitterDeath_Two.Play();
            StartCoroutine(LerpPosition(positionToMoveTo, 10));
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            bubble_Three.TriggerSubEmitter(0);
            bubble_Three.Stop();
            bubble_Three.Clear();
            SubEmitterDeath_Three.Play();
            StartCoroutine(LerpPosition(positionToMoveTo, 10));
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            bubble_Four.TriggerSubEmitter(0);
            bubble_Four.Stop();
            bubble_Four.Clear();
            SubEmitterDeath_Four.Play();
            StartCoroutine(LerpPosition(positionToMoveTo, 10));
        }

    }

    //move fish
    IEnumerator LerpPosition(Vector3 targetPosition, float duration, GameObject fish)
    {
        float time = 0;
        Vector3 startPosition = fish.transform.position;

        while (time < duration)
        {
           fish.transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        //transform.position = targetPosition;
    }

    //bubble respawn
    IEnumerator RefreshBubble(ParticleSystem particleSystem)
    {
            yield return new WaitForSeconds(5);
            Debug.Log("hello");
            particleSystem.Play();
             }
}
