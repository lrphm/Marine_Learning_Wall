using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ParticleSystem particleObject;

    // Start is called before the first frame update
    void Start()
    {
      //  particleObject = GetComponent<ParticleSystem>();
       // particleObject.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("pressed");
            particleObject.Stop();
            particleObject.Clear();

        }
    }
}
