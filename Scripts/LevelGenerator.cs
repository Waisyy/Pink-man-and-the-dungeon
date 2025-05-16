using UnityEngine.Tilemaps;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Tilemap groundTilemap;
    [SerializeField] private Tilemap wallsTilemap;
    [SerializeField] private Tilemap decorTilemap;

    [SerializeField] private TileBase groundTile;
    [SerializeField] private TileBase wallTile;
    [SerializeField] private TileBase torchTile; // Пример декора

    void Start()
    {
        GenerateLevel();
    }

    void GenerateLevel()
    {
        // Генерация пола
        for (int x = 0; x < 20; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                groundTilemap.SetTile(new Vector3Int(x, y, 0), groundTile);
            }
        }

        // Генерация стен
        for (int x = -1; x <= 20; x++)
        {
            wallsTilemap.SetTile(new Vector3Int(x, -1, 0), wallTile);
            wallsTilemap.SetTile(new Vector3Int(x, 10, 0), wallTile);
        }

        // Декорации (например, факелы)
        decorTilemap.SetTile(new Vector3Int(5, 5, 0), torchTile);
    }
}
