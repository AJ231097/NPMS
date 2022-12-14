USE [NPMS.Models]
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'7436b410-79e3-4612-b23b-cf665eeb80be', N'Users', N'USERS', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'9378bff5-6cad-4992-94f3-5fd2f72ead0f', N'Admins', N'ADMINS', NULL)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'13f78f7d-9d97-4c53-b117-b132aa674df4', N'test5', N'TEST5', N'lucifermorningstar231087@gmail.com', N'LUCIFERMORNINGSTAR231087@GMAIL.COM', 1, N'AQAAAAEAAnEAAAAAEEZWSJNfRFea2K7SMyvrSqY3As/ycN4TSnMg6S/crAYsyfAmN8IZ7PHEgMxlLV5hFA==', N'IOZLVAH6AGNKLQQN4OW6G3TEWSHGWD33', N'ccb5d2d6-b7bf-4df3-877e-779d59236419', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'3869bd34-1f21-4420-94f2-13cbfceb3ae7', N'test', N'TEST', N'test@gmail.com', N'TEST@GMAIL.COM', 1, N'AQAAAAEAAnEAAAAAEPBDXYgDKnQkYvLCE5uwk6ZFPtuEjgTBZ7eXvKwT3qNJzh7DcmMJL9GdWX9df79XSA==', N'ZPLHV36IGNCUYJUJNFRHBNQPUJJ3QAVP', N'5f807505-795c-4621-b694-38896be439b1', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'7b95719d-fc21-43e8-b110-7fae9b10d352', N'test1', N'TEST1', N'test1@gmail.com', N'TEST1@GMAIL.COM', 1, N'AQAAAAEAAnEAAAAAECxbpon00vOzWcGYllo265MtPLWAiZzGzsWVCYc+hKUkjstbvu/cad/Bs0SlBicUcA==', N'L2OJSIG2NVCCX3LNXA33EJ4TWXQVDFZ5', N'f4c193dc-e25f-41e8-a3cc-8e7171b44711', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3869bd34-1f21-4420-94f2-13cbfceb3ae7', N'9378bff5-6cad-4992-94f3-5fd2f72ead0f')
GO
INSERT [dbo].[Carts] ([OrderId], [TotalAmount], [UserId]) VALUES (N'72de281e-dd1a-486d-b221-0481153f78d0', CAST(90.00 AS Decimal(18, 2)), N'7b95719d-fc21-43e8-b110-7fae9b10d352')
INSERT [dbo].[Carts] ([OrderId], [TotalAmount], [UserId]) VALUES (N'5a16cdb6-2870-4638-b532-3ae12df4d461', CAST(80.00 AS Decimal(18, 2)), N'7b95719d-fc21-43e8-b110-7fae9b10d352')
INSERT [dbo].[Carts] ([OrderId], [TotalAmount], [UserId]) VALUES (N'b2c9a35a-7690-4359-a701-5fcc23a54d3b', CAST(90.00 AS Decimal(18, 2)), N'7b95719d-fc21-43e8-b110-7fae9b10d352')
INSERT [dbo].[Carts] ([OrderId], [TotalAmount], [UserId]) VALUES (N'e03980d1-8a29-42cb-bb5e-600cb20397dc', CAST(80.00 AS Decimal(18, 2)), N'7b95719d-fc21-43e8-b110-7fae9b10d352')
INSERT [dbo].[Carts] ([OrderId], [TotalAmount], [UserId]) VALUES (N'94744c8e-666f-478f-96e2-a44e51117819', CAST(105.00 AS Decimal(18, 2)), N'7b95719d-fc21-43e8-b110-7fae9b10d352')
INSERT [dbo].[Carts] ([OrderId], [TotalAmount], [UserId]) VALUES (N'cd504b38-d974-4a1c-8d48-c38e4e07264b', CAST(160.00 AS Decimal(18, 2)), N'7b95719d-fc21-43e8-b110-7fae9b10d352')
GO
INSERT [dbo].[Careers] ([CareerId], [CareerName], [CareerDescription], [CareerRecruiter], [CareerPlace]) VALUES (N'8e13098a-672f-453a-9b80-00142f8b6b7b', N'Rock Climbing Instructor', N'As a rock climbing instructor, your job duties include preparing the rope for the climb, giving safety demonstrations, and leading the climb up the rock wall. You need strong physical skills and experience climbing a variety of rocks and pitches.', N'maine@nps.gov', N'Acadia National Park, Maine')
INSERT [dbo].[Careers] ([CareerId], [CareerName], [CareerDescription], [CareerRecruiter], [CareerPlace]) VALUES (N'1cf4150a-b5f2-4fad-846d-fd4c5679f790', N'Biological Science Technician', N'Collects data on condition of forage, range, or streams; and makes preliminary determinations on the cause of problems noted, e.g., drought, overpopulations, toxins. Seeks assistance for situations not covered by instructions or guidelines. Assists in the preparation of reports, plans, and guidelines on such issues as seasons of recreational use or hunting limits by collecting and compiling the specified data.Enters and retrieves data from Geographic Information System (GIS) and/or other information management systems', N'cape_hatteras@nps.gov', N'Buxton, North Carolina ')
GO
SET IDENTITY_INSERT [dbo].[Events] ON 

INSERT [dbo].[Events] ([EventId], [EventName], [EventDescription]) VALUES (1, N'Rock Climbing', N'Rock climbing is an activity in which participants climb up, down or across natural rock formations or artificial rock walls. The goal is to reach the summit of a formation or the endpoint of a pre-defined route without falling. Rock climbing is a physically and mentally demanding sport, one that often tests a climber’s strength, endurance, agility and balance along with mental control. It can be a dangerous sport and knowledge of proper climbing techniques and usage of specialized climbing equipment is crucial for the safe completion of routes. Because of the wide range and variety of rock formations around the world, rock climbing has been separated into several different styles and sub-disciplines.')
INSERT [dbo].[Events] ([EventId], [EventName], [EventDescription]) VALUES (2, N'Rafting', N'Rafting and whitewater rafting are recreational outdoor activities which use an inflatable raft to navigate a river or other body of water. This is often done on whitewater or different degrees of rough water. Dealing with risk is often a part of the experience.')
SET IDENTITY_INSERT [dbo].[Events] OFF
GO
SET IDENTITY_INSERT [dbo].[Parks] ON 

INSERT [dbo].[Parks] ([ParkId], [ParkName], [ParkDescription], [ParkImageUrl]) VALUES (1, N'Acadia National Park', N'Acadia National Park located in Maine protects the natural beauty of the highest rocky headlands along the Atlantic coastline of the United States, an abundance of habitats, and a rich cultural heritage. At 4 million visits a year, it''s one of the top 10 most-visited national parks in the United States. Visitors enjoy 27 miles of historic motor roads, 158 miles of hiking trails, and 45 miles of carriage roads.', N'/images/acadia.jpg')
INSERT [dbo].[Parks] ([ParkId], [ParkName], [ParkDescription], [ParkImageUrl]) VALUES (2, N'Appalachian', N'The Appalachian Trail is a 2,180+ mile long public footpath that traverses the scenic, wooded, pastoral, wild, and culturally resonant lands of the Appalachian Mountains. Conceived in 1921, built by private citizens, and completed in 1937, today the trail is managed by the National Park Service, US Forest Service, Appalachian Trail Conservancy, numerous state agencies and thousands of volunteers.', N'/images/appalachian.jpg')
INSERT [dbo].[Parks] ([ParkId], [ParkName], [ParkDescription], [ParkImageUrl]) VALUES (3, N'Shenandoah National Park', N'Shenandoah National Park extends along the Blue Ridge Mountains in the U.S. state of Virginia. The Skyline Drive runs its length, and a vast network of trails includes a section of the long-distance Appalachian Trail. Mostly forested, the park features wetlands, waterfalls and rocky peaks like Hawksbill and Old Rag mountains.', N'/images/shenandoah.jpg')
SET IDENTITY_INSERT [dbo].[Parks] OFF
GO
SET IDENTITY_INSERT [dbo].[Passes] ON 

INSERT [dbo].[Passes] ([Id], [PassName], [PassPrice]) VALUES (1, N'Military', 80)
INSERT [dbo].[Passes] ([Id], [PassName], [PassPrice]) VALUES (2, N'Annual', 90)
INSERT [dbo].[Passes] ([Id], [PassName], [PassPrice]) VALUES (3, N'Group', 50)
INSERT [dbo].[Passes] ([Id], [PassName], [PassPrice]) VALUES (5, N'Parking', 20)
INSERT [dbo].[Passes] ([Id], [PassName], [PassPrice]) VALUES (6, N'Individual', 20)
INSERT [dbo].[Passes] ([Id], [PassName], [PassPrice]) VALUES (7, N'Festival ', 34)
SET IDENTITY_INSERT [dbo].[Passes] OFF
GO
INSERT [dbo].[Reservations] ([Rid], [ReservationName], [TypeOfEvent], [ContactNumber], [ReservationEmail], [ReservationDate], [ParkName]) VALUES (N'dfdc633b-c276-4622-937e-5ccbeb6601c1', N'User1', N'Anniversary', N'2408176541', N'test4@gmail.com', CAST(N'2022-11-26T00:00:00.0000000' AS DateTime2), N'Shenandoah National Park')
GO
