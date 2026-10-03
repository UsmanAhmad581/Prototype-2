using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{   
    public InputAction moveAction;
    private Vector2 moveInput;
    public float moveSpeed = 5f;
    public float xRange = 20.5f;
    public float topRange = 18f;
    public float bottomRange = 0.5f;

 

    public InputAction fireAction;

    public GameObject projectilePrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction.Enable();
        fireAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {   
        if(transform.position.x < -xRange){
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if(transform.position.x > xRange){
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if(transform.position.z < bottomRange){
            transform.position = new Vector3(transform.position.x, transform.position.y, bottomRange);
        }
        if(transform.position.z > topRange){
            transform.position = new Vector3(transform.position.x, transform.position.y, topRange);
        }
        moveInput = moveAction.ReadValue<Vector2>();
        transform.Translate(Vector3.right * moveInput.x * moveSpeed * Time.deltaTime);
        transform.Translate(Vector3.forward * moveInput.y * moveSpeed * Time.deltaTime);

        if(fireAction.WasPressedThisFrame()){
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
