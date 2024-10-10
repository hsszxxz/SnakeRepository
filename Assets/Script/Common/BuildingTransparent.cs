using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class BuildingTransparent : MonoBehaviour
{
    public List<string> buildingTags;
    private List<GameObject[]> buildings;
    private void Start()
    {
        buildings = new List<GameObject[]>();
        Debug.Log(buildings);
        for (int i =0; i <buildingTags.Count;i++)
        {
            buildings.Add(GameObject.FindGameObjectsWithTag(buildingTags[i]));
        }
    }
    private void Update()
    {
        foreach (GameObject[] gos in buildings)
        {
            for (int i = 0; i < gos.Length; i++)
            {
                Transform go = gos[i].transform;
                float aFic = (float)Mathf.Max(0, Vector3.Distance(Camera.main.transform.position, go.position) - 7) / 4;
                float aFic2 = (float)Mathf.Max(0, Vector3.Distance(Camera.main.transform.position, go.position) - 7)/4;
                if (aFic < 1)
                {
                    Color oldColor = go.GetComponent<SpriteRenderer>().color;
                    Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, aFic);
                    go.GetComponent<SpriteRenderer>().color = newColor;
                }
            }
        }
        
    }
}
