IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240613072104_DbInitial'
)
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240613072104_DbInitial'
)
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240613072104_DbInitial'
)
BEGIN
    CREATE TABLE [GameVersion] (
        [GameVersionId] int NOT NULL IDENTITY,
        [GameVersionName] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_GameVersion] PRIMARY KEY ([GameVersionId])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240613072104_DbInitial'
)
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240613072104_DbInitial'
)
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240613072104_DbInitial'
)
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(128) NOT NULL,
        [ProviderKey] nvarchar(128) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240613072104_DbInitial'
)
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240613072104_DbInitial'
)
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(128) NOT NULL,
        [Name] nvarchar(128) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240613072104_DbInitial'
)
BEGIN
    CREATE TABLE [Characters] (
        [CharacterId] int NOT NULL IDENTITY,
        [GameVersionId] int NOT NULL,
        [CharacterName] nvarchar(max) NOT NULL,
        [AcquiredBy] nvarchar(max) NULL,
        [AcquiredFrom] nvarchar(max) NULL,
        [Notes] nvarchar(max) NULL,
        [CharacterImage] varbinary(max) NULL,
        [isUnlocked] bit NULL,
        [CharacterLevel] int NULL,
        [AssignedSkill] nvarchar(max) NULL,
        [FavoriteThing1] nvarchar(max) NULL,
        [FavoriteThing2] nvarchar(max) NULL,
        [FavoriteThing3] nvarchar(max) NULL,
        CONSTRAINT [PK_Characters] PRIMARY KEY ([CharacterId]),
        CONSTRAINT [FK_Characters_GameVersion_GameVersionId] FOREIGN KEY ([GameVersionId]) REFERENCES [GameVersion] ([GameVersionId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240613072104_DbInitial'
)
BEGIN
    CREATE TABLE [Fish] (
        [FishId] int NOT NULL IDENTITY,
        [GameVersionId] int NOT NULL,
        [FishName] nvarchar(max) NOT NULL,
        [FishImage] varbinary(max) NULL,
        [RippleColor] nvarchar(max) NULL,
        [SellsFor] int NULL,
        [Energy] int NULL,
        [Notes] nvarchar(max) NULL,
        CONSTRAINT [PK_Fish] PRIMARY KEY ([FishId]),
        CONSTRAINT [FK_Fish_GameVersion_GameVersionId] FOREIGN KEY ([GameVersionId]) REFERENCES [GameVersion] ([GameVersionId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240613072104_DbInitial'
)
BEGIN
    CREATE TABLE [Ingredient] (
        [IngredientId] int NOT NULL IDENTITY,
        [GameVersionId] int NOT NULL,
        [IngredientName] nvarchar(max) NOT NULL,
        [IngredientCategory] nvarchar(max) NULL,
        [BuyPrice] int NULL,
        [SellsFor] int NULL,
        [Energy] int NULL,
        [GrowTime] nvarchar(max) NULL,
        [Water] int NULL,
        [Yield] int NULL,
        [LocationId] int NULL,
        [Method] nvarchar(max) NULL,
        [Notes] nvarchar(max) NULL,
        CONSTRAINT [PK_Ingredient] PRIMARY KEY ([IngredientId]),
        CONSTRAINT [FK_Ingredient_GameVersion_GameVersionId] FOREIGN KEY ([GameVersionId]) REFERENCES [GameVersion] ([GameVersionId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240613072104_DbInitial'
)
BEGIN
    CREATE TABLE [Locations] (
        [LocationId] int NOT NULL IDENTITY,
        [GameVersionId] int NOT NULL,
        [LocationName] nvarchar(max) NOT NULL,
        [Cost] nvarchar(max) NULL,
        CONSTRAINT [PK_Locations] PRIMARY KEY ([LocationId]),
        CONSTRAINT [FK_Locations_GameVersion_GameVersionId] FOREIGN KEY ([GameVersionId]) REFERENCES [GameVersion] ([GameVersionId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240613072104_DbInitial'
)
BEGIN
    CREATE TABLE [FishLocations] (
        [FishLocationId] int NOT NULL IDENTITY,
        [FishId] int NOT NULL,
        [LocationId] int NOT NULL,
        CONSTRAINT [PK_FishLocations] PRIMARY KEY ([FishLocationId]),
        CONSTRAINT [FK_FishLocations_Fish_FishId] FOREIGN KEY ([FishId]) REFERENCES [Fish] ([FishId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_FishLocations_Locations_LocationId] FOREIGN KEY ([LocationId]) REFERENCES [Locations] ([LocationId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240613072104_DbInitial'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'GameVersionId', N'GameVersionName') AND [object_id] = OBJECT_ID(N'[GameVersion]'))
        SET IDENTITY_INSERT [GameVersion] ON;
    EXEC(N'INSERT INTO [GameVersion] ([GameVersionId], [GameVersionName])
    VALUES (1, N''Base Game''),
    (2, N''A Rift In Time'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'GameVersionId', N'GameVersionName') AND [object_id] = OBJECT_ID(N'[GameVersion]'))
        SET IDENTITY_INSERT [GameVersion] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240613072104_DbInitial'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CharacterId', N'AcquiredBy', N'AcquiredFrom', N'AssignedSkill', N'CharacterImage', N'CharacterLevel', N'CharacterName', N'FavoriteThing1', N'FavoriteThing2', N'FavoriteThing3', N'GameVersionId', N'Notes', N'isUnlocked') AND [object_id] = OBJECT_ID(N'[Characters]'))
        SET IDENTITY_INSERT [Characters] ON;
    EXEC(N'INSERT INTO [Characters] ([CharacterId], [AcquiredBy], [AcquiredFrom], [AssignedSkill], [CharacterImage], [CharacterLevel], [CharacterName], [FavoriteThing1], [FavoriteThing2], [FavoriteThing3], [GameVersionId], [Notes], [isUnlocked])
    VALUES (1, N''Realm'', N''Frozen Realm'', NULL, NULL, NULL, N''Anna'', NULL, NULL, NULL, 1, N''Unlock Realm'', NULL),
    (2, N''Quest'', N''Goofy'', NULL, NULL, NULL, N''Ariel'', NULL, NULL, NULL, 1, N''The Mysterious Wreck'', NULL),
    (3, N''Realm'', N''Beauty and the Beast Realm'', NULL, NULL, NULL, N''Belle'', NULL, NULL, NULL, 1, N''Unlock Realm'', NULL),
    (4, N''Realm'', N''Toy Story Realm'', NULL, NULL, NULL, N''Buzz Lightyear'', NULL, NULL, NULL, 1, N''Unlock Realm'', NULL),
    (5, N''Quest'', N''Mickey Mouse'', NULL, NULL, NULL, N''Daisy'', NULL, NULL, NULL, 1, N''You Have Mail!'', NULL),
    (6, N''Quest'', N''Kristoff'', NULL, NULL, NULL, N''Donald Duck'', NULL, NULL, NULL, 1, N''Story - Lost in the Dark Grove'', NULL),
    (7, N''Realm'', N''Frozen Realm'', NULL, NULL, NULL, N''Elsa'', NULL, NULL, NULL, 1, N''Complete initial realm  quest'', NULL),
    (8, N''Quest'', N''Peaceful Meadow'', NULL, NULL, NULL, N''Goofy'', NULL, NULL, NULL, 1, N''The Royal Tools'', NULL),
    (9, N''Quest'', N''ForgottenLands'', NULL, NULL, NULL, N''Jack Skellington'', NULL, NULL, NULL, 1, N''After Fairy Godmother''''s Fire Alarm quest, search for Matryoshka Dolls to trigger quest.'', NULL),
    (10, N''Quest'', N''Forest of Valor'', NULL, NULL, NULL, N''Kristoff'', NULL, NULL, NULL, 1, N''Unlock Biome'', NULL),
    (11, N''Realm'', N''Moana Realm'', NULL, NULL, NULL, N''Maui'', NULL, NULL, NULL, 1, N''Complete initial realm  quest'', NULL),
    (12, NULL, N''The Plaza'', NULL, NULL, NULL, N''Merlin'', NULL, NULL, NULL, 1, N''Unlock Realm'', NULL),
    (13, NULL, N''The Plaza'', NULL, NULL, NULL, N''Mickey Mouse'', NULL, NULL, NULL, 1, N''Unlock Realm'', NULL),
    (14, N''Realm'', N''Monsters Inc. Realm	'', NULL, NULL, NULL, N''Mike Wazowski'', NULL, NULL, NULL, 1, N''Complete initial realm  quest'', NULL),
    (15, N''Quest'', N''Mickey Mouse'', NULL, NULL, NULL, N''Minnie Mouse'', NULL, NULL, NULL, 1, N''Memory Magnification'', NULL),
    (16, N''Quest'', N''Merlin'', NULL, NULL, NULL, N''Mirabel'', NULL, NULL, NULL, 1, N''The Golden Dorknob'', NULL),
    (17, N''Realm'', N''Moana Realm'', NULL, NULL, NULL, N''Moana'', NULL, NULL, NULL, 1, N''Unlock Realm'', NULL),
    (18, N''Quest'', N''Glade of Trust'', NULL, NULL, NULL, N''Mother Gothel'', NULL, NULL, NULL, 1, N''Story - The Curse'', NULL),
    (19, N''Realm'', N''The Lion King Realm'', NULL, NULL, NULL, N''Nala'', NULL, NULL, NULL, 1, N''Unlock Realm'', NULL),
    (20, N''Quest'', N''Frosted Heights'', NULL, NULL, NULL, N''Olaf'', NULL, NULL, NULL, 1, N''Story - The Great Blizzard'', NULL),
    (21, N''Quest	'', N''Ursala'', NULL, NULL, NULL, N''Prince Eric'', NULL, NULL, NULL, 1, N''After Ariel and Ursala reach level 10'', NULL),
    (22, N''Realm'', N''Ratatouille Realm'', NULL, NULL, NULL, N''Remy'', NULL, NULL, NULL, 1, N''Unlock Realm'', NULL),
    (23, N''Quest'', N''Sunlit Plateau'', NULL, NULL, NULL, N''Scar'', NULL, NULL, NULL, 1, N''After The Curse in completed.'', NULL),
    (24, NULL, N''The Plaza'', NULL, NULL, NULL, N''Scrooge McDuck'', NULL, NULL, NULL, 1, N''Unlock Realm'', NULL),
    (25, N''Realm'', N''The Lion King Realm'', NULL, NULL, NULL, N''Simba'', NULL, NULL, NULL, 1, N''Complete initial realm  quest'', NULL),
    (26, N''Quest'', N''Donald Duck'', NULL, NULL, NULL, N''Stitch'', NULL, NULL, NULL, 1, N''The Mystery of the Stolen Socks'', NULL),
    (27, N''Realm'', N''Monsters Inc. Realm'', NULL, NULL, NULL, N''Sulley'', NULL, NULL, NULL, 1, N''Unlock Realm'', NULL),
    (28, N''Realm'', N''Beauty and the Beast Realm'', NULL, NULL, NULL, N''The Beast'', NULL, NULL, NULL, 1, N''Complete initial realm  quest'', NULL),
    (29, N''Quest	'', N''	ForgottenLands'', NULL, NULL, NULL, N''The Fairy Godmother'', NULL, NULL, NULL, 1, N'' After repairing the 6 Pillars'', NULL),
    (30, N''Quest'', N''Dazzle Beach'', NULL, NULL, NULL, N''Ursula'', NULL, NULL, NULL, 1, N''Story - With Great Power'', NULL),
    (31, N''Quest'', N''Scrooge'', NULL, NULL, NULL, N''Vanellope'', NULL, NULL, NULL, 1, N'' The Haunting of Dreamlight Valley'', NULL),
    (32, N''Realm'', N''WALL-E Realm'', NULL, NULL, NULL, N''WALL-E'', NULL, NULL, NULL, 1, N''Unlock Realm'', NULL),
    (33, N''Realm'', N''Toy Story Realm'', NULL, NULL, NULL, N''Woody'', NULL, NULL, NULL, 1, N''Complete initial realm  quest'', NULL),
    (34, N''Quest'', N''Ancient''''s Landing'', NULL, NULL, NULL, N''EVE'', NULL, NULL, NULL, 2, N''After receiving pickaxe upgrade	'', NULL),
    (35, N''Quest'', N''Glittering Dunes'', NULL, NULL, NULL, N''Gaston'', NULL, NULL, NULL, 2, N''Unlock Biome'', NULL),
    (36, N''Quest'', N''Ancient''''s Landing'', NULL, NULL, NULL, N''Oswald'', NULL, NULL, NULL, 2, N'' The Spark of Imagination.'', NULL),
    (37, N''Quest'', N''Wild Tangle'', NULL, NULL, NULL, N''Rapunzel'', NULL, NULL, NULL, 2, N''Unlock Biome'', NULL)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CharacterId', N'AcquiredBy', N'AcquiredFrom', N'AssignedSkill', N'CharacterImage', N'CharacterLevel', N'CharacterName', N'FavoriteThing1', N'FavoriteThing2', N'FavoriteThing3', N'GameVersionId', N'Notes', N'isUnlocked') AND [object_id] = OBJECT_ID(N'[Characters]'))
        SET IDENTITY_INSERT [Characters] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240613072104_DbInitial'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'FishId', N'Energy', N'FishImage', N'FishName', N'GameVersionId', N'Notes', N'RippleColor', N'SellsFor') AND [object_id] = OBJECT_ID(N'[Fish]'))
        SET IDENTITY_INSERT [Fish] ON;
    EXEC(N'INSERT INTO [Fish] ([FishId], [Energy], [FishImage], [FishName], [GameVersionId], [Notes], [RippleColor], [SellsFor])
    VALUES (1, 2000, NULL, N''Anglerfish'', 1, NULL, N''Orange'', 1500),
    (2, 150, NULL, N''Bass'', 1, N''Could be outside of Ripples'', N''White'', 25),
    (3, 1300, NULL, N''Bream'', 1, NULL, N''Blue'', 280),
    (4, 800, NULL, N''Carp'', 1, N''Can be White'', N''Blue'', 400),
    (5, 1200, NULL, N''Catfish'', 1, NULL, N''Orange'', 550),
    (6, 150, NULL, N''Cod'', 1, N''Could be outside of Ripples'', N''White'', 35),
    (7, 1550, NULL, N''Crab'', 1, N''Can be White'', N''Blue'', 600),
    (8, 1700, NULL, N''Fugu'', 1, N''Requires rain'', N''Orange'', 900),
    (9, 1000, NULL, N''Here and There Fish'', 1, N''Also outside of Ripples. Requires morning (6-10am) or evening (6-10pm) after completing Menu Icon Quests.png Here and There and Back Again'', N''	White'', 2000),
    (10, 250, NULL, N''Herring'', 1, NULL, N''White'', 65),
    (11, 800, NULL, N''Kingfish'', 1, N''Requires night (6pm-5am)'', N''Blue'', 450),
    (12, 1300, NULL, N''Lancetfish'', 1, NULL, N''Blue'', 650),
    (13, 1600, NULL, N''Lobster'', 1, NULL, N''Orange'', 950),
    (14, 400, NULL, N''Perch'', 1, N''Can be White'', N''Blue'', 80),
    (15, 1500, NULL, N''Pike'', 1, NULL, N''Orange'', 800),
    (16, 300, NULL, N''Rainbow Trout'', 1, NULL, N''White'', 50),
    (17, 500, NULL, N''Salmon'', 1, N''Can be blue'', N''White'', 150),
    (18, 25, NULL, N''Seaweed'', 1, NULL, NULL, 20),
    (19, 750, NULL, N''Shrimp'', 1, N''Can be White'', N''Blue'', 300),
    (20, 500, NULL, N''Sole'', 1, N''Can be blue'', N''White'', 200),
    (21, 1000, NULL, N''Squid'', 1, N''Can be White'', N''Blue'', 500),
    (22, 1500, NULL, N''Swordfish'', 1, NULL, N''Orange'', 700),
    (23, 1150, NULL, N''Tilapia'', 1, NULL, N''Blue'', 600),
    (24, 350, NULL, N''Tuna'', 1, N''Can be blue'', N''White'', 95),
    (25, 1700, NULL, N''Walleye'', 1, NULL, N''Orange'', 1100),
    (26, 1800, NULL, N''White Sturgeon'', 1, NULL, N''Orange'', 1250),
    (27, 1650, NULL, N''Brilliant Blue Starfish'', 2, NULL, N''Orange'', 875),
    (28, 1100, NULL, N''Dunebopper'', 2, NULL, N''Blue'', 550),
    (29, 1200, NULL, N''Electric Eel'', 2, NULL, N''Orange'', 1025),
    (30, 700, NULL, N''Octopus'', 2, N''Can be White'', N''Blue'', 290),
    (31, 1900, NULL, N''Piranha'', 2, NULL, N''Orange'', 1300),
    (32, 1250, NULL, N''Pirarucu'', 2, NULL, N''Blue'', 625),
    (33, 1500, NULL, N''Pretty Pink Starfish'', 2, NULL, N''Orange'', 875),
    (34, 1600, NULL, N''Prisma Shrimp'', 2, NULL, N''Orange'', 1100),
    (35, 1350, NULL, N''Robot Fish'', 2, NULL, N''Orange'', 625),
    (36, 150, NULL, N''Sand Fish'', 2, N''Could be outside of Ripples'', N''White'', 30),
    (37, 1650, NULL, N''Sand Worm'', 2, NULL, N''Orange'', 800),
    (38, 900, NULL, N''Scorpion'', 2, NULL, N''Blue'', 425),
    (39, 800, NULL, N''Sea Snail'', 2, N''Can be White'', N''Blue'', 250),
    (40, 300, NULL, N''Shad'', 2, NULL, N''White'', 60),
    (41, 500, NULL, N''Skeleton Fish'', 2, N''Can be blue'', N''White'', 100)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'FishId', N'Energy', N'FishImage', N'FishName', N'GameVersionId', N'Notes', N'RippleColor', N'SellsFor') AND [object_id] = OBJECT_ID(N'[Fish]'))
        SET IDENTITY_INSERT [Fish] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240613072104_DbInitial'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IngredientId', N'BuyPrice', N'Energy', N'GameVersionId', N'GrowTime', N'IngredientCategory', N'IngredientName', N'LocationId', N'Method', N'Notes', N'SellsFor', N'Water', N'Yield') AND [object_id] = OBJECT_ID(N'[Ingredient]'))
        SET IDENTITY_INSERT [Ingredient] ON;
    EXEC(N'INSERT INTO [Ingredient] ([IngredientId], [BuyPrice], [Energy], [GameVersionId], [GrowTime], [IngredientCategory], [IngredientName], [LocationId], [Method], [Notes], [SellsFor], [Water], [Yield])
    VALUES (1, 50, 300, 1, N''20 m'', N''Fruit'', N''Apple'', 1, N''Gardening'', NULL, 25, NULL, 3),
    (2, 200, 42, 1, N''2 h 15 m'', N''Vegetables'', N''Asparagus'', 7, N''Gardening'', NULL, 133, 2, 3),
    (3, 58, 350, 1, N''23 m'', N''Fruit'', N''Banana'', 3, N''Gardening'', NULL, 29, NULL, 3),
    (4, NULL, 100, 1, NULL, N''Spices'', N''Basil'', 2, N''Foraging'', NULL, 50, NULL, NULL),
    (5, 50, 79, 1, N''15 m'', N''Vegetables'', N''Bell Pepper'', 4, N''Gardening'', NULL, 33, 1, 1),
    (6, 58, 350, 1, N''23 m'', N''Fruit'', N''Blueberry'', 4, N''Gardening'', NULL, 29, NULL, 3),
    (7, 190, 285, 1, NULL, N''Dairy and Oil'', N''Butter'', 32, N''Purchase'', N''After A Restaurant Makeover'', 190, NULL, NULL),
    (8, 164, 59, 1, N''35 m'', N''Dairy and Oil'', N''Canola'', 4, N''Gardening'', NULL, 109, 3, 1),
    (9, 66, 57, 1, N''15 m'', N''Vegetables'', N''Carrot'', 2, N''Gardening'', NULL, 44, 1, 1),
    (10, 180, 270, 1, NULL, N''Dairy and Oil'', N''Cheese'', 32, N''Purchase'', N''After A Restaurant Makeover'', 180, NULL, NULL),
    (11, 83, 500, 1, N''33 m'', N''Fruit'', N''Cherry'', 7, N''Gardening'', NULL, 42, NULL, 3),
    (12, 117, 140, 1, N''45 m'', N''Vegetables'', N''Chili Pepper'', 6, N''Gardening'', NULL, 78, 1, 1),
    (13, NULL, 120, 1, NULL, N''Seafood'', N''Clam'', 3, N''Foraging'', NULL, 50, NULL, NULL),
    (14, 75, 450, 1, N''30 m'', N''Sweetener'', N''Cocoa Bean'', 5, N''Gardening'', NULL, 38, NULL, 3),
    (15, NULL, 500, 1, N''23 m'', N''Fruit'', N''Coconut'', 3, N''Foraging'', N''After Burying the Eel'', 42, NULL, 3),
    (16, NULL, 425, 1, N''40 m'', N''Fruit'', N''Coffee Bean'', 5, N''Foraging'', N''After Very Sleepy Stitch'', 36, NULL, 3),
    (17, 24, 30, 1, N''12 m'', N''Vegetables'', N''Corn'', 3, N''Gardening'', NULL, 16, 1, 2),
    (18, 239, 145, 1, N''1 h 15 m'', N''Vegetables'', N''Cucumber'', 7, N''Gardening'', NULL, 159, 1, 1),
    (19, NULL, 500, 1, N''1 d'', N''Fruit'', N''Dreamlight Fruit'', 6, N''Foraging'', N''After The Dreamlight Grove'', 40, NULL, 3),
    (20, 220, 330, 1, NULL, N''Dairy and Oil'', N''Egg'', 32, N''Purchase'', N''After A Restaurant Makeover'', 220, NULL, NULL),
    (21, 462, 451, 1, N''3 h'', N''Vegetables'', N''Eggplant'', 7, N''Gardening'', NULL, 308, 2, 1),
    (22, NULL, 135, 1, NULL, N''Spices'', N''Garlic'', 4, N''Foraging'', NULL, 50, NULL, NULL),
    (23, NULL, 175, 1, NULL, N''Spices'', N''Ginger'', 8, N''Foraging'', NULL, 50, NULL, NULL),
    (24, 100, 600, 1, N''40 m'', N''Fruit'', N''Gooseberry'', 7, N''Gardening'', NULL, 50, NULL, 3),
    (25, 464, 228, 1, N''2 h'', N''Vegetables'', N''Leek'', 8, N''Gardening'', NULL, 309, 2, 1),
    (26, 67, 400, 1, N''27 m'', N''Fruit'', N''Lemon'', 5, N''Gardening'', NULL, 33, NULL, 3),
    (27, 12, 56, 1, N''3 m'', N''Vegetables'', N''Lettuce'', 2, N''Gardening'', NULL, 8, 1, 1),
    (28, 230, 345, 1, NULL, N''Dairy and Oil'', N''Milk'', 32, N''Purchase'', N''After A Restaurant Makeover'', 230, NULL, NULL),
    (29, NULL, 155, 1, NULL, N''Spices'', N''Mint'', 7, N''Foraging'', NULL, 50, NULL, NULL),
    (30, NULL, 105, 1, NULL, N''Vegetables'', N''Mushroom'', 5, N''Foraging'', NULL, 30, NULL, NULL),
    (31, 171, 31, 1, N''2 h'', N''Vegetables'', N''Okra'', 5, N''Gardening'', NULL, 114, 1, 3),
    (32, 255, 146, 1, N''1 h 15 m'', N''Vegetables'', N''Onion'', 4, N''Gardening'', NULL, 170, 2, 1),
    (33, NULL, 95, 1, NULL, N''Spices'', N''Oregano'', 1, N''Foraging'', NULL, 50, NULL, NULL),
    (34, NULL, 250, 1, NULL, N''Seafood'', N''Oyster'', 3, N''Foraging'', NULL, 50, NULL, NULL),
    (35, 200, 300, 1, NULL, N''Dairy and Oil'', N''Peanut'', 32, N''Purchase'', N''After Remy''''s Recipe Book'', 200, NULL, NULL),
    (36, 189, 113, 1, N''35 m'', N''Vegetables'', N''Potato'', 8, N''Gardening'', NULL, 126, 3, 1),
    (37, 996, 187, 1, N''4 h'', N''Vegetables'', N''Pumpkin'', 8, N''Gardening'', NULL, 664, 2, 1),
    (38, NULL, 275, 1, N''17 m'', N''Fruit'', N''Raspberry'', 2, N''Gardening'', NULL, 21, NULL, 3),
    (39, 92, 59, 1, N''50 m'', N''Grains'', N''Rice'', 5, N''Gardening'', NULL, 61, 2, 2),
    (40, NULL, 125, 1, NULL, N''Seafood'', N''Scallop'', 3, N''Foraging'', NULL, 50, NULL, NULL),
    (41, 150, 225, 1, NULL, N''Ice'', N''Slush Ice'', 32, N''Purchase'', N''After The Unknown Flavor'', 150, NULL, NULL),
    (42, 104, 58, 1, N''1 h 30 m'', N''Dairy and Oil'', N''Soya'', 6, N''Gardening'', NULL, 69, 2, 3);
    INSERT INTO [Ingredient] ([IngredientId], [BuyPrice], [Energy], [GameVersionId], [GrowTime], [IngredientCategory], [IngredientName], [LocationId], [Method], [Notes], [SellsFor], [Water], [Yield])
    VALUES (43, 62, 60, 1, N''1 h'', N''Vegetables'', N''Spinach'', 5, N''Gardening'', NULL, 41, 2, 3),
    (44, 29, 46, 1, N''7 m'', N''Sweetener'', N''Sugarcane'', 3, N''Gardening'', NULL, 19, 1, 1),
    (45, 33, 21, 1, N''25 m'', N''Vegetables'', N''Tomato'', 3, N''Gardening'', NULL, 22, 2, 3),
    (46, NULL, 135, 1, NULL, N''Sweetener'', N''Vanilla'', 6, N''Foraging'', NULL, 50, NULL, NULL),
    (47, 3, 19, 1, N''1 m'', N''Grains'', N''Wheat'', 2, N''Gardening'', NULL, 2, 1, 2),
    (48, 78, 48, 1, N''40 m'', N''Vegetables'', N''Zucchini'', 6, N''Gardening'', NULL, 52, 2, 2),
    (49, NULL, 100, 2, NULL, N''Sweetener'', N''Agave'', 10, N''Foraging'', NULL, 25, NULL, NULL),
    (50, NULL, 500, 2, N''50 m'', N''Fruit'', N''Almonds'', 11, N''Foraging'', NULL, 42, NULL, 2),
    (51, NULL, 155, 2, NULL, N''Vegetables'', N''Bamboo'', 11, N''Foraging'', NULL, 80, NULL, NULL),
    (52, NULL, 41, 2, N''1 h'', N''Vegetables'', N''Beans'', 10, N''Gardening'', NULL, 49, NULL, 3),
    (53, NULL, 73, 2, N''40 m'', N''Vegetables'', N''Broccoli'', 10, N''Gardening'', NULL, 152, NULL, 1),
    (54, NULL, 142, 2, N''1 h'', N''Vegetables'', N''Cabbage'', 11, N''Gardening'', NULL, 256, NULL, 1),
    (55, NULL, 400, 2, N''45 m'', N''Fruit'', N''Cactoberries'', 10, N''Foraging'', NULL, 34, NULL, 2),
    (56, NULL, 60, 2, N''10 m'', N''Vegetables'', N''Celery'', 9, N''Gardening'', NULL, 65, NULL, 1),
    (57, NULL, 155, 2, NULL, N''Spices'', N''Cinnamon'', 11, N''Foraging'', NULL, 30, NULL, NULL),
    (58, NULL, 52, 2, N''25 m'', N''Fruit'', N''Cosmic Figs'', 9, N''Gardening'', NULL, 22, NULL, 2),
    (59, NULL, 90, 2, NULL, N''Spices'', N''Cumin'', 9, N''Foraging'', NULL, 15, NULL, NULL),
    (60, NULL, 350, 2, N''55 m'', N''Fruit'', N''Dates'', 10, N''Foraging'', NULL, 29, NULL, 3),
    (61, NULL, 600, 2, N''1 h'', N''Fruit'', N''Dreamango'', 11, N''Foraging'', NULL, 50, NULL, 2),
    (62, NULL, 46, 2, N''10 m'', N''Vegetables'', N''Flute Root'', 9, N''Gardening'', NULL, 112, NULL, 2),
    (63, NULL, 21, 2, N''20 m'', N''Fruit'', N''Grapes'', 9, N''Gardening'', NULL, 9, NULL, 3),
    (64, NULL, 105, 2, NULL, N''Spices'', N''Majestea'', 9, N''Foraging'', NULL, 30, NULL, NULL),
    (65, NULL, 88, 2, N''30 m'', N''Fruit'', N''Melon'', 10, N''Gardening'', NULL, 93, NULL, 1),
    (66, NULL, 300, 2, N''35 m'', N''Fruit'', N''Nestling Pear'', 9, N''Foraging'', NULL, 25, NULL, 2),
    (67, NULL, 125, 2, NULL, N''Spices'', N''Paprika'', 10, N''Foraging'', NULL, 50, NULL, NULL),
    (68, NULL, 168, 2, N''3 h'', N''Fruit'', N''Pineapple'', 11, N''Gardening'', NULL, 532, NULL, 1),
    (69, 250, 250, 2, NULL, N''Protein'', N''Pork'', 10, N''Purchase'', NULL, 250, NULL, NULL),
    (70, 500, 250, 2, NULL, N''Protein'', N''Poultry'', 10, N''Purchase'', NULL, 500, NULL, NULL),
    (71, NULL, 37, 2, N''2 h'', N''Vegetables'', N''Ruby Lentils'', 11, N''Gardening'', NULL, 156, NULL, 3),
    (72, NULL, 275, 2, N''30 m'', N''Fruit'', N''Strawberry'', 9, N''Foraging'', NULL, 23, NULL, 2),
    (73, NULL, 263, 2, N''4 h'', N''Vegetables'', N''Turnip'', 11, N''Gardening'', NULL, 187, NULL, 2),
    (74, 1000, 250, 2, NULL, N''Protein'', N''Venison'', 10, N''Purchase'', NULL, 500, NULL, NULL),
    (75, NULL, 83, 2, N''4 h'', N''Vegetables'', N''Yam'', 9, N''Gardening'', NULL, 36, NULL, 1)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IngredientId', N'BuyPrice', N'Energy', N'GameVersionId', N'GrowTime', N'IngredientCategory', N'IngredientName', N'LocationId', N'Method', N'Notes', N'SellsFor', N'Water', N'Yield') AND [object_id] = OBJECT_ID(N'[Ingredient]'))
        SET IDENTITY_INSERT [Ingredient] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240613072104_DbInitial'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'LocationId', N'Cost', N'GameVersionId', N'LocationName') AND [object_id] = OBJECT_ID(N'[Locations]'))
        SET IDENTITY_INSERT [Locations] ON;
    EXEC(N'INSERT INTO [Locations] ([LocationId], [Cost], [GameVersionId], [LocationName])
    VALUES (1, NULL, 1, N''Plaza''),
    (2, NULL, 1, N''Peaceful Meadow''),
    (3, N''1000 Dreamlight'', 1, N''Dazzle Beach''),
    (4, N''3000 Dreamlight'', 1, N''Forest of Valor''),
    (5, N''5000 Dreamlight'', 1, N''Glade of Trust''),
    (6, N''7000 Dreamlight'', 1, N''Sunlit Plateau''),
    (7, N''10000 Dreamlight'', 1, N''Frosted Heights''),
    (8, N''15000 Dreamlight'', 1, N''Forgotten Lands''),
    (9, NULL, 2, N''Ancient''''s Landing''),
    (10, NULL, 2, N''Glittering Dunes''),
    (11, NULL, 2, N''Wild Tangle''),
    (12, NULL, 2, N''The Docks''),
    (13, N''6000 Mist'', 2, N''The Overlook''),
    (14, N''10000 Mist'', 2, N''The Ruins''),
    (15, NULL, 2, N''The Courtyard''),
    (16, NULL, 2, N''The Plains''),
    (17, N''4000 Mist'', 2, N''The Wastes''),
    (18, N''6000 Mist'', 2, N''The Oasis''),
    (19, N''10000 Mist'', 2, N''The Borderlands''),
    (20, N''2000 Mist'', 2, N''The Grasslands''),
    (21, N''4000 Mist'', 2, N''The Grove''),
    (22, N''6000 Mist'', 2, N''The Promenade''),
    (23, N''10000 Mist'', 2, N''The Lagoon''),
    (24, N''12500 Dreamlight'', 1, N''Beauty and the Beast Realm''),
    (25, N''4000 Dreamlight'', 1, N''Frozen Realm''),
    (26, N''3000 Dreamlight'', 1, N''Moana Realm''),
    (27, N''15000 Dreamlight'', 1, N''Monsters, Inc. Realm''),
    (28, N''3000 Dreamlight'', 1, N''Ratatouille Realm''),
    (29, N''10000 Dreamlight'', 1, N''The Lion King Realm''),
    (30, N''7000 Dreamlight'', 1, N''Toy Story Realm''),
    (31, N''3000 Dreamlight'', 1, N''WALL-E Realm''),
    (32, NULL, 1, N''Chez Remy'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'LocationId', N'Cost', N'GameVersionId', N'LocationName') AND [object_id] = OBJECT_ID(N'[Locations]'))
        SET IDENTITY_INSERT [Locations] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240613072104_DbInitial'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'FishLocationId', N'FishId', N'LocationId') AND [object_id] = OBJECT_ID(N'[FishLocations]'))
        SET IDENTITY_INSERT [FishLocations] ON;
    EXEC(N'INSERT INTO [FishLocations] ([FishLocationId], [FishId], [LocationId])
    VALUES (1, 1, 8),
    (2, 2, 4),
    (3, 2, 7),
    (4, 2, 2),
    (5, 2, 6),
    (6, 2, 17),
    (7, 2, 18),
    (8, 3, 2),
    (9, 27, 18),
    (10, 4, 4),
    (11, 4, 6),
    (12, 5, 2),
    (13, 6, 3),
    (14, 6, 8),
    (15, 6, 5),
    (16, 6, 12),
    (17, 6, 13),
    (18, 7, 7),
    (19, 28, 18),
    (20, 29, 20),
    (21, 29, 22),
    (22, 8, 3),
    (23, 9, 3),
    (24, 9, 4),
    (25, 9, 8),
    (26, 9, 7),
    (27, 9, 5),
    (28, 9, 2),
    (29, 9, 6),
    (30, 10, 3),
    (31, 10, 5),
    (32, 11, 3),
    (33, 12, 8),
    (34, 13, 5),
    (35, 30, 12),
    (36, 30, 13),
    (37, 14, 4),
    (38, 14, 6),
    (39, 14, 21),
    (40, 14, 23),
    (41, 15, 4),
    (42, 31, 23);
    INSERT INTO [FishLocations] ([FishLocationId], [FishId], [LocationId])
    VALUES (43, 31, 20),
    (44, 31, 21),
    (45, 31, 23),
    (46, 31, 22),
    (47, 33, 18),
    (48, 34, 21),
    (49, 16, 4),
    (50, 16, 2),
    (51, 35, 12),
    (52, 35, 13),
    (53, 17, 7),
    (54, 17, 6),
    (55, 17, 20),
    (56, 17, 22),
    (57, 36, 19),
    (58, 36, 16),
    (59, 36, 17),
    (60, 37, 19),
    (61, 37, 16),
    (62, 37, 17),
    (63, 38, 19),
    (64, 38, 16),
    (65, 38, 17),
    (66, 39, 12),
    (67, 39, 13),
    (68, 40, 12),
    (69, 40, 13),
    (70, 19, 3),
    (71, 41, 19),
    (72, 41, 16),
    (73, 41, 17),
    (74, 20, 8),
    (75, 20, 12),
    (76, 20, 13),
    (77, 21, 8),
    (78, 21, 5),
    (79, 22, 3),
    (80, 23, 7),
    (81, 23, 6),
    (82, 24, 8),
    (83, 24, 5),
    (84, 25, 6);
    INSERT INTO [FishLocations] ([FishLocationId], [FishId], [LocationId])
    VALUES (85, 26, 7)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'FishLocationId', N'FishId', N'LocationId') AND [object_id] = OBJECT_ID(N'[FishLocations]'))
        SET IDENTITY_INSERT [FishLocations] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240613072104_DbInitial'
)
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240613072104_DbInitial'
)
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240613072104_DbInitial'
)
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240613072104_DbInitial'
)
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240613072104_DbInitial'
)
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240613072104_DbInitial'
)
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240613072104_DbInitial'
)
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240613072104_DbInitial'
)
BEGIN
    CREATE INDEX [IX_Characters_GameVersionId] ON [Characters] ([GameVersionId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240613072104_DbInitial'
)
BEGIN
    CREATE INDEX [IX_Fish_GameVersionId] ON [Fish] ([GameVersionId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240613072104_DbInitial'
)
BEGIN
    CREATE INDEX [IX_FishLocations_FishId] ON [FishLocations] ([FishId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240613072104_DbInitial'
)
BEGIN
    CREATE INDEX [IX_FishLocations_LocationId] ON [FishLocations] ([LocationId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240613072104_DbInitial'
)
BEGIN
    CREATE INDEX [IX_Ingredient_GameVersionId] ON [Ingredient] ([GameVersionId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240613072104_DbInitial'
)
BEGIN
    CREATE INDEX [IX_Locations_GameVersionId] ON [Locations] ([GameVersionId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240613072104_DbInitial'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240613072104_DbInitial', N'8.0.6');
END;
GO

COMMIT;
GO

