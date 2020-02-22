using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload : MonoBehaviour
{
    [SerializeField]private Transform arrowPlaceholder;
    [SerializeField] private BoxCollider arrowPlaceholderCollider;
    // Start is called before the first frame update
    void Start()
    {
        arrowPlaceholder = gameObject.GetComponent<Transform>();
        arrowPlaceholderCollider = gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Arrow")
        {
            arrowPlaceholderCollider.enabled = false;
            other.attachedRigidbody.useGravity = false;
            other.attachedRigidbody.isKinematic = true;

            other.GetComponent<DetachObjectFromHand>().DoDetach();
            MoveArrow(other.transform);
        }
    }

    void MoveArrow(Transform arrow)
    {
        while(arrow.position != arrowPlaceholder.position)
        {
            float step = 0.02f * Time.deltaTime;
            arrow.position = Vector3.MoveTowards(arrow.position, arrowPlaceholder.position, step);
        }
        arrow.GetComponent<Rigidbody>().useGravity = true;
        arrow.GetComponent<Rigidbody>().useGravity = false;

    }
}
