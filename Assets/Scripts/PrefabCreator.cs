//Attach this script to a global scripting purpose gO.
//It creates some prefabs at given position, in a given parent gO.
//The prefab, the containing gO, different Xpos and a range for random Ypos are determinable.
//There are as prefabs created as Xpos determinated.
//Scale and Rotation can be randomized if desired.

using UnityEngine;
using System.Collections;


public class PrefabCreator : MonoBehaviour
{

    public Transform PrefabToCreate;
    public Transform gOToPutPrefabs;

    public int[] Xpos = {};
    public Vector2 Range_Ypos = new Vector2();

    public bool randScale;
    public bool randRotation;

    private float parent_Zpos;
    private GameObject new_gO;



    void Awake()
    {
        parent_Zpos = gOToPutPrefabs.transform.position.z;

        for (int x = 0; x < Xpos.Length; x++)
        {
            new_gO = ((Transform)Instantiate(PrefabToCreate, new Vector3(Xpos[x], Random.Range(Range_Ypos[0], Range_Ypos[1]), parent_Zpos), Quaternion.identity)).gameObject;
            new_gO.transform.parent = gOToPutPrefabs;

            if (randRotation) {
                new_gO.transform.Rotate(new Vector3 (0f, 0f, Random.Range(0f, 360f)));
            }

            if (randScale) {
                float newScale = Random.Range(0.5f, 1.5f);
                new_gO.transform.localScale = new Vector3(newScale, newScale, new_gO.transform.position.z);
            }
        }
    }

}
