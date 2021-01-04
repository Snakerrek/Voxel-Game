﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BiomeUtils
{
   public static Biome SelectBiome(Vector3 chunkPos)
    {
        float temperature = ChunkUtils.GenerateTemperature(chunkPos.x / World.chunkSize, chunkPos.z / World.chunkSize);
        float moisture = ChunkUtils.GenerateMoisture(chunkPos.x / World.chunkSize, chunkPos.z / World.chunkSize);
        Biome biome = new StandardBiome();

        if(temperature < 0.4f)
        {
            biome = new SnowBiome();
        }
        else
        {
            if(moisture < 0.5f && temperature > 0.5f)
            {
                biome = new DesertBiome();
            }
            else
            {
                biome = new StandardBiome();
            }
        }

        return biome;
    }
}
