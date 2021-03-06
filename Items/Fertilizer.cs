using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LovelyMod.Items
{
	public class Fertilizer : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Important for healthy saplings.");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 22;
			item.maxStack = 99;
			item.rare = 1;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.UseSound = SoundID.Item81;
			item.consumable = true;
		}

		public override bool CanUseItem(Player player)
		{
			return TileLoader.IsSapling(Main.tile[Player.tileTargetX, Player.tileTargetY].type);
		}

		// Note that this item does not work in Multiplayer, but serves as a learning tool for other things.
		public override bool UseItem(Player player)
		{
			if (WorldGen.GrowTree(Player.tileTargetX, Player.tileTargetY))
			{
				WorldGen.TreeGrowFXCheck(Player.tileTargetX, Player.tileTargetY);
			}
			else
			{
				item.stack++;
			}
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 1);
			recipe.SetResult(this, 50);
			recipe.AddRecipe();
		}
	}
}