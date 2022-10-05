using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    static Quaternion toQuaternion(Vector3 euler)
    {
        Quaternion q;
        float pitch = euler.y;
        float roll = euler.x;
        float yaw = euler.z;
        float t0 = Mathf.Cos(yaw * 0.5f);
        float t1 = Mathf.Sin(yaw * 0.5f);
        float t2 = Mathf.Cos(roll * 0.5f);
        float t3 = Mathf.Sin(roll * 0.5f);
        float t4 = Mathf.Cos(pitch * 0.5f);
        float t5 = Mathf.Sin(pitch * 0.5f);
        q.x = t0 * t3 * t4 - t1 * t2 * t5;
        q.y = t0 * t2 * t5 + t1 * t3 * t4;
        q.z = t1 * t2 * t4 - t0 * t3 * t5;
        q.w = t0 * t2 * t4 + t1 * t3 * t5;
        return q;
    }
    // public int aksi;
    public float speed;
    public int score;
    Vector3 kekanan;
    Vector3 kekiri;
    Vector3 keatas;
    Vector3 kebawah;
    Vector3 rotasiKekanan;
    Vector3 rotasiKekiri;

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "enemyTag") {
            Debug.Log ("Game over");
            Time.timeScale = 0;
        }
    }
    void OnCollisionStay2D(Collision2D coll) {
        if (coll.gameObject.tag == "coinTag") {
            Debug.Log ("Sedang Nabrak");
            
        }
    }
    void OnCollisionExit2D(Collision2D coll) {
        if (coll.gameObject.tag == "coinTag") {
            Debug.Log ("Sudah Nabrak");
            score++;
            Debug.Log ("menambah score" + score);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        kekanan = new Vector3(1,0,0);
        kekiri = new Vector3(-1,0,0);
        keatas = new Vector3(0,1,0);
        kebawah = new Vector3(0,-1,0);            
        rotasiKekanan = new Vector3(0,0,-1);
        rotasiKekiri = new Vector3(0,0,1); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("right")){
            transform.position = transform.position + (kekanan * speed * Time.deltaTime);
        }else if(Input.GetKey("left")){
            transform.position = transform.position + (kekiri * speed * Time.deltaTime);
        }else if(Input.GetKey("up")){
            transform.position = transform.position + (keatas * speed * Time.deltaTime);
        }else if(Input.GetKey("down")){
            transform.position = transform.position + (kebawah * speed * Time.deltaTime);
        }else if(Input.GetKey(KeyCode.D)){
            transform.rotation = transform.rotation * toQuaternion(rotasiKekanan * speed * Time.deltaTime);
        }else if(Input.GetKey(KeyCode.A)){
            transform.rotation = transform.rotation * toQuaternion(rotasiKekiri * speed * Time.deltaTime);
        }
        // switch (aksi) {
        //     case 0:
        //         //translasi ke kanan
        //         transform.position = transform.position + (kekanan * speed * Time.deltaTime);
        //         break;
        //     case 1:
        //         //translasi ke kiri
        //         transform.position = transform.position + (kekiri * speed * Time.deltaTime);
        //         break;
        //     case 2:
        //         //translasi ke atas
        //         transform.position = transform.position + (keatas * speed * Time.deltaTime);
        //         break;
        //     case 3:
        //         //translasi ke bawah
        //         transform.position = transform.position + (kebawah * speed * Time.deltaTime);
        //         break;
        //     case 4:
        //         //rotasi ke kanan
        //         transform.rotation = transform.rotation * toQuaternion(rotasiKekanan * speed * Time.deltaTime);
        //         break;
        //     case 5:
        //         //rotasi ke kiri
        //         transform.rotation = transform.rotation * toQuaternion(rotasiKekiri * speed * Time.deltaTime);
        //         break;
        // }        
    }
}
