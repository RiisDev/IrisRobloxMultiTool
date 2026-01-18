
// ReSharper disable InconsistentNaming
namespace IrisRobloxMultiTool.Classes
{
	public class Account
	{
		public string Cookie { get; set; } = string.Empty;
		public string Name { get; set; } = Environment.UserName;
		public string Id { get; set; } = string.Empty;
		public string ProfilePicture { get; set; } = string.Empty;
		public string ProfileUrl { get; set; } = string.Empty;
		public bool IsVerified { get; set; }
		public string RobuxCount { get; set; } = "-1";
		public string CsrfToken { get; set; } = string.Empty;
	}

	public class RobloxApi
    {
	    public bool SkippedSignIn { get; set; }
		public Account Account = new();

		public async Task<string> RefreshCsrfToken()
		{
			if (Account.Cookie.IsNullOrEmpty())
				throw new InvalidOperationException("Cookie not set in account data");

			if (SkippedSignIn)
				throw new InvalidOperationException("Cannot get new Csrf token without signin");

			RobloxContainer.Add(new Uri("https://auth.roblox.com"), new Cookie(".ROBLOSECURITY", Account.Cookie, "/", "auth.roblox.com"));
			RobloxContainer.Add(new Uri("https://roblox.com"), new Cookie(".ROBLOSECURITY", Account.Cookie, "/", "roblox.com"));

			using HttpRequestMessage request = new (HttpMethod.Post, "https://auth.roblox.com/v2/logout");
			using HttpResponseMessage response = await RobloxClient.SendAsync(request);

			bool foundHeader = response.Headers.TryGetValues("x-csrf-token", out IEnumerable<string>? headers);

			if (!foundHeader || headers is null)
				throw new InvalidOperationException("Failed to refresh CSRF token");

			Account.CsrfToken = headers.First();
			
			return Account.CsrfToken;
		}

		public async Task SetupAccountData()
		{
			if (Account.Cookie.IsNullOrEmpty())
				throw new InvalidOperationException("Cookie not set in account data");

			if (SkippedSignIn)
				throw new InvalidOperationException("Cannot setup account data without signin");

			RobloxContainer.Add(new Uri("https://auth.roblox.com"), new Cookie(".ROBLOSECURITY", Account.Cookie, "/", "auth.roblox.com"));
			RobloxContainer.Add(new Uri("https://roblox.com"), new Cookie(".ROBLOSECURITY", Account.Cookie, "/", "roblox.com"));
			
			HttpResponseMessage response = await RobloxClient.GetAsync("https://www.roblox.com/my/account/json");
			response.EnsureSuccessStatusCode();

			string content = await response.Content.ReadAsStringAsync();

			JsonDocument document = JsonDocument.Parse(content);
			JsonElement root = document.RootElement;

			Account.Name = root.GetProperty("DisplayName").GetString() ?? string.Empty;
			Account.Id = root.GetProperty("UserId").GetInt32().ToString();
			Account.IsVerified = root.GetProperty("IsEmailVerified").GetBoolean();
			Account.ProfileUrl = $"https://www.roblox.com/users/{Account.Id}/profile";

			response.Dispose();

			response = await RobloxClient.GetAsync($"https://thumbnails.roblox.com/v1/users/avatar-headshot?userIds={Account.Id}&size=150x150&format=Png&isCircular=true");
			response.EnsureSuccessStatusCode();

			content = await response.Content.ReadAsStringAsync();
			document = JsonDocument.Parse(content);
			root = document.RootElement;

			Account.ProfilePicture = root.GetProperty("data")[0].GetProperty("imageUrl").GetString() ?? string.Empty;

			response.Dispose();

			response = await RobloxClient.GetAsync($"https://economy.roblox.com/v1/users/{Account.Id}/currency");
			response.EnsureSuccessStatusCode();

			content = await response.Content.ReadAsStringAsync();
			document = JsonDocument.Parse(content);
			root = document.RootElement;

			Account.RobuxCount = root.GetProperty("robux").GetInt32().ToString();

			await RefreshCsrfToken();
		}

		public enum CatalogCategory
		{
			All = 1,
			Clothing = 3,
			Accessories = 11,
			AvatarAnimations = 12,
			Body = 18
		}

		public static readonly Dictionary<int, CatalogCategory> CatalogCategoryById = new()
		{
			{ 1, CatalogCategory.All },
			{ 3, CatalogCategory.Clothing },
			{ 11, CatalogCategory.Accessories },
			{ 12, CatalogCategory.AvatarAnimations },
			{ 18, CatalogCategory.Body }
		};
    
		public enum CatalogSubcategory
		{
			Featured = 0,
			All = 1,
			Collectibles = 2,
			Clothing = 3,
			BodyParts = 4,
			Gear = 5,
			Models = 6,
			Plugins = 7,
			Decals = 8,
			Hats = 9,
			Faces = 10,
			Packages = 11,
			Shirts = 12,
			Tshirts = 13,
			Pants = 14,
			Heads = 15,
			Audio = 16,
			RobloxCreated = 17,
			Meshes = 18,
			Accessories = 19,

			HairAccessories = 20,
			FaceAccessories = 21,
			NeckAccessories = 22,
			ShoulderAccessories = 23,
			FrontAccessories = 24,
			BackAccessories = 25,
			WaistAccessories = 26,

			AvatarAnimations = 27,
			ClimbAnimations = 28,
			FallAnimations = 30,
			IdleAnimations = 31,
			JumpAnimations = 32,
			RunAnimations = 33,
			SwimAnimations = 34,
			WalkAnimations = 35,

			AnimationPackage = 36,
			BodyPartsBundles = 37,
			AnimationBundles = 38,
			EmoteAnimations = 39,

			CommunityCreations = 40,
			Video = 41,

			Recommended = 51,
			LayeredClothing = 52,
			AllBundles = 53,

			HeadAccessories = 54,
			ClassicTShirts = 55,
			ClassicShirts = 56,
			ClassicPants = 57,

			TShirtAccessories = 58,
			ShirtAccessories = 59,
			PantsAccessories = 60,
			JacketAccessories = 61,
			SweaterAccessories = 62,
			ShortsAccessories = 63,
			ShoesBundles = 64,
			DressSkirtAccessories = 65,
			DynamicHeads = 66
		}

		public static readonly Dictionary<int, CatalogSubcategory> CatalogSubcategoryById = new ()
		{
			{ 0, CatalogSubcategory.Featured },
			{ 1, CatalogSubcategory.All },
			{ 2, CatalogSubcategory.Collectibles },
			{ 3, CatalogSubcategory.Clothing },
			{ 4, CatalogSubcategory.BodyParts },
			{ 5, CatalogSubcategory.Gear },
			{ 6, CatalogSubcategory.Models },
			{ 7, CatalogSubcategory.Plugins },
			{ 8, CatalogSubcategory.Decals },
			{ 9, CatalogSubcategory.Hats },
			{ 10, CatalogSubcategory.Faces },
			{ 11, CatalogSubcategory.Packages },
			{ 12, CatalogSubcategory.Shirts },
			{ 13, CatalogSubcategory.Tshirts },
			{ 14, CatalogSubcategory.Pants },
			{ 15, CatalogSubcategory.Heads },
			{ 16, CatalogSubcategory.Audio },
			{ 17, CatalogSubcategory.RobloxCreated },
			{ 18, CatalogSubcategory.Meshes },
			{ 19, CatalogSubcategory.Accessories },
			{ 20, CatalogSubcategory.HairAccessories },
			{ 21, CatalogSubcategory.FaceAccessories },
			{ 22, CatalogSubcategory.NeckAccessories },
			{ 23, CatalogSubcategory.ShoulderAccessories },
			{ 24, CatalogSubcategory.FrontAccessories },
			{ 25, CatalogSubcategory.BackAccessories },
			{ 26, CatalogSubcategory.WaistAccessories },
			{ 27, CatalogSubcategory.AvatarAnimations },
			{ 28, CatalogSubcategory.ClimbAnimations },
			{ 30, CatalogSubcategory.FallAnimations },
			{ 31, CatalogSubcategory.IdleAnimations },
			{ 32, CatalogSubcategory.JumpAnimations },
			{ 33, CatalogSubcategory.RunAnimations },
			{ 34, CatalogSubcategory.SwimAnimations },
			{ 35, CatalogSubcategory.WalkAnimations },
			{ 36, CatalogSubcategory.AnimationPackage },
			{ 37, CatalogSubcategory.BodyPartsBundles },
			{ 38, CatalogSubcategory.AnimationBundles },
			{ 39, CatalogSubcategory.EmoteAnimations },
			{ 40, CatalogSubcategory.CommunityCreations },
			{ 41, CatalogSubcategory.Video },
			{ 51, CatalogSubcategory.Recommended },
			{ 52, CatalogSubcategory.LayeredClothing },
			{ 53, CatalogSubcategory.AllBundles },
			{ 54, CatalogSubcategory.HeadAccessories },
			{ 55, CatalogSubcategory.ClassicTShirts },
			{ 56, CatalogSubcategory.ClassicShirts },
			{ 57, CatalogSubcategory.ClassicPants },
			{ 58, CatalogSubcategory.TShirtAccessories },
			{ 59, CatalogSubcategory.ShirtAccessories },
			{ 60, CatalogSubcategory.PantsAccessories },
			{ 61, CatalogSubcategory.JacketAccessories },
			{ 62, CatalogSubcategory.SweaterAccessories },
			{ 63, CatalogSubcategory.ShortsAccessories },
			{ 64, CatalogSubcategory.ShoesBundles },
			{ 65, CatalogSubcategory.DressSkirtAccessories },
			{ 66, CatalogSubcategory.DynamicHeads }
		};

		public enum AssetType
		{
			TShirt = 2,
			Shirt = 11,
			Pants = 12,

			Head = 17,
			Face = 18,

			Gear = 19,

			HeadAccessory = 8,
			HairAccessory = 41,
			FaceAccessory = 42,
			NeckAccessory = 43,
			ShoulderAccessory = 44,
			FrontAccessory = 45,
			BackAccessory = 46,
			WaistAccessory = 47,

			EmoteAnimation = 61,

			LayeredTShirt = 64,
			LayeredShirt = 65,
			LayeredPants = 66,
			Jacket = 67,
			Sweater = 68,
			Shorts = 69,
			DressSkirt = 72
		}

		public static readonly Dictionary<int, AssetType> AssetTypeById = new ()
		{
			{ 2, AssetType.TShirt },
			{ 11, AssetType.Shirt },
			{ 12, AssetType.Pants },
			{ 17, AssetType.Head },
			{ 18, AssetType.Face },
			{ 19, AssetType.Gear },
			{ 8, AssetType.HeadAccessory },
			{ 41, AssetType.HairAccessory },
			{ 42, AssetType.FaceAccessory },
			{ 43, AssetType.NeckAccessory },
			{ 44, AssetType.ShoulderAccessory },
			{ 45, AssetType.FrontAccessory },
			{ 46, AssetType.BackAccessory },
			{ 47, AssetType.WaistAccessory },
			{ 61, AssetType.EmoteAnimation },
			{ 64, AssetType.LayeredTShirt },
			{ 65, AssetType.LayeredShirt },
			{ 66, AssetType.LayeredPants },
			{ 67, AssetType.Jacket },
			{ 68, AssetType.Sweater },
			{ 69, AssetType.Shorts },
			{ 72, AssetType.DressSkirt }
		};

		public static readonly Dictionary<AssetType, CatalogCategory> AssetToCategory = new()
		{
			{ AssetType.HeadAccessory, CatalogCategory.Accessories },
			{ AssetType.HairAccessory, CatalogCategory.Body },
			{ AssetType.FaceAccessory, CatalogCategory.Accessories },
			{ AssetType.NeckAccessory, CatalogCategory.Accessories },
			{ AssetType.ShoulderAccessory, CatalogCategory.Accessories },
			{ AssetType.FrontAccessory, CatalogCategory.Accessories },
			{ AssetType.BackAccessory, CatalogCategory.Accessories },
			{ AssetType.WaistAccessory, CatalogCategory.Accessories },
			{ AssetType.Gear, CatalogCategory.Accessories },

			{ AssetType.EmoteAnimation, CatalogCategory.AvatarAnimations },

			{ AssetType.Face, CatalogCategory.Body },
			{ AssetType.Head, CatalogCategory.Body },

			{ AssetType.TShirt, CatalogCategory.Clothing },
			{ AssetType.Shirt, CatalogCategory.Clothing },
			{ AssetType.Pants, CatalogCategory.Clothing },
			{ AssetType.LayeredTShirt, CatalogCategory.Clothing },
			{ AssetType.LayeredShirt, CatalogCategory.Clothing },
			{ AssetType.LayeredPants, CatalogCategory.Clothing },
			{ AssetType.Jacket, CatalogCategory.Clothing },
			{ AssetType.Sweater, CatalogCategory.Clothing },
			{ AssetType.Shorts, CatalogCategory.Clothing },
			{ AssetType.DressSkirt, CatalogCategory.Clothing }
		};

		public static readonly Dictionary<AssetType, CatalogSubcategory> AssetToSubcategory = new()
		{
			{ AssetType.HeadAccessory, CatalogSubcategory.HeadAccessories },
			{ AssetType.HairAccessory, CatalogSubcategory.HairAccessories },
			{ AssetType.FaceAccessory, CatalogSubcategory.FaceAccessories },
			{ AssetType.NeckAccessory, CatalogSubcategory.NeckAccessories },
			{ AssetType.ShoulderAccessory, CatalogSubcategory.ShoulderAccessories },
			{ AssetType.FrontAccessory, CatalogSubcategory.FrontAccessories },
			{ AssetType.BackAccessory, CatalogSubcategory.BackAccessories },
			{ AssetType.WaistAccessory, CatalogSubcategory.WaistAccessories },
			{ AssetType.Gear, CatalogSubcategory.Gear },

			{ AssetType.EmoteAnimation, CatalogSubcategory.EmoteAnimations },

			{ AssetType.Face, CatalogSubcategory.Faces },
			{ AssetType.Head, CatalogSubcategory.Heads },

			{ AssetType.TShirt, CatalogSubcategory.ClassicTShirts },
			{ AssetType.Shirt, CatalogSubcategory.ClassicShirts },
			{ AssetType.Pants, CatalogSubcategory.ClassicPants },

			{ AssetType.LayeredTShirt, CatalogSubcategory.TShirtAccessories },
			{ AssetType.LayeredShirt, CatalogSubcategory.ShirtAccessories },
			{ AssetType.LayeredPants, CatalogSubcategory.PantsAccessories },
			{ AssetType.Jacket, CatalogSubcategory.JacketAccessories },
			{ AssetType.Sweater, CatalogSubcategory.SweaterAccessories },
			{ AssetType.Shorts, CatalogSubcategory.ShortsAccessories },
			{ AssetType.DressSkirt, CatalogSubcategory.DressSkirtAccessories }
		};

		public static readonly Dictionary<CatalogCategory, string> CategoryNames = new()
		{
			{ CatalogCategory.All, "All Items" },
			{ CatalogCategory.Body, "Body" },
			{ CatalogCategory.Clothing, "Clothing" },
			{ CatalogCategory.Accessories, "Accessories" },
			{ CatalogCategory.AvatarAnimations, "Animations" }
		};

		public static readonly Dictionary<CatalogSubcategory, string> SubcategoryNames = new()
		{
			{ CatalogSubcategory.HeadAccessories, "Head" },
			{ CatalogSubcategory.HairAccessories, "Hair" },
			{ CatalogSubcategory.FaceAccessories, "Face" },
			{ CatalogSubcategory.NeckAccessories, "Neck" },
			{ CatalogSubcategory.ShoulderAccessories, "Shoulder" },
			{ CatalogSubcategory.FrontAccessories, "Front" },
			{ CatalogSubcategory.BackAccessories, "Back" },
			{ CatalogSubcategory.WaistAccessories, "Waist" },

			{ CatalogSubcategory.ClassicTShirts, "Classic T-Shirts" },
			{ CatalogSubcategory.ClassicShirts, "Classic Shirts" },
			{ CatalogSubcategory.ClassicPants, "Classic Pants" },

			{ CatalogSubcategory.TShirtAccessories, "T-Shirts" },
			{ CatalogSubcategory.ShirtAccessories, "Shirts" },
			{ CatalogSubcategory.PantsAccessories, "Pants" },
			{ CatalogSubcategory.JacketAccessories, "Jackets" },
			{ CatalogSubcategory.SweaterAccessories, "Sweaters" },
			{ CatalogSubcategory.ShortsAccessories, "Shorts" },
			{ CatalogSubcategory.DressSkirtAccessories, "Dresses & Skirts" },

			{ CatalogSubcategory.ShoesBundles, "Shoes" },
			{ CatalogSubcategory.DynamicHeads, "Heads" },
			{ CatalogSubcategory.EmoteAnimations, "Emotes" }
		};

		public static readonly Dictionary<string, CatalogCategory> CategoryNamesReversed = new()
		{
			{ "All Items", CatalogCategory.All },
			{ "Body", CatalogCategory.Body },
			{ "Clothing", CatalogCategory.Clothing },
			{ "Accessories", CatalogCategory.Accessories },
			{ "Animations", CatalogCategory.AvatarAnimations }
		};

		public static readonly Dictionary<string, CatalogSubcategory> SubcategoryNamesReversed = new()
		{
			{ "Head", CatalogSubcategory.HeadAccessories },
			{ "Hair", CatalogSubcategory.HairAccessories },
			{ "Face", CatalogSubcategory.FaceAccessories },
			{ "Neck", CatalogSubcategory.NeckAccessories },
			{ "Shoulder", CatalogSubcategory.ShoulderAccessories },
			{ "Front", CatalogSubcategory.FrontAccessories },
			{ "Back", CatalogSubcategory.BackAccessories },
			{ "Waist", CatalogSubcategory.WaistAccessories },

			{ "Classic T-Shirts", CatalogSubcategory.ClassicTShirts },
			{ "Classic Shirts", CatalogSubcategory.ClassicShirts },
			{ "Classic Pants", CatalogSubcategory.ClassicPants },

			{ "T-Shirts", CatalogSubcategory.TShirtAccessories },
			{ "Shirts", CatalogSubcategory.ShirtAccessories },
			{ "Pants", CatalogSubcategory.PantsAccessories },
			{ "Jackets", CatalogSubcategory.JacketAccessories },
			{ "Sweaters", CatalogSubcategory.SweaterAccessories },
			{ "Shorts", CatalogSubcategory.ShortsAccessories },
			{ "Dresses & Skirts", CatalogSubcategory.DressSkirtAccessories },

			{ "Shoes", CatalogSubcategory.ShoesBundles },
			{ "Heads", CatalogSubcategory.DynamicHeads },
			{ "Emotes", CatalogSubcategory.EmoteAnimations }
		};

		public enum CatalogType
		{
			Bundle,
			Asset
		}
	}
}
