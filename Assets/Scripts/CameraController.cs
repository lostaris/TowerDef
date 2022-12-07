using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float panSpeed = 30f;
    public float panBoarderHeight = Screen.height / 10;
    public float panBoarderWidth = Screen.width / 10;

    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;

    private float leftLimitX = -20f;
    private float rightLimitX = 70f;
    private float upLimitZ = 40f;
    private float downLimitZ = -10f;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GameIsOver)
        {
            this.enabled = false;
        }


        /*
         *  checks for a key press or a mouse near the edge of the screen, if either is true will move the camera in that direstion
         *  has capped camera movement bounds
         * */

        if((Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBoarderHeight) &&
            transform.position.z < upLimitZ)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if ((Input.GetKey("s") || Input.mousePosition.y <=  panBoarderHeight) &&
            transform.position.z > downLimitZ)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if ((Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBoarderWidth) &&
            transform.position.x < rightLimitX)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if ((Input.GetKey("a") || Input.mousePosition.x <= panBoarderWidth) &&
            transform.position.x > leftLimitX)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }


        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;
        Mathf.Clamp(pos.x, -10f, 50f);
        Mathf.Clamp(pos.z, -10f, 50f);

        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }
}
