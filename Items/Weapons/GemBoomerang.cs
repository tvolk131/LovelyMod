using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LovelyMod.Items.Weapons
{
  public class GemBoomerang : ModItem
  {
    public override void SetDefaults()
    {
      item.damage = 30;
      item.melee = true;
      item.width = 30;
      item.height = 30;
      item.useTime = 25;
      item.useAnimation = 25;
      item.noUseGraphic = true;
      item.useStyle = 1;
      item.knockBack = 3;
      item.value = 8;
      item.rare = 6;
      item.shootSpeed = 12f;
      item.shoot = mod.ProjectileType ("GemBoomerang");
      item.UseSound = SoundID.Item1;
      item.autoReuse = true;
    }
    //Prevents more than one boomerang projectile from existing at once
    public override bool CanUseItem(Player player)
    {
      for (int i = 0; i < 1000; ++i)
      {
        if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == item.shoot)
        {
          return false;
        }
      }
      return true;
    }
    public override void AddRecipes()
    {
      ModRecipe recipe = new ModRecipe(mod);
      recipe.AddIngredient(ItemID.DirtBlock, 1);
      recipe.SetResult(this);
      recipe.AddRecipe();
    }
  }
}
