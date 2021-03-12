using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMyAnimation : MonoBehaviour
{
    [SerializeField] private Animator myAnimationController;
    public enum MySign
    {
        Left,
        Right
    }

    public MySign currentMysign;

    IEnumerator LeftOpenDoorAnim()
    {
        Vector3 euler = transform.localEulerAngles;
        euler.z += 90;
        transform.localEulerAngles = euler;
        float timer = 0f;
        while(true)
        {
            timer += Time.deltaTime*.25f;
            transform.localRotation = Quaternion.Lerp(transform.localRotation,Quaternion.Euler(euler),timer);
            if (timer >= 1)
            {
                break;
            }
            yield return new WaitForEndOfFrame();
        }
    }
    IEnumerator RightOpenDoorAnim()
    {
        Vector3 euler = transform.localEulerAngles;
        euler.z -= 90;
        transform.localEulerAngles = euler;
        float timer = 0f;
        while (true)
        {
            timer += Time.deltaTime * .25f;
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(euler), timer);
            if (timer >= 1)
            {
                break;
            }
            yield return new WaitForEndOfFrame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        MovePlayer comp = other.GetComponent<MovePlayer>();
        if (comp)
        {
            comp.playerAnim.SetTrigger("isDoor");
            GetComponent<Collider>().enabled = false;
            //  myAnimationController.SetBool("playOpen", true);
            switch (currentMysign)
            {
                case MySign.Left:
                    StartCoroutine(RightOpenDoorAnim());
                    break;
                case MySign.Right:
                    StartCoroutine(LeftOpenDoorAnim());
                    break;
            }
        }
        

       /* if (other.CompareTag("Player"))
        {
            GetComponent<Collider>().enabled = false;
            //  myAnimationController.SetBool("playOpen", true);
            switch (currentMysign)
            {
                case MySign.Left:
                    StartCoroutine(RightOpenDoorAnim());
                    break;
                case MySign.Right:
                    StartCoroutine(LeftOpenDoorAnim());
                    break;
            }
           
        }*/
    }
}
