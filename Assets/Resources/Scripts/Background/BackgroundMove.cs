using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    public float moveSpeed = 100f;
    private bool OnOff = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        if (transform.position.x <= 0 && OnOff)
        {
            ReGeneration();
            OnOff = false;
        }
        if (transform.position.y <= -1800)
        {
            Destroy(gameObject);
        }
    }
    private void ReGeneration()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        float objectWidth = spriteRenderer.bounds.size.x;
        Vector2 nextPos = transform.position;
        nextPos.x = nextPos.x + objectWidth;
        GameObject BackGround = Instantiate(gameObject, nextPos, transform.rotation);
    }
}
