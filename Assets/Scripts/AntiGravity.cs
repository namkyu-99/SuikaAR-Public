using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiGravity : MonoBehaviour
{
    public float antiGravityForce = 9.8f; // 중력의 반대 방향으로 가할 힘의 크기

    void FixedUpdate()
    {
        // Rigidbody 컴포넌트를 가져옴
        Rigidbody rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            // 중력의 반대 방향으로 힘을 가함
            rb.AddForce(Vector3.up * antiGravityForce, ForceMode.Force);
        }
    }
}
