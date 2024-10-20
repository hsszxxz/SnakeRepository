using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LayerManager : MonoBehaviour
{
    private void Start()
    {
        Physics2D.IgnoreLayerCollision(8, 9);
    }
    public void EnableCollision(int layer1,int layer2)
    {
        Physics2D.IgnoreLayerCollision(layer1, layer2,false);
    }
}
