using System;

public static class Tools
{
    private static Random s_random = new();

    public static float Random(int min, int max) => 
        s_random.Next(min, max);
}