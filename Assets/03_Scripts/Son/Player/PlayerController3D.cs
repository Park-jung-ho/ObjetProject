using UnityEngine;

public class PlayerController3D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sensitivity = 500f;
    public float rotationX = 0f;
    public float rotationY = 90f;
    public float rotateLimit = 45f;
    private Rigidbody rb;
    public bool isTalk;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked; // 마우스 커서를 고정
        Cursor.visible = false; // 마우스 커서를 숨김
        rb.constraints = RigidbodyConstraints.FreezeRotation; // 오브젝트의 회전을 막음
        isTalk = false;
    }

    void Update()
    {
        if(!isTalk){
            MovePlayer(); // 플레이어 이동 함수 호출
            RotateView(); // 시야 회전 함수 호출
        }
        if(isTalk){
            if(Input.GetMouseButtonDown(0)) DialogManager.instance.OnClick();
            // 현재 마우스의 위치를 가져옵니다.
            Vector3 mousePosition = Input.mousePosition;

        }
    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
        Vector3 newPosition = rb.position + transform.TransformDirection(movement);
        rb.MovePosition(newPosition);
    }

    void RotateView()
    {
        float mouseMoveX = Input.GetAxis("Mouse X");
        float mouseMoveY = Input.GetAxis("Mouse Y");
        rotationY += mouseMoveX * sensitivity * Time.deltaTime;
        rotationX += mouseMoveY * sensitivity * Time.deltaTime;

        rotationX = Mathf.Clamp(rotationX, -rotateLimit, rotateLimit); // 시야 각도 제한

        transform.eulerAngles = new Vector3(-rotationX, rotationY, 0);
    }
}