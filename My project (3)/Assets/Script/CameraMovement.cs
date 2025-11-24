using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour
{
    // ---------- 싱글톤 ----------
    public static CameraMovement Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<CameraMovement>();
                if (instance == null)
                {
                    var instanceContainer = new GameObject("CameraMovement");
                    instance = instanceContainer.AddComponent<CameraMovement>();
                }
            }
            return instance;
        }
    }
    private static CameraMovement instance;

    // ---------- 필드 ----------
    public GameObject Player;

    public float offsetY = 45f;
    public float offsetZ = -40f;

    private Vector3 cameraPosition;

    // ---------- Unity 콜백 ----------
    void LateUpdate()
    {
        if (Player == null)
            return;

        cameraPosition = transform.position;

        cameraPosition.y = Player.transform.position.y + offsetY;
        cameraPosition.z = Player.transform.position.z + offsetZ;

        transform.position = cameraPosition;
    }

    // 방을 옮길 때 X 축만 플레이어 쪽으로 이동시키는 함수로 보임
    public void CameraNextRoom()
    {
        if (Player == null)
            return;

        // //Fade in/out  (효과는 따로 구현)

        cameraPosition = transform.position;
        cameraPosition.x = Player.transform.position.x;

        transform.position = cameraPosition;
    }
}
