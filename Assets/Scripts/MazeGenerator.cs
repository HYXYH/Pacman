using UnityEngine;
using System.Collections;

public class MazeGenerator
{
    const int size = 20;
    const int fullfill = 100; // in %
    const int wallshort = 50;  // in %
    int[,] m = new int[size + 1, size + 1];
    // Random generator
    int[,] r = new int[2, size / 2 * size / 2];
    int h; // How many number in array;
    void initrandom()
    {
        int j = 0;
        for (int y = 2; y < size; y += 2)
            for (int x = 2; x < size; x += 2)
            {
                r[0, j] = x; r[1, j] = y; j++;
            }
        h = j - 1;
    }
    int getrandom(int x, int y)
    {
        int i = Random.Range(0, h - 1);
        x = r[0, i]; y = r[1, i];
        r[0, i] = r[0, h];
        r[1, i] = r[1, h];
        return h--;
    }
    int[,] Generate()
    {
        // Clear labirint
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                m[i, j] = 0;
            }
        }
        // Make border
        for (int i = 0; i <= size; i++)
        {
            m[0, i] = 1; m[size, i] = 1;
            m[i, 0] = 1; m[i, size] = 1;
        }
        initrandom();
        int startx = 0, starty = 0;
        while (getrandom(startx, starty) == 1)
        {
            if (m[starty, startx] == 1) continue;
            if (Random.Range(0, 100) > fullfill) continue;
            int sx = 0, sy = 0;
            do
            {
                sx = Random.Range(0, 3) - 1;
                sy = Random.Range(0, 3) - 1;
            } while (sx == 0 && sy == 0 || sx != 0 && sy != 0);
            while (m[starty, startx] == 0)
            {
                if (Random.Range(0, 100) > wallshort)
                { m[starty, startx] = 1; break; }
                m[starty, startx] = 1;
                startx += sx; starty += sy;
                m[starty, startx] = 1;
                startx += sx; starty += sy;
            }
        }
        return m;
    }
}
