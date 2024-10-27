using enemy;
using Fungus;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class FungusController : MonoSingleton<FungusController>
{
    public Flowchart flowchart;
    private void Start()
    {
        flowchart.ExecuteBlock("µº»Î");
   }
    public void StartBlock(string blockName)
    {
        flowchart.ExecuteBlock(blockName);
    }
}

