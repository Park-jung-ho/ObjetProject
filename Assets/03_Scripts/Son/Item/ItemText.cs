using TMPro;
using UnityEngine;

public class ItemText : MonoBehaviour
{
    TextMeshProUGUI itemText; // 아이템의 TextMesh
    void Start()
    {
        itemText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        // 메인 카메라를 찾습니다. 만약 메인 카메라가 없다면, 에러를 방지하기 위해 리턴합니다.
        Camera mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("메인 카메라를 찾을 수 없습니다.");
            return;
        }

        // 카메라가 바라보는 방향을 가져옵니다.
        Vector3 cameraDirection = mainCamera.transform.forward;

        // 아이템의 Text를 카메라를 향하도록 회전시킵니다.
        itemText.transform.rotation = Quaternion.LookRotation(cameraDirection);
    }
}
