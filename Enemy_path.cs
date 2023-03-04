using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]

public class Enemy_path : MonoBehaviour
{
   
    [SerializeField] [Range(0f,5f)] public float speed;


    List<Node> path = new List<Node>();

    Grid_Manager grid_Manager_enemy_path;
    Pathfinder pathfinder_enemy_path;


    Enemy enemy;

    void OnEnable()
    {
        Return_Start();
        Recalculate_path(true);
    }

    void Awake()
    {
        enemy = GetComponent<Enemy>();
        grid_Manager_enemy_path = FindAnyObjectByType<Grid_Manager>();
        pathfinder_enemy_path = FindAnyObjectByType<Pathfinder>();
    }






    public void Speed_Dif()
    {
        speed+=.2f;
    }











    void Recalculate_path(bool resetPath)
    {

        Vector2Int coordinates_recalculate = new Vector2Int();


        if (resetPath)
        {
            coordinates_recalculate = pathfinder_enemy_path.Start_coordiantes;
        }
        else
        {
            coordinates_recalculate = grid_Manager_enemy_path.Get_coordinates_from_position(transform.position);
        }



        StopAllCoroutines();

        path.Clear();
        path = pathfinder_enemy_path.Get_newpath(coordinates_recalculate);

        StartCoroutine(Followpath());

    }







    void Finish_Path()
    {
        enemy.Steal();
        gameObject.SetActive(false);
    }














    void Return_Start()
    {
        transform.position = grid_Manager_enemy_path.Get_position_from_coordinates(pathfinder_enemy_path.Start_coordiantes);
    }


   IEnumerator Followpath()
    {
        for(int i=1; i<path.Count;i++)
        {
            Vector3 Start_pos = transform.position;
            Vector3 Finish_pos = grid_Manager_enemy_path.Get_position_from_coordinates(path[i].coordinates);
            float Travel_percentage = 0f;


            transform.LookAt(Finish_pos);

            while (Travel_percentage < 1f)
            {
                Travel_percentage += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(Start_pos, Finish_pos, Travel_percentage);
                yield return new WaitForEndOfFrame();
            }
        }

        Finish_Path();
    }






}
