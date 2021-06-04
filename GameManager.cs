using System.Collections;
using System.IO.Ports;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    private SerialPort port;
    //
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

    //second fish 
    public GameObject fishTwo;

    //third fish 
    public GameObject fishThree;


    //fourth fish 
    public GameObject fishFour;

    //first fish move position
    private Vector3 positionToMoveFirstFish = new Vector3(-6, 1, 11);

    //second fish position
    private Vector3 positionToMoveSecondFish = new Vector3(-4, 1, 16);
    //third fish position
    private Vector3 positionToMoveThirdFish = new Vector3(-5, -2, 17);
    //fourth fish position
    private Vector3 positionToMoveFourthFish = new Vector3(-4, -2, 11);


    private Vector3 fishOneStartPos = new Vector3(-25, 0, 12);

    private Vector3 fishTwoStartPos = new Vector3(-22, 3, 30);

    private Vector3 fishThreeStartPos = new Vector3(-42, 4, 28);

    private Vector3 fishFourStartPos = new Vector3(-27, -2, 15);

    private bool fishOneSwim = false;

    private bool fishTwoSwim = false;

    private bool fishThreeSwim = false;

    private bool fishFourSwim = false;

    private enum PortStatus {
        NotFound, NotConnected, Connected
    }

    private PortStatus pStatus = PortStatus.NotFound;


    // Start is called before the first frame update
    void Start()
    {
        string[] portList = SerialPort.GetPortNames();

        foreach (string p in portList) {
            Debug.Log(p);
        }

        // We are going to assume that the first entry is the Arduino
        // You may need to adjust this or hardcode the name if needed.
        if (portList.Length > 0) {
            //port = new SerialPort(portList[0], 9600);
            port = new SerialPort("/dev/cu.usbmodem11101", 9600);
            pStatus = PortStatus.NotConnected;
        }

        clownfish.transform.position = fishOneStartPos;
        fishTwo.transform.position = fishTwoStartPos;

    }

    // Update is called once per frame
    void Update()
    {
        if (pStatus == PortStatus.NotConnected) {
            OpenConnection();
        } else if (pStatus == PortStatus.Connected) {

            // We want to read from the port in a Try/Catch block to catch
            // any potential timeout exceptions that are thrown when the
            // reading times out at 50 milliseconds.

            try {
                char command = (char)port.ReadChar();

                switch (command) {
                    case '1':
                        Debug.Log(fishOneSwim);
                        if (fishOneSwim == false)
                        {
                            bubbleOne.Stop();
                            bubbleOne.Clear();
                            SubEmitterDeath_One.Play();
                            StartCoroutine(LerpPosition(positionToMoveFirstFish, 5, clownfish));
                            fishOneSwim = true;
                            Debug.Log(fishOneSwim);
                            StartCoroutine(resetFishAndBubble(clownfish));
                        }
                        break;
                    case '2':
                        if (fishTwoSwim == false)
                        {
                            bubbleTwo.Stop();
                            bubbleTwo.Clear();
                            SubEmitterDeath_Two.Play();
                            StartCoroutine(LerpPosition(positionToMoveSecondFish, 5, fishTwo));
                            fishTwoSwim = true;
                            StartCoroutine(resetFishAndBubble(fishTwo));
                        }
                        break;
                    case '3':
                        if (fishThreeSwim == false)
                        {
                            bubbleThree.Stop();
                            bubbleThree.Clear();
                            SubEmitterDeath_Three.Play();
                            StartCoroutine(LerpPosition(positionToMoveThirdFish, 5, fishThree));
                            fishThreeSwim = true;
                            StartCoroutine(resetFishAndBubble(fishThree));
                        }
                        break;
                    case '4':
                        if (fishFourSwim == false) {
                            bubbleFour.Stop();
                            bubbleFour.Clear();
                            SubEmitterDeath_Four.Play();
                            StartCoroutine(LerpPosition(positionToMoveFourthFish, 5, fishFour));
                            fishFourSwim = true;
                            StartCoroutine(resetFishAndBubble(fishFour));
                    }

                        break;
                    default:
                        break;
                }
            } catch (TimeoutException e) {

            }
        }

        // clownfish.transform.Translate(0, 0, Time.deltaTime);
        // if (Input.GetKeyDown(KeyCode.Q))
        // {
        //     Debug.Log(fishOneSwim);
        //     if (fishOneSwim == false)
        //     {
        //         bubbleOne.Stop();
        //         bubbleOne.Clear();
        //         SubEmitterDeath_One.Play();
        //         StartCoroutine(LerpPosition(positionToMoveFirstFish, 5, clownfish));
        //         fishOneSwim = true;
        //         Debug.Log(fishOneSwim);
        //         StartCoroutine(resetFishAndBubble(clownfish));
        //     }
        // }
        // else if (Input.GetKeyDown(KeyCode.W))
        // {
        //     if (fishTwoSwim == false)
        //     {
        //         bubbleTwo.Stop();
        //         bubbleTwo.Clear();
        //         SubEmitterDeath_Two.Play();
        //         StartCoroutine(LerpPosition(positionToMoveSecondFish, 5, fishTwo));
        //         fishTwoSwim = true;
        //         StartCoroutine(resetFishAndBubble(fishTwo));
        //     }
        // }
        // else if (Input.GetKeyDown(KeyCode.E))
        // {
        //     if (fishThreeSwim == false)
        //     {
        //         bubbleThree.Stop();
        //         bubbleThree.Clear();
        //         SubEmitterDeath_Three.Play();
        //         StartCoroutine(LerpPosition(positionToMoveThirdFish, 5, fishThree));
        //         fishThreeSwim = true;
        //         StartCoroutine(resetFishAndBubble(fishThree));
        //     }
          
        // }
        // else if (Input.GetKeyDown(KeyCode.R))
        // {
        //     if (fishFourSwim == false)
        //     {
        //         bubbleFour.Stop();
        //         bubbleFour.Clear();
        //         SubEmitterDeath_Four.Play();
        //         StartCoroutine(LerpPosition(positionToMoveFourthFish, 5, fishFour));
        //         fishFourSwim = true;
        //         StartCoroutine(resetFishAndBubble(fishFour));
        //     }

        // }
        // else if (Input.GetKey(KeyCode.Space))
        // {
        //     moveFishtoStart();
        //     bubbleOne.Play();
        //     bubbleTwo.Play();
        //     bubbleThree.Play();
        //     bubbleFour.Play();
        // }

        }

    // Open the connection to the Arduino. Here we also want to set
    // the timeout to be 50 milliseconds so if there is no data being
    // sent from the Arduino Unity will not block and wait until it gets
    // data
    private void OpenConnection() {
        port.Open();
        port.ReadTimeout = 50;
        pStatus = PortStatus.Connected;
    }

    IEnumerator resetFishAndBubble(GameObject fishy)
    {

        // variable to change before fish go home
        yield return new WaitForSeconds(30);

        if (fishy == clownfish)
        {
            fishy.transform.position = fishOneStartPos;
            bubbleOne.Play();
            fishOneSwim = false;
        } else if (fishy == fishTwo)
        {
            fishy.transform.position = fishTwoStartPos;
            bubbleTwo.Play();
            fishTwoSwim = false;
        } else if (fishy == fishThree)
        {
            fishy.transform.position = fishThreeStartPos;
            bubbleThree.Play();
            fishThreeSwim = false;
        } else if (fishy == fishFour)
         {
            fishy.transform.position = fishFourStartPos;
            bubbleFour.Play();
            fishFourSwim = false;
        }
    }

        //move all fish to starting position
        void moveFishtoStart()
        {
        clownfish.transform.position = fishOneStartPos;
        fishTwo.transform.position = fishTwoStartPos;
        fishThree.transform.position = fishThreeStartPos;
        fishFour.transform.position = fishFourStartPos;
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

