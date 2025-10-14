using System.Collections;
using System.Numerics;
using Vector3 = UnityEngine.Vector3;

public class ChangePaddleSize : BasePowerUp
{
    public Vector3 sizeIncrease = Vector3.zero;
    public Vector3 minPaddleSize = new Vector3(0.1f, 0.1f, 0.4f);
    
    protected override void OnPickup()
    {
        base.OnPickup();
        
        print("Changing paddle size");
        
        Paddle p = FindAnyObjectByType<Paddle>();
        p.transform.localScale += sizeIncrease;
        
        Vector3 size = p.transform.localScale;
        if (size.x < minPaddleSize.x)
        {
            size.x = minPaddleSize.x;
        }
        
        if (size.y < minPaddleSize.y) 
        {
            size.y = minPaddleSize.y;
        }

        if (size.z < minPaddleSize.z)
        {
            size.z = minPaddleSize.z;
        }
        
        p.transform.localScale = size;
    }
}