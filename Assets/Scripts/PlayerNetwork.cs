using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerNetwork : NetworkBehaviour
{
    [SerializeField] private float moveSpeed = 20f;

    private NetworkVariable<int> randomNumber = new NetworkVariable<int>(1);

    void Update()
    {
        if (!IsOwner) return;

        if (Input.GetKeyUp(KeyCode.T))
        {
            randomNumber.Value = Random.Range(0, 100);
        }

        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        transform.Translate(xValue, 0, zValue);
    }
}
