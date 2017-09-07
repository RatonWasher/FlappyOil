//Attach this script to the gO containing some BgElements gOs.
//It makes the attached gO's children rotate.
//The rotation power is determinable.

using UnityEngine;
using System.Collections;

public class BgElementsRotator : MonoBehaviour
{

    public float rotatePower;



    void Update()
    {
        for (int i = 0; i < transform.childCount; i++) {
            transform.GetChild(i).transform.Rotate(new Vector3(0f, 0f, rotatePower) * Time.deltaTime);
        }
    }
}
