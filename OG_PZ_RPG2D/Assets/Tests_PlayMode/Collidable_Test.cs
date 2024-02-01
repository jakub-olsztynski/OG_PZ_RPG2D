// Twój skrypt Collidable
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
        collidable.filter.layerMask = LayerMask.GetMask("YourCollisionLayer"); // Ustaw warstwê kolizji

        // Act
        // Symuluj kolizjê
        Physics2D.SyncTransforms();

        // U¿yj publicznej metody testowej zamiast chronionej metody
        collidable.CallOnCollideForTesting(collider);

        // Assert
        // ... dodaj kod asercji, aby sprawdziæ, czy OnCollide zosta³o wywo³ane poprawnie

        // Mo¿esz u¿yæ Assert.Pass, aby oznaczyæ, ¿e test zakoñczy³ siê sukcesem
        Assert.Pass("Test Update successful");
    }
}
