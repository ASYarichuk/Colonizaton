using UnityEngine;

public class MapSize : MonoBehaviour
{
    private int _mapSizeMinX = -64;
    private int _mapSizeMaxX = 107;
    private int _mapSizeMinZ = -10;
    private int _mapSizeMaxZ = 55;

    public int GiveMapSizeMinX()
    {
        return _mapSizeMinX;
    } 
    
    public int GiveMapSizeMaxX()
    {
        return _mapSizeMaxX;
    }   
    
    public int GiveMapSizeMinZ()
    {
        return _mapSizeMinZ;
    }    
    
    public int GiveMapSizeMaxZ()
    {
        return _mapSizeMaxZ;
    }
}
