using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
public class Singularity : MonoBehaviour
{
    //This is the main script which pulls the objects nearby
    [SerializeField] public float GRAVITY_PULL = 100f;
    public static float m_GravityRadius = 1f;

    void Awake() {
        m_GravityRadius = GetComponent<SphereCollider>().radius;

        if(GetComponent<SphereCollider>()){
            GetComponent<SphereCollider>().isTrigger = true;
        }
    }
    
    void OnTriggerStay (Collider other) {
        //if(other.attachedRigidbody && other.GetComponent<SingularityPullable>())
        if(!other.CompareTag("Ground")&& Vector3.Distance(transform.position, other.transform.position)>2f)
        {
            if (other.GetComponent<Rigidbody>()==null) { other.gameObject.AddComponent<Rigidbody>(); }
            other.gameObject.layer = 7;
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            float gravityIntensity = m_GravityRadius/ Vector3.Distance(transform.position, other.transform.position);
            other.GetComponent<Rigidbody>().AddForce((transform.position - other.transform.position) * gravityIntensity * other.attachedRigidbody.mass * GRAVITY_PULL * Time.smoothDeltaTime);
        }
    }
}
