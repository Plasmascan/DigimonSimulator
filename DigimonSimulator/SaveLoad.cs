﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.Json;

namespace DigimonSimulator
{
    public class SaveData
    {
        public Digimon digimon { get; set; }
        public bool isHost { get; set; }
        public int hostPort { get; set; }
        public int connectPort { get; set; }
        public string connectIP { get; set; }
    }
    public static class SaveLoad
    {
        static string keyString = "b14cahszi24e413hsz4e2ea2315ag4s3";
        public static void SerializeSaveData(DigimonGame game)
        {
            SaveData data = new SaveData();
            data.digimon = game.currentDigimon;
            data.isHost = game.isHost;
            data.hostPort = game.hostPort;
            data.connectIP = game.connectIP;
            data.connectPort = game.connectPort;
            //string jsonString = JsonSerializer.Serialize(data);
            string jsonString = SymmetricKeyEncryptionDecryption.EncryptString(keyString, JsonSerializer.Serialize(data));
            File.WriteAllText("saveFile.dig", jsonString);
        }

        public static bool DeserializeSaveData(DigimonGame game)
        {
            try
            {
                //string jsonString = File.ReadAllText("saveFile.dig");
                string jsonString = SymmetricKeyEncryptionDecryption.DecryptString(keyString, File.ReadAllText("saveFile.dig"));
                SaveData data = JsonSerializer.Deserialize<SaveData>(jsonString);
                Digimon loadDigimon = data.digimon;
                if (loadDigimon == null)
                {
                    throw new Exception();
                }
                loadDigimon.game = game;
                int evolutionTimeRemaining = loadDigimon.evolveTime;
                loadDigimon.SetupDigimon(loadDigimon.digimonID);
                loadDigimon.evolveTime = evolutionTimeRemaining;
                game.currentDigimon = loadDigimon;
                game.isHost = data.isHost;
                game.hostPort = data.hostPort;
                game.connectIP = data.connectIP;
                game.connectPort = data.connectPort;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
