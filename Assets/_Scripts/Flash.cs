using UnityEngine;
using System.Collections;

public class Flash : MonoBehaviour 
{
    [SerializeField]private SpriteRenderer flash_sprite;
    [SerializeField]private GameObject scare_prefab;
    [SerializeField]private Transform Player;
    private bool flash;
    private bool scare;


    private void Start()
    {
        flash_sprite.enabled = false;   
        flash = false;
        scare = false;
    }

    private void Update()
    {
        if (!flash&&!scare)
        {
            StartCoroutine(FlashStar());
        }
        if (flash)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Safe");
            }
        }
        if (scare)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                CreateScare();
                Debug.Log("Scare");
            }
        }
    }

    IEnumerator FlashStar()
    {
        flash = true;
        flash_sprite.enabled = true;
        yield return new WaitForSeconds(0.25f); 
        flash_sprite.enabled = false;
        flash = false;

        scare = true;
        yield return new WaitForSeconds(1f);
        scare = false;
        yield return new WaitForSeconds(4f);
    }

    private void CreateScare()
    {
        Instantiate(scare_prefab, scare_prefab.transform.localPosition, Quaternion.identity);
    }
}
