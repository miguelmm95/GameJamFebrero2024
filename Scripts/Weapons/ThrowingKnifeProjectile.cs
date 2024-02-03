using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingKnifeProjectile : MonoBehaviour
{

    Vector3 direction;
    [SerializeField] float speed;
    [SerializeField] float baseDamage = 5;

    public void SetDirection(float dir_x, float dir_y)
    {
        direction = new Vector3(dir_x, dir_y);

        if(dir_x < 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = scale.x * -1;
            transform.localScale = scale;
        }
    }

    bool hitDetected = false;
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        if(Time.frameCount % 6 == 0)
        {
            Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, 0.7f);

            foreach (Collider2D e in hit)
            {
                Enemy enemy = e.GetComponent<Enemy>();

                if (enemy != null)
                {
                    enemy.TakeDamage(baseDamage);
                    hitDetected = true;
                    break;
                }
            }

            if (hitDetected)
            {
                Destroy(gameObject);
            }
        }
    }
}
