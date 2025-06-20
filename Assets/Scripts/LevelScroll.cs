using UnityEngine;

public class LevelScroll : MonoBehaviour
{
    [SerializeField]float scrollSpeed = 5;

    void Update()
    {
        transform.position += Vector3.left * scrollSpeed * Time.deltaTime;
    }
}
