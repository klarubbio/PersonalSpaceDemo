using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{
    public float speed = 0;
    public float horizontalInput;
    public float verticalInput;
    public GameObject restricted;
    public GameObject arm;


    // Start is called before the first frame update
    void Start()
    {
        arm.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);

        if(Vector3.Distance(transform.position, restricted.transform.position) < 2)
        {
            transform.Translate(-Vector3.forward * speed * verticalInput * Time.deltaTime);
            transform.Translate(-Vector3.right * speed * horizontalInput * Time.deltaTime);
        }
        
        if (arm.activeSelf)
        {
            Debug.Log("arm active");
            arm.transform.position = new Vector3(transform.position.x, 0.75f, transform.position.z + 0.75f);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (!arm.activeSelf)
                arm.SetActive(true);
        }
            
    }

    
}
