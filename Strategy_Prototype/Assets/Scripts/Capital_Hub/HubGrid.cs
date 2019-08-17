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
        BuildGrid(gameObject.GetComponent<HubTopBehaviour>().x_size, gameObject.GetComponent<HubTopBehaviour>().x_size);
        DrawGrid();
    }

    void BuildGrid(float max_xf, float max_yf)
    {
        Vector3 zero_point = gameObject.transform.position + (new Vector3(-max_xf/2, 2f, -max_yf/2));
        grid_size_x = (int)(max_xf/grid_step) + 1;
        grid_size_y = (int)(max_yf/grid_step) + 1;
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

    void DrawGrid()
    {
        for (int i = 0; i < grid_size_x; i++)
        {
            Gizmos.color = Color.black;
            Vector3 From = listOfNodes.Find(x => ((x.x == i) && (x.y == 0))).real_position;
            Vector3 To = listOfNodes.Find(x => ((x.x == i) && (x.y == grid_size_y))).real_position;
            Gizmos.DrawLine(From, To);
        }
        for (int i = 0; i < grid_size_y; i++)
        {
            Gizmos.color = Color.black;
            Vector3 From = listOfNodes.Find(x => ((x.y == i) && (x.x == 0))).real_position;
            Vector3 To = listOfNodes.Find(x => ((x.y == i) && (x.y == grid_size_x))).real_position;
            Gizmos.DrawLine(From, To);
        }
    }
}
