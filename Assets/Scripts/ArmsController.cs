using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmsController : MonoBehaviour
{
    public enum armSide
    {
        Gauche, Droit
    };

    public armSide side;

    private Vector3 initialPosition; // Stockage des positions de départ des bras sur le corps
    private Quaternion initialRotation; // Stockage des rotations de départ des bras sur le corps
    private Vector3 tmpPos; // Manipulation avec des nouvelles valeurs pour les bras

    private bool isInvoking = false;
    private float animationPunchDelay = 1.0f;
    private float armLengthForPunch = 12.0f;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerController playerController = GetComponentInParent<PlayerController>();
        if (playerController.side != PlayerController.sideBoxer.Bleu)
        {
            if (Input.GetKeyDown(KeyCode.F) && side == armSide.Gauche && !isInvoking)
            {
                RotateArm();
                //MoveArm();
                Invoke("ResetArm", animationPunchDelay);
            }

            if (Input.GetKeyDown(KeyCode.G) && side == armSide.Droit && !isInvoking)
            {
                RotateArm();
                //MoveArm();
                Invoke("ResetArm", animationPunchDelay);
            }
        }
    }

    void RotateArm()
    {
        Debug.Log("RORATETEETTET");
        transform.Rotate(Vector3.forward * 90f);
    }

    void MoveArm()
    {
        isInvoking = true;
        //tmpPos = transform.position;
        //Debug.Log(tmpPos);
        //tmpPos.z += -0.7f;
        //tmpPos.x = 0.1f;
        //transform.position = tmpPos;
        transform.Translate(Vector3.right * Time.deltaTime * armLengthForPunch);
    }

    void ResetArm()
    {
        isInvoking = false;
        //transform.position = initialPosition;
        //transform.position = new Vector3(initialPosition.x, initialPosition.y, 0);
        //transform.position = new Vector3(0, 0, 0);
        transform.rotation = initialRotation;
    }
}
