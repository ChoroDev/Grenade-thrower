using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManagerOnCollidable : BaseManager<TileManagerOnCollidable>
{
    #region Fields

    [SerializeField] Tilemap tilemap;
    [SerializeField] Tile tile;

    Vector3Int holdedPosition;
    Vector3Int unholdedPosition;

    #endregion


    #region Unity lifecycle

    void Update()
    {
#warning HERE IS WORKING WITH TILES (DESTROY AND PLACE) BUT I DROPPED THIS FOR A WHILE
        //ManageTile();
    }

    #endregion


    #region Private methods

    void ManageTile()
    {
        Vector3Int tilePositionInt = CalculateTilePosition();
        if (Input.GetMouseButtonDown(0))
        {
            holdedPosition = tilemap.WorldToCell(Camera.main.ScreenToViewportPoint(Input.mousePosition));
        }
        if (Input.GetMouseButtonUp(0))
        {
            unholdedPosition = tilemap.WorldToCell(Camera.main.ScreenToViewportPoint(Input.mousePosition));
            if (holdedPosition.Equals(unholdedPosition))
            {
                if (tilemap.HasTile(tilePositionInt))
                {
                    RemoveTile(tilePositionInt);
                }
                else
                {
                    PlaceTile(tilePositionInt, tile);
                }
            }
        }
    }


    private Vector3Int CalculateTilePosition()
    {
        Vector3 mousePositionRelativeToWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int mousePositionInt = tilemap.WorldToCell(mousePositionRelativeToWorld);
        mousePositionInt.z = 0;
        return mousePositionInt;
    }


    private void RemoveTile(Vector3Int tilePositionInt)
    {
        PlaceTile(tilePositionInt, null);
    }


    private void PlaceTile(Vector3Int tilePlacePositionInt, Tile tile)
    {
        tilemap.SetTile(tilePlacePositionInt, tile);
    }

    #endregion
}
