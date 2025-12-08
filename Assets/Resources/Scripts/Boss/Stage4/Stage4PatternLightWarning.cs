using UnityEngine;

public class Stage4PatternLightWarning: MonoBehaviour
{
    public GameObject lightDamage;
    private SpriteRenderer spriteRenderer;
    private float alphaValue = 1f;
    private Color currentColor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentColor = spriteRenderer.color;
        Invoke("LightDamage", 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        SetTransparency();
    }
    public void SetTransparency()
    {
        if (currentColor.a <= 0.8f)
        {
            alphaValue *= -1;
        }
        if (currentColor.a >= 0.2f)
        {
            alphaValue *= -1;
        }
        currentColor.a += alphaValue * Time.deltaTime;
        spriteRenderer.color = currentColor;
    }
    private void LightDamage()
    {
        GameObject lightDamge = Instantiate(lightDamage, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
