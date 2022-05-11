using UnityEngine;

public class DestroyTimer : MonoBehaviour
{ 
    [SerializeField] float timeLeft;

    public void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
            Destroy(this.gameObject);
    }
}