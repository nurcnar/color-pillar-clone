using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject food;
    public float speed;
    public List<GameObject> foods = new List<GameObject>();
    public List<GameObject> inHands = new List<GameObject>();
    int lastY;
    Color targetColor=Color.green;
    
    void Start()
    {

        //rb = GetComponent<Rigidbody>();
        rb.GetComponent<Renderer>().material.color = targetColor;
        StartCoroutine(Change());
        for (int i = 0; i < 30; i++)
        {
            int x = Random.Range(-4, 4);
            int z = Random.Range(4, 94);
            GameObject clone = Instantiate(food, new Vector3(x, 0, z ), Quaternion.identity);
            int r = Random.Range(0, 4);
            Color color = Color.white;
            switch(r)
            {
                case 0:
                    color = Color.green;
                    break;
                case 1:
                    color = Color.black;
                    break;
                case 2:
                    color = Color.yellow;
                    break;
                case 3:
                    color = Color.blue;
                    break;
            }
            clone.GetComponent<Renderer>().material.color = color;
            foods.Add(clone);
            //foods[i].GetComponent<Renderer>().material.color = Color.green;
        }
    }
    private void OnTriggerEnter(Collider food)
    {
        if (food.gameObject.CompareTag("food"))
        {
            if(food.GetComponent<Renderer>().material.color == targetColor)
            {
                inHands.Add(food.gameObject);
                foreach (var item in inHands)
                {
                    item.GetComponent<Renderer>().material.color = targetColor;
                }
                lastY++;
                ScoreManager.instance.AddScore();
                food.transform.parent = transform;
                food.transform.localPosition = Vector3.up * lastY;
            }
            else
            {
                //Destroy(food.gameObject);
                ScoreManager.instance.DecreaseScore();
            }
        }
    }
    IEnumerator Change()
    {
        while(true)
        {
            yield return new WaitForSeconds(5  );
            Color color = Color.white;
            int r = Random.Range(0, 4);
            switch (r)
            {
                case 0:
                    color = Color.green;
                    break;
                case 1:
                    color = Color.black;
                    break;
                case 2:
                    color = Color.yellow;
                    break;
                case 3:
                    color = Color.blue;
                    break;
            }
            targetColor = color;
            rb.GetComponent<Renderer>().material.color = targetColor;
        }
    }



    void FixedUpdate()
    {

        //rb.AddForce(movement * speed);
        //rb.velocity = Vector3.Lerp(rb.velocity, movement, Time.deltaTime * speed);
        //transform.Translate(Vector3.forward * 0.1f * Time.deltaTime*.1f);
        //transform.position += Vector3.forward * Time.deltaTime;
        //Vector3 movement = new Vector3(horizontal, 0, vertical);
        //rb.MovePosition(rb.position + movement * 8.0f)*/
        //transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, Time.deltaTime * 0.0001f);
        //transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * 0.3f);
        /*if(transform.position.x>-4 && Input.GetAxis("Horizontal")<0) //A->-1 D->+1 nothing->0
        {
            
            float amountToMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            transform.Translate(Vector3.right * amountToMove, Space.Self);
        }
        if(transform.position.x <4 && Input.GetAxis("Horizontal") >0)
        {
            float amountToMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            transform.Translate(Vector3.right * amountToMove, Space.Self);
        }*/
        transform.Translate(0, 0, 1 * speed * Time.deltaTime);//getle senden aldığı konumu gönderiyor, set etmiyo sana bişi vermiyor, alıyo senden, verilen vectorü sana ekliyo o konuma götürmüyo seni, öteleme yapıyor, ekleme 
        float xPos = Mathf.Clamp(transform.position.x, -4, 4);
        float zPos = Mathf.Clamp(transform.position.z, -4, 94);
        transform.position = new Vector3(xPos, 0, zPos);
        float amountToMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(Vector3.right * amountToMove, Space.Self);
    }

    
}