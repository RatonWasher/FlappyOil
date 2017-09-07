using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class Scrolling : MonoBehaviour
{

    public float speed = 10f;
    public float direction = -1f;



    void Update() {
        Vector3 movement = new Vector3(speed * direction, 0, 0) * Time.deltaTime;
        transform.Translate(movement);
    }
}
