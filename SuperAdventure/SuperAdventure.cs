using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using Engine;
using System.Reflection;

namespace SuperAdventure
{
    public partial class SuperAdventure : Form
    {
        #region Declarations
        private Player _player;
        private Monster _currentMonster;

        private const string PLAYER_DATA_FILE_NAME = "PlayerData.xml";
        #endregion

        ResourceManager RmLoc = new ResourceManager("SuperAdventure.Strings", typeof(SuperAdventure).Assembly);

        public SuperAdventure()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr-FR");

            InitializeComponent();
            

            if (File.Exists(PLAYER_DATA_FILE_NAME))
            {
                _player = Player.CreatePlayerFromXmlString(File.ReadAllText(PLAYER_DATA_FILE_NAME));
            }
            else
            {
                _player = Player.CreateDefaultPlayer();
            }
            MoveTo(_player.CurrentLocation);
            UpdatePlayerStats();
        }

        private void btnNorth_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToNorth);
        }

        private void btnEast_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToEast);
        }

        private void btnSouth_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToSouth);
        }

        private void btnWest_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToWest);
        }

        private void MoveTo(Location newLocation)
        {

            //Does the location have any required items
            if (!_player.HasRequiredItemToEnterThisLocation(newLocation))
            {
                rtbMessages.Text += RmLoc.GetString("strPlayerMustHave") + newLocation.ItemRequiredToEnter.Name + RmLoc.GetString("strPlayerToEnter") + Environment.NewLine;
                ScrollToBottomOfMessages();
                return;
            }

            // Update the player's current location
            _player.CurrentLocation = newLocation;

            // Show/hide available movement buttons
            btnNorth.Visible = (newLocation.LocationToNorth != null);
            btnEast.Visible = (newLocation.LocationToEast != null);
            btnSouth.Visible = (newLocation.LocationToSouth != null);
            btnWest.Visible = (newLocation.LocationToWest != null);

            // Display current location name and description
            rtbLocation.Text = newLocation.Name + Environment.NewLine;
            rtbLocation.Text += newLocation.Description + Environment.NewLine;
            
            pnBank.Visible = (newLocation.BankAvailableHere != null);
            if (newLocation.BankAvailableHere != null)
            {
                Bank bank = World.BankByID( newLocation.BankAvailableHere.ID);
                if(bank.AvailableGold != 0)
                { 
                    txtAvailableGold.Text = bank.AvailableGold.ToString();
                }
                else
                {
                    txtAvailableGold.Text = "0";
                }
                rtbLocation.Text += RmLoc.GetString("strPlayerSeeA") + bank.Name+ Environment.NewLine;
                ScrollToBottomOfMessages();
            }

            
            // Completely heal the player
            _player.CurrentHitPoints = _player.MaximumHitPoints;

            // Update Hit Points in UI
            lblHitPoints.Text = _player.CurrentHitPoints.ToString();

            // Does the location have a quest?
            if (newLocation.QuestAvailableHere != null)
            {
                // See if the player already has the quest, and if they've completed it
                bool playerAlreadyHasQuest = _player.HasThisQuest(newLocation.QuestAvailableHere);
                bool playerAlreadyCompletedQuest = _player.CompletedThisQuest(newLocation.QuestAvailableHere);

                // See if the player already has the quest
                if (playerAlreadyHasQuest)
                {
                    // If the player has not completed the quest yet
                    if (!playerAlreadyCompletedQuest)
                    {
                        // See if the player has all the items needed to complete the quest
                        bool playerHasAllItemsToCompleteQuest = _player.HasAllQuestCompletionItems(newLocation.QuestAvailableHere);

                        // The player has all items required to complete the quest
                        if (playerHasAllItemsToCompleteQuest)
                        {
                            // Display message
                            rtbMessages.Text += Environment.NewLine;
                            rtbMessages.Text += RmLoc.GetString("strQuestComplete")+ newLocation.QuestAvailableHere.Name + Environment.NewLine;

                            ScrollToBottomOfMessages();
                            // Remove quest items from inventory
                            _player.RemoveQuestCompletionItems(newLocation.QuestAvailableHere);

                            // Give quest rewards
                            rtbMessages.Text += RmLoc.GetString("strRewardReceive") + Environment.NewLine;
                            rtbMessages.Text += newLocation.QuestAvailableHere.RewardExperiencePoints.ToString() + RmLoc.GetString("strRewardExperience") + Environment.NewLine;
                            rtbMessages.Text += newLocation.QuestAvailableHere.RewardGold.ToString() + RmLoc.GetString("strRewardGold") + Environment.NewLine;
                            rtbMessages.Text += newLocation.QuestAvailableHere.RewardItem.Name + Environment.NewLine;
                            rtbMessages.Text += Environment.NewLine;
                            ScrollToBottomOfMessages();

                            _player.ExperiencePoints += newLocation.QuestAvailableHere.RewardExperiencePoints;
                            _player.Gold += newLocation.QuestAvailableHere.RewardGold;

                            // Add the reward item to the player's inventory
                            _player.AddItemToInventory(newLocation.QuestAvailableHere.RewardItem);

                            // Mark the quest as completed
                            _player.MarkQuestCompleted(newLocation.QuestAvailableHere);
                            lblExperience.Text = _player.ExperiencePoints.ToString();
                        }
                    }
                }
                else
                {
                    // The player does not already have the quest

                    // Display the messages
                    rtbMessages.Text += RmLoc.GetString("strQuestReceive") + newLocation.QuestAvailableHere.Name + Environment.NewLine;
                    rtbMessages.Text += newLocation.QuestAvailableHere.Description + Environment.NewLine;
                    rtbMessages.Text += RmLoc.GetString("strQuestToComplete") + Environment.NewLine;
                    foreach (QuestCompletionItem qci in newLocation.QuestAvailableHere.QuestCompletionItems)
                    {
                        if (qci.Quantity == 1)
                        {
                            rtbMessages.Text += qci.Quantity.ToString() + " " + qci.Details.Name + Environment.NewLine;
                        }
                        else
                        {
                            rtbMessages.Text += qci.Quantity.ToString() + " " + qci.Details.NamePlural + Environment.NewLine;
                        }
                    }
                    rtbMessages.Text += Environment.NewLine;
                    ScrollToBottomOfMessages();
                    // Add the quest to the player's quest list
                    _player.Quests.Add(new PlayerQuest(newLocation.QuestAvailableHere));
                }
            }

            // Does the location have a monster?
            if (newLocation.MonsterLivingHere != null)
            {
                rtbMessages.Text += RmLoc.GetString("strPlayerSeeA") + newLocation.MonsterLivingHere.Name + Environment.NewLine;
                ScrollToBottomOfMessages();
                // Make a new monster, using the values from the standard monster in the World.Monster list
                Monster standardMonster = World.MonsterByID(newLocation.MonsterLivingHere.ID);

                _currentMonster = new Monster(standardMonster.ID, standardMonster.Name, standardMonster.MaximumDamage,
                    standardMonster.RewardExperiencePoints, standardMonster.RewardGold, standardMonster.CurrentHitPoints, standardMonster.MaximumHitPoints, standardMonster.IsAggro);

                foreach (LootItem lootItem in standardMonster.LootTable)
                {
                    _currentMonster.LootTable.Add(lootItem);
                }

                cboWeapons.Visible = true;
                cboPotions.Visible = true;
                btnUseWeapon.Visible = true;
                btnUsePotion.Visible = true;
            }
            else
            {
                _currentMonster = null;

                cboWeapons.Visible = false;
                cboPotions.Visible = false;
                btnUseWeapon.Visible = false;
                btnUsePotion.Visible = false;
            }


            // Refresh player's inventory list
            UpdateInventoryListInUI();

            // Refresh player's quest list
            UpdateQuestListInUI();

            // Refresh player's weapons combobox
            UpdateWeaponListInUI();

            // Refresh player's potions combobox
            UpdatePotionListInUI();
        }

        private void UpdateInventoryListInUI()
        {
            dgvInventory.RowHeadersVisible = false;

            dgvInventory.ColumnCount = 2;

            dgvInventory.Columns[0].Width = 220;

            dgvInventory.Columns[1].Width = 92;
            dgvInventory.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            
            dgvInventory.Rows.Clear();

            foreach (InventoryItem inventoryItem in _player.Inventory)
            {
                if (inventoryItem.Quantity > 0)
                {
                    dgvInventory.Rows.Add(new[] { inventoryItem.Details.Name, inventoryItem.Quantity.ToString() });
                }
            }
        }

        private void UpdateQuestListInUI()
        {
            string completed;
            dgvQuests.RowHeadersVisible = false;

            dgvQuests.ColumnCount = 2;
            dgvQuests.Columns[0].Width = 220;
            dgvQuests.Columns[1].Width = 92;

            dgvQuests.Rows.Clear();
            foreach (PlayerQuest playerQuest in _player.Quests)
            {
                if (playerQuest.IsCompleted)
                {
                    completed = RmLoc.GetString("strTrue");
                }
                else
                {
                    completed = RmLoc.GetString("strFalse");
                }
                dgvQuests.Rows.Add(new[] { playerQuest.Details.Name, completed });
            }
        }

        private void UpdateWeaponListInUI()
        {
            List<Weapon> weapons = new List<Weapon>();

            foreach (InventoryItem inventoryItem in _player.Inventory)
            {
                if (inventoryItem.Details is Weapon)
                {
                    if (inventoryItem.Quantity > 0)
                    {
                        weapons.Add((Weapon)inventoryItem.Details);
                    }
                }
            }

            if (weapons.Count == 0)
            {
                // The player doesn't have any weapons, so hide the weapon combobox and "Use" button
                cboWeapons.Visible = false;
                btnUseWeapon.Visible = false;
            }
            else
            {
                cboWeapons.DataSource = weapons;
                cboWeapons.DisplayMember = "Name";
                cboWeapons.ValueMember = "ID";

                cboWeapons.SelectedIndex = 0;
            }
        }

        private void UpdatePotionListInUI()
        {
            List<HealingPotion> healingPotions = new List<HealingPotion>();

            foreach (InventoryItem inventoryItem in _player.Inventory)
            {
                if (inventoryItem.Details is HealingPotion)
                {
                    if (inventoryItem.Quantity > 0)
                    {
                        healingPotions.Add((HealingPotion)inventoryItem.Details);
                    }
                }
            }

            if (healingPotions.Count == 0)
            {
                // The player doesn't have any potions, so hide the potion combobox and "Use" button
                cboPotions.Visible = false;
                btnUsePotion.Visible = false;
            }
            else
            {
                cboPotions.DataSource = healingPotions;
                cboPotions.DisplayMember = "Name";
                cboPotions.ValueMember = "ID";

                cboPotions.SelectedIndex = 0;
            }
        }

        private void btnUseWeapon_Click(object sender, EventArgs e)
        {
            // Get the currently selected weapon from the cboWeapons ComboBox
            Weapon currentWeapon = (Weapon)cboWeapons.SelectedItem;

            // Determine the amount of damage to do to the monster
            int damageToMonster = RandomNumberGenerator.NumberBetween(currentWeapon.MinimumDamage, currentWeapon.MaximumDamage);

            // Apply the damage to the monster's CurrentHitPoints
            _currentMonster.CurrentHitPoints -= damageToMonster;

            // Display message
            rtbMessages.Text += RmLoc.GetString("strPlayerHit") + _currentMonster.Name + RmLoc.GetString("strFor") + damageToMonster.ToString() + RmLoc.GetString("strDamagePoints") + Environment.NewLine;
            ScrollToBottomOfMessages();
            // Check if the monster is dead
            if (_currentMonster.CurrentHitPoints <= 0)
            {
                // Monster is dead
                rtbMessages.Text += Environment.NewLine;
                rtbMessages.Text += RmLoc.GetString("strPlayerDefeatedMonster") + _currentMonster.Name + Environment.NewLine;
                ScrollToBottomOfMessages();
                // Give player experience points for killing the monster
                _player.ExperiencePoints += _currentMonster.RewardExperiencePoints;
                rtbMessages.Text += RmLoc.GetString("strRewardReceive") + _currentMonster.RewardExperiencePoints.ToString() + RmLoc.GetString("strRewardExperience") + Environment.NewLine;

                // Give player gold for killing the monster 
                _player.Gold += _currentMonster.RewardGold;
                rtbMessages.Text += RmLoc.GetString("strRewardReceive") + _currentMonster.RewardGold.ToString() + RmLoc.GetString("strRewardGold") + Environment.NewLine;
                ScrollToBottomOfMessages();
                // Get random loot items from the monster
                List<InventoryItem> lootedItems = new List<InventoryItem>();

                // Add items to the lootedItems list, comparing a random number to the drop percentage
                foreach (LootItem lootItem in _currentMonster.LootTable)
                {
                    if (RandomNumberGenerator.NumberBetween(1, 100) <= lootItem.DropPercentage)
                    {
                        lootedItems.Add(new InventoryItem(lootItem.Details, 1));
                    }
                }

                // If no items were randomly selected, then add the default loot item(s).
                if (lootedItems.Count == 0)
                {
                    foreach (LootItem lootItem in _currentMonster.LootTable)
                    {
                        if (lootItem.IsDefaultItem)
                        {
                            lootedItems.Add(new InventoryItem(lootItem.Details, 1));
                        }
                    }
                }

                // Add the looted items to the player's inventory
                foreach (InventoryItem inventoryItem in lootedItems)
                {
                    _player.AddItemToInventory(inventoryItem.Details);

                    if (inventoryItem.Quantity == 1)
                    {
                        rtbMessages.Text += RmLoc.GetString("strPlayerLoot") + inventoryItem.Quantity.ToString() + " " + inventoryItem.Details.Name + Environment.NewLine;
                    }
                    else
                    {
                        rtbMessages.Text += RmLoc.GetString("strPlayerLoot") + inventoryItem.Quantity.ToString() + " " + inventoryItem.Details.NamePlural + Environment.NewLine;
                    }
                }
                ScrollToBottomOfMessages();

                // Refresh player information and inventory controls
                lblHitPoints.Text = _player.CurrentHitPoints.ToString();
                lblGold.Text = _player.Gold.ToString();
                lblExperience.Text = _player.ExperiencePoints.ToString();
                lblLevel.Text = _player.Level.ToString();
                lblExperience.Text = _player.ExperiencePoints.ToString();

                UpdateInventoryListInUI();
                UpdateWeaponListInUI();
                UpdatePotionListInUI();

                // Add a blank line to the messages box, just for appearance.
                rtbMessages.Text += Environment.NewLine;

                // Move player to current location (to heal player and create a new monster to fight)
                MoveTo(_player.CurrentLocation);
            }
            else
            {
                // Monster is still alive

                // Determine the amount of damage the monster does to the player
                int damageToPlayer = RandomNumberGenerator.NumberBetween(0, _currentMonster.MaximumDamage);

                // Display message
                rtbMessages.Text += RmLoc.GetString("strThe") + _currentMonster.Name + RmLoc.GetString("strDid") + damageToPlayer.ToString() + RmLoc.GetString("strDamagePoints") + Environment.NewLine;
                ScrollToBottomOfMessages();
                // Subtract damage from player
                _player.CurrentHitPoints -= damageToPlayer;

                // Refresh player data in UI
                lblHitPoints.Text = _player.CurrentHitPoints.ToString();

                if (_player.CurrentHitPoints <= 0)
                {
                    // Display message
                    rtbMessages.Text += RmLoc.GetString("strThe") + _currentMonster.Name + RmLoc.GetString("strKilledYou") + Environment.NewLine;
                    ScrollToBottomOfMessages();
                    // Move player to "Home"
                    MoveTo(World.LocationByID(World.LOCATION_ID_HOME));
                }
            }
        }

        private void btnUsePotion_Click(object sender, EventArgs e)
        {
            // Get the currently selected potion from the combobox
            HealingPotion potion = (HealingPotion)cboPotions.SelectedItem;

            // Add healing amount to the player's current hit points
            _player.CurrentHitPoints = (_player.CurrentHitPoints + potion.AmountToHeal);

            // CurrentHitPoints cannot exceed player's MaximumHitPoints
            if (_player.CurrentHitPoints > _player.MaximumHitPoints)
            {
                _player.CurrentHitPoints = _player.MaximumHitPoints;
            }

            // Remove the potion from the player's inventory
            foreach (InventoryItem ii in _player.Inventory)
            {
                if (ii.Details.ID == potion.ID)
                {
                    ii.Quantity--;
                    break;
                }
            }

            // Display message
            rtbMessages.Text += RmLoc.GetString("strPlayerDrink") + potion.Name + Environment.NewLine;
            ScrollToBottomOfMessages();
            // Monster gets their turn to attack

            // Determine the amount of damage the monster does to the player
            int damageToPlayer = RandomNumberGenerator.NumberBetween(0, _currentMonster.MaximumDamage);

            // Display message
            rtbMessages.Text += RmLoc.GetString("strThe") + _currentMonster.Name + RmLoc.GetString("strDid") + damageToPlayer.ToString() + RmLoc.GetString("strDamagePoints") + Environment.NewLine;
            ScrollToBottomOfMessages();
            // Subtract damage from player
            _player.CurrentHitPoints -= damageToPlayer;

            if (_player.CurrentHitPoints <= 0)
            {
                // Display message
                rtbMessages.Text += RmLoc.GetString("strThe") + _currentMonster.Name + RmLoc.GetString("strKilledYou") + Environment.NewLine;
                ScrollToBottomOfMessages();
                // Move player to "Home"
                MoveTo(World.LocationByID(World.LOCATION_ID_HOME));
            }

            // Refresh player data in UI
            lblHitPoints.Text = _player.CurrentHitPoints.ToString();
            UpdateInventoryListInUI();
            UpdatePotionListInUI();
        }

        private void ScrollToBottomOfMessages()
        {
            // Sets the cursor at the end of rich text box to avoid player scrolling
            rtbMessages.SelectionStart = rtbMessages.Text.Length;
            rtbMessages.ScrollToCaret();
        }

        private void UpdatePlayerStats()
        {
            // Refresh player information and inventory controls
            lblHitPoints.Text = _player.CurrentHitPoints.ToString();
            lblGold.Text = _player.Gold.ToString();
            lblExperience.Text = _player.ExperiencePoints.ToString();
            lblLevel.Text = _player.Level.ToString();
            txtAvailableGold.Text = _player.AvailableGold.ToString();
            
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create a new game and reset interface and properties
            rtbMessages.Clear();
            _player = Player.CreateDefaultPlayer();
            MoveTo(_player.CurrentLocation);
            UpdatePlayerStats();
        }

        private void openSavedGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadGame();
        }

        private void saveGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveGame();
        }

        private void LoadGame()
        {
            // Open a previously saved game and sets the player properties
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Application.ExecutablePath;
            openFileDialog1.Filter = "Xml Files|*.xml";
            openFileDialog1.FileName = PLAYER_DATA_FILE_NAME;

            if(openFileDialog1.ShowDialog() == DialogResult.OK)
                _player = Player.CreatePlayerFromXmlString(File.ReadAllText(openFileDialog1.FileName));
            MoveTo(_player.CurrentLocation);
            UpdatePlayerStats();
            openFileDialog1.Dispose();
        }

        private void SaveGame()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = Application.ExecutablePath;
            saveFileDialog1.Filter = "Xml Files|*.xml";
            saveFileDialog1.FileName = PLAYER_DATA_FILE_NAME;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                File.WriteAllText(saveFileDialog1.FileName, _player.ToXmlString());

            saveFileDialog1.Dispose();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {

            if (txtGoldBank.Text != "")
            {
                switch (cboBank.SelectedIndex)
                {
                    case 0:
                        if(_player.Gold < Convert.ToInt32(txtGoldBank.Text))
                        {
                            rtbMessages.Text += RmLoc.GetString("strPlayerNotEnoughGold") + Environment.NewLine;
                            txtGoldBank.Text = "";
                        }
                        else
                        {                                                       
                            _player.Gold -= Convert.ToInt32(txtGoldBank.Text);
                            _player.AvailableGold = (Convert.ToInt32(txtAvailableGold.Text) + Convert.ToInt32(txtGoldBank.Text));
                            txtAvailableGold.Text = _player.AvailableGold.ToString();                        
                            rtbMessages.Text += RmLoc.GetString("strBankDeposit") + txtGoldBank.Text.ToString() + RmLoc.GetString("strBankFrom") + Environment.NewLine;
                            txtGoldBank.Text = "";
                            UpdatePlayerStats();
                        }
                        
                        break;

                    case 1:
                        if (Convert.ToInt32(txtGoldBank.Text) > Convert.ToInt32(txtAvailableGold.Text))
                        {
                            rtbMessages.Text += RmLoc.GetString("strBankNotEnoughGold") + Environment.NewLine;
                            txtGoldBank.Text = "";
                        }
                        else
                        {
                            _player.Gold += Convert.ToInt32(txtGoldBank.Text);
                            _player.AvailableGold = (Convert.ToInt32(txtAvailableGold.Text) - Convert.ToInt32(txtGoldBank.Text));
                            txtAvailableGold.Text = _player.AvailableGold.ToString();

                            rtbMessages.Text += RmLoc.GetString("strBankWithdrawal") + txtGoldBank.Text.ToString() + RmLoc.GetString("strBankFrom") + Environment.NewLine;
                            txtGoldBank.Text = "";
                            UpdatePlayerStats();
                        }
                        break;

                    default:
                        txtGoldBank.Text = "";                      
                        break;
                }
            }
            else
            {
               rtbMessages.Text += RmLoc.GetString("strBankNoAmount") + Environment.NewLine;
            }
            ScrollToBottomOfMessages();
        }

        private void SuperAdventure_Load(object sender, EventArgs e)
        {

        }
    }
}