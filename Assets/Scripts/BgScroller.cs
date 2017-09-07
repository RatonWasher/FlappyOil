//Attach this to a gO containing two background renderer gO.
//Scrolls the children background and recycles them when they're out of camera view.
//The speed and direction (-1 for left and 1 for right) are determinable.

using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class BgScroller : MonoBehaviour
{

    public float speed = 10F;
    public float direction = -1F;

    private List<Transform> backgroundPart;
    private Vector2 repeatableSize;

    void Start()
    {
        // Get all part of the layer
        backgroundPart = new List<Transform>();

        for (int i = 0; i < transform.childCount; i++) {
            backgroundPart.Add(transform.GetChild(i));
        }

        // Sort by position, depends on the scrolling direction
        backgroundPart = backgroundPart.OrderBy(t => t.position.x * (-1 * direction)).ToList();

        // Get the size of the repeatable parts
        var first = backgroundPart.First();
        var last = backgroundPart.Last();

        repeatableSize = new Vector2(Mathf.Abs(last.position.x - first.position.x), 0);
    }

    void Update()
    {
        // Movement
        Vector3 movement = new Vector3(speed * direction, 0, 0);

        movement *= Time.deltaTime;
        transform.Translate(movement);


        // Camera borders
        var dist = (transform.position - Camera.main.transform.position).z;
        float leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
        float rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;

        // Determine entry and exit border using direction
        Vector3 exitBorder = Vector3.zero;
        Vector3 entryBorder = Vector3.zero;

        if (direction < 0)
        {
            exitBorder.x = leftBorder;
            entryBorder.x = rightBorder;
        }
        else if (direction > 0)
        {
            exitBorder.x = rightBorder;
            entryBorder.x = leftBorder;
        }

        // Get the first object
        Transform firstChild = backgroundPart.FirstOrDefault();

        if (firstChild != null)
        {
            bool checkVisible = false;

            // Check if we are after the camera
            // The check is on the position first as IsVisibleFrom is a heavy method
            // Here again, we check the border depending on the direction
            if (direction != 0)
            {
                if ((direction < 0 && (firstChild.position.x < exitBorder.x))
                || (direction > 0 && (firstChild.position.x > exitBorder.x)))
                {
                    checkVisible = true;
                }
            }

            // Check if the sprite is really visible on the camera or not
            if (checkVisible)
            {
                if (firstChild.GetComponent<Renderer>().IsVisibleFrom(Camera.main) == false)
                {
                    // Moving the out of camera background to the other side
                    firstChild.position = new Vector3(
                      firstChild.position.x + ((repeatableSize.x * 2) * -1 * direction),
                      firstChild.position.y,
                      firstChild.position.z
                    );

                    backgroundPart.Remove(firstChild);
                    backgroundPart.Add(firstChild);
                }
            }
        }
    }
}
