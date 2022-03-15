/****** Script for SelectTopNRows command from SSMS  ******/
DELETE from FacebookDbs;

Declare @DateStart	Date = '2022-03-28'
		,@DateEnd	Date = '2022-02-01'

Declare @x int;
Declare @RandDate Date;

SET @x = 1;

While @x <= 250
BEGIN
	SET @RandDate = DateAdd(Day, Rand() * DateDiff(Day, @DateStart, @DateEnd), @DateStart)
	INSERT INTO FacebookDbs (Id,DatePosted,content,likes,retweets,comments) VALUES (NEWID(),@RandDate,'RLCS',FLOOR(RAND()*(1000-5+1)+5),FLOOR(RAND()*(1000-5+1)+5),FLOOR(RAND()*(1000-5+1)+5))
	SET @x = @x +1;
END

SET @x = 1;

While @x <= 250
BEGIN
	SET @RandDate = DateAdd(Day, Rand() * DateDiff(Day, @DateStart, @DateEnd), @DateStart)
	INSERT INTO FacebookDbs (Id,DatePosted,content,likes,retweets,comments) VALUES (NEWID(),@RandDate,'test',FLOOR(RAND()*(1000-5+1)+5),FLOOR(RAND()*(1000-5+1)+5),FLOOR(RAND()*(1000-5+1)+5))
	SET @x = @x +1;
END
SELECT TOP (1000) [Id]
      ,[DatePosted]
      ,[content]
      ,[likes]
      ,[retweets]
      ,[comments]
  FROM [SocialMediaAnalytics].[dbo].[FacebookDbs]



  /****** Script for SelectTopNRows command from SSMS  ******/
DELETE from LinkedInDbs;

SET @x = 1;

While @x <= 150
BEGIN
	SET @RandDate = DateAdd(Day, Rand() * DateDiff(Day, @DateStart, @DateEnd), @DateStart)
	INSERT INTO LinkedInDbs (Id,DatePosted,content,likes,retweets,comments) VALUES (NEWID(),@RandDate,'RLCS',FLOOR(RAND()*(1000-5+1)+5),FLOOR(RAND()*(1000-5+1)+5),FLOOR(RAND()*(1000-5+1)+5))
	SET @x = @x +1;
END

SET @x = 1;

While @x <= 150
BEGIN
	SET @RandDate = DateAdd(Day, Rand() * DateDiff(Day, @DateStart, @DateEnd), @DateStart)
	INSERT INTO LinkedInDbs (Id,DatePosted,content,likes,retweets,comments) VALUES (NEWID(),@RandDate,'test',FLOOR(RAND()*(1000-5+1)+5),FLOOR(RAND()*(1000-5+1)+5),FLOOR(RAND()*(1000-5+1)+5))
	SET @x = @x +1;
END
SELECT TOP (1000) [Id]
      ,[DatePosted]
      ,[content]
      ,[likes]
      ,[retweets]
      ,[comments]
  FROM [SocialMediaAnalytics].[dbo].[LinkedInDbs]