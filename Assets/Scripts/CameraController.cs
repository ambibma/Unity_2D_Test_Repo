using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    public Transform target;

    //parallaxing effect for background element, background scrolling

    public Transform farBackground, middleBackground;
    private float lastXPos;


    public float minHeight, maxHeight;

    // Start is called before the first frame update
    void Start()
    {
        lastXPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        //camera following target
        /*transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        float clampedY = Mathf.Clamp(transform.position.y, minHeight, maxHeight);
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z); */

        transform.position = new Vector3(target.position.x, Mathf.Clamp(transform.position.y, minHeight, maxHeight), transform.position.z);

        //parallaxing
        float amountToMoveX = transform.position.x - lastXPos;
        farBackground.position += new Vector3(amountToMoveX, 0f, 0f);
        middleBackground.position += new Vector3((amountToMoveX * .5f), 0f, 0f);
        lastXPos = transform.position.x;
    }
}
