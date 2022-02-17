DELETE FROM dbo.[Feeds]
WHERE Feeds.Id NOT IN (SELECT FeedId FROM dbo.[Diets])