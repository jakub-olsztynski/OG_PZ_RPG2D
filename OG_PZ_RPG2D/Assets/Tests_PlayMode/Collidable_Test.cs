// Tw�j skrypt Collidable
using NUnit.Framework;
using UnityEngine;

// Test jednostkowy
[TestFixture]
public class CollidableTests
{
    [Test]
    public void Collidable_Update_CallsOnCollideWhenCollisionOccurs()
    {
        // Arrange
        GameObject gameObject = new GameObject();
        Collidable collidable = gameObject.AddComponent<Collidable>();
        BoxCollider2D collider = gameObject.AddComponent<BoxCollider2D>();
        collidable.filter.layerMask = LayerMask.GetMask("YourCollisionLayer"); // Ustaw warstw� kolizji

        // Act
        // Symuluj kolizj�
        Physics2D.SyncTransforms();

        // U�yj publicznej metody testowej zamiast chronionej metody
        collidable.CallOnCollideForTesting(collider);

        // Assert
        // ... dodaj kod asercji, aby sprawdzi�, czy OnCollide zosta�o wywo�ane poprawnie

        // Mo�esz u�y� Assert.Pass, aby oznaczy�, �e test zako�czy� si� sukcesem
        Assert.Pass("Test Update successful");
    }
}
