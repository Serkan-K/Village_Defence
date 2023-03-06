using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Path : MonoBehaviour
{
    [SerializeField] Tower Tower_prefab;

    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; }  }


    Grid_Manager grid_Manager_tile;
    Pathfinder pathfinder_tile;
    Vector2Int coordiantes_tile = new Vector2Int();



    void Awake()
    {
        grid_Manager_tile = FindAnyObjectByType<Grid_Manager>();
        pathfinder_tile = FindAnyObjectByType<Pathfinder>();
    }


    void Start()
    {
        if (grid_Manager_tile != null)
        {
            coordiantes_tile = grid_Manager_tile.Get_coordinates_from_position(transform.position);

            if (!isPlaceable)
            {
                grid_Manager_tile.BlockNode(coordiantes_tile);
            }
        }    
    }



    void OnMouseDown()
    {
        if (grid_Manager_tile.GetNode(coordiantes_tile).isWalkable &&!pathfinder_tile.Tower_block_path(coordiantes_tile))
        {
            bool isSuccesful= Tower_prefab.Tower_Spawn(Tower_prefab, transform.position);

            if (isSuccesful)
            {
                grid_Manager_tile.BlockNode(coordiantes_tile);
                pathfinder_tile.Notify_receivers();
            }
            
        }
    }
}
 