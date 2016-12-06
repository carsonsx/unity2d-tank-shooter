using UnityEngine;
using System.Collections;

public class TankController : MonoBehaviour
{

    public GameObject aimPosition;
    public GameObject firePosition;
    public GameObject shellPrefab;

    private float screenZ = 0;

    void Start()
    {
        screenZ = Camera.main.WorldToScreenPoint(transform.position).z;
    }

    void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, 0, screenZ));

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 offset = GetMouseWorldPosition() - aimPosition.transform.position;
            transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg - 90);
            GameObject shell = GameObject.Instantiate(shellPrefab, firePosition.transform.position, transform.localRotation) as GameObject;
            shell.GetComponent<Rigidbody>().AddForce(50 * offset.x, 50 * offset.y, 0);
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenZ));
    }
}
