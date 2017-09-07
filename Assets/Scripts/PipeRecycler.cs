//Attach this script to a gO with a 2DColl.
//When it touchs another gO with a 2DColl, modify the touched gO's parent's transform.
//Xpos and a range for random Ypos are determinable.

using UnityEngine;
using System.Collections;


public class PipeRecycler : MonoBehaviour
{

    public float NewX = 15.5F;
    public Vector2 Range_NewY = new Vector2(5F, 14F);



    void OnTriggerEnter2D(Collider2D collider){
        collider.gameObject.transform.parent.transform.position = new Vector3(NewX, Random.Range(Range_NewY[0], Range_NewY[1]), 0);
    }

}
