using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //first bubble
    public ParticleSystem bubbleOne;
    //second bubble
    public ParticleSystem bubbleTwo;
    //third bubble
    public ParticleSystem bubbleThree;
    //fourth bubble
    public ParticleSystem bubbleFour;

    //death bubble one
    public ParticleSystem SubEmitterDeath_One;

    //death bubble two
    public ParticleSystem SubEmitterDeath_Two;

    //death bubble three
    public ParticleSystem SubEmitterDeath_Three;

    //death bubble four
    public ParticleSystem SubEmitterDeath_Four;

    //first fish (clownfish)
    public GameObject clownfish;

    //second fish (clownfish)
    public GameObject fishTwo;

    //third fish (clownfish)
    public GameObject fishThree;


    //fourth fish (clownfish)
    public GameObject fishFour;

    //first fish position
    public Vector3 positionToMoveFirstFish;

    //first fish position
    public Vector3 positionToMoveSecondFish;
    //first fish position
    public Vector3 positionToMoveThirdFish;
    //first fish position
    public Vector3 positionToMoveFourthFish;
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
            bubbleOne.Stop();
            bubbleOne.Clear();
            SubEmitterDeath_One.Play();
            StartCoroutine(LerpPosition(positionToMoveFirstFish, 5, clownfish));
            StartCoroutine(RefreshBubble(bubbleOne));
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            bubbleTwo.Stop();
            bubbleTwo.Clear();
            SubEmitterDeath_Two.Play();
            // StartCoroutine(LerpPosition(positionToMoveSecondFish, 10,clownfish));
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {  
            bubbleThree.Stop();
            bubbleThree.Clear();
            SubEmitterDeath_Three.Play();
            // StartCoroutine(LerpPosition(positionToMoveThirdFish, 10));
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {   
            bubbleFour.Stop();
            bubbleFour.Clear();
            SubEmitterDeath_Four.Play();
            // StartCoroutine(LerpPosition(positionToMoveFourthFish, 10));
        } else if (Input.GetKey(KeyCode.Space)){
            bubbleOne.Play();
            bubbleTwo.Play();
            bubbleThree.Play();
            bubbleFour.Play();
        }

    }

    IEnumerator RefreshBubble(ParticleSystem particleSystem)
    {
        yield return new WaitForSeconds(15);
        particleSystem.Play();
    }

    //move fish
    IEnumerator LerpPosition(Vector3 targetPosition, float duration, GameObject fishy)
    {
        {
            float time = 0;
            Vector3 startPosition = fishy.transform.position;

            while (time < duration)
            {
                fishy.transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
                time += Time.deltaTime;
                yield return null;
            }
            //transform.position = targetPosition;
        }

      
    }

}
