using UnityEngine;
using NUnit.Framework;

public class CameraFollowPlayerUnitTest
{
    [Test]
    public void Camera_DoesNotGoBelowMinbounds()
    {
        GameObject cameraObj = new GameObject();
        CameraFollowPlayer cam = cameraObj.AddComponent<CameraFollowPlayer>();
        cam.minBounds = new Vector2(0, 0);
        cam.maxBounds = new Vector2(10, 10);
        cam.TestClampPosition(new Vector3(-100, -100, 0));
        Assert.GreaterOrEqual(cameraObj.transform.position.x, 0);
        Assert.GreaterOrEqual(cameraObj.transform.position.y, 0);
    }

    [Test]
    public void Camera_DoesNotGoAboveMaxbounds()
    {
        GameObject cameraObj = new GameObject();
        CameraFollowPlayer cam = cameraObj.AddComponent<CameraFollowPlayer>();
        cam.minBounds = new Vector2(0, 0);
        cam.maxBounds = new Vector2(10, 10);
        cam.TestClampPosition(new Vector3(100, 100, 0));
        Assert.LessOrEqual(cameraObj.transform.position.x, 10);
        Assert.LessOrEqual(cameraObj.transform.position.y, 10);
    }
}