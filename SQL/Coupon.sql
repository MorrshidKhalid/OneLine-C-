SELECT TOP (1000) [CouponId]
      ,[Code]
      ,[DiscountAmount]
      ,[ExpirationDate]
  FROM [OneLine_Coupon].[oneline].[Coupon]


  Truncate TABLE [OneLine_Coupon].[oneline].[Coupon]

  INSERT INTO [OneLine_Coupon].[oneline].[Coupon] (Code, DiscountAmount, ExpirationDate)
  VALUES 
  ('k-inv25', 10, '2025-03-20'),
  ('k-inv26', 12, '2025-04-10'),
  ('k-inv27', 3, '2025-05-22'),
  ('k-inv28', 20, '2025-07-19');