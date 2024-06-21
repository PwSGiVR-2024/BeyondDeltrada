using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapMennager : MonoBehaviour
{
    private static MapMennager _instance;

    public static MapMennager Instance
    {
        get
        {
            return _instance;
        }
    }

    public GameObject overlayTilePrefab;
    public GameObject overlayContainer;
    public Dictionary<Vector2Int, GameObject> map;
    public bool ignoreBottomTiles;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        var tilemap = gameObject.GetComponentInChildren<Tilemap>();

        BoundsInt boundsInt = tilemap.cellBounds;
        for (int z = boundsInt.max.z; z >= boundsInt.min.z; z--)
        {
            for (int y = boundsInt.min.y; y < boundsInt.max.y; y++)
            {
                for (int x = boundsInt.min.x; x < boundsInt.max.x; x++)
                {
                    var tileLocation = new Vector3Int(x, y, z);
                    var tilekey = new Vector2Int(x, y);
                    if (tilemap.HasTile(tileLocation) && !map.ContainsKey(tilekey))
                    {
                        var overlayTile = Instantiate(overlayTilePrefab, overlayContainer.transform);
                        var cellWorldPosition = tilemap.GetCellCenterWorld(tileLocation);
                        overlayTile.transform.position = new Vector3(cellWorldPosition.x, cellWorldPosition.y, cellWorldPosition.z+1);
                        overlayTile.GetComponent<SpriteRenderer>().sortingOrder = tilemap.GetComponent<TilemapRenderer>().sortingOrder;
                        map.Add(tilekey, overlayTile);
                    }
                }
            }
        }
    }
}
