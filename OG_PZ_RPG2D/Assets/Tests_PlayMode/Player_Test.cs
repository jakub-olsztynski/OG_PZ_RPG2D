using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class PlayerTests
{
     
    [Test]
    public void CalculatesNewPosition()
    {
        Player player = new Player();
        Assert.AreEqual(new Vector3(0,0,0),player.GetNewPosition(5,5), "Scale should be Vector3.one when moving right");
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