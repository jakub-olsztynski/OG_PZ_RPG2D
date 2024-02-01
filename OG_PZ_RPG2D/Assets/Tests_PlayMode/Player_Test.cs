using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class PlayerTests
{
     
    [Test]
    public void CalculatesNewPosition()
    {
        GameObject gameObject = new GameObject();
        //Collidable collidable = gameObject.AddComponent<Collidable>();
        // Player player = new Player();
        Player player = gameObject.AddComponent<Player>();
        BoxCollider2D collider = gameObject.AddComponent<BoxCollider2D>();
        //boxCollider = GetComponent<BoxCollider2D>();
        Assert.AreEqual(new Vector3(314,157,0),player.GetNewPosition(new Vector3(100,50,0),collider,(float)3.14), "Scale should be Vector3.one when moving right");
    }

    /*public void Player_FixedUpdate_MoveRight_ScaleIsOne()
    {
        // Arrange
        Player player1 = new Player();
        player1.
        GameObject playerObject = new GameObject();
        MockPlayer player = playerObject.AddComponent<MockPlayer>();
        BoxCollider2D collider = playerObject.AddComponent<BoxCollider2D>();
        playerObject.transform.position = Vector3.zero;

        // Act
        player.CallFixedUpdate();

        // Assert
        // Upewnij siê, ¿e skalowanie obiektu jest równe Vector3.one, gdy gracz porusza siê w prawo
        Assert.AreEqual(Vector3.one, playerObject.transform.localScale, "Scale should be Vector3.one when moving right");
    }

    [Test]
    public void Player_FixedUpdate_MoveLeft_ScaleIsFlipped()
    {
        // Arrange
        GameObject playerObject = new GameObject();
        MockPlayer player = playerObject.AddComponent<MockPlayer>();
        BoxCollider2D collider = playerObject.AddComponent<BoxCollider2D>();
        playerObject.transform.position = Vector3.zero;

        // Act
        Input.GetAxisRaw = axis => -1f; // Mock ruchu w lewo
        player.CallFixedUpdate();

        // Assert
        // Upewnij siê, ¿e skalowanie obiektu jest odwrócone, gdy gracz porusza siê w lewo
        Assert.AreEqual(new Vector3(-1, 1, 1), playerObject.transform.localScale, "Scale should be flipped when moving left");
    }*/

}