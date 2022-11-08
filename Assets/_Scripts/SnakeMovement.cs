using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{

    public List<Transform> bodyParts = new List<Transform>();

    public float minDistance = 0.25f;

    public int beginSize;
    
    public float speed = 1;
    public float rotationSpeed = 50;

    public GameObject bodyprefabs;

    private float dis;
    private Transform curBodyPart;
    private Transform PrevBodyPart;

    [SerializeField] private Transform cameraPosition;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < beginSize - 1; i++)
        {
            AddBodyPart();
        }
    }

    // Update is called once per frame
    void Update()
    {
        cameraPosition.position = bodyParts[0].transform.position;
        Move();

        if (Input.GetKey(KeyCode.Q))
            AddBodyPart();
    }

    private void Move()
    {

        float curspeed = speed;

        // if (Input.GetKey(KeyCode.W))
        // {
        //     curspeed *= 2;
        // }
      //  bodyParts[0].Translate(bodyParts[0].forward * curspeed * Time.smoothDeltaTime, Space.World);

        float Horizontal = Input.GetAxis("Horizontal");
        // if (Horizontal != 0)
        // {
            //bodyParts[0].Rotate(Vector3.up * rotationSpeed * Time.deltaTime * Mathf.Abs(Horizontal));
        //    float turn =  Vector3.up * rotationSpeed * Time.deltaTime * Mathf.Abs(Horizontal)
            float moveHorizontal = Input.GetAxis("Horizontal");

            Vector3 movements = new Vector3(moveHorizontal *rotationSpeed *  Time.deltaTime, 0, curspeed * Time.deltaTime );

            // bodyParts[0].transform.position += movements;
            bodyParts[0].gameObject.GetComponent<CharacterController>().Move( movements );

        
        // }
        for (int i = 1; i < bodyParts.Count; i++)
        {
            curBodyPart = bodyParts[i];
            PrevBodyPart = bodyParts[i - 1];

            dis = Vector3.Distance(PrevBodyPart.position,curBodyPart.position);

            Vector3 newpos = PrevBodyPart.position;

            newpos.y = bodyParts[0].position.y;

            float T = Time.deltaTime * dis / minDistance * curspeed;

            if (T > 0.5f)
                T = 0.5f;
            curBodyPart.position = Vector3.Slerp(curBodyPart.position, newpos, T);
            curBodyPart.rotation = Quaternion.Slerp(curBodyPart.rotation, PrevBodyPart.rotation, T);
        }
    }
    public void AddBodyPart()
    {
        //we add a bodyPart When we Collect a Bodypart 

        Transform newpart = (Instantiate (bodyprefabs, bodyParts[bodyParts.Count - 1].position, bodyParts[bodyParts.Count - 1].rotation) as GameObject).transform;

        newpart.SetParent(transform);

        bodyParts.Add(newpart);
    }

}

