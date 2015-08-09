using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Resources;

namespace Engine
{
    public static class World
    {
        #region Declarations
        public static readonly List<Item> Items = new List<Item>();
        public static readonly List<Monster> Monsters = new List<Monster>();
        public static readonly List<Quest> Quests = new List<Quest>();
        public static readonly List<Location> Locations = new List<Location>();
        public static List<Bank> Banks = new List<Bank>();
        public static readonly List<Shop> Shops = new List<Shop>();


        public const int ITEM_ID_RUSTY_SWORD = 1;
        public const int ITEM_ID_RAT_TAIL = 2;
        public const int ITEM_ID_PIECE_OF_FUR = 3;
        public const int ITEM_ID_SNAKE_FANG = 4;
        public const int ITEM_ID_SNAKESKIN = 5;
        public const int ITEM_ID_CLUB = 6;
        public const int ITEM_ID_HEALING_POTION = 7;
        public const int ITEM_ID_SPIDER_FANG = 8;
        public const int ITEM_ID_SPIDER_SILK = 9;
        public const int ITEM_ID_ADVENTURER_PASS = 10;

        public const int MONSTER_ID_RAT = 1;
        public const int MONSTER_ID_SNAKE = 2;
        public const int MONSTER_ID_GIANT_SPIDER = 3;

        public const int QUEST_ID_CLEAR_ALCHEMIST_GARDEN = 1;
        public const int QUEST_ID_CLEAR_FARMERS_FIELD = 2;

        public const int BANK_ID_TOWN_SQUARE = 1;

        public const int SHOP_ID_TOWN_SQUARE = 1;

        public const int LOCATION_ID_HOME = 1;
        public const int LOCATION_ID_TOWN_SQUARE = 2;
        public const int LOCATION_ID_GUARD_POST = 3;
        public const int LOCATION_ID_ALCHEMIST_HUT = 4;
        public const int LOCATION_ID_ALCHEMISTS_GARDEN = 5;
        public const int LOCATION_ID_FARMHOUSE = 6;
        public const int LOCATION_ID_FARM_FIELD = 7;
        public const int LOCATION_ID_BRIDGE = 8;
        public const int LOCATION_ID_SPIDER_FIELD = 9;
        #endregion

        static World()
        {
            PopulateItems();
            PopulateMonsters();
            PopulateQuests();
            PopulateBanks();
            PopulateLocations();
        }

        private static void PopulateItems()
        {
            Items.Add(new Weapon(ITEM_ID_RUSTY_SWORD, Resources.Text.resRustySword, Resources.Text.resRustySwordPlural, 0, 5));
            Items.Add(new Item(ITEM_ID_RAT_TAIL, Resources.Text.resRatTail, Resources.Text.resRatTailPlural));
            Items.Add(new Item(ITEM_ID_PIECE_OF_FUR, Resources.Text.resPieceFur, Resources.Text.resPieceFurPlural));
            Items.Add(new Item(ITEM_ID_SNAKE_FANG, Resources.Text.resSnakeFang, Resources.Text.resSnakeFangPlural));
            Items.Add(new Item(ITEM_ID_SNAKESKIN, Resources.Text.resSnakeSkin, Resources.Text.resSnakeSkinPlural));
            Items.Add(new Weapon(ITEM_ID_CLUB, Resources.Text.resClub, Resources.Text.resClubPlural, 3, 10));
            Items.Add(new HealingPotion(ITEM_ID_HEALING_POTION, Resources.Text.resHealingPotion, Resources.Text.resHealingPotionPlural, 5));
            Items.Add(new Item(ITEM_ID_SPIDER_FANG, Resources.Text.resSpiderFang, Resources.Text.resSpiderFangPlural));
            Items.Add(new Item(ITEM_ID_SPIDER_SILK, Resources.Text.resSpiderSilk, Resources.Text.resSpiderSilkPlural));
            Items.Add(new Item(ITEM_ID_ADVENTURER_PASS, Resources.Text.resAdventurerPass, Resources.Text.resAdventurerPassPlural));
        }

        private static void PopulateMonsters()
        {
            Monster rat = new Monster(MONSTER_ID_RAT, Resources.Text.resRat, 5, 3, 10, 3, 3, 0);
            rat.LootTable.Add(new LootItem(ItemByID(ITEM_ID_RAT_TAIL), 75, false));
            rat.LootTable.Add(new LootItem(ItemByID(ITEM_ID_PIECE_OF_FUR), 75, true));

            Monster snake = new Monster(MONSTER_ID_SNAKE, Resources.Text.resSnake, 5, 3, 10, 3, 3, 60);
            snake.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SNAKE_FANG), 75, false));
            snake.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SNAKESKIN), 75, true));

            Monster giantSpider = new Monster(MONSTER_ID_GIANT_SPIDER, Resources.Text.resGiantSpider, 20, 5, 40, 10, 10, 0);
            giantSpider.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SPIDER_FANG), 75, true));
            giantSpider.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SPIDER_SILK), 25, false));

            Monsters.Add(rat);
            Monsters.Add(snake);
            Monsters.Add(giantSpider);
        }

        private static void PopulateQuests()
        {
            Quest clearAlchemistGarden =
                new Quest(
                    QUEST_ID_CLEAR_ALCHEMIST_GARDEN,
                    Resources.Text.resAlchemistGarden, Resources.Text.resAlchemistGardenInfo, 20, 10);

            clearAlchemistGarden.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_RAT_TAIL), 3));

            clearAlchemistGarden.RewardItem = ItemByID(ITEM_ID_HEALING_POTION);

            Quest clearFarmersField =
                new Quest(
                    QUEST_ID_CLEAR_FARMERS_FIELD,
                    Resources.Text.resFarmerField, Resources.Text.resFarmerFieldInfo, 20, 20);

            clearFarmersField.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_SNAKE_FANG), 3));

            clearFarmersField.RewardItem = ItemByID(ITEM_ID_ADVENTURER_PASS);

            Quests.Add(clearAlchemistGarden);
            Quests.Add(clearFarmersField);
        }

        public static void PopulateBanks()
        {

            Bank townSquareBank = new Bank(BANK_ID_TOWN_SQUARE, Resources.Text.strTownSquareBank, Resources.Text.strTownSquareBankDesc, 0);
            Banks.Add(townSquareBank);
            
        }

        public static void PopulateShops()
        {

        }

        private static void PopulateLocations()
        {
            // Create each location
            Location home = new Location(LOCATION_ID_HOME, Resources.Text.strHome, Resources.Text.strHomeDesc);

            Location townSquare = new Location(LOCATION_ID_TOWN_SQUARE, Resources.Text.strTownSquare, Resources.Text.strTownSquareDesc);
            townSquare.BankAvailableHere = BankByID(BANK_ID_TOWN_SQUARE);
            

            Location alchemistHut = new Location(LOCATION_ID_ALCHEMIST_HUT, Resources.Text.strAlchemistHut, Resources.Text.strAlchemistHutDesc);
            alchemistHut.QuestAvailableHere = QuestByID(QUEST_ID_CLEAR_ALCHEMIST_GARDEN);

            Location alchemistsGarden = new Location(LOCATION_ID_ALCHEMISTS_GARDEN, Resources.Text.strAlchemistGarden, Resources.Text.strAlchemistGardenDesc);
            alchemistsGarden.MonsterLivingHere = MonsterByID(MONSTER_ID_RAT);

            Location farmhouse = new Location(LOCATION_ID_FARMHOUSE, Resources.Text.strFarmhouse, Resources.Text.strFarmhouseDesc);
            farmhouse.QuestAvailableHere = QuestByID(QUEST_ID_CLEAR_FARMERS_FIELD);

            Location farmersField = new Location(LOCATION_ID_FARM_FIELD, Resources.Text.strFarmerField, Resources.Text.strFarmerFieldDesc);
            farmersField.MonsterLivingHere = MonsterByID(MONSTER_ID_SNAKE);

            Location guardPost = new Location(LOCATION_ID_GUARD_POST, Resources.Text.strGuardPost,Resources.Text.strGuardPostDesc, ItemByID(ITEM_ID_ADVENTURER_PASS));

            Location bridge = new Location(LOCATION_ID_BRIDGE, Resources.Text.strBridge, Resources.Text.strBridgeDesc);

            Location spiderField = new Location(LOCATION_ID_SPIDER_FIELD, Resources.Text.strForest, Resources.Text.strForestDesc);
            spiderField.MonsterLivingHere = MonsterByID(MONSTER_ID_GIANT_SPIDER);

            // Link the locations together
            home.LocationToNorth = townSquare;

            townSquare.LocationToNorth = alchemistHut;
            townSquare.LocationToSouth = home;
            townSquare.LocationToEast = guardPost;
            townSquare.LocationToWest = farmhouse;

            farmhouse.LocationToEast = townSquare;
            farmhouse.LocationToWest = farmersField;

            farmersField.LocationToEast = farmhouse;

            alchemistHut.LocationToSouth = townSquare;
            alchemistHut.LocationToNorth = alchemistsGarden;

            alchemistsGarden.LocationToSouth = alchemistHut;

            guardPost.LocationToEast = bridge;
            guardPost.LocationToWest = townSquare;

            bridge.LocationToWest = guardPost;
            bridge.LocationToEast = spiderField;

            spiderField.LocationToWest = bridge;

            // Add the locations to the static list
            Locations.Add(home);
            Locations.Add(townSquare);
            Locations.Add(guardPost);
            Locations.Add(alchemistHut);
            Locations.Add(alchemistsGarden);
            Locations.Add(farmhouse);
            Locations.Add(farmersField);
            Locations.Add(bridge);
            Locations.Add(spiderField);
        }

        public static Item ItemByID(int id)
        {
            foreach (Item item in Items)
            {
                if (item.ID == id)
                {
                    return item;
                }
            }

            return null;
        }

        public static Monster MonsterByID(int id)
        {
            foreach (Monster monster in Monsters)
            {
                if (monster.ID == id)
                {
                    return monster;
                }
            }

            return null;
        }

        public static Quest QuestByID(int id)
        {
            foreach (Quest quest in Quests)
            {
                if (quest.ID == id)
                {
                    return quest;
                }
            }

            return null;
        }

        public static Bank BankByID(int id)
        {
            foreach (Bank bank in Banks)
            {
                if (bank.ID == id)
                {
                    return bank;
                }
            }
            return null;
        }

        public static Shop ShopByID(int id)
        {
            foreach (Shop shop in Shops)
            {
                if (shop.ID == id)
                {
                    return shop;
                }
            }
            return null;
        }

        public static Location LocationByID(int id)
        {
            foreach (Location location in Locations)
            {
                if (location.ID == id)
                {
                    return location;
                }
            }

            return null;
        }


    }
}