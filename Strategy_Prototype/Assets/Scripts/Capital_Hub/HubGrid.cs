using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct GridNode
{
    public int x;
    public int y;
    public Vector3 real_position;
}

[ExecuteInEditMode]
public class HubGrid : MonoBehaviour
{
    //Grid step
    public float grid_step;
    //Grid size (in nodes)
    public int grid_size_x;
    public int grid_size_y;
    //List of grid nodes (each element of the list has 2-dimensional coordinates)
    List<GridNode> listOfNodes = new List<GridNode>(1);
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (listOfNodes.Count != 0 ) listOfNodes.Clear();
        BuildGrid(gameObject.GetComponent<HubTopBehaviour>().x_size, gameObject.GetComponent<HubTopBehaviour>().y_size);
    }

    void BuildGrid(float max_xf, float max_yf)
    {
        Vector3 zero_point = gameObject.transform.position; 
        grid_size_x = (int)(max_xf/grid_step);
        grid_size_y = (int)(max_yf/grid_step);
        for (int i = 0; i <= grid_size_x; i++)
        {
            for (int j = 0; j <= grid_size_y; j++)
            {
                GridNode gridNodeToAdd = new GridNode();
                gridNodeToAdd.x = i;
                gridNodeToAdd.y = j;
                gridNodeToAdd.real_position = zero_point + (new Vector3(i*grid_step, 0, j*grid_step));
                listOfNodes.Add(gridNodeToAdd);
            }
        }
    }

    void DestroyGrid()
    {
        listOfNodes.Clear();
    }

    /// Callback to draw gizmos that are pickable and always drawn.
    void OnDrawGizmos()
    {
        for (int i = 0; i <= grid_size_x; i++)
        {
            Gizmos.color = Color.black;
            Vector3 From = listOfNodes.Find(node => ((node.x == i) && (node.y == 0))).real_position;
            Vector3 To = listOfNodes.Find(node => ((node.x == i) && (node.y == grid_size_y))).real_position;
            Gizmos.DrawLine(From, To);
        }
        for (int i = 0; i <= grid_size_y; i++)
        {
            Gizmos.color = Color.black;
            Vector3 From = listOfNodes.Find(node => ((node.y == i) && (node.x == 0))).real_position;
            Vector3 To = listOfNodes.Find(node => ((node.y == i) && (node.x == grid_size_x))).real_position;
            Gizmos.DrawLine(From, To);
        }
    }
    
}
