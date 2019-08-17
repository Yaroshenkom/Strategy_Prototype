using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class HubTopBehaviour : MonoBehaviour
{
    //Size of the playable hub space (in meters)
    public int x_size;
    public int y_size;

    //Reference to the floor prototype object
    private GameObject prototype_floor = null;


    // Awake is called when the script instance is being loaded.
    void Awake()
    {
        prototype_floor = gameObject.transform.Find("Floor").gameObject;
        prototype_floor.GetComponent<Renderer>().sharedMaterial.color = new Color(127, 127, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Scale the cube prototype depending on the x_size and y_size variables
        prototype_floor.transform.localScale = new Vector3(x_size, prototype_floor.transform.localScale.y , y_size);
        prototype_floor.transform.position = new Vector3((float)x_size/2, prototype_floor.transform.position.y, (float)y_size/2);
    }
}
