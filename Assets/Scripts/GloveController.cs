using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloveController : MonoBehaviour
{
    public Material gloveMaterial;

    // Start is called before the first frame update
    void Start()
    {
        PlayerController playerController = GetComponentInParent<PlayerController>();
        if (playerController.side == PlayerController.sideBoxer.Bleu)
        {
            gloveMaterial.color = Color.blue;
        }
        else
        {
            gloveMaterial.color = Color.red;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
