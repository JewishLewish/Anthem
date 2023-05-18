using System.Threading;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace Anthem.Items.MNPC
{

    public class Kanye : ModNPC
    {

        public int randitem = Main.rand.Next(ItemID.Count);

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

            while (true){
                if (Main.dayTime.Equals(0)) {
                    randitem = Main.rand.Next(ItemID.Count);
                }  
            }

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

            shop.item[nextSlot].SetDefaults(randitem , false);
            shop.item[nextSlot].value = 1;
            nextSlot++;

            

            shop.item[nextSlot].SetDefaults(ItemID.TinBow, false);
            shop.item[nextSlot].value = 500;          
            nextSlot++;

            if (NPC.downedBoss1)
            {
                shop.item[nextSlot].SetDefaults(ItemID.PlatinumBow, false);
                nextSlot++;
            }

            if (NPC.downedPlantBoss)
            {
                shop.item[nextSlot].SetDefaults(ItemID.ChlorophyteBullet, false); // chlorophyte bullets after plantera :)))
                shop.item[nextSlot].value = 5000;
                nextSlot++;
            }
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            return true;
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
                default:
                    return "Men";
            }
        }
    }
}