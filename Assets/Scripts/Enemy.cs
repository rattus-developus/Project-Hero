using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health = 100f;

    void Update()
    {
        if(health <= 0f)
        {
            Die(false);
        }
    }

    public void OnShot()
    {
        health -= 25f;

        Color newColor = GetComponent<SpriteRenderer>().color;
        newColor.a *= 0.8f;
        GetComponent<SpriteRenderer>().color = newColor;

        Color newAccent = transform.GetChild(0).GetComponent<SpriteRenderer>().color;
        newAccent.a *= 0.8f;
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = newAccent;
    }

    public void Die(bool byTouch)
    {
        EnemyManager.Instance.enemyCount--;

        if(byTouch) UIManager.Instance.touchKills++;
        else UIManager.Instance.eggKills++;

        UIManager.Instance.SetKills();

        Destroy(gameObject);
    }
}
