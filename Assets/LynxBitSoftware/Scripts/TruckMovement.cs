using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMovement : MonoBehaviour
{
    public Vector3 initPos;
    public CarController car;
    public bool startAnim = false;
    // Start is called before the first frame update
    void Start()
    {
        initPos = this.gameObject.transform.position;   
    }

    // Update is called once per frame
    void Update()
    {
        if (startAnim) {
            startAnim = false;
            StartCoroutine(Move());
        }
    }

    public IEnumerator Move()
    {
        while (this.gameObject.transform.position != initPos + new Vector3(-5,0))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, initPos + new Vector3(-5, 0), Time.deltaTime * 1);
            yield return null;
        }
        StartCoroutine(ReturnToInitPos());
    }
    IEnumerator ReturnToInitPos()
    {
        this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
        while (this.gameObject.transform.position != initPos)
        {
            
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, initPos, Time.deltaTime * 1);
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        car.canStack = true;
        this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
    }
}
