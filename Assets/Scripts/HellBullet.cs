using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.CanvasScaler;

public class HellBullet : MonoBehaviour
{
    // Вызывается при столкновении с другими объектами
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Проверяем, столкнулись ли с замком
        if (collision.gameObject.CompareTag("Castle"))
        {
            CastleHeatlh castleHeatlh;
            collision.gameObject.TryGetComponent(out castleHeatlh);
            //castleHeatlh.
            Destroy(gameObject);
        }
    }
}
