﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Anthem.Items.MNPC
{
    [AutoloadHead]
    public class Kanye : ModNPC
    {


        public int randitem = Main.rand.Next(ItemID.Count);
        public bool wasDayTime = false;

        public override void SetStaticDefaults()
        {
            
            DisplayName.SetDefault("Kanye");
            Main.npcFrameCount[NPC.type] = 26;
            NPCID.Sets.AttackFrameCount[NPC.type] = 5;
            NPCID.Sets.DangerDetectRange[NPC.type] = 500;
            NPCID.Sets.AttackType[NPC.type] = 1;
            NPCID.Sets.AttackTime[NPC.type] = 45;
            NPCID.Sets.AttackAverageChance[NPC.type] = 30;
            NPCID.Sets.HatOffsetY[NPC.type] = -6;
        }

        public override List<string> SetNPCNameList()
        {
            return new List<string>()
            {
                "Kanye"
            };
        }

        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 18;
            NPC.height = 40;
            NPC.aiStyle = 7;
            NPC.damage = 10;
            NPC.defense = 50;
            NPC.lifeMax = 1000;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            AnimationType = NPCID.Steampunker;
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "Shop";
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                shop = true;
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {

            if(!wasDayTime && Main.dayTime) {
                randitem = Main.rand.Next(ItemID.Count);
            }
            wasDayTime = Main.dayTime;



            shop.item[nextSlot].SetDefaults(randitem , false);
            shop.item[nextSlot].value = 1;
            nextSlot++;

            if (NPC.downedBoss1)
            {
                shop.item[nextSlot].SetDefaults(ItemID.DemoniteOre, false);
                nextSlot++;
            }

            if (NPC.downedBoss2) {
                shop.item[nextSlot].SetDefaults(ItemID.ShadowScale, false);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.TissueSample, false);
                nextSlot++;
            }

            if (NPC.downedBoss3) {
                shop.item[nextSlot].SetDefaults(ItemID.Obsidian, false);
                shop.item[nextSlot].value = 5000;
                nextSlot++;
            }

            if (NPC.downedPlantBoss)
            {
                shop.item[nextSlot].SetDefaults(ItemID.ChlorophyteBullet, false); // chlorophyte bullets after plantera :)))
                shop.item[nextSlot].value = 5000;
                nextSlot++;
            }

            if (NPC.downedDeerclops) {
                shop.item[nextSlot].SetDefaults(ItemID.PewMaticHorn, false); // chlorophyte bullets after plantera :)))
                shop.item[nextSlot].value = 10000;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.WeatherPain, false); // chlorophyte bullets after plantera :)))
                shop.item[nextSlot].value = 10000;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.HoundiusShootius, false); // chlorophyte bullets after plantera :)))
                shop.item[nextSlot].value = 10000;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.LucyTheAxe, false); // chlorophyte bullets after plantera :)))
                shop.item[nextSlot].value = 10000;
                nextSlot++;

            }
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            return true;
        }

         public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (NPC.CountNPCS(ModContent.NPCType<Kanye>()) >= 1)
            {
                return 0;
            }
            return 1.0f;
        }

        public override string GetChat()
        {
            NPC.FindFirstNPC(ModContent.NPCType<Kanye>());
            switch (Main.rand.Next(3))
            {
                case 0:
                    return "Runaway.";
                case 1:
                    return "I am jumping out of the window";
                case 2:
                    return "I love you Jessie";
                case 3:
                    return "Bean is my main man";
                default:
                    return "Men";
            }
        }
    }
}