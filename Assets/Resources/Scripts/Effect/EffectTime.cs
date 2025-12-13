using UnityEngine;

public class EffectTime : MonoBehaviour
{
    public float effectTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, effectTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
